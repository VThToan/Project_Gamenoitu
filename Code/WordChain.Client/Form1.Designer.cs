namespace WordChain.Client;

partial class Form1
{
    /// <summary>
    /// Biến designer bắt buộc để quản lý các thành phần (components) của giao diện.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Giải phóng các tài nguyên (như kết nối mạng, bộ nhớ) đang được sử dụng.
    /// </summary>
    /// <param name="disposing">true nếu các tài nguyên được giải phóng nên được giải tán; ngược lại là false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Phương thức bắt buộc cho hỗ trợ Designer của Visual Studio.
    /// KHÔNG ĐƯỢC TỰ Ý sửa đổi nội dung của phương thức này bằng trình soạn thảo mã nguồn nếu dùng kéo thả.
    /// Phương thức này dùng để khởi tạo kích thước cửa sổ, màu sắc, tiêu đề, và các nút điều khiển trên giao diện.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        
        // Thiết lập kích thước cửa sổ mặc định (Rộng 800, Cao 450)
        this.ClientSize = new System.Drawing.Size(800, 450);
        
        // Tiêu đề của cửa sổ ứng dụng Client
        this.Text = "Game Nối Từ Online";
        
        // TODO: Khi bạn kéo thả các Control (như Button, TextBox, Label) từ ToolBox của Visual Studio,
        // mã nguồn khởi tạo của chúng sẽ tự động được sinh ra thêm ở khu vực này.
    }

    #endregion
}
