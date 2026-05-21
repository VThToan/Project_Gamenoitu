using System;

namespace WordChain.StressTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("==============================================");
            Console.WriteLine("        WORDCHAIN - STRESS TEST SKELETON      ");
            Console.WriteLine("==============================================");

            // TODO 1: Khởi tạo nhiều kết nối Client giả lập (Simulated Clients)
            // - Tạo một vòng lặp để khởi tạo đồng thời N đối tượng TcpClient (ví dụ: 50 - 100 clients).
            // - Kết nối tất cả các clients này đến địa chỉ Server IP và Cổng đang chạy.
            
            // TODO 2: Giả lập hành vi của người chơi (Player Simulation)
            // - Cho các client giả lập đăng ký biệt danh tự động (ví dụ: Bot_01, Bot_02...).
            // - Giả lập các thao tác tự động gửi gói tin Chat, tham gia phòng và gửi từ nối liên tục.
            
            // TODO 3: Đo đạc và ghi nhận thông số hiệu năng (Performance Telemetry)
            // - Sử dụng đồng hồ bấm giờ (Stopwatch) để đo thời gian phản hồi (Latency) từ lúc gửi gói tin đến lúc nhận gói tin phản hồi.
            // - Thống kê tỷ lệ truyền nhận thành công, số lượng kết nối tối đa máy chủ chịu được mà không phát sinh ngoại lệ.
            // - Ghi nhận kết quả ra tệp nhật ký để làm báo cáo minh chứng stress test (ví dụ: lưu vào thư mục 'Extra/StressTest_Results.txt').
        }
    }
}
