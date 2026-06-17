using System.Net;
using System.Net.Sockets;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Text.Json;
using WordChain.Common;

namespace WordChain.Server
{
    class Program
    {
        static ConcurrentDictionary<string, (TcpClient tcp, PlayerInfo info, StreamWriter writer)> _clients = new();
        static ConcurrentDictionary<string, RoomInfo> _rooms = new();
        static ConcurrentDictionary<string, string> _clientRooms = new();
        static ConcurrentDictionary<string, string> _roomPasswords = new();
        static ConcurrentDictionary<string, RoomGameState> _gameStates = new();
        static readonly VietnameseDictionaryService _dictionary = new();
        static readonly Random _random = new();

        sealed class RoomGameState
        {
            public string CurrentWord { get; set; } = "";
            public string CurrentTurnPlayerId { get; set; } = "";
            public int TurnIndex { get; set; }
            public HashSet<string> UsedWords { get; } = new(StringComparer.OrdinalIgnoreCase);
            public List<string> ActivePlayerIds { get; set; } = [];
            public int TurnSeconds { get; set; } = 20;
        }

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== GAME NỐI TỪ - SERVER ===");

            var listener = new TcpListener(IPAddress.Any, 8888);
            listener.Start();
            Console.WriteLine("✅ Server đang chạy trên cổng 8888. Chờ Client kết nối...");

            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                _ = Task.Run(() => HandleClient(client));
            }
        }

        static async Task HandleClient(TcpClient client)
        {
            var stream = client.GetStream();
            var reader = new StreamReader(stream, Encoding.UTF8);
            var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
            string clientId = Guid.NewGuid().ToString();

            try
            {
                while (true)
                {
                    string? line = await reader.ReadLineAsync();
                    if (line == null) break;

                    var packet = Packet.FromJson(line);
                    if (packet == null) continue;

                    Console.WriteLine($"[{clientId}] {packet.Type}: {packet.Payload}");

                    switch (packet.Type)
                    {
                        case PacketType.Connect:
                            var player = new PlayerInfo { Id = clientId, Nickname = packet.Payload };
                            _clients[clientId] = (client, player, writer);
                            await writer.WriteLineAsync(new Packet { Type = PacketType.ConnectOK, Payload = "Kết nối thành công!" }.ToJson());
                            await BroadcastRoomList();
                            break;
                        case PacketType.CreateRoom:
                            await HandleCreateRoom(clientId, packet.Payload, writer);
                            break;
                        case PacketType.JoinRoom:
                            await HandleJoinRoom(clientId, packet.Payload, writer);
                            break;
                        case PacketType.QuickJoin:
                            await HandleQuickJoin(clientId, writer);
                            break;
                        case PacketType.LeaveRoom:
                            await HandleLeaveRoom(clientId);
                            break;
                        case PacketType.StartGame:
                            await HandleStartGame(clientId, writer);
                            break;
                        case PacketType.SubmitWord:
                            await XuLyTraLoi(clientId, packet.Payload.Trim(), writer, hetGio: false);
                            break;
                        case PacketType.TurnTimeout:
                            await XuLyTraLoi(clientId, "", writer, hetGio: true);
                            break;
                        case PacketType.Chat:
                            await HandleChat(clientId, packet.Payload);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Client [{clientId}] lỗi: {ex.Message}");
            }
            finally
            {
                await HandleLeaveRoom(clientId);
                _clients.TryRemove(clientId, out _);
                client.Close();
            }
        }

        static string GenerateRoomCode()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            return new string(Enumerable.Range(0, 4).Select(_ => chars[_random.Next(chars.Length)]).ToArray());
        }

        static CreateRoomRequest? ParseCreateRoom(string payload)
        {
            if (string.IsNullOrWhiteSpace(payload)) return null;
            try { return JsonSerializer.Deserialize<CreateRoomRequest>(payload); }
            catch { return null; }
        }

        static JoinRoomRequest ParseJoinRoom(string payload)
        {
            if (string.IsNullOrWhiteSpace(payload))
                return new JoinRoomRequest();

            try
            {
                var req = JsonSerializer.Deserialize<JoinRoomRequest>(payload);
                if (req is not null && !string.IsNullOrWhiteSpace(req.RoomId))
                    return req;
            }
            catch { /* mã thuần 4 ký tự */ }

            return new JoinRoomRequest { RoomId = payload.Trim().ToUpperInvariant() };
        }

        static async Task HandleCreateRoom(string clientId, string payload, StreamWriter writer)
        {
            if (!_clients.ContainsKey(clientId)) return;
            if (_clientRooms.ContainsKey(clientId))
                await RemoveClientFromRoom(clientId);

            CreateRoomRequest? req = ParseCreateRoom(payload);
            string roomCode;
            do { roomCode = GenerateRoomCode(); } while (_rooms.ContainsKey(roomCode));

            var player = _clients[clientId].info;
            int turnSeconds = Math.Clamp(req?.TurnSeconds ?? 20, 10, 60);

            var room = new RoomInfo
            {
                RoomId = roomCode,
                HostNickname = player.Nickname,
                MaxPlayers = Math.Clamp(req?.MaxPlayers ?? 4, 2, 8),
                TurnSeconds = turnSeconds,
                IsPrivate = req?.IsPrivate ?? false,
                RoomName = string.IsNullOrWhiteSpace(req?.RoomName) ? $"Phòng {roomCode}" : req!.RoomName.Trim()
            };

            if (room.IsPrivate)
            {
                if (string.IsNullOrWhiteSpace(req?.Password))
                {
                    await writer.WriteLineAsync(new Packet
                    {
                        Type = PacketType.JoinRoomFail,
                        Payload = "Phòng riêng tư cần có mật khẩu."
                    }.ToJson());
                    return;
                }
                _roomPasswords[roomCode] = req!.Password.Trim();
            }

            room.Players.Add(new PlayerInfo { Id = player.Id, Nickname = player.Nickname });
            _rooms[roomCode] = room;
            _clientRooms[clientId] = roomCode;

            Console.WriteLine($"Phòng [{roomCode}] riêng={room.IsPrivate}, {turnSeconds}s/lượt");

            await writer.WriteLineAsync(new Packet { Type = PacketType.CreateRoomOK, Payload = JsonSerializer.Serialize(room) }.ToJson());
            await BroadcastRoomList();
            await BroadcastRoomUpdate(roomCode);
        }

        static bool KiemTraMatKhauPhong(string roomCode, RoomInfo room, string? password)
        {
            if (!room.IsPrivate) return true;
            if (!_roomPasswords.TryGetValue(roomCode, out string? expected)) return false;
            return string.Equals(expected, password?.Trim() ?? "", StringComparison.Ordinal);
        }

        static async Task HandleJoinRoom(string clientId, string payload, StreamWriter writer)
        {
            JoinRoomRequest joinReq = ParseJoinRoom(payload);
            string roomCode = joinReq.RoomId.Trim().ToUpperInvariant();

            if (roomCode.Length != 4)
            {
                await FailJoin(writer, "Mã phòng phải có đúng 4 ký tự!");
                return;
            }

            if (!_rooms.TryGetValue(roomCode, out var room))
            {
                await FailJoin(writer, "Mã phòng không tồn tại!");
                return;
            }

            if (room.IsPrivate && !KiemTraMatKhauPhong(roomCode, room, joinReq.Password))
            {
                await FailJoin(writer, "Mật khẩu phòng không đúng. Phòng riêng tư yêu cầu mật khẩu chính xác.");
                return;
            }

            if (room.IsPlaying) { await FailJoin(writer, "Phòng đang chơi, không thể tham gia!"); return; }
            if (room.CurrentPlayers >= room.MaxPlayers) { await FailJoin(writer, "Phòng đã đầy!"); return; }

            if (_clientRooms.ContainsKey(clientId))
                await RemoveClientFromRoom(clientId);

            var player = _clients[clientId].info;
            if (!room.Players.Any(p => p.Id == player.Id))
                room.Players.Add(new PlayerInfo { Id = player.Id, Nickname = player.Nickname });

            _clientRooms[clientId] = roomCode;

            await writer.WriteLineAsync(new Packet { Type = PacketType.JoinRoomOK, Payload = JsonSerializer.Serialize(room) }.ToJson());
            await BroadcastRoomList();
            await BroadcastRoomUpdate(roomCode);
        }

        static async Task HandleQuickJoin(string clientId, StreamWriter writer)
        {
            var room = _rooms.Values
                .Where(r => !r.IsPrivate && !r.IsPlaying && r.CurrentPlayers < r.MaxPlayers)
                .OrderByDescending(r => r.CurrentPlayers)
                .ThenBy(r => r.RoomId)
                .FirstOrDefault();

            if (room is null)
            {
                await writer.WriteLineAsync(new Packet
                {
                    Type = PacketType.QuickJoinFail,
                    Payload = "Không có phòng công khai trống. Phòng riêng cần nhập mã và mật khẩu."
                }.ToJson());
                return;
            }

            if (_clientRooms.ContainsKey(clientId))
                await RemoveClientFromRoom(clientId);

            var player = _clients[clientId].info;
            if (!room.Players.Any(p => p.Id == player.Id))
                room.Players.Add(new PlayerInfo { Id = player.Id, Nickname = player.Nickname });

            _clientRooms[clientId] = room.RoomId;

            await writer.WriteLineAsync(new Packet { Type = PacketType.QuickJoinOK, Payload = JsonSerializer.Serialize(room) }.ToJson());
            await BroadcastRoomList();
            await BroadcastRoomUpdate(room.RoomId);
        }

        static async Task FailJoin(StreamWriter writer, string msg) =>
            await writer.WriteLineAsync(new Packet { Type = PacketType.JoinRoomFail, Payload = msg }.ToJson());

        static async Task HandleStartGame(string clientId, StreamWriter writer)
        {
            if (!_clientRooms.TryGetValue(clientId, out string? roomCode) ||
                !_rooms.TryGetValue(roomCode, out var room))
            {
                await writer.WriteLineAsync(new Packet { Type = PacketType.StartGameFail, Payload = "Bạn chưa ở trong phòng nào." }.ToJson());
                return;
            }

            var player = _clients[clientId].info;
            if (!player.Nickname.Equals(room.HostNickname, StringComparison.OrdinalIgnoreCase))
            {
                await writer.WriteLineAsync(new Packet { Type = PacketType.StartGameFail, Payload = "Chỉ chủ phòng mới có thể bắt đầu." }.ToJson());
                return;
            }

            if (room.IsPlaying)
            {
                await writer.WriteLineAsync(new Packet { Type = PacketType.StartGameFail, Payload = "Trò chơi đã bắt đầu." }.ToJson());
                return;
            }

            if (room.Players.Count < 2)
            {
                await writer.WriteLineAsync(new Packet { Type = PacketType.StartGameFail, Payload = "Cần ít nhất 2 người chơi." }.ToJson());
                return;
            }

            string tuBatDau = await _dictionary.LayTuNgauNhienAsync();
            int turnIndex = _random.Next(room.Players.Count);
            var firstPlayer = room.Players[turnIndex];
            int turnSeconds = room.TurnSeconds;

            var gameState = new RoomGameState
            {
                CurrentWord = tuBatDau,
                CurrentTurnPlayerId = firstPlayer.Id,
                TurnIndex = turnIndex,
                TurnSeconds = turnSeconds,
                ActivePlayerIds = room.Players.Select(p => p.Id).ToList()
            };
            gameState.UsedWords.Add(tuBatDau);

            _gameStates[roomCode] = gameState;
            room.IsPlaying = true;
            room.CurrentWord = tuBatDau;
            room.CurrentTurnNickname = firstPlayer.Nickname;

            Console.WriteLine($"[{roomCode}] Bắt đầu: từ=[{tuBatDau}], {turnSeconds}s, lượt=[{firstPlayer.Nickname}]");

            await BroadcastToRoom(roomCode, new Packet
            {
                Type = PacketType.GameStart,
                Payload = JsonSerializer.Serialize(new GameStartInfo
                {
                    RoomId = roomCode,
                    CurrentWord = tuBatDau,
                    CurrentTurnNickname = firstPlayer.Nickname,
                    TurnSeconds = turnSeconds
                })
            }.ToJson());

            await BroadcastRoomList();
            await BroadcastRoomUpdate(roomCode);
        }

        static async Task XuLyTraLoi(string clientId, string newWord, StreamWriter writer, bool hetGio)
        {
            if (!_clientRooms.TryGetValue(clientId, out string? roomCode) ||
                !_rooms.TryGetValue(roomCode, out var room) ||
                !_gameStates.TryGetValue(roomCode, out var gameState))
            {
                await writer.WriteLineAsync(new Packet { Type = PacketType.WordResult, Payload = "FAIL|Bạn chưa trong trận đấu." }.ToJson());
                return;
            }

            if (clientId != gameState.CurrentTurnPlayerId)
            {
                await writer.WriteLineAsync(new Packet { Type = PacketType.WordResult, Payload = "FAIL|Chưa đến lượt bạn." }.ToJson());
                return;
            }

            var player = _clients[clientId].info;
            string message;
            bool valid = false;

            if (hetGio)
                message = "Hết thời gian!";
            else if (string.IsNullOrWhiteSpace(newWord))
                message = "Từ không được để trống.";
            else if (gameState.UsedWords.Contains(newWord))
                message = "Từ này đã được dùng rồi.";
            else if (!IsValidChain(gameState.CurrentWord, newWord))
                message = $"Sai luật nối từ! Phải bắt đầu bằng \"{LayAmTietCuoi(gameState.CurrentWord)}\".";
            else if (!await _dictionary.KiemTraTuHopLeAsync(newWord))
                message = "Từ không có trong từ điển tiếng Việt hoặc sai chính tả.";
            else
            {
                valid = true;
                message = "Hợp lệ!";
                gameState.UsedWords.Add(newWord);
                gameState.CurrentWord = newWord;
                room.CurrentWord = newWord;
                ChuyenLuotTiepTheo(gameState, room);
            }

            if (!valid)
            {
                await LoaiNguoiChoi(roomCode, room, gameState, clientId, player.Nickname, newWord, message, writer);
                return;
            }

            var submitted = TaoWordSubmitted(player.Nickname, newWord, true, message, gameState, room);
            await BroadcastToRoom(roomCode, new Packet { Type = PacketType.WordSubmitted, Payload = JsonSerializer.Serialize(submitted) }.ToJson());
            await writer.WriteLineAsync(new Packet { Type = PacketType.WordResult, Payload = $"OK|{newWord}" }.ToJson());
            await BroadcastRoomUpdate(roomCode);
        }

        static async Task LoaiNguoiChoi(string roomCode, RoomInfo room, RoomGameState gameState,
            string clientId, string nickname, string word, string message, StreamWriter writer)
        {
            gameState.ActivePlayerIds.Remove(clientId);
            await writer.WriteLineAsync(new Packet { Type = PacketType.WordResult, Payload = $"FAIL|{message}" }.ToJson());

            if (gameState.ActivePlayerIds.Count <= 1)
            {
                var submitted = TaoWordSubmitted(nickname, word, false, message, gameState, room);
                submitted.PlayerEliminated = true;
                submitted.EliminatedNickname = nickname;
                submitted.GameEnded = true;
                submitted.WinnerNickname = gameState.ActivePlayerIds.Count == 1
                    ? room.Players.First(p => p.Id == gameState.ActivePlayerIds[0]).Nickname : "";

                await BroadcastToRoom(roomCode, new Packet { Type = PacketType.WordSubmitted, Payload = JsonSerializer.Serialize(submitted) }.ToJson());
                await KetThucTroChoi(roomCode, room, gameState);
                return;
            }

            if (gameState.CurrentTurnPlayerId == clientId)
                ChuyenLuotTiepTheo(gameState, room);

            var thongBao = TaoWordSubmitted(nickname, word, false, message, gameState, room);
            thongBao.PlayerEliminated = true;
            thongBao.EliminatedNickname = nickname;

            await BroadcastToRoom(roomCode, new Packet { Type = PacketType.WordSubmitted, Payload = JsonSerializer.Serialize(thongBao) }.ToJson());
            await BroadcastRoomUpdate(roomCode);
        }

        static async Task KetThucTroChoi(string roomCode, RoomInfo room, RoomGameState gameState)
        {
            string winner = gameState.ActivePlayerIds.Count == 1
                ? room.Players.First(p => p.Id == gameState.ActivePlayerIds[0]).Nickname
                : "Không xác định";

            room.IsPlaying = false;
            room.CurrentTurnNickname = "";
            _gameStates.TryRemove(roomCode, out _);

            await BroadcastToRoom(roomCode, new Packet
            {
                Type = PacketType.GameWinner,
                Payload = JsonSerializer.Serialize(new GameWinnerInfo
                {
                    RoomId = roomCode,
                    WinnerNickname = winner,
                    Message = $"Chúc mừng {winner} đã chiến thắng!"
                })
            }.ToJson());

            await BroadcastRoomList();
            await BroadcastRoomUpdate(roomCode);
        }

        static void ChuyenLuotTiepTheo(RoomGameState gameState, RoomInfo room)
        {
            var active = room.Players.Where(p => gameState.ActivePlayerIds.Contains(p.Id)).ToList();
            if (active.Count == 0) return;

            int idx = active.FindIndex(p => p.Id == gameState.CurrentTurnPlayerId);
            idx = idx < 0 ? 0 : (idx + 1) % active.Count;

            gameState.CurrentTurnPlayerId = active[idx].Id;
            gameState.TurnIndex = room.Players.FindIndex(p => p.Id == active[idx].Id);
            room.CurrentTurnNickname = active[idx].Nickname;
        }

        static WordSubmittedInfo TaoWordSubmitted(string nickname, string word, bool valid, string message,
            RoomGameState gameState, RoomInfo room) => new()
        {
            Nickname = nickname,
            Word = word,
            IsValid = valid,
            Message = message,
            CurrentWord = gameState.CurrentWord,
            NextTurnNickname = room.CurrentTurnNickname,
            TurnSeconds = gameState.TurnSeconds
        };

        static async Task HandleChat(string clientId, string payload)
        {
            if (!_clientRooms.TryGetValue(clientId, out string? roomCode)) return;
            var player = _clients[clientId].info;
            await BroadcastToRoom(roomCode, new Packet { Type = PacketType.Chat, Payload = $"{player.Nickname}|{payload.Trim()}" }.ToJson());
        }

        static async Task HandleLeaveRoom(string clientId)
        {
            if (!_clientRooms.TryRemove(clientId, out string? roomCode)) return;
            await RemoveClientFromRoom(clientId, roomCode);
        }

        static async Task RemoveClientFromRoom(string clientId, string? roomCode = null)
        {
            if (roomCode is null && !_clientRooms.TryRemove(clientId, out roomCode)) return;
            else _clientRooms.TryRemove(clientId, out _);

            if (!_rooms.TryGetValue(roomCode!, out var room)) return;

            if (_clients.TryGetValue(clientId, out var client))
                room.Players.RemoveAll(p => p.Id == clientId);

            if (room.Players.Count == 0)
            {
                _rooms.TryRemove(roomCode!, out _);
                _roomPasswords.TryRemove(roomCode!, out _);
                _gameStates.TryRemove(roomCode!, out _);
            }
            else if (!room.Players.Any(p => p.Nickname.Equals(room.HostNickname, StringComparison.OrdinalIgnoreCase)))
            {
                room.HostNickname = room.Players[0].Nickname;
            }

            await BroadcastRoomList();
            await BroadcastRoomUpdate(roomCode!);
        }

        static async Task BroadcastRoomList()
        {
            var packet = new Packet { Type = PacketType.RoomList, Payload = JsonSerializer.Serialize(_rooms.Values.ToList()) }.ToJson();
            foreach (var (_, _, w) in _clients.Values)
            {
                try { await w.WriteLineAsync(packet); } catch { }
            }
        }

        static async Task BroadcastRoomUpdate(string roomCode)
        {
            if (!_rooms.TryGetValue(roomCode, out var room)) return;
            await BroadcastToRoom(roomCode, new Packet { Type = PacketType.RoomUpdate, Payload = JsonSerializer.Serialize(room) }.ToJson());
        }

        static async Task BroadcastToRoom(string roomCode, string packetJson)
        {
            if (!_rooms.TryGetValue(roomCode, out var room)) return;
            foreach (var p in room.Players)
            {
                if (_clients.TryGetValue(p.Id, out var c))
                {
                    try { await c.writer.WriteLineAsync(packetJson); } catch { }
                }
            }
        }

        static bool IsValidChain(string lastWord, string newWord)
        {
            if (string.IsNullOrEmpty(lastWord)) return true;
            return LayAmTietCuoi(lastWord) == LayAmTietDau(newWord);
        }

        static string LayAmTietCuoi(string word) =>
            ChuanHoaAmTiet(word.Split(' ', StringSplitOptions.RemoveEmptyEntries).Last());

        static string LayAmTietDau(string word) =>
            ChuanHoaAmTiet(word.Split(' ', StringSplitOptions.RemoveEmptyEntries).First());

        static string ChuanHoaAmTiet(string amTiet) =>
            amTiet.Trim().Normalize(NormalizationForm.FormC).ToLowerInvariant();
    }
}
