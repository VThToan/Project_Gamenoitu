# Game Nối Từ Online (Online Word Chain)

**Mã dự án:** [Điền mã dự án tại đây]  
**Môn học:** Lập trình mạng  
**Học kỳ:** [Điền học kỳ tại đây]  

---

## 1. Giới thiệu dự án
Dự án **Game Nối Từ Online** là một ứng dụng trò chơi trực tuyến thời gian thực áp dụng kiến thức môn Lập trình mạng. Trò chơi cho phép nhiều người chơi kết nối đến một máy chủ trung tâm, tham gia hoặc tạo các phòng chơi và thực hiện luật chơi nối từ tiếng Việt.

## 2. Kiến trúc hệ thống
Dự án được xây dựng dựa trên mô hình **Client - Server** giao tiếp qua giao thức **TCP Socket**:
* **Server**: Chịu trách nhiệm lắng nghe kết nối từ các client, quản lý danh sách phòng chơi, điều phối lượt chơi, kiểm tra tính hợp lệ của từ nối (thông qua việc gọi API từ điển tiếng Việt) và xử lý sự kiện người dùng ngắt kết nối.
* **Client**: Ứng dụng Desktop chạy trên hệ điều hành Windows được xây dựng bằng công nghệ **Windows Forms (WinForms)** với giao diện đồ họa hiện đại, trực quan, cho phép người chơi đăng nhập nickname, tạo/vào phòng chơi bằng mã phòng, tham gia chat room và gửi từ nối thời gian thực.

---

## 3. Cấu trúc thư mục repository
Đồ án tuân thủ cấu trúc thư mục tiêu chuẩn sau:

```text
├── Code/             # Chứa toàn bộ mã nguồn của dự án (.NET 8.0 Solution)
│   ├── WordChainGame.sln             # File Solution chính quản lý các dự án thành phần
│   ├── WordChain.Common/             # Thư viện dùng chung (Mô hình Packet JSON, Logic gọi API từ điển kiểm tra từ)
│   ├── WordChain.Server/             # Ứng dụng máy chủ TCP Server (Console App)
│   ├── WordChain.Client/             # Ứng dụng client người chơi (Windows Forms GUI)
│   └── WordChain.StressTest/         # Công cụ giả lập stress test hiệu năng hệ thống
│
├── DOCX/             # Chứa tài liệu báo cáo của dự án (Định dạng Word DOC/DOCX)
│   └── Báo_cáo_đề_xuất_Lập_trình_mạng.docx
│
├── Extra/            # Chứa các thông tin bổ sung, hình ảnh minh chứng và kết quả đo hiệu năng
│   └── placeholders.txt
│
├── PPTX/             # Chứa file trình chiếu slide thuyết trình (Định dạng PowerPoint PPT/PPTX)
│   └── Thuyết_minh_đồ_án_Game_Nối_Từ.pptx
│
└── ReadMe.md         # File thông tin giới thiệu và tài liệu hướng dẫn của dự án (File này)
```

---

## 4. Các chức năng chính dự kiến hoàn thành
* **Đăng nhập**: Người chơi thiết lập Nickname và chọn hình đại diện (Avatar).
* **Kết nối & Lobby**: Client kết nối Socket TCP thời gian thực đến Server, hiển thị danh sách phòng hiện có.
* **Quản lý phòng**: Hỗ trợ tạo phòng chơi mới hoặc tham gia phòng thông qua mã phòng (Room Code).
* **Game logic realtime**: Chơi game nối từ theo lượt, đếm ngược thời gian cho mỗi lượt chơi (Timeout 15 giây).
* **Luật chơi nối từ**: Kiểm tra từ nối đúng quy tắc từ trước, không trùng lặp và xác thực thông qua API từ điển tiếng Việt.
* **Chat Room**: Kênh chat realtime giữa các người chơi trong phòng sảnh và trong trận đấu.
* **Xử lý mất kết nối**: Đảm bảo game tiếp tục vận hành ổn định và chuyển lượt khi một client đột ngột mất kết nối.
