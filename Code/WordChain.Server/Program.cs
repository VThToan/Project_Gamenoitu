using System.Net;
using System.Net.Sockets;
using System.Collections.Concurrent;
using System.IO;
using System.Text.Json;
using WordChain.Common;

namespace WordChain.Server
{
    class Program
    {
        static ConcurrentDictionary<string, (TcpClient tcp, PlayerInfo info, StreamWriter writer)> _clients = new();
        static ConcurrentDictionary<string, RoomInfo> _rooms = new();
        static ConcurrentDictionary<string, string> _clientRooms = new();
        static ConcurrentDictionary<string, RoomGameState> _gameStates = new();
        static readonly VietnameseDictionaryService _dictionary = new();
        static readonly Random _random = new();

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== GAME NỐI TỪ - SERVER ===");

            var listener = new TcpListener(IPAddress.Any, 8888);
            listener.Start();
            Console.WriteLine("✅ Server đang chạy trên cổng 8888. Chờ Client kết nối...");

            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                Console.WriteLine("🔌 Có Client mới kết nối!");
                _ = Task.Run(() => HandleClient(client));
            }
        }

        sealed class RoomGameState
        {
            public string CurrentWord { get; set; } = "";
            public string CurrentTurnPlayerId { get; set; } = "";
            public int TurnIndex { get; set; }
            public HashSet<string> UsedWords { get; } = new(StringComparer.OrdinalIgnoreCase);
            public List<string> ActivePlayerIds { get; set; } = [];
            public int TurnSeconds { get; set; } = 20;
        }

        static async Task HandleClient(TcpClient client)
        {
            var stream = client.GetStream();
            var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
            var writer = new StreamWriter(stream, System.Text.Encoding.UTF8) { AutoFlush = true };

            string clientId = Guid.NewGuid().ToString();

            try
            {
                while (true)
                {
                    string? line = await reader.ReadLineAsync();
                    if (line == null) break;

                    var packet = Packet.FromJson(line);
                    if (packet == null) continue;

                    Console.WriteLine($"Nhận từ [{clientId}]: {packet.Type} - {packet.Payload}");

                    switch (packet.Type)
                    {
                        case PacketType.Connect:
                            var player = new PlayerInfo { Id = clientId, Nickname = packet.Payload };
                            _clients[clientId] = (client, player, writer);
                            Console.WriteLine($"Người chơi [{player.Nickname}] đã tham gia.");
                            await writer.WriteLineAsync(new Packet
                            {
                                Type = PacketType.ConnectOK,
                                Payload = "Kết nối thành công!"
                            }.ToJson());
                            await BroadcastRoomList();
                            break;

                        case PacketType.CreateRoom:
                            await HandleCreateRoom(clientId, writer);
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
                            await HandleSubmitWord(clientId, packet.Payload, writer);
                            break;

                        case PacketType.TurnTimeout:
                            await HandleTurnTimeout(clientId, writer);
                            break;

                        case PacketType.Chat:
                            await HandleChat(clientId, packet.Payload);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Client [{clientId}] ngắt kết nối: {ex.Message}");
            }
            finally
            {
                await HandleLeaveRoom(clientId);
                _clients.TryRemove(clientId, out _);
                client.Close();
                Console.WriteLine($"Client [{clientId}] đã rời khỏi server.");
            }
        }

        static string GenerateRoomCode()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            return new string(Enumerable.Range(0, 4)
                .Select(_ => chars[_random.Next(chars.Length)]).ToArray());
        }

        static async Task HandleCreateRoom(string clientId, StreamWriter writer)
        {
            if (!_clients.ContainsKey(clientId))
                return;

            if (_clientRooms.ContainsKey(clientId))
                await RemoveClientFromRoom(clientId);

            string roomCode;
            do
            {
                roomCode = GenerateRoomCode();
            } while (_rooms.ContainsKey(roomCode));

            var player = _clients[clientId].info;
            var room = new RoomInfo
            {
                RoomId = roomCode,
                HostNickname = player.Nickname,
                MaxPlayers = 4
            };
            room.Players.Add(new PlayerInfo { Id = player.Id, Nickname = player.Nickname });

            _rooms[roomCode] = room;
            _clientRooms[clientId] = roomCode;

            Console.WriteLine($"Phòng [{roomCode}] được tạo bởi [{player.Nickname}]");

            await writer.WriteLineAsync(new Packet
            {
                Type = PacketType.CreateRoomOK,
                Payload = JsonSerializer.Serialize(room)
            }.ToJson());

            await BroadcastRoomList();
            await BroadcastRoomUpdate(roomCode);
        }

        static async Task HandleJoinRoom(string clientId, string roomCode, StreamWriter writer)
        {
            roomCode = roomCode.Trim().ToUpperInvariant();

            if (roomCode.Length != 4)
            {
                await writer.WriteLineAsync(new Packet
                {
                    Type = PacketType.JoinRoomFail,
                    Payload = "Mã phòng phải có đúng 4 ký tự!"
                }.ToJson());
                return;
            }

            if (!_rooms.TryGetValue(roomCode, out var room))
            {
                await writer.WriteLineAsync(new Packet
                {
                    Type = PacketType.JoinRoomFail,
                    Payload = "Mã phòng không tồn tại!"
                }.ToJson());
                return;
            }

            if (room.IsPlaying)
            {
                await writer.WriteLineAsync(new Packet
                {
                    Type = PacketType.JoinRoomFail,
                    Payload = "Phòng đang chơi, không thể tham gia!"
                }.ToJson());
                return;
            }

            if (room.CurrentPlayers >= room.MaxPlayers)
            {
                await writer.WriteLineAsync(new Packet
                {
                    Type = PacketType.JoinRoomFail,
                    Payload = "Phòng đã đầy!"
                }.ToJson());
                return;
            }

            if (_clientRooms.ContainsKey(clientId))
                await RemoveClientFromRoom(clientId);

            var player = _clients[clientId].info;
            if (!room.Players.Any(p => p.Id == player.Id))
            {
                room.Players.Add(new PlayerInfo { Id = player.Id, Nickname = player.Nickname });
            }

            _clientRooms[clientId] = roomCode;

            Console.WriteLine($"[{player.Nickname}] vào phòng [{roomCode}]");

            await writer.WriteLineAsync(new Packet
            {
                Type = PacketType.JoinRoomOK,
                Payload = JsonSerializer.Serialize(room)
            }.ToJson());

            await BroadcastRoomList();
            await BroadcastRoomUpdate(roomCode);
        }

        static async Task HandleQuickJoin(string clientId, StreamWriter writer)
        {
            var room = _rooms.Values
                .Where(r => !r.IsPlaying && r.CurrentPlayers < r.MaxPlayers)
                .OrderByDescending(r => r.CurrentPlayers)
                .ThenBy(r => r.RoomId)
                .FirstOrDefault();

            if (room is null)
            {
                await writer.WriteLineAsync(new Packet
                {
                    Type = PacketType.QuickJoinFail,
                    Payload = "Hiện chưa có phòng trống. Hãy tạo phòng mới nhé!"
                }.ToJson());
                return;
            }

            if (_clientRooms.ContainsKey(clientId))
                await RemoveClientFromRoom(clientId);

            var player = _clients[clientId].info;
            if (!room.Players.Any(p => p.Id == player.Id))
            {
                room.Players.Add(new PlayerInfo { Id = player.Id, Nickname = player.Nickname });
            }

            _clientRooms[clientId] = room.RoomId;

            await writer.WriteLineAsync(new Packet
            {
                Type = PacketType.QuickJoinOK,
                Payload = JsonSerializer.Serialize(room)
            }.ToJson());

            await BroadcastRoomList();
            await BroadcastRoomUpdate(room.RoomId);
        }

        static async Task HandleStartGame(string clientId, StreamWriter writer)
        {
            if (!_clientRooms.TryGetValue(clientId, out string? roomCode) ||
                !_rooms.TryGetValue(roomCode, out var room))
            {
                await writer.WriteLineAsync(new Packet
                {
                    Type = PacketType.StartGameFail,
                    Payload = "Bạn chưa ở trong phòng nào."
                }.ToJson());
                return;
            }

            var player = _clients[clientId].info;
            if (!player.Nickname.Equals(room.HostNickname, StringComparison.OrdinalIgnoreCase))
            {
                await writer.WriteLineAsync(new Packet
                {
                    Type = PacketType.StartGameFail,
                    Payload = "Chỉ chủ phòng mới có thể bắt đầu trò chơi."
                }.ToJson());
                return;
            }

            if (room.IsPlaying)
            {
                await writer.WriteLineAsync(new Packet
                {
                    Type = PacketType.StartGameFail,
                    Payload = "Trò chơi đã bắt đầu rồi."
                }.ToJson());
                return;
            }

            if (room.Players.Count < 2)
            {
                await writer.WriteLineAsync(new Packet
                {
                    Type = PacketType.StartGameFail,
                    Payload = "Cần ít nhất 2 người chơi để bắt đầu."
                }.ToJson());
                return;
            }

            string tuBatDau = await _dictionary.LayTuNgauNhienAsync();
            int turnIndex = _random.Next(room.Players.Count);
            var firstPlayer = room.Players[turnIndex];

            var gameState = new RoomGameState
            {
                CurrentWord = tuBatDau,
                CurrentTurnPlayerId = firstPlayer.Id,
                TurnIndex = turnIndex,
                TurnSeconds = 20,
                ActivePlayerIds = room.Players.Select(p => p.Id).ToList()
            };
            gameState.UsedWords.Add(tuBatDau);

            _gameStates[roomCode] = gameState;
            room.IsPlaying = true;
            room.CurrentWord = tuBatDau;
            room.CurrentTurnNickname = firstPlayer.Nickname;

            Console.WriteLine($"Phòng [{roomCode}] bắt đầu. Từ: [{tuBatDau}], lượt: [{firstPlayer.Nickname}]");

            var gameStart = new GameStartInfo
            {
                RoomId = roomCode,
                CurrentWord = tuBatDau,
                CurrentTurnNickname = firstPlayer.Nickname,
                TurnSeconds = gameState.TurnSeconds
            };

            await BroadcastToRoom(roomCode, new Packet
            {
                Type = PacketType.GameStart,
                Payload = JsonSerializer.Serialize(gameStart)
            }.ToJson());

            await BroadcastRoomList();
            await BroadcastRoomUpdate(roomCode);
        }

        static async Task HandleSubmitWord(string clientId, string payload, StreamWriter writer)
        {
            await XuLyTraLoi(clientId, payload.Trim(), writer, hetGio: false);
        }

        static async Task HandleTurnTimeout(string clientId, StreamWriter writer)
        {
            await XuLyTraLoi(clientId, "", writer, hetGio: true);
        }

        static async Task XuLyTraLoi(string clientId, string newWord, StreamWriter writer, bool hetGio)
        {
            if (!_clientRooms.TryGetValue(clientId, out string? roomCode) ||
                !_rooms.TryGetValue(roomCode, out var room) ||
                !_gameStates.TryGetValue(roomCode, out var gameState))
            {
                await writer.WriteLineAsync(new Packet
                {
                    Type = PacketType.WordResult,
                    Payload = "FAIL|Bạn chưa trong trận đấu."
                }.ToJson());
                return;
            }

            if (clientId != gameState.CurrentTurnPlayerId)
            {
                await writer.WriteLineAsync(new Packet
                {
                    Type = PacketType.WordResult,
                    Payload = "FAIL|Chưa đến lượt bạn."
                }.ToJson());
                return;
            }

            var player = _clients[clientId].info;
            string message;
            bool valid = false;

            if (hetGio)
            {
                message = "Hết thời gian! Bạn đã bị loại.";
            }
            else if (string.IsNullOrWhiteSpace(newWord))
            {
                message = "Từ không được để trống.";
            }
            else if (gameState.UsedWords.Contains(newWord))
            {
                message = "Từ này đã được dùng rồi.";
            }
            else if (!IsValidChain(gameState.CurrentWord, newWord))
            {
                message = $"Sai luật nối từ! Phải bắt đầu bằng âm tiết \"{LayAmTietCuoi(gameState.CurrentWord)}\".";
            }
            else if (!await _dictionary.KiemTraTuHopLeAsync(newWord))
            {
                message = "Từ không có trong từ điển tiếng Việt hoặc sai chính tả.";
            }
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

            string nextTurnNickname = room.CurrentTurnNickname;
            var submitted = TaoWordSubmitted(player.Nickname, newWord, valid, message, gameState, room, nextTurnNickname);

            await BroadcastToRoom(roomCode, new Packet
            {
                Type = PacketType.WordSubmitted,
                Payload = JsonSerializer.Serialize(submitted)
            }.ToJson());

            await writer.WriteLineAsync(new Packet
            {
                Type = PacketType.WordResult,
                Payload = $"OK|{newWord}"
            }.ToJson());

            await BroadcastRoomUpdate(roomCode);
        }

        static async Task LoaiNguoiChoi(
            string roomCode, RoomInfo room, RoomGameState gameState,
            string clientId, string nickname, string word, string message, StreamWriter writer)
        {
            gameState.ActivePlayerIds.Remove(clientId);

            await writer.WriteLineAsync(new Packet
            {
                Type = PacketType.WordResult,
                Payload = $"FAIL|{message}"
            }.ToJson());

            Console.WriteLine($"[{nickname}] bị loại khỏi phòng [{roomCode}]: {message}");

            if (gameState.ActivePlayerIds.Count <= 1)
            {
                var submitted = TaoWordSubmitted(nickname, word, false, message, gameState, room, "");
                submitted.PlayerEliminated = true;
                submitted.EliminatedNickname = nickname;
                submitted.GameEnded = true;
                submitted.WinnerNickname = gameState.ActivePlayerIds.Count == 1
                    ? room.Players.First(p => p.Id == gameState.ActivePlayerIds[0]).Nickname
                    : "";

                await BroadcastToRoom(roomCode, new Packet
                {
                    Type = PacketType.WordSubmitted,
                    Payload = JsonSerializer.Serialize(submitted)
                }.ToJson());

                await KetThucTroChoi(roomCode, room, gameState);
                return;
            }

            if (gameState.CurrentTurnPlayerId == clientId)
            {
                ChuyenLuotTiepTheo(gameState, room);
            }

            var thongBao = TaoWordSubmitted(nickname, word, false, message, gameState, room, room.CurrentTurnNickname);
            thongBao.PlayerEliminated = true;
            thongBao.EliminatedNickname = nickname;

            await BroadcastToRoom(roomCode, new Packet
            {
                Type = PacketType.WordSubmitted,
                Payload = JsonSerializer.Serialize(thongBao)
            }.ToJson());

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

            var winnerInfo = new GameWinnerInfo
            {
                RoomId = roomCode,
                WinnerNickname = winner,
                Message = $"🎉 Chúc mừng {winner} đã chiến thắng!"
            };

            Console.WriteLine($"Phòng [{roomCode}] kết thúc. Người thắng: [{winner}]");

            await BroadcastToRoom(roomCode, new Packet
            {
                Type = PacketType.GameWinner,
                Payload = JsonSerializer.Serialize(winnerInfo)
            }.ToJson());

            await BroadcastRoomList();
            await BroadcastRoomUpdate(roomCode);
        }

        static void ChuyenLuotTiepTheo(RoomGameState gameState, RoomInfo room)
        {
            var activePlayers = room.Players.Where(p => gameState.ActivePlayerIds.Contains(p.Id)).ToList();
            if (activePlayers.Count == 0)
            {
                return;
            }

            int currentIdx = activePlayers.FindIndex(p => p.Id == gameState.CurrentTurnPlayerId);
            if (currentIdx < 0)
            {
                currentIdx = 0;
            }
            else
            {
                currentIdx = (currentIdx + 1) % activePlayers.Count;
            }

            var nextPlayer = activePlayers[currentIdx];
            gameState.CurrentTurnPlayerId = nextPlayer.Id;
            gameState.TurnIndex = room.Players.FindIndex(p => p.Id == nextPlayer.Id);
            room.CurrentTurnNickname = nextPlayer.Nickname;
        }

        static WordSubmittedInfo TaoWordSubmitted(
            string nickname, string word, bool valid, string message,
            RoomGameState gameState, RoomInfo room, string nextTurnNickname)
        {
            return new WordSubmittedInfo
            {
                Nickname = nickname,
                Word = word,
                IsValid = valid,
                Message = message,
                CurrentWord = gameState.CurrentWord,
                NextTurnNickname = nextTurnNickname,
                TurnSeconds = gameState.TurnSeconds
            };
        }

        static async Task HandleChat(string clientId, string payload)
        {
            if (!_clientRooms.TryGetValue(clientId, out string? roomCode))
                return;

            var player = _clients[clientId].info;
            string chatPayload = $"{player.Nickname}|{payload.Trim()}";

            await BroadcastToRoom(roomCode, new Packet
            {
                Type = PacketType.Chat,
                Payload = chatPayload
            }.ToJson());
        }

        static async Task HandleLeaveRoom(string clientId)
        {
            if (!_clientRooms.TryRemove(clientId, out string? roomCode))
                return;

            await RemoveClientFromRoom(clientId, roomCode);
        }

        static async Task RemoveClientFromRoom(string clientId, string? roomCode = null)
        {
            if (roomCode is null)
            {
                if (!_clientRooms.TryRemove(clientId, out roomCode))
                    return;
            }
            else
            {
                _clientRooms.TryRemove(clientId, out _);
            }

            if (!_rooms.TryGetValue(roomCode, out var room))
                return;

            if (_clients.TryGetValue(clientId, out var client))
            {
                room.Players.RemoveAll(p => p.Id == clientId);
                Console.WriteLine($"[{client.info.Nickname}] rời phòng [{roomCode}]");
            }

            if (room.Players.Count == 0)
            {
                _rooms.TryRemove(roomCode, out _);
                _gameStates.TryRemove(roomCode, out _);
                Console.WriteLine($"Phòng [{roomCode}] đã bị xóa.");
            }
            else if (room.IsPlaying && _gameStates.TryGetValue(roomCode, out var gameState))
            {
                if (!room.Players.Any(p => p.Id == gameState.CurrentTurnPlayerId))
                {
                    gameState.TurnIndex %= Math.Max(room.Players.Count, 1);
                    if (room.Players.Count > 0)
                    {
                        var next = room.Players[gameState.TurnIndex % room.Players.Count];
                        gameState.CurrentTurnPlayerId = next.Id;
                        room.CurrentTurnNickname = next.Nickname;
                    }
                }

                if (room.Players.Count < 2)
                {
                    room.IsPlaying = false;
                    room.CurrentWord = "";
                    room.CurrentTurnNickname = "";
                    _gameStates.TryRemove(roomCode, out _);
                }
            }

            if (room.Players.Count > 0 &&
                !room.Players.Any(p => p.Nickname.Equals(room.HostNickname, StringComparison.OrdinalIgnoreCase)))
            {
                room.HostNickname = room.Players[0].Nickname;
            }

            await BroadcastRoomList();
            await BroadcastRoomUpdate(roomCode);
        }

        static async Task BroadcastRoomList()
        {
            var list = _rooms.Values.ToList();
            var packet = new Packet
            {
                Type = PacketType.RoomList,
                Payload = JsonSerializer.Serialize(list)
            };

            foreach (var (_, _, writer) in _clients.Values)
            {
                try { await writer.WriteLineAsync(packet.ToJson()); }
                catch { /* Client đã ngắt */ }
            }
        }

        static async Task BroadcastRoomUpdate(string roomCode)
        {
            if (!_rooms.TryGetValue(roomCode, out var room))
                return;

            await BroadcastToRoom(roomCode, new Packet
            {
                Type = PacketType.RoomUpdate,
                Payload = JsonSerializer.Serialize(room)
            }.ToJson());
        }

        static async Task BroadcastToRoom(string roomCode, string packetJson)
        {
            if (!_rooms.TryGetValue(roomCode, out var room))
                return;

            foreach (var player in room.Players)
            {
                if (_clients.TryGetValue(player.Id, out var client))
                {
                    try { await client.writer.WriteLineAsync(packetJson); }
                    catch { /* Client đã ngắt */ }
                }
            }
        }

        static bool IsValidChain(string lastWord, string newWord)
        {
            string lastSyllable = LayAmTietCuoi(lastWord);
            string firstSyllable = LayAmTietDau(newWord);
            return lastSyllable == firstSyllable;
        }

        static string LayAmTietCuoi(string word)
        {
            return word.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Last().ToLowerInvariant();
        }

        static string LayAmTietDau(string word)
        {
            return word.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).First().ToLowerInvariant();
        }
    }
}
