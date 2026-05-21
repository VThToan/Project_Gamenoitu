using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordChain.Client
{
    public partial class Form1 : Form
    {
        // Khai báo các đối tượng kết nối mạng TCP
        private TcpClient? _client;
        private NetworkStream? _stream;
        private StreamReader? _reader;
        private StreamWriter? _writer;
        private bool _isConnected = false;

        public Form1()
        {
            InitializeComponent();
            
            // TODO 1: Thiết kế giao diện (UI Design)
            // - Bạn có thể kéo thả các điều khiển (Controls) trong giao diện thiết kế (Designer)
            // - Giao diện nên có:
            //   1. Màn hình kết nối: Nhập IP, Cổng (Port), Biệt danh (Nickname), chọn ảnh đại diện.
            //   2. Màn hình sảnh (Lobby): Xem danh sách phòng, tạo phòng, tham gia phòng và khung chat chung.
            //   3. Màn hình phòng game: Danh sách người chơi trong phòng kèm điểm/mạng số, ô chat phòng, 
            //      luồng hiển thị lịch sử từ nối, thanh tiến trình thời gian đếm ngược, ô nhập từ để nộp.
        }

        // TODO 2: Thiết lập kết nối đến Server
        // - Khi nhấn nút "Kết nối" (Connect button click event):
        //   + Khởi tạo: _client = new TcpClient();
        //   + Kết nối bất đồng bộ: await _client.ConnectAsync(ip, port);
        //   + Lấy luồng dữ liệu: _stream = _client.GetStream();
        //   + Tạo bộ đọc/ghi: _reader = new StreamReader(_stream); _writer = new StreamWriter(_stream) { AutoFlush = true };
        //   + Gửi gói tin đăng nhập chứa Nickname lên Server.
        //   + Khởi chạy một Task chạy nền để liên tục đọc dữ liệu gửi về từ Server: Task.Run(ReceiveMessagesAsync);
        private async void BtnConnect_Click(object sender, EventArgs e)
        {
            // Viết code xử lý kết nối ở đây
        }

        // TODO 3: Vòng lặp nhận dữ liệu từ Server (Background Reader Loop)
        // - Chạy ngầm để liên tục lắng nghe Server:
        //   while (_isConnected) { string line = await _reader.ReadLineAsync(); ... }
        // - Giải mã chuỗi JSON nhận được thành đối tượng gói tin.
        // - LƯU Ý QUAN TRỌNG: Bạn không được cập nhật trực tiếp giao diện (WinForms) từ luồng chạy nền này 
        //   để tránh lỗi "Cross-thread operation not valid". Hãy sử dụng:
        //   this.Invoke(new Action(() => { UpdateUI(packet); }));
        private async Task ReceiveMessagesAsync()
        {
            // Viết code vòng lặp đọc dữ liệu bất đồng bộ ở đây
        }

        // TODO 4: Xử lý sự kiện người dùng (UI Events)
        // - Sự kiện tạo phòng: Gửi yêu cầu CreateRoom (Tên phòng, số người, thời gian).
        //   _writer.WriteLine(jsonCreateRoomPacket);
        // - Sự kiện nộp từ nối: Lấy chuỗi trong ô TextBox, gửi yêu cầu SubmitWord lên Server.
        // - Sự kiện chat room: Lấy nội dung chat gửi yêu cầu Chat lên Server.
        // - Sự kiện rời phòng: Thoát khỏi phòng hiện tại để quay về sảnh chờ (Lobby).
    }
}
