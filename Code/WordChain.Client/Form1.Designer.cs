namespace WordChain.Client;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        pnlTopBar = new Panel();
        lblTenUngDung = new Label();
        tabMain = new TabControl();
        tabDangNhap = new TabPage();
        cardDangNhap = new Panel();
        btnDangNhap = new Button();
        lnkQuenMatKhau = new LinkLabel();
        chkGhiNhoDangNhap = new CheckBox();
        txtDangNhapMatKhau = new TextBox();
        txtDangNhapTenDangNhap = new TextBox();
        btnTabChoiNhanh = new Button();
        btnTabDangKy = new Button();
        btnTabDangNhap = new Button();
        lblLogoOnline = new Label();
        lblLogoGame = new Label();
        tabDangKy = new TabPage();
        cardDangKy = new Panel();
        lnkDangNhapNgay = new LinkLabel();
        lblDaCoTaiKhoan = new Label();
        btnDangKy = new Button();
        txtDangKyNhapLaiMatKhau = new TextBox();
        txtDangKyMatKhau = new TextBox();
        txtDangKyTenDangNhap = new TextBox();
        lblDangKyTieuDe = new Label();
        tabChoiNhanh = new TabPage();
        cardChoiNhanh = new Panel();
        lnkDangKyNgay = new LinkLabel();
        lblChuaCoTaiKhoan = new Label();
        btnBatDauChoiNhanh = new Button();
        avatar5 = new Panel();
        avatar4 = new Panel();
        avatar3 = new Panel();
        avatar2 = new Panel();
        avatar1 = new Panel();
        txtChoiNhanhTenNguoiChoi = new TextBox();
        lblAvatarMau = new Label();
        lblChoiNhanhMoTa = new Label();
        lblChoiNhanhTieuDe = new Label();
        tabSanhCho = new TabPage();
        pnlSanhChoNoiDung = new Panel();
        lblPhongNoiBat = new Label();
        lstPhongNoiBat = new ListBox();
        lblTrangThaiPhong = new Label();
        cardThamGiaPhong = new Panel();
        btnThamGiaPhong = new Button();
        lblMoTaThamGiaPhong = new Label();
        lblTieuDeThamGiaPhong = new Label();
        lblIconThamGiaPhong = new Label();
        cardTaoPhong = new Panel();
        btnTaoPhong = new Button();
        lblMoTaTaoPhong = new Label();
        lblTieuDeTaoPhong = new Label();
        lblIconTaoPhong = new Label();
        lblMoTaSanhCho = new Label();
        lblTieuDeSanhCho = new Label();
        pnlSanhChoMenu = new Panel();
        btnThoat = new Button();
        btnCaiDat = new Button();
        btnBangXepHang = new Button();
        btnBanBe = new Button();
        btnMenuThamGiaPhong = new Button();
        btnMenuTaoPhong = new Button();
        btnMenuSanhCho = new Button();
        lblTrangThaiOnline = new Label();
        lblTenNguoiChoiSanh = new Label();
        lblAvatarSanhCho = new Label();
        tabPhongChoi = new TabPage();
        pnlPhongChoi = new Panel();
        cardThongTinTranDau = new Panel();
        lblThongTinChiTiet = new Label();
        cardChat = new Panel();
        btnGuiChat = new Button();
        txtTinNhan = new TextBox();
        lstChatTrongPhong = new ListBox();
        lblTrangThaiChat = new Label();
        lblChat = new Label();
        cardLichSuVaNguoiChoi = new Panel();
        lstNguoiChoi = new ListBox();
        lblTrangThaiNguoiChoi = new Label();
        lblDanhSachNguoiChoi = new Label();
        cardGame = new Panel();
        btnGuiTu = new Button();
        txtNhapTu = new TextBox();
        lblNhapTu = new Label();
        lblHuongDanNoiTu = new Label();
        lblTuHienTai = new Label();
        lblTieuDeTuHienTai = new Label();
        lblBoDem = new Label();
        lblLuotChoi = new Label();
        pnlPhongTop = new Panel();
        btnRoiPhong = new Button();
        lblThongTinPhong = new Label();
        pnlTopBar.SuspendLayout();
        tabMain.SuspendLayout();
        tabDangNhap.SuspendLayout();
        cardDangNhap.SuspendLayout();
        tabDangKy.SuspendLayout();
        cardDangKy.SuspendLayout();
        tabChoiNhanh.SuspendLayout();
        cardChoiNhanh.SuspendLayout();
        tabSanhCho.SuspendLayout();
        pnlSanhChoNoiDung.SuspendLayout();
        cardThamGiaPhong.SuspendLayout();
        cardTaoPhong.SuspendLayout();
        pnlSanhChoMenu.SuspendLayout();
        tabPhongChoi.SuspendLayout();
        pnlPhongChoi.SuspendLayout();
        cardThongTinTranDau.SuspendLayout();
        cardChat.SuspendLayout();
        cardLichSuVaNguoiChoi.SuspendLayout();
        cardGame.SuspendLayout();
        pnlPhongTop.SuspendLayout();
        SuspendLayout();
        // 
        // pnlTopBar
        // 
        pnlTopBar.BackColor = Color.FromArgb(246, 248, 252);
        pnlTopBar.Controls.Add(lblTenUngDung);
        pnlTopBar.Dock = DockStyle.Top;
        pnlTopBar.Location = new Point(0, 0);
        pnlTopBar.Name = "pnlTopBar";
        pnlTopBar.Size = new Size(1440, 48);
        pnlTopBar.TabIndex = 0;
        // 
        // lblTenUngDung
        // 
        lblTenUngDung.AutoSize = true;
        lblTenUngDung.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        lblTenUngDung.ForeColor = Color.FromArgb(40, 65, 120);
        lblTenUngDung.Location = new Point(22, 13);
        lblTenUngDung.Name = "lblTenUngDung";
        lblTenUngDung.Size = new Size(157, 20);
        lblTenUngDung.TabIndex = 0;
        lblTenUngDung.Text = "Game Nối Từ Online";
        // 
        // tabMain
        // 
        tabMain.Alignment = TabAlignment.Bottom;
        tabMain.Controls.Add(tabDangNhap);
        tabMain.Controls.Add(tabDangKy);
        tabMain.Controls.Add(tabChoiNhanh);
        tabMain.Controls.Add(tabSanhCho);
        tabMain.Controls.Add(tabPhongChoi);
        tabMain.Dock = DockStyle.Fill;
        tabMain.ItemSize = new Size(0, 1);
        tabMain.Location = new Point(0, 48);
        tabMain.Multiline = true;
        tabMain.Name = "tabMain";
        tabMain.SelectedIndex = 0;
        tabMain.Size = new Size(1440, 852);
        tabMain.SizeMode = TabSizeMode.Fixed;
        tabMain.TabIndex = 1;
        // 
        // tabDangNhap
        // 
        tabDangNhap.BackColor = Color.FromArgb(41, 88, 197);
        tabDangNhap.Controls.Add(cardDangNhap);
        tabDangNhap.Controls.Add(lblLogoOnline);
        tabDangNhap.Controls.Add(lblLogoGame);
        tabDangNhap.Location = new Point(4, 4);
        tabDangNhap.Name = "tabDangNhap";
        tabDangNhap.Size = new Size(1432, 843);
        tabDangNhap.TabIndex = 0;
        // 
        // cardDangNhap
        // 
        cardDangNhap.BackColor = Color.White;
        cardDangNhap.Controls.Add(btnDangNhap);
        cardDangNhap.Controls.Add(lnkQuenMatKhau);
        cardDangNhap.Controls.Add(chkGhiNhoDangNhap);
        cardDangNhap.Controls.Add(txtDangNhapMatKhau);
        cardDangNhap.Controls.Add(txtDangNhapTenDangNhap);
        cardDangNhap.Controls.Add(btnTabChoiNhanh);
        cardDangNhap.Controls.Add(btnTabDangKy);
        cardDangNhap.Controls.Add(btnTabDangNhap);
        cardDangNhap.Location = new Point(456, 257);
        cardDangNhap.Name = "cardDangNhap";
        cardDangNhap.Size = new Size(520, 355);
        cardDangNhap.TabIndex = 2;
        // 
        // btnDangNhap
        // 
        btnDangNhap.BackColor = Color.FromArgb(46, 106, 226);
        btnDangNhap.FlatAppearance.BorderSize = 0;
        btnDangNhap.FlatStyle = FlatStyle.Flat;
        btnDangNhap.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
        btnDangNhap.ForeColor = Color.White;
        btnDangNhap.Location = new Point(30, 245);
        btnDangNhap.Name = "btnDangNhap";
        btnDangNhap.Size = new Size(460, 48);
        btnDangNhap.TabIndex = 7;
        btnDangNhap.Text = "ĐĂNG NHẬP";
        btnDangNhap.UseVisualStyleBackColor = false;
        btnDangNhap.Click += btnDangNhap_Click;
        // 
        // lnkQuenMatKhau
        // 
        lnkQuenMatKhau.ActiveLinkColor = Color.FromArgb(46, 106, 226);
        lnkQuenMatKhau.AutoSize = true;
        lnkQuenMatKhau.LinkColor = Color.FromArgb(46, 106, 226);
        lnkQuenMatKhau.Location = new Point(382, 207);
        lnkQuenMatKhau.Name = "lnkQuenMatKhau";
        lnkQuenMatKhau.Size = new Size(89, 15);
        lnkQuenMatKhau.TabIndex = 6;
        lnkQuenMatKhau.TabStop = true;
        lnkQuenMatKhau.Text = "Quên mật khẩu?";
        // 
        // chkGhiNhoDangNhap
        // 
        chkGhiNhoDangNhap.AutoSize = true;
        chkGhiNhoDangNhap.Location = new Point(32, 206);
        chkGhiNhoDangNhap.Name = "chkGhiNhoDangNhap";
        chkGhiNhoDangNhap.Size = new Size(117, 19);
        chkGhiNhoDangNhap.TabIndex = 5;
        chkGhiNhoDangNhap.Text = "Ghi nhớ đăng nhập";
        chkGhiNhoDangNhap.UseVisualStyleBackColor = true;
        // 
        // txtDangNhapMatKhau
        // 
        txtDangNhapMatKhau.Font = new Font("Segoe UI", 12F);
        txtDangNhapMatKhau.Location = new Point(30, 147);
        txtDangNhapMatKhau.Name = "txtDangNhapMatKhau";
        txtDangNhapMatKhau.PlaceholderText = "Mật khẩu";
        txtDangNhapMatKhau.Size = new Size(460, 29);
        txtDangNhapMatKhau.TabIndex = 4;
        txtDangNhapMatKhau.UseSystemPasswordChar = true;
        // 
        // txtDangNhapTenDangNhap
        // 
        txtDangNhapTenDangNhap.Font = new Font("Segoe UI", 12F);
        txtDangNhapTenDangNhap.Location = new Point(30, 94);
        txtDangNhapTenDangNhap.Name = "txtDangNhapTenDangNhap";
        txtDangNhapTenDangNhap.PlaceholderText = "Tên đăng nhập";
        txtDangNhapTenDangNhap.Size = new Size(460, 29);
        txtDangNhapTenDangNhap.TabIndex = 3;
        // 
        // btnTabChoiNhanh
        // 
        btnTabChoiNhanh.BackColor = Color.White;
        btnTabChoiNhanh.FlatAppearance.BorderSize = 0;
        btnTabChoiNhanh.FlatStyle = FlatStyle.Flat;
        btnTabChoiNhanh.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        btnTabChoiNhanh.ForeColor = Color.FromArgb(70, 84, 111);
        btnTabChoiNhanh.Location = new Point(346, 19);
        btnTabChoiNhanh.Name = "btnTabChoiNhanh";
        btnTabChoiNhanh.Size = new Size(144, 36);
        btnTabChoiNhanh.TabIndex = 2;
        btnTabChoiNhanh.Text = "CHƠI NHANH";
        btnTabChoiNhanh.UseVisualStyleBackColor = false;
        btnTabChoiNhanh.Click += btnTabChoiNhanh_Click;
        // 
        // btnTabDangKy
        // 
        btnTabDangKy.BackColor = Color.White;
        btnTabDangKy.FlatAppearance.BorderSize = 0;
        btnTabDangKy.FlatStyle = FlatStyle.Flat;
        btnTabDangKy.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        btnTabDangKy.ForeColor = Color.FromArgb(70, 84, 111);
        btnTabDangKy.Location = new Point(180, 19);
        btnTabDangKy.Name = "btnTabDangKy";
        btnTabDangKy.Size = new Size(144, 36);
        btnTabDangKy.TabIndex = 1;
        btnTabDangKy.Text = "ĐĂNG KÝ";
        btnTabDangKy.UseVisualStyleBackColor = false;
        btnTabDangKy.Click += btnTabDangKy_Click;
        // 
        // btnTabDangNhap
        // 
        btnTabDangNhap.BackColor = Color.White;
        btnTabDangNhap.FlatAppearance.BorderSize = 0;
        btnTabDangNhap.FlatStyle = FlatStyle.Flat;
        btnTabDangNhap.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold | FontStyle.Underline);
        btnTabDangNhap.ForeColor = Color.FromArgb(46, 106, 226);
        btnTabDangNhap.Location = new Point(16, 19);
        btnTabDangNhap.Name = "btnTabDangNhap";
        btnTabDangNhap.Size = new Size(144, 36);
        btnTabDangNhap.TabIndex = 0;
        btnTabDangNhap.Text = "ĐĂNG NHẬP";
        btnTabDangNhap.UseVisualStyleBackColor = false;
        btnTabDangNhap.Click += btnTabDangNhap_Click;
        // 
        // lblLogoOnline
        // 
        lblLogoOnline.AutoSize = true;
        lblLogoOnline.BackColor = Color.FromArgb(46, 106, 226);
        lblLogoOnline.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
        lblLogoOnline.ForeColor = Color.White;
        lblLogoOnline.Location = new Point(618, 189);
        lblLogoOnline.Name = "lblLogoOnline";
        lblLogoOnline.Padding = new Padding(10, 2, 10, 2);
        lblLogoOnline.Size = new Size(171, 36);
        lblLogoOnline.TabIndex = 1;
        lblLogoOnline.Text = "ONLINE";
        // 
        // lblLogoGame
        // 
        lblLogoGame.AutoSize = true;
        lblLogoGame.Font = new Font("Segoe UI Black", 34F, FontStyle.Bold);
        lblLogoGame.ForeColor = Color.FromArgb(255, 213, 92);
        lblLogoGame.Location = new Point(527, 72);
        lblLogoGame.Name = "lblLogoGame";
        lblLogoGame.Size = new Size(398, 124);
        lblLogoGame.TabIndex = 0;
        lblLogoGame.Text = "GAME\r\nNỐI TỪ";
        lblLogoGame.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // tabDangKy
        // 
        tabDangKy.BackColor = Color.FromArgb(41, 88, 197);
        tabDangKy.Controls.Add(cardDangKy);
        tabDangKy.Location = new Point(4, 4);
        tabDangKy.Name = "tabDangKy";
        tabDangKy.Size = new Size(1432, 843);
        tabDangKy.TabIndex = 1;
        // 
        // cardDangKy
        // 
        cardDangKy.BackColor = Color.White;
        cardDangKy.Controls.Add(lnkDangNhapNgay);
        cardDangKy.Controls.Add(lblDaCoTaiKhoan);
        cardDangKy.Controls.Add(btnDangKy);
        cardDangKy.Controls.Add(txtDangKyNhapLaiMatKhau);
        cardDangKy.Controls.Add(txtDangKyMatKhau);
        cardDangKy.Controls.Add(txtDangKyTenDangNhap);
        cardDangKy.Controls.Add(lblDangKyTieuDe);
        cardDangKy.Location = new Point(443, 158);
        cardDangKy.Name = "cardDangKy";
        cardDangKy.Size = new Size(546, 448);
        cardDangKy.TabIndex = 0;
        // 
        // lnkDangNhapNgay
        // 
        lnkDangNhapNgay.ActiveLinkColor = Color.FromArgb(46, 106, 226);
        lnkDangNhapNgay.AutoSize = true;
        lnkDangNhapNgay.LinkColor = Color.FromArgb(46, 106, 226);
        lnkDangNhapNgay.Location = new Point(299, 379);
        lnkDangNhapNgay.Name = "lnkDangNhapNgay";
        lnkDangNhapNgay.Size = new Size(89, 15);
        lnkDangNhapNgay.TabIndex = 6;
        lnkDangNhapNgay.TabStop = true;
        lnkDangNhapNgay.Text = "Đăng nhập ngay";
        lnkDangNhapNgay.LinkClicked += (sender, e) => btnMoDangNhapTuDangKy_Click(sender, EventArgs.Empty);
        // 
        // lblDaCoTaiKhoan
        // 
        lblDaCoTaiKhoan.AutoSize = true;
        lblDaCoTaiKhoan.Location = new Point(158, 379);
        lblDaCoTaiKhoan.Name = "lblDaCoTaiKhoan";
        lblDaCoTaiKhoan.Size = new Size(98, 15);
        lblDaCoTaiKhoan.TabIndex = 5;
        lblDaCoTaiKhoan.Text = "Đã có tài khoản?";
        // 
        // btnDangKy
        // 
        btnDangKy.BackColor = Color.FromArgb(46, 106, 226);
        btnDangKy.FlatAppearance.BorderSize = 0;
        btnDangKy.FlatStyle = FlatStyle.Flat;
        btnDangKy.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
        btnDangKy.ForeColor = Color.White;
        btnDangKy.Location = new Point(48, 296);
        btnDangKy.Name = "btnDangKy";
        btnDangKy.Size = new Size(451, 48);
        btnDangKy.TabIndex = 4;
        btnDangKy.Text = "ĐĂNG KÝ";
        btnDangKy.UseVisualStyleBackColor = false;
        btnDangKy.Click += btnDangKy_Click;
        // 
        // txtDangKyNhapLaiMatKhau
        // 
        txtDangKyNhapLaiMatKhau.Font = new Font("Segoe UI", 12F);
        txtDangKyNhapLaiMatKhau.Location = new Point(48, 227);
        txtDangKyNhapLaiMatKhau.Name = "txtDangKyNhapLaiMatKhau";
        txtDangKyNhapLaiMatKhau.PlaceholderText = "Nhập lại mật khẩu";
        txtDangKyNhapLaiMatKhau.Size = new Size(451, 29);
        txtDangKyNhapLaiMatKhau.TabIndex = 3;
        txtDangKyNhapLaiMatKhau.UseSystemPasswordChar = true;
        // 
        // txtDangKyMatKhau
        // 
        txtDangKyMatKhau.Font = new Font("Segoe UI", 12F);
        txtDangKyMatKhau.Location = new Point(48, 169);
        txtDangKyMatKhau.Name = "txtDangKyMatKhau";
        txtDangKyMatKhau.PlaceholderText = "Mật khẩu";
        txtDangKyMatKhau.Size = new Size(451, 29);
        txtDangKyMatKhau.TabIndex = 2;
        txtDangKyMatKhau.UseSystemPasswordChar = true;
        // 
        // txtDangKyTenDangNhap
        // 
        txtDangKyTenDangNhap.Font = new Font("Segoe UI", 12F);
        txtDangKyTenDangNhap.Location = new Point(48, 111);
        txtDangKyTenDangNhap.Name = "txtDangKyTenDangNhap";
        txtDangKyTenDangNhap.PlaceholderText = "Tên đăng nhập";
        txtDangKyTenDangNhap.Size = new Size(451, 29);
        txtDangKyTenDangNhap.TabIndex = 1;
        // 
        // lblDangKyTieuDe
        // 
        lblDangKyTieuDe.AutoSize = true;
        lblDangKyTieuDe.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold);
        lblDangKyTieuDe.ForeColor = Color.FromArgb(40, 65, 120);
        lblDangKyTieuDe.Location = new Point(147, 40);
        lblDangKyTieuDe.Name = "lblDangKyTieuDe";
        lblDangKyTieuDe.Size = new Size(262, 37);
        lblDangKyTieuDe.TabIndex = 0;
        lblDangKyTieuDe.Text = "ĐĂNG KÝ TÀI KHOẢN";
        // 
        // tabChoiNhanh
        // 
        tabChoiNhanh.BackColor = Color.FromArgb(41, 88, 197);
        tabChoiNhanh.Controls.Add(cardChoiNhanh);
        tabChoiNhanh.Location = new Point(4, 4);
        tabChoiNhanh.Name = "tabChoiNhanh";
        tabChoiNhanh.Size = new Size(1432, 843);
        tabChoiNhanh.TabIndex = 2;
        // 
        // cardChoiNhanh
        // 
        cardChoiNhanh.BackColor = Color.White;
        cardChoiNhanh.Controls.Add(lnkDangKyNgay);
        cardChoiNhanh.Controls.Add(lblChuaCoTaiKhoan);
        cardChoiNhanh.Controls.Add(btnBatDauChoiNhanh);
        cardChoiNhanh.Controls.Add(avatar5);
        cardChoiNhanh.Controls.Add(avatar4);
        cardChoiNhanh.Controls.Add(avatar3);
        cardChoiNhanh.Controls.Add(avatar2);
        cardChoiNhanh.Controls.Add(avatar1);
        cardChoiNhanh.Controls.Add(txtChoiNhanhTenNguoiChoi);
        cardChoiNhanh.Controls.Add(lblAvatarMau);
        cardChoiNhanh.Controls.Add(lblChoiNhanhMoTa);
        cardChoiNhanh.Controls.Add(lblChoiNhanhTieuDe);
        cardChoiNhanh.Location = new Point(387, 112);
        cardChoiNhanh.Name = "cardChoiNhanh";
        cardChoiNhanh.Size = new Size(658, 557);
        cardChoiNhanh.TabIndex = 0;
        // 
        // lnkDangKyNgay
        // 
        lnkDangKyNgay.ActiveLinkColor = Color.FromArgb(46, 106, 226);
        lnkDangKyNgay.AutoSize = true;
        lnkDangKyNgay.LinkColor = Color.FromArgb(46, 106, 226);
        lnkDangKyNgay.Location = new Point(361, 489);
        lnkDangKyNgay.Name = "lnkDangKyNgay";
        lnkDangKyNgay.Size = new Size(76, 15);
        lnkDangKyNgay.TabIndex = 11;
        lnkDangKyNgay.TabStop = true;
        lnkDangKyNgay.Text = "Đăng ký ngay";
        lnkDangKyNgay.LinkClicked += (sender, e) => btnTabDangKy_Click(sender, EventArgs.Empty);
        // 
        // lblChuaCoTaiKhoan
        // 
        lblChuaCoTaiKhoan.AutoSize = true;
        lblChuaCoTaiKhoan.Location = new Point(214, 489);
        lblChuaCoTaiKhoan.Name = "lblChuaCoTaiKhoan";
        lblChuaCoTaiKhoan.Size = new Size(104, 15);
        lblChuaCoTaiKhoan.TabIndex = 10;
        lblChuaCoTaiKhoan.Text = "Bạn chưa có tài khoản?";
        // 
        // btnBatDauChoiNhanh
        // 
        btnBatDauChoiNhanh.BackColor = Color.FromArgb(82, 191, 84);
        btnBatDauChoiNhanh.FlatAppearance.BorderSize = 0;
        btnBatDauChoiNhanh.FlatStyle = FlatStyle.Flat;
        btnBatDauChoiNhanh.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
        btnBatDauChoiNhanh.ForeColor = Color.White;
        btnBatDauChoiNhanh.Location = new Point(104, 401);
        btnBatDauChoiNhanh.Name = "btnBatDauChoiNhanh";
        btnBatDauChoiNhanh.Size = new Size(450, 54);
        btnBatDauChoiNhanh.TabIndex = 9;
        btnBatDauChoiNhanh.Text = "BẮT ĐẦU CHƠI";
        btnBatDauChoiNhanh.UseVisualStyleBackColor = false;
        btnBatDauChoiNhanh.Click += btnBatDauChoiNhanh_Click;
        // 
        // avatar5
        // 
        avatar5.BackColor = Color.MediumOrchid;
        avatar5.Location = new Point(492, 325);
        avatar5.Name = "avatar5";
        avatar5.Size = new Size(38, 38);
        avatar5.TabIndex = 8;
        // 
        // avatar4
        // 
        avatar4.BackColor = Color.HotPink;
        avatar4.Location = new Point(427, 325);
        avatar4.Name = "avatar4";
        avatar4.Size = new Size(38, 38);
        avatar4.TabIndex = 7;
        // 
        // avatar3
        // 
        avatar3.BackColor = Color.Gold;
        avatar3.Location = new Point(362, 325);
        avatar3.Name = "avatar3";
        avatar3.Size = new Size(38, 38);
        avatar3.TabIndex = 6;
        // 
        // avatar2
        // 
        avatar2.BackColor = Color.YellowGreen;
        avatar2.Location = new Point(297, 325);
        avatar2.Name = "avatar2";
        avatar2.Size = new Size(38, 38);
        avatar2.TabIndex = 5;
        // 
        // avatar1
        // 
        avatar1.BackColor = Color.DodgerBlue;
        avatar1.Location = new Point(232, 325);
        avatar1.Name = "avatar1";
        avatar1.Size = new Size(38, 38);
        avatar1.TabIndex = 4;
        // 
        // txtChoiNhanhTenNguoiChoi
        // 
        txtChoiNhanhTenNguoiChoi.Font = new Font("Segoe UI", 12F);
        txtChoiNhanhTenNguoiChoi.Location = new Point(104, 252);
        txtChoiNhanhTenNguoiChoi.Name = "txtChoiNhanhTenNguoiChoi";
        txtChoiNhanhTenNguoiChoi.PlaceholderText = "Tên của bạn";
        txtChoiNhanhTenNguoiChoi.Size = new Size(450, 29);
        txtChoiNhanhTenNguoiChoi.TabIndex = 3;
        // 
        // lblAvatarMau
        // 
        lblAvatarMau.AutoSize = true;
        lblAvatarMau.Font = new Font("Segoe UI", 56F);
        lblAvatarMau.Location = new Point(257, 114);
        lblAvatarMau.Name = "lblAvatarMau";
        lblAvatarMau.Size = new Size(147, 100);
        lblAvatarMau.TabIndex = 2;
        lblAvatarMau.Text = "🐱";
        // 
        // lblChoiNhanhMoTa
        // 
        lblChoiNhanhMoTa.AutoSize = true;
        lblChoiNhanhMoTa.Font = new Font("Segoe UI", 11F);
        lblChoiNhanhMoTa.ForeColor = Color.FromArgb(82, 97, 126);
        lblChoiNhanhMoTa.Location = new Point(190, 72);
        lblChoiNhanhMoTa.Name = "lblChoiNhanhMoTa";
        lblChoiNhanhMoTa.Size = new Size(278, 20);
        lblChoiNhanhMoTa.TabIndex = 1;
        lblChoiNhanhMoTa.Text = "Nhập tên của bạn và bắt đầu chơi ngay!";
        // 
        // lblChoiNhanhTieuDe
        // 
        lblChoiNhanhTieuDe.AutoSize = true;
        lblChoiNhanhTieuDe.Font = new Font("Segoe UI Black", 22F, FontStyle.Bold);
        lblChoiNhanhTieuDe.ForeColor = Color.FromArgb(40, 65, 120);
        lblChoiNhanhTieuDe.Location = new Point(234, 25);
        lblChoiNhanhTieuDe.Name = "lblChoiNhanhTieuDe";
        lblChoiNhanhTieuDe.Size = new Size(191, 41);
        lblChoiNhanhTieuDe.TabIndex = 0;
        lblChoiNhanhTieuDe.Text = "CHƠI NHANH";
        // 
        // tabSanhCho
        // 
        tabSanhCho.BackColor = Color.FromArgb(245, 247, 251);
        tabSanhCho.Controls.Add(pnlSanhChoNoiDung);
        tabSanhCho.Controls.Add(pnlSanhChoMenu);
        tabSanhCho.Location = new Point(4, 4);
        tabSanhCho.Name = "tabSanhCho";
        tabSanhCho.Size = new Size(1432, 843);
        tabSanhCho.TabIndex = 3;
        // 
        // pnlSanhChoNoiDung
        // 
        pnlSanhChoNoiDung.Controls.Add(lblPhongNoiBat);
        pnlSanhChoNoiDung.Controls.Add(lblTrangThaiPhong);
        pnlSanhChoNoiDung.Controls.Add(lstPhongNoiBat);
        pnlSanhChoNoiDung.Controls.Add(cardThamGiaPhong);
        pnlSanhChoNoiDung.Controls.Add(cardTaoPhong);
        pnlSanhChoNoiDung.Controls.Add(lblMoTaSanhCho);
        pnlSanhChoNoiDung.Controls.Add(lblTieuDeSanhCho);
        pnlSanhChoNoiDung.Dock = DockStyle.Fill;
        pnlSanhChoNoiDung.Location = new Point(250, 0);
        pnlSanhChoNoiDung.Name = "pnlSanhChoNoiDung";
        pnlSanhChoNoiDung.Padding = new Padding(40, 34, 40, 34);
        pnlSanhChoNoiDung.Size = new Size(1182, 843);
        pnlSanhChoNoiDung.TabIndex = 1;
        // 
        // lblPhongNoiBat
        // 
        lblPhongNoiBat.AutoSize = true;
        lblPhongNoiBat.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
        lblPhongNoiBat.ForeColor = Color.FromArgb(40, 65, 120);
        lblPhongNoiBat.Location = new Point(43, 436);
        lblPhongNoiBat.Name = "lblPhongNoiBat";
        lblPhongNoiBat.Size = new Size(160, 32);
        lblPhongNoiBat.TabIndex = 5;
        lblPhongNoiBat.Text = "PHÒNG NỔI BẬT";
        // 
        // lstPhongNoiBat
        // 
        lstPhongNoiBat.BorderStyle = BorderStyle.None;
        lstPhongNoiBat.Font = new Font("Segoe UI", 13F);
        lstPhongNoiBat.FormattingEnabled = true;
        lstPhongNoiBat.ItemHeight = 23;
        lstPhongNoiBat.Location = new Point(48, 490);
        lstPhongNoiBat.Name = "lstPhongNoiBat";
        lstPhongNoiBat.Size = new Size(1032, 184);
        lstPhongNoiBat.TabIndex = 4;
        // 
        // lblTrangThaiPhong
        // 
        lblTrangThaiPhong.AutoSize = true;
        lblTrangThaiPhong.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
        lblTrangThaiPhong.ForeColor = Color.FromArgb(109, 123, 150);
        lblTrangThaiPhong.Location = new Point(48, 490);
        lblTrangThaiPhong.Name = "lblTrangThaiPhong";
        lblTrangThaiPhong.Size = new Size(222, 20);
        lblTrangThaiPhong.TabIndex = 6;
        lblTrangThaiPhong.Text = "Hiện chưa có phòng nào sẵn sàng.";
        // 
        // cardThamGiaPhong
        // 
        cardThamGiaPhong.BackColor = Color.White;
        cardThamGiaPhong.Controls.Add(btnThamGiaPhong);
        cardThamGiaPhong.Controls.Add(lblMoTaThamGiaPhong);
        cardThamGiaPhong.Controls.Add(lblTieuDeThamGiaPhong);
        cardThamGiaPhong.Controls.Add(lblIconThamGiaPhong);
        cardThamGiaPhong.Location = new Point(615, 138);
        cardThamGiaPhong.Name = "cardThamGiaPhong";
        cardThamGiaPhong.Size = new Size(462, 236);
        cardThamGiaPhong.TabIndex = 3;
        // 
        // btnThamGiaPhong
        // 
        btnThamGiaPhong.BackColor = Color.FromArgb(46, 106, 226);
        btnThamGiaPhong.FlatAppearance.BorderSize = 0;
        btnThamGiaPhong.FlatStyle = FlatStyle.Flat;
        btnThamGiaPhong.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        btnThamGiaPhong.ForeColor = Color.White;
        btnThamGiaPhong.Location = new Point(133, 168);
        btnThamGiaPhong.Name = "btnThamGiaPhong";
        btnThamGiaPhong.Size = new Size(189, 42);
        btnThamGiaPhong.TabIndex = 3;
        btnThamGiaPhong.Text = "THAM GIA";
        btnThamGiaPhong.UseVisualStyleBackColor = false;
        btnThamGiaPhong.Click += btnThamGiaPhong_Click;
        // 
        // lblMoTaThamGiaPhong
        // 
        lblMoTaThamGiaPhong.AutoSize = true;
        lblMoTaThamGiaPhong.Font = new Font("Segoe UI", 10F);
        lblMoTaThamGiaPhong.ForeColor = Color.FromArgb(82, 97, 126);
        lblMoTaThamGiaPhong.Location = new Point(108, 105);
        lblMoTaThamGiaPhong.Name = "lblMoTaThamGiaPhong";
        lblMoTaThamGiaPhong.Size = new Size(241, 38);
        lblMoTaThamGiaPhong.TabIndex = 2;
        lblMoTaThamGiaPhong.Text = "Nhập mã phòng để\r\ntham gia cùng mọi người";
        lblMoTaThamGiaPhong.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTieuDeThamGiaPhong
        // 
        lblTieuDeThamGiaPhong.AutoSize = true;
        lblTieuDeThamGiaPhong.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
        lblTieuDeThamGiaPhong.ForeColor = Color.FromArgb(40, 65, 120);
        lblTieuDeThamGiaPhong.Location = new Point(123, 67);
        lblTieuDeThamGiaPhong.Name = "lblTieuDeThamGiaPhong";
        lblTieuDeThamGiaPhong.Size = new Size(213, 32);
        lblTieuDeThamGiaPhong.TabIndex = 1;
        lblTieuDeThamGiaPhong.Text = "THAM GIA PHÒNG";
        // 
        // lblIconThamGiaPhong
        // 
        lblIconThamGiaPhong.AutoSize = true;
        lblIconThamGiaPhong.Font = new Font("Segoe UI", 38F);
        lblIconThamGiaPhong.Location = new Point(187, 0);
        lblIconThamGiaPhong.Name = "lblIconThamGiaPhong";
        lblIconThamGiaPhong.Size = new Size(88, 68);
        lblIconThamGiaPhong.TabIndex = 0;
        lblIconThamGiaPhong.Text = "↪";
        // 
        // cardTaoPhong
        // 
        cardTaoPhong.BackColor = Color.White;
        cardTaoPhong.Controls.Add(btnTaoPhong);
        cardTaoPhong.Controls.Add(lblMoTaTaoPhong);
        cardTaoPhong.Controls.Add(lblTieuDeTaoPhong);
        cardTaoPhong.Controls.Add(lblIconTaoPhong);
        cardTaoPhong.Location = new Point(48, 138);
        cardTaoPhong.Name = "cardTaoPhong";
        cardTaoPhong.Size = new Size(462, 236);
        cardTaoPhong.TabIndex = 2;
        // 
        // btnTaoPhong
        // 
        btnTaoPhong.BackColor = Color.FromArgb(46, 106, 226);
        btnTaoPhong.FlatAppearance.BorderSize = 0;
        btnTaoPhong.FlatStyle = FlatStyle.Flat;
        btnTaoPhong.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        btnTaoPhong.ForeColor = Color.White;
        btnTaoPhong.Location = new Point(136, 168);
        btnTaoPhong.Name = "btnTaoPhong";
        btnTaoPhong.Size = new Size(189, 42);
        btnTaoPhong.TabIndex = 3;
        btnTaoPhong.Text = "TẠO NGAY";
        btnTaoPhong.UseVisualStyleBackColor = false;
        btnTaoPhong.Click += btnTaoPhong_Click;
        // 
        // lblMoTaTaoPhong
        // 
        lblMoTaTaoPhong.AutoSize = true;
        lblMoTaTaoPhong.Font = new Font("Segoe UI", 10F);
        lblMoTaTaoPhong.ForeColor = Color.FromArgb(82, 97, 126);
        lblMoTaTaoPhong.Location = new Point(131, 105);
        lblMoTaTaoPhong.Name = "lblMoTaTaoPhong";
        lblMoTaTaoPhong.Size = new Size(195, 38);
        lblMoTaTaoPhong.TabIndex = 2;
        lblMoTaTaoPhong.Text = "Tạo phòng mới\r\nvà mời bạn bè cùng chơi";
        lblMoTaTaoPhong.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTieuDeTaoPhong
        // 
        lblTieuDeTaoPhong.AutoSize = true;
        lblTieuDeTaoPhong.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
        lblTieuDeTaoPhong.ForeColor = Color.FromArgb(40, 65, 120);
        lblTieuDeTaoPhong.Location = new Point(145, 67);
        lblTieuDeTaoPhong.Name = "lblTieuDeTaoPhong";
        lblTieuDeTaoPhong.Size = new Size(174, 32);
        lblTieuDeTaoPhong.TabIndex = 1;
        lblTieuDeTaoPhong.Text = "TẠO PHÒNG";
        // 
        // lblIconTaoPhong
        // 
        lblIconTaoPhong.AutoSize = true;
        lblIconTaoPhong.Font = new Font("Segoe UI", 38F);
        lblIconTaoPhong.Location = new Point(188, 0);
        lblIconTaoPhong.Name = "lblIconTaoPhong";
        lblIconTaoPhong.Size = new Size(80, 68);
        lblIconTaoPhong.TabIndex = 0;
        lblIconTaoPhong.Text = "+";
        // 
        // lblMoTaSanhCho
        // 
        lblMoTaSanhCho.AutoSize = true;
        lblMoTaSanhCho.Font = new Font("Segoe UI", 12F);
        lblMoTaSanhCho.ForeColor = Color.FromArgb(82, 97, 126);
        lblMoTaSanhCho.Location = new Point(44, 78);
        lblMoTaSanhCho.Name = "lblMoTaSanhCho";
        lblMoTaSanhCho.Size = new Size(200, 21);
        lblMoTaSanhCho.TabIndex = 1;
        lblMoTaSanhCho.Text = "Chọn chế độ để bắt đầu chơi";
        // 
        // lblTieuDeSanhCho
        // 
        lblTieuDeSanhCho.AutoSize = true;
        lblTieuDeSanhCho.Font = new Font("Segoe UI Black", 26F, FontStyle.Bold);
        lblTieuDeSanhCho.ForeColor = Color.FromArgb(40, 65, 120);
        lblTieuDeSanhCho.Location = new Point(38, 28);
        lblTieuDeSanhCho.Name = "lblTieuDeSanhCho";
        lblTieuDeSanhCho.Size = new Size(174, 47);
        lblTieuDeSanhCho.TabIndex = 0;
        lblTieuDeSanhCho.Text = "SẢNH CHỜ";
        // 
        // pnlSanhChoMenu
        // 
        pnlSanhChoMenu.BackColor = Color.White;
        pnlSanhChoMenu.Controls.Add(btnThoat);
        pnlSanhChoMenu.Controls.Add(btnCaiDat);
        pnlSanhChoMenu.Controls.Add(btnBangXepHang);
        pnlSanhChoMenu.Controls.Add(btnBanBe);
        pnlSanhChoMenu.Controls.Add(btnMenuThamGiaPhong);
        pnlSanhChoMenu.Controls.Add(btnMenuTaoPhong);
        pnlSanhChoMenu.Controls.Add(btnMenuSanhCho);
        pnlSanhChoMenu.Controls.Add(lblTrangThaiOnline);
        pnlSanhChoMenu.Controls.Add(lblTenNguoiChoiSanh);
        pnlSanhChoMenu.Controls.Add(lblAvatarSanhCho);
        pnlSanhChoMenu.Dock = DockStyle.Left;
        pnlSanhChoMenu.Location = new Point(0, 0);
        pnlSanhChoMenu.Name = "pnlSanhChoMenu";
        pnlSanhChoMenu.Size = new Size(250, 843);
        pnlSanhChoMenu.TabIndex = 0;
        // 
        // btnThoat
        // 
        btnThoat.FlatAppearance.BorderSize = 0;
        btnThoat.FlatStyle = FlatStyle.Flat;
        btnThoat.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        btnThoat.ForeColor = Color.IndianRed;
        btnThoat.Location = new Point(27, 742);
        btnThoat.Name = "btnThoat";
        btnThoat.Size = new Size(193, 42);
        btnThoat.TabIndex = 9;
        btnThoat.Text = "Thoát";
        btnThoat.UseVisualStyleBackColor = true;
        // 
        // btnCaiDat
        // 
        btnCaiDat.FlatAppearance.BorderSize = 0;
        btnCaiDat.FlatStyle = FlatStyle.Flat;
        btnCaiDat.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        btnCaiDat.ForeColor = Color.FromArgb(70, 84, 111);
        btnCaiDat.Location = new Point(27, 524);
        btnCaiDat.Name = "btnCaiDat";
        btnCaiDat.Size = new Size(193, 42);
        btnCaiDat.TabIndex = 8;
        btnCaiDat.Text = "Cài đặt";
        btnCaiDat.TextAlign = ContentAlignment.MiddleLeft;
        btnCaiDat.UseVisualStyleBackColor = true;
        // 
        // btnBangXepHang
        // 
        btnBangXepHang.FlatAppearance.BorderSize = 0;
        btnBangXepHang.FlatStyle = FlatStyle.Flat;
        btnBangXepHang.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        btnBangXepHang.ForeColor = Color.FromArgb(70, 84, 111);
        btnBangXepHang.Location = new Point(27, 476);
        btnBangXepHang.Name = "btnBangXepHang";
        btnBangXepHang.Size = new Size(193, 42);
        btnBangXepHang.TabIndex = 7;
        btnBangXepHang.Text = "Bảng xếp hạng";
        btnBangXepHang.TextAlign = ContentAlignment.MiddleLeft;
        btnBangXepHang.UseVisualStyleBackColor = true;
        // 
        // btnBanBe
        // 
        btnBanBe.FlatAppearance.BorderSize = 0;
        btnBanBe.FlatStyle = FlatStyle.Flat;
        btnBanBe.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        btnBanBe.ForeColor = Color.FromArgb(70, 84, 111);
        btnBanBe.Location = new Point(27, 428);
        btnBanBe.Name = "btnBanBe";
        btnBanBe.Size = new Size(193, 42);
        btnBanBe.TabIndex = 6;
        btnBanBe.Text = "Bạn bè";
        btnBanBe.TextAlign = ContentAlignment.MiddleLeft;
        btnBanBe.UseVisualStyleBackColor = true;
        // 
        // btnMenuThamGiaPhong
        // 
        btnMenuThamGiaPhong.FlatAppearance.BorderSize = 0;
        btnMenuThamGiaPhong.FlatStyle = FlatStyle.Flat;
        btnMenuThamGiaPhong.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        btnMenuThamGiaPhong.ForeColor = Color.FromArgb(70, 84, 111);
        btnMenuThamGiaPhong.Location = new Point(27, 380);
        btnMenuThamGiaPhong.Name = "btnMenuThamGiaPhong";
        btnMenuThamGiaPhong.Size = new Size(193, 42);
        btnMenuThamGiaPhong.TabIndex = 5;
        btnMenuThamGiaPhong.Text = "Tham gia phòng";
        btnMenuThamGiaPhong.TextAlign = ContentAlignment.MiddleLeft;
        btnMenuThamGiaPhong.UseVisualStyleBackColor = true;
        // 
        // btnMenuTaoPhong
        // 
        btnMenuTaoPhong.FlatAppearance.BorderSize = 0;
        btnMenuTaoPhong.FlatStyle = FlatStyle.Flat;
        btnMenuTaoPhong.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        btnMenuTaoPhong.ForeColor = Color.FromArgb(70, 84, 111);
        btnMenuTaoPhong.Location = new Point(27, 332);
        btnMenuTaoPhong.Name = "btnMenuTaoPhong";
        btnMenuTaoPhong.Size = new Size(193, 42);
        btnMenuTaoPhong.TabIndex = 4;
        btnMenuTaoPhong.Text = "Tạo phòng";
        btnMenuTaoPhong.TextAlign = ContentAlignment.MiddleLeft;
        btnMenuTaoPhong.UseVisualStyleBackColor = true;
        // 
        // btnMenuSanhCho
        // 
        btnMenuSanhCho.BackColor = Color.FromArgb(46, 106, 226);
        btnMenuSanhCho.FlatAppearance.BorderSize = 0;
        btnMenuSanhCho.FlatStyle = FlatStyle.Flat;
        btnMenuSanhCho.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        btnMenuSanhCho.ForeColor = Color.White;
        btnMenuSanhCho.Location = new Point(27, 284);
        btnMenuSanhCho.Name = "btnMenuSanhCho";
        btnMenuSanhCho.Size = new Size(193, 42);
        btnMenuSanhCho.TabIndex = 3;
        btnMenuSanhCho.Text = "Sảnh chờ";
        btnMenuSanhCho.TextAlign = ContentAlignment.MiddleLeft;
        btnMenuSanhCho.UseVisualStyleBackColor = false;
        // 
        // lblTrangThaiOnline
        // 
        lblTrangThaiOnline.AutoSize = true;
        lblTrangThaiOnline.ForeColor = Color.ForestGreen;
        lblTrangThaiOnline.Location = new Point(88, 151);
        lblTrangThaiOnline.Name = "lblTrangThaiOnline";
        lblTrangThaiOnline.Size = new Size(42, 15);
        lblTrangThaiOnline.TabIndex = 2;
        lblTrangThaiOnline.Text = "● Online";
        // 
        // lblTenNguoiChoiSanh
        // 
        lblTenNguoiChoiSanh.AutoSize = true;
        lblTenNguoiChoiSanh.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
        lblTenNguoiChoiSanh.ForeColor = Color.FromArgb(40, 65, 120);
        lblTenNguoiChoiSanh.Location = new Point(86, 121);
        lblTenNguoiChoiSanh.Name = "lblTenNguoiChoiSanh";
        lblTenNguoiChoiSanh.Size = new Size(91, 25);
        lblTenNguoiChoiSanh.TabIndex = 1;
        lblTenNguoiChoiSanh.Text = "PlayerOne";
        // 
        // lblAvatarSanhCho
        // 
        lblAvatarSanhCho.AutoSize = true;
        lblAvatarSanhCho.Font = new Font("Segoe UI", 34F);
        lblAvatarSanhCho.Location = new Point(24, 109);
        lblAvatarSanhCho.Name = "lblAvatarSanhCho";
        lblAvatarSanhCho.Size = new Size(86, 62);
        lblAvatarSanhCho.TabIndex = 0;
        lblAvatarSanhCho.Text = "🐱";
        // 
        // tabPhongChoi
        // 
        tabPhongChoi.BackColor = Color.FromArgb(245, 247, 251);
        tabPhongChoi.Controls.Add(pnlPhongChoi);
        tabPhongChoi.Controls.Add(pnlPhongTop);
        tabPhongChoi.Location = new Point(4, 4);
        tabPhongChoi.Name = "tabPhongChoi";
        tabPhongChoi.Size = new Size(1432, 843);
        tabPhongChoi.TabIndex = 4;
        // 
        // pnlPhongChoi
        // 
        pnlPhongChoi.Controls.Add(cardThongTinTranDau);
        pnlPhongChoi.Controls.Add(cardChat);
        pnlPhongChoi.Controls.Add(cardLichSuVaNguoiChoi);
        pnlPhongChoi.Controls.Add(cardGame);
        pnlPhongChoi.Dock = DockStyle.Fill;
        pnlPhongChoi.Location = new Point(0, 74);
        pnlPhongChoi.Name = "pnlPhongChoi";
        pnlPhongChoi.Padding = new Padding(28);
        pnlPhongChoi.Size = new Size(1432, 769);
        pnlPhongChoi.TabIndex = 1;
        // 
        // cardThongTinTranDau
        // 
        cardThongTinTranDau.BackColor = Color.White;
        cardThongTinTranDau.Controls.Add(lblThongTinChiTiet);
        cardThongTinTranDau.Location = new Point(369, 502);
        cardThongTinTranDau.Name = "cardThongTinTranDau";
        cardThongTinTranDau.Size = new Size(750, 177);
        cardThongTinTranDau.TabIndex = 3;
        // 
        // lblThongTinChiTiet
        // 
        lblThongTinChiTiet.AutoSize = true;
        lblThongTinChiTiet.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        lblThongTinChiTiet.ForeColor = Color.FromArgb(70, 84, 111);
        lblThongTinChiTiet.Location = new Point(31, 36);
        lblThongTinChiTiet.Name = "lblThongTinChiTiet";
        lblThongTinChiTiet.Size = new Size(468, 63);
        lblThongTinChiTiet.TabIndex = 0;
        lblThongTinChiTiet.Text = "THÔNG TIN TRẬN ĐẤU\r\nChế độ: Thường | Thời gian: 20 giây/lượt\r\nNgôn ngữ: Tiếng Việt | Số người tối đa: 6";
        // 
        // cardChat
        // 
        cardChat.BackColor = Color.White;
        cardChat.Controls.Add(btnGuiChat);
        cardChat.Controls.Add(txtTinNhan);
        cardChat.Controls.Add(lblTrangThaiChat);
        cardChat.Controls.Add(lstChatTrongPhong);
        cardChat.Controls.Add(lblChat);
        cardChat.Location = new Point(1148, 28);
        cardChat.Name = "cardChat";
        cardChat.Size = new Size(249, 651);
        cardChat.TabIndex = 2;
        // 
        // btnGuiChat
        // 
        btnGuiChat.BackColor = Color.FromArgb(46, 106, 226);
        btnGuiChat.FlatAppearance.BorderSize = 0;
        btnGuiChat.FlatStyle = FlatStyle.Flat;
        btnGuiChat.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        btnGuiChat.ForeColor = Color.White;
        btnGuiChat.Location = new Point(173, 593);
        btnGuiChat.Name = "btnGuiChat";
        btnGuiChat.Size = new Size(53, 33);
        btnGuiChat.TabIndex = 3;
        btnGuiChat.Text = "Gửi";
        btnGuiChat.UseVisualStyleBackColor = false;
        btnGuiChat.Click += btnGuiChat_Click;
        // 
        // txtTinNhan
        // 
        txtTinNhan.Location = new Point(22, 597);
        txtTinNhan.Name = "txtTinNhan";
        txtTinNhan.PlaceholderText = "Nhập tin nhắn...";
        txtTinNhan.Size = new Size(140, 23);
        txtTinNhan.TabIndex = 2;
        // 
        // lstChatTrongPhong
        // 
        lstChatTrongPhong.BorderStyle = BorderStyle.None;
        lstChatTrongPhong.Font = new Font("Segoe UI", 11F);
        lstChatTrongPhong.FormattingEnabled = true;
        lstChatTrongPhong.ItemHeight = 20;
        lstChatTrongPhong.Location = new Point(22, 63);
        lstChatTrongPhong.Name = "lstChatTrongPhong";
        lstChatTrongPhong.Size = new Size(204, 500);
        lstChatTrongPhong.TabIndex = 1;
        // 
        // lblTrangThaiChat
        // 
        lblTrangThaiChat.AutoSize = true;
        lblTrangThaiChat.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
        lblTrangThaiChat.ForeColor = Color.FromArgb(109, 123, 150);
        lblTrangThaiChat.Location = new Point(22, 63);
        lblTrangThaiChat.Name = "lblTrangThaiChat";
        lblTrangThaiChat.Size = new Size(204, 38);
        lblTrangThaiChat.TabIndex = 4;
        lblTrangThaiChat.Text = "Chat sẽ hiển thị khi có tin nhắn\r\nthực từ phòng chơi.";
        // 
        // lblChat
        // 
        lblChat.AutoSize = true;
        lblChat.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold);
        lblChat.ForeColor = Color.FromArgb(40, 65, 120);
        lblChat.Location = new Point(20, 18);
        lblChat.Name = "lblChat";
        lblChat.Size = new Size(72, 30);
        lblChat.TabIndex = 0;
        lblChat.Text = "CHAT";
        // 
        // cardLichSuVaNguoiChoi
        // 
        cardLichSuVaNguoiChoi.BackColor = Color.White;
        cardLichSuVaNguoiChoi.Controls.Add(lblTrangThaiNguoiChoi);
        cardLichSuVaNguoiChoi.Controls.Add(lstNguoiChoi);
        cardLichSuVaNguoiChoi.Controls.Add(lblDanhSachNguoiChoi);
        cardLichSuVaNguoiChoi.Location = new Point(28, 28);
        cardLichSuVaNguoiChoi.Name = "cardLichSuVaNguoiChoi";
        cardLichSuVaNguoiChoi.Size = new Size(303, 651);
        cardLichSuVaNguoiChoi.TabIndex = 1;
        // 
        // lstNguoiChoi
        // 
        lstNguoiChoi.BorderStyle = BorderStyle.None;
        lstNguoiChoi.Font = new Font("Segoe UI", 12F);
        lstNguoiChoi.FormattingEnabled = true;
        lstNguoiChoi.ItemHeight = 21;
        lstNguoiChoi.Location = new Point(24, 66);
        lstNguoiChoi.Name = "lstNguoiChoi";
        lstNguoiChoi.Size = new Size(251, 504);
        lstNguoiChoi.TabIndex = 1;
        // 
        // lblTrangThaiNguoiChoi
        // 
        lblTrangThaiNguoiChoi.AutoSize = true;
        lblTrangThaiNguoiChoi.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
        lblTrangThaiNguoiChoi.ForeColor = Color.FromArgb(109, 123, 150);
        lblTrangThaiNguoiChoi.Location = new Point(24, 66);
        lblTrangThaiNguoiChoi.Name = "lblTrangThaiNguoiChoi";
        lblTrangThaiNguoiChoi.Size = new Size(204, 38);
        lblTrangThaiNguoiChoi.TabIndex = 2;
        lblTrangThaiNguoiChoi.Text = "Chưa có người chơi trong phòng.\r\nHãy mời thêm bạn bè cùng tham gia.";
        // 
        // lblDanhSachNguoiChoi
        // 
        lblDanhSachNguoiChoi.AutoSize = true;
        lblDanhSachNguoiChoi.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold);
        lblDanhSachNguoiChoi.ForeColor = Color.FromArgb(40, 65, 120);
        lblDanhSachNguoiChoi.Location = new Point(20, 18);
        lblDanhSachNguoiChoi.Name = "lblDanhSachNguoiChoi";
        lblDanhSachNguoiChoi.Size = new Size(234, 30);
        lblDanhSachNguoiChoi.TabIndex = 0;
        lblDanhSachNguoiChoi.Text = "DANH SÁCH NGƯỜI CHƠI";
        // 
        // cardGame
        // 
        cardGame.BackColor = Color.White;
        cardGame.Controls.Add(btnGuiTu);
        cardGame.Controls.Add(txtNhapTu);
        cardGame.Controls.Add(lblNhapTu);
        cardGame.Controls.Add(lblHuongDanNoiTu);
        cardGame.Controls.Add(lblTuHienTai);
        cardGame.Controls.Add(lblTieuDeTuHienTai);
        cardGame.Controls.Add(lblBoDem);
        cardGame.Controls.Add(lblLuotChoi);
        cardGame.Location = new Point(369, 28);
        cardGame.Name = "cardGame";
        cardGame.Size = new Size(750, 447);
        cardGame.TabIndex = 0;
        // 
        // btnGuiTu
        // 
        btnGuiTu.BackColor = Color.FromArgb(46, 106, 226);
        btnGuiTu.FlatAppearance.BorderSize = 0;
        btnGuiTu.FlatStyle = FlatStyle.Flat;
        btnGuiTu.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
        btnGuiTu.ForeColor = Color.White;
        btnGuiTu.Location = new Point(569, 312);
        btnGuiTu.Name = "btnGuiTu";
        btnGuiTu.Size = new Size(124, 42);
        btnGuiTu.TabIndex = 7;
        btnGuiTu.Text = "GỬI";
        btnGuiTu.UseVisualStyleBackColor = false;
        btnGuiTu.Click += btnGuiTu_Click;
        // 
        // txtNhapTu
        // 
        txtNhapTu.Font = new Font("Segoe UI", 12F);
        txtNhapTu.Location = new Point(46, 319);
        txtNhapTu.Name = "txtNhapTu";
        txtNhapTu.PlaceholderText = "Nhập từ mới...";
        txtNhapTu.Size = new Size(490, 29);
        txtNhapTu.TabIndex = 6;
        // 
        // lblNhapTu
        // 
        lblNhapTu.AutoSize = true;
        lblNhapTu.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
        lblNhapTu.ForeColor = Color.FromArgb(40, 65, 120);
        lblNhapTu.Location = new Point(41, 276);
        lblNhapTu.Name = "lblNhapTu";
        lblNhapTu.Size = new Size(157, 25);
        lblNhapTu.TabIndex = 5;
        lblNhapTu.Text = "NHẬP TỪ CỦA BẠN";
        // 
        // lblHuongDanNoiTu
        // 
        lblHuongDanNoiTu.AutoSize = true;
        lblHuongDanNoiTu.Font = new Font("Segoe UI", 12F);
        lblHuongDanNoiTu.ForeColor = Color.ForestGreen;
        lblHuongDanNoiTu.Location = new Point(136, 222);
        lblHuongDanNoiTu.Name = "lblHuongDanNoiTu";
        lblHuongDanNoiTu.Size = new Size(396, 21);
        lblHuongDanNoiTu.TabIndex = 4;
        lblHuongDanNoiTu.Text = "Khi trò chơi bắt đầu, từ hiện tại sẽ hiển thị tại đây.";
        // 
        // lblTuHienTai
        // 
        lblTuHienTai.AutoSize = true;
        lblTuHienTai.Font = new Font("Segoe UI Black", 28F, FontStyle.Bold);
        lblTuHienTai.ForeColor = Color.FromArgb(40, 65, 120);
        lblTuHienTai.Location = new Point(281, 153);
        lblTuHienTai.Name = "lblTuHienTai";
        lblTuHienTai.Size = new Size(172, 51);
        lblTuHienTai.TabIndex = 3;
        lblTuHienTai.Text = "--";
        // 
        // lblTieuDeTuHienTai
        // 
        lblTieuDeTuHienTai.AutoSize = true;
        lblTieuDeTuHienTai.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
        lblTieuDeTuHienTai.ForeColor = Color.FromArgb(40, 65, 120);
        lblTieuDeTuHienTai.Location = new Point(45, 77);
        lblTieuDeTuHienTai.Name = "lblTieuDeTuHienTai";
        lblTieuDeTuHienTai.Size = new Size(117, 25);
        lblTieuDeTuHienTai.TabIndex = 2;
        lblTieuDeTuHienTai.Text = "TỪ HIỆN TẠI";
        // 
        // lblBoDem
        // 
        lblBoDem.AutoSize = true;
        lblBoDem.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold);
        lblBoDem.ForeColor = Color.ForestGreen;
        lblBoDem.Location = new Point(580, 24);
        lblBoDem.Name = "lblBoDem";
        lblBoDem.Size = new Size(104, 30);
        lblBoDem.TabIndex = 1;
        lblBoDem.Text = "15 GIÂY";
        // 
        // lblLuotChoi
        // 
        lblLuotChoi.AutoSize = true;
        lblLuotChoi.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
        lblLuotChoi.ForeColor = Color.FromArgb(40, 65, 120);
        lblLuotChoi.Location = new Point(42, 28);
        lblLuotChoi.Name = "lblLuotChoi";
        lblLuotChoi.Size = new Size(154, 25);
        lblLuotChoi.TabIndex = 0;
        lblLuotChoi.Text = "Lượt của: chưa xác định";
        // 
        // pnlPhongTop
        // 
        pnlPhongTop.BackColor = Color.White;
        pnlPhongTop.Controls.Add(btnRoiPhong);
        pnlPhongTop.Controls.Add(lblThongTinPhong);
        pnlPhongTop.Dock = DockStyle.Top;
        pnlPhongTop.Location = new Point(0, 0);
        pnlPhongTop.Name = "pnlPhongTop";
        pnlPhongTop.Size = new Size(1432, 74);
        pnlPhongTop.TabIndex = 0;
        // 
        // btnRoiPhong
        // 
        btnRoiPhong.BackColor = Color.White;
        btnRoiPhong.FlatStyle = FlatStyle.Flat;
        btnRoiPhong.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        btnRoiPhong.ForeColor = Color.IndianRed;
        btnRoiPhong.Location = new Point(1262, 18);
        btnRoiPhong.Name = "btnRoiPhong";
        btnRoiPhong.Size = new Size(132, 38);
        btnRoiPhong.TabIndex = 1;
        btnRoiPhong.Text = "Rời phòng";
        btnRoiPhong.UseVisualStyleBackColor = false;
        btnRoiPhong.Click += btnRoiPhong_Click;
        // 
        // lblThongTinPhong
        // 
        lblThongTinPhong.AutoSize = true;
        lblThongTinPhong.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold);
        lblThongTinPhong.ForeColor = Color.FromArgb(40, 65, 120);
        lblThongTinPhong.Location = new Point(28, 22);
        lblThongTinPhong.Name = "lblThongTinPhong";
        lblThongTinPhong.Size = new Size(269, 32);
        lblThongTinPhong.TabIndex = 0;
        lblThongTinPhong.Text = "Bạn chưa vào phòng nào";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1440, 900);
        Controls.Add(tabMain);
        Controls.Add(pnlTopBar);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Game Nối Từ Online";
        pnlTopBar.ResumeLayout(false);
        pnlTopBar.PerformLayout();
        tabMain.ResumeLayout(false);
        tabDangNhap.ResumeLayout(false);
        tabDangNhap.PerformLayout();
        cardDangNhap.ResumeLayout(false);
        cardDangNhap.PerformLayout();
        tabDangKy.ResumeLayout(false);
        cardDangKy.ResumeLayout(false);
        cardDangKy.PerformLayout();
        tabChoiNhanh.ResumeLayout(false);
        cardChoiNhanh.ResumeLayout(false);
        cardChoiNhanh.PerformLayout();
        tabSanhCho.ResumeLayout(false);
        pnlSanhChoNoiDung.ResumeLayout(false);
        pnlSanhChoNoiDung.PerformLayout();
        cardThamGiaPhong.ResumeLayout(false);
        cardThamGiaPhong.PerformLayout();
        cardTaoPhong.ResumeLayout(false);
        cardTaoPhong.PerformLayout();
        pnlSanhChoMenu.ResumeLayout(false);
        pnlSanhChoMenu.PerformLayout();
        tabPhongChoi.ResumeLayout(false);
        pnlPhongChoi.ResumeLayout(false);
        cardThongTinTranDau.ResumeLayout(false);
        cardThongTinTranDau.PerformLayout();
        cardChat.ResumeLayout(false);
        cardChat.PerformLayout();
        cardLichSuVaNguoiChoi.ResumeLayout(false);
        cardLichSuVaNguoiChoi.PerformLayout();
        cardGame.ResumeLayout(false);
        cardGame.PerformLayout();
        pnlPhongTop.ResumeLayout(false);
        pnlPhongTop.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlTopBar;
    private Label lblTenUngDung;
    private TabControl tabMain;
    private TabPage tabDangNhap;
    private TabPage tabDangKy;
    private TabPage tabChoiNhanh;
    private TabPage tabSanhCho;
    private TabPage tabPhongChoi;
    private Label lblLogoGame;
    private Label lblLogoOnline;
    private Panel cardDangNhap;
    private Button btnTabDangNhap;
    private Button btnTabDangKy;
    private Button btnTabChoiNhanh;
    private TextBox txtDangNhapTenDangNhap;
    private TextBox txtDangNhapMatKhau;
    private CheckBox chkGhiNhoDangNhap;
    private LinkLabel lnkQuenMatKhau;
    private Button btnDangNhap;
    private Panel cardDangKy;
    private Label lblDangKyTieuDe;
    private TextBox txtDangKyTenDangNhap;
    private TextBox txtDangKyMatKhau;
    private TextBox txtDangKyNhapLaiMatKhau;
    private Button btnDangKy;
    private Label lblDaCoTaiKhoan;
    private LinkLabel lnkDangNhapNgay;
    private Panel cardChoiNhanh;
    private Label lblChoiNhanhTieuDe;
    private Label lblChoiNhanhMoTa;
    private Label lblAvatarMau;
    private TextBox txtChoiNhanhTenNguoiChoi;
    private Panel avatar1;
    private Panel avatar2;
    private Panel avatar3;
    private Panel avatar4;
    private Panel avatar5;
    private Button btnBatDauChoiNhanh;
    private Label lblChuaCoTaiKhoan;
    private LinkLabel lnkDangKyNgay;
    private Panel pnlSanhChoMenu;
    private Label lblAvatarSanhCho;
    private Label lblTenNguoiChoiSanh;
    private Label lblTrangThaiOnline;
    private Button btnMenuSanhCho;
    private Button btnMenuTaoPhong;
    private Button btnMenuThamGiaPhong;
    private Button btnBanBe;
    private Button btnBangXepHang;
    private Button btnCaiDat;
    private Button btnThoat;
    private Panel pnlSanhChoNoiDung;
    private Label lblTieuDeSanhCho;
    private Label lblMoTaSanhCho;
    private Panel cardTaoPhong;
    private Label lblIconTaoPhong;
    private Label lblTieuDeTaoPhong;
    private Label lblMoTaTaoPhong;
    private Button btnTaoPhong;
    private Panel cardThamGiaPhong;
    private Button btnThamGiaPhong;
    private Label lblMoTaThamGiaPhong;
    private Label lblTieuDeThamGiaPhong;
    private Label lblIconThamGiaPhong;
    private ListBox lstPhongNoiBat;
    private Label lblPhongNoiBat;
    private Panel pnlPhongTop;
    private Label lblThongTinPhong;
    private Button btnRoiPhong;
    private Panel pnlPhongChoi;
    private Panel cardGame;
    private Panel cardLichSuVaNguoiChoi;
    private Panel cardChat;
    private Panel cardThongTinTranDau;
    private Label lblDanhSachNguoiChoi;
    private ListBox lstNguoiChoi;
    private Label lblLuotChoi;
    private Label lblBoDem;
    private Label lblTieuDeTuHienTai;
    private Label lblTuHienTai;
    private Label lblHuongDanNoiTu;
    private Label lblNhapTu;
    private TextBox txtNhapTu;
    private Button btnGuiTu;
    private Label lblChat;
    private ListBox lstChatTrongPhong;
    private TextBox txtTinNhan;
    private Button btnGuiChat;
    private Label lblThongTinChiTiet;
    private Label lblTrangThaiPhong;
    private Label lblTrangThaiChat;
    private Label lblTrangThaiNguoiChoi;
}
