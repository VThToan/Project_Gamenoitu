using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WordChain.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("==============================================");
            Console.WriteLine("        GAME NỐI TỪ ONLINE - SERVER SKELETON  ");
            Console.WriteLine("==============================================");

            // TODO 1: Khởi tạo Server và lắng nghe kết nối
            // - Khởi tạo đối tượng TcpListener lắng nghe trên một cổng (ví dụ: 8888).
            // - Bắt đầu lắng nghe kết nối (listener.Start()).
            
            Console.WriteLine("[Server] Đang lắng nghe kết nối...");

            // TODO 2: Tạo vòng lặp chấp nhận Client kết nối (Accept Loop)
            // - Sử dụng listener.AcceptTcpClient() hoặc listener.AcceptTcpClientAsync() để nhận kết nối từ Client.
            // - Mỗi khi có Client kết nối, tạo một Thread mới hoặc chạy một Task mới để xử lý Client đó độc lập.
            //   Ví dụ: Task.Run(() => HandleClient(tcpClient));

            // TODO 3: Quản lý Danh sách người chơi & Phòng chơi (Rooms & Players Manager)
            // - Tạo các cấu trúc dữ liệu thread-safe (như ConcurrentDictionary hoặc sử dụng lock)
            //   để lưu trữ danh sách Client đang kết nối, danh sách các phòng đấu hiện có.
            
            // TODO 4: Xử lý giao tiếp (Read/Write Loop) cho từng Client
            // - Nhận luồng dữ liệu NetworkStream từ TcpClient.
            // - Sử dụng StreamReader/StreamWriter để gửi và nhận các chuỗi JSON (các gói tin).
            // - Phân tích gói tin nhận được (Type) để thực hiện logic:
            //   + Tạo phòng (CreateRoom)
            //   + Vào phòng (JoinRoom)
            //   + Chơi game (SubmitWord): Gọi API từ điển để xác thực từ và chuyển lượt chơi.
            //   + Chat (Realtime Chat)
            //   + Ngắt kết nối (Disconnect): Xử lý dọn dẹp phòng chơi khi người chơi thoát.
        }
    }
}
