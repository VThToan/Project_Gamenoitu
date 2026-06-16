using System;
using System.Net.Sockets;
using System.Text.Json;

namespace WordChain.Common
{
    // 1. Định nghĩa các loại hành động/gói tin giao tiếp giữa Client và Server
    public enum PacketType
    {
        Connect,    // Client gửi nickname lên Server khi mới vào game
        ConnectOK,  // Server xác nhận kết nối thành công và phản hồi lại
        Chat,       // Tin nhắn chat hoặc từ ngữ dùng để nối chữ
        Disconnect,  // Báo ngắt kết nối
        
        // Phòng chơi
        CreateRoom, CreateRoomOK,
        JoinRoom, JoinRoomOK, JoinRoomFail,
        QuickJoin, QuickJoinOK, QuickJoinFail,
        LeaveRoom,
        RoomList, RoomUpdate,
        StartGame, StartGameFail,
        SubmitWord, WordResult, WordSubmitted,
        TurnTimeout,
        GameStart, NextTurn, GameWinner
    }

    // 2. Cấu trúc chuẩn của một gói tin khi truyền qua mạng
    public class Packet
    {
        // Loại gói tin (thuộc enum PacketType ở trên)
        public PacketType Type { get; set; }

        // Nội dung chi tiết của gói tin (chuỗi text thường hoặc chuỗi JSON khác)
        public string Payload { get; set; } = "";

        // Hàm chuyển đổi đối tượng Packet thành chuỗi JSON để gửi đi (Serialize)
        public string ToJson() => JsonSerializer.Serialize(this);

        // Hàm tĩnh đọc chuỗi JSON nhận được và chuyển ngược lại thành đối tượng Packet (Deserialize)
        public static Packet? FromJson(string json) => JsonSerializer.Deserialize<Packet>(json);
    }

    // 3. Cấu trúc lưu trữ thông tin của một người chơi (nếu cần dùng ở các tính năng sau)
    public class PlayerInfo
    {
        public string Id { get; set; } = "";
        public string Nickname { get; set; } = "";
    }


   public class RoomInfo
    {
        // Mã phòng (VD: A1B2)
        public string RoomId { get; set; } = "";

        // Người tạo phòng
        public string HostNickname { get; set; } = "";

        // Danh sách người chơi trong phòng
        public List<PlayerInfo> Players { get; set; } = new();

        // Số người hiện tại
        public int CurrentPlayers
        {
            get { return Players.Count; }
        }

        // Số người tối đa
        public int MaxPlayers { get; set; } = 4;

        // Trạng thái phòng
        public bool IsPlaying { get; set; } = false;

        // Từ hiện tại khi đang chơi
        public string CurrentWord { get; set; } = "";

        // Nickname người đang đến lượt
        public string CurrentTurnNickname { get; set; } = "";
    }

    // Payload khi tạo phòng thành công
    public class CreateRoomResponse
    {
        public string RoomId { get; set; } = "";
    }

    // Payload khi yêu cầu vào phòng
    public class JoinRoomRequest
    {
        public string RoomId { get; set; } = "";
    }

    // Payload gửi từ nối chữ
    public class SubmitWordRequest
    {
        public string Word { get; set; } = "";
    }

    // Payload trả kết quả từ đúng/sai
    public class WordResultResponse
    {
        public bool IsValid { get; set; }

        public string Message { get; set; } = "";
    }

    // Payload khi bắt đầu trò chơi (broadcast tới mọi người trong phòng)
    public class GameStartInfo
    {
        public string RoomId { get; set; } = "";
        public string CurrentWord { get; set; } = "";
        public string CurrentTurnNickname { get; set; } = "";
        public int TurnSeconds { get; set; } = 20;
    }

    // Payload khi có người gửi từ (broadcast tới mọi người trong phòng)
    public class WordSubmittedInfo
    {
        public string Nickname { get; set; } = "";
        public string Word { get; set; } = "";
        public bool IsValid { get; set; }
        public string Message { get; set; } = "";
        public string CurrentWord { get; set; } = "";
        public string NextTurnNickname { get; set; } = "";
        public bool PlayerEliminated { get; set; }
        public string EliminatedNickname { get; set; } = "";
        public bool GameEnded { get; set; }
        public string WinnerNickname { get; set; } = "";
        public int TurnSeconds { get; set; } = 20;
    }

    // Payload thông báo người chiến thắng
    public class GameWinnerInfo
    {
        public string WinnerNickname { get; set; } = "";
        public string Message { get; set; } = "";
        public string RoomId { get; set; } = "";
    }

    // Payload thông báo lượt chơi
    public class NextTurnInfo
    {
        public string Nickname { get; set; } = "";
        public string CurrentWord { get; set; } = "";
    }
}
