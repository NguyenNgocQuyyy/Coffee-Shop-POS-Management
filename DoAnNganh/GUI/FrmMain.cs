using Đồ_án_ngành.BUS;
using Đồ_án_ngành.GUI;
using MODEL;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Đồ_án_ngành
{
    public partial class FrmMain : Form
    {
        private readonly BanBUS _banBUS = new BanBUS();
        private readonly NhanVien _nhanVienDangNhap;

        [DllImport("user32.dll")]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

        private const int SB_VERT = 1;

        public FrmMain(NhanVien nhanVien)
        {
            InitializeComponent();

            _nhanVienDangNhap = nhanVien;

            lblNguoiDung.Text = "Người dùng: " + _nhanVienDangNhap.TenDangNhap;

            TaoMenuChucNang();

            LoadDanhSachBan();

            flpBan.MouseClick += FlpBan_MouseClick;
        }

        private void TaoMenuChucNang()
        {
            string[] danhSachChucNang =
            {
                "QUẢN LÝ MENU",
                "QUẢN LÝ TOPPING",
                "CÔNG THỨC",
                "KHÁCH HÀNG",
                "KHUYẾN MÃI",
                "NHÀ CUNG CẤP",
                "KHO NGUYÊN LIỆU",
                "PHIẾU NHẬP",
                "PHIẾU XUẤT",
                "HÓA ĐƠN",
                "ĐỔI MẬT KHẨU",
                "BÁO CÁO DOANH THU",
                "DASHBOARD",
                "ĐĂNG XUẤT"
            };

            foreach (string tenChucNang in danhSachChucNang)
            {
                Image icon = null;

                switch (tenChucNang)
                {
                    case "QUẢN LÝ MENU":
                        icon = Properties.Resources.QuanLyMenu;
                        break;

                    case "QUẢN LÝ TOPPING":
                        icon = Properties.Resources.QuanLyTopping;
                        break;

                    case "CÔNG THỨC":
                        icon = Properties.Resources.CongThuc;
                        break;

                    case "KHÁCH HÀNG":
                        icon = Properties.Resources.KhachHang;
                        break;

                    case "KHUYẾN MÃI":
                        icon = Properties.Resources.KhuyenMai;
                        break;

                    case "NHÀ CUNG CẤP":
                        icon = Properties.Resources.NhaCungCap;
                        break;

                    case "KHO NGUYÊN LIỆU":
                        icon = Properties.Resources.KhoNguyenLieu;
                        break;

                    case "PHIẾU NHẬP":
                        icon = Properties.Resources.PhieuNhap;
                        break;

                    case "PHIẾU XUẤT":
                        icon = Properties.Resources.PhieuXuat;
                        break;

                    case "HÓA ĐƠN":
                        icon = Properties.Resources.HoaDon;
                        break;

                    case "ĐỔI MẬT KHẨU":
                        icon = Properties.Resources.QuanLyNhanVien;
                        break;

                    case "BÁO CÁO DOANH THU":
                        icon = Properties.Resources.BaoCaoDoanhThu;
                        break;

                    case "DASHBOARD":
                        icon = Properties.Resources.Dashboard;
                        break;

                    case "ĐĂNG XUẤT":
                        icon = Properties.Resources.DangXuat;
                        break;
                }

                Panel pnlItem = new Panel();

                pnlItem.Width = flpChucNang.ClientSize.Width - 20;
                pnlItem.Height = 100;
                pnlItem.Margin = new Padding(10);
                pnlItem.BackColor = Color.White;

                PictureBox picIcon = new PictureBox();

                picIcon.Width = 48;
                picIcon.Height = 48;
                picIcon.Location = new Point((pnlItem.Width - picIcon.Width) / 2,10);
                picIcon.SizeMode = PictureBoxSizeMode.Zoom;
                picIcon.Cursor = Cursors.Hand;
                picIcon.BackColor = Color.Transparent;
                picIcon.Image = icon;
                picIcon.Tag = tenChucNang;
                picIcon.Click += PicIcon_Click;

                pnlItem.Controls.Add(picIcon);

                Label lblTen = new Label();

                lblTen.Text = tenChucNang;
                lblTen.AutoSize = false;
                lblTen.Width = pnlItem.Width;
                lblTen.Height = 25;
                lblTen.Location = new Point(0, 70);
                lblTen.TextAlign = ContentAlignment.MiddleCenter;
                lblTen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                lblTen.ForeColor = Color.FromArgb(78, 47, 32);

                pnlItem.Controls.Add(lblTen);

                flpChucNang.Controls.Add(pnlItem);
            }
        }

        private void btnScrollDown_Click(object sender, EventArgs e)
        {
            int y = flpChucNang.VerticalScroll.Value + 100;

            if (y > flpChucNang.VerticalScroll.Maximum)
            {
                y = flpChucNang.VerticalScroll.Maximum;
            }

            flpChucNang.AutoScrollPosition = new Point(0, y);

            ShowScrollBar(flpChucNang.Handle, SB_VERT, false);
        }

        private void btnScrollUp_Click(object sender, EventArgs e)
        {
            int y = flpChucNang.VerticalScroll.Value - 100;

            if (y < flpChucNang.VerticalScroll.Minimum)
            {
                y = flpChucNang.VerticalScroll.Minimum;
            }

            flpChucNang.AutoScrollPosition = new Point(0, y);

            ShowScrollBar(flpChucNang.Handle, SB_VERT, false);
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            ShowScrollBar(flpChucNang.Handle, SB_VERT, false);
        }

        private void LoadDanhSachBan()
        {
            flpBan.Controls.Clear();

            var danhSachBan = _banBUS.GetAll();

            foreach (var ban in danhSachBan)
            {
                Panel pnlBan = new Panel();

                pnlBan.Width = 140;
                pnlBan.Height = 100;
                pnlBan.Margin = new Padding(12);
                pnlBan.Cursor = Cursors.Hand;
                pnlBan.Tag = ban;
                pnlBan.Click += PnlBan_Click;
                switch (ban.TrangThai)
                {
                    case "Trống":
                        pnlBan.BackColor = Color.FromArgb(230, 205, 175);
                        break;

                    case "Đang sử dụng":
                        pnlBan.BackColor = Color.FromArgb(198, 120, 90);
                        break;

                    case "Đang bảo trì":
                        pnlBan.BackColor = Color.FromArgb(180, 180, 180);
                        break;

                    default:
                        pnlBan.BackColor = Color.White;
                        break;
                }

                flpBan.Controls.Add(pnlBan);

                Label lblSoBan = new Label();

                lblSoBan.Text = ban.SoBan;
                lblSoBan.AutoSize = false;
                lblSoBan.Dock = DockStyle.Fill;
                lblSoBan.TextAlign = ContentAlignment.MiddleCenter;
                lblSoBan.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                lblSoBan.ForeColor = Color.FromArgb(78, 47, 32);

                pnlBan.Controls.Add(lblSoBan);

                lblSoBan.Cursor = Cursors.Hand;
                lblSoBan.Click += (s, e) => PnlBan_Click(pnlBan, e);
            }
        }

        private void PnlBan_Click(object sender, EventArgs e)
        {
            Panel pnlBan = sender as Panel;

            if (pnlBan == null)
                return;

            Ban ban = pnlBan.Tag as Ban;

            if (ban == null)
                return;

            // 1. MANAGER: bàn đang sử dụng giữ nguyên ràng buộc cũ
            if (_nhanVienDangNhap.ChucVu == "Manager" &&
                ban.TrangThai == "Đang sử dụng")
            {
                MessageBox.Show(
                    "Bàn đang có khách, không thể thay đổi trạng thái trực tiếp.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // 2. MANAGER: bàn trống / bảo trì mở menu quản lý
            if (_nhanVienDangNhap.ChucVu == "Manager")
            {
                HienThiMenuQuanLyBan(ban, pnlBan);
                return;
            }

            // 3. CASH: không gọi món ở bàn đang bảo trì
            if (ban.TrangThai == "Đang bảo trì")
            {
                MessageBox.Show(
                    "Bàn này đang bảo trì, không thể gọi món.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // 4. CASH: mở form gọi món
            FrmGoiMon frmGoiMon =
                new FrmGoiMon(ban, _nhanVienDangNhap);

            frmGoiMon.ShowDialog();

            LoadDanhSachBan();
        }

        private void PicIcon_Click(object sender, EventArgs e)
        {
            PictureBox picIcon = sender as PictureBox;

            if (picIcon == null)
                return;

            string tenChucNang = picIcon.Tag?.ToString();

            switch (tenChucNang)
            {
                case "QUẢN LÝ MENU":
                    if (_nhanVienDangNhap.ChucVu != "Manager")
                    {
                        ThongBaoKhongCoQuyen("Quản lý Menu");
                        return;
                    }

                    FrmQuanLyMenu frmQuanLyMenu = new FrmQuanLyMenu();
                    frmQuanLyMenu.ShowDialog();
                    break;

                case "QUẢN LÝ TOPPING":
                    if (_nhanVienDangNhap.ChucVu != "Manager")
                    {
                        ThongBaoKhongCoQuyen("Quản lý Topping");
                        return;
                    }

                    FrmQuanLyTopping frmQuanLyTopping = new FrmQuanLyTopping();
                    frmQuanLyTopping.ShowDialog();
                    break;

                case "CÔNG THỨC":
                    FrmQuanLyCongThuc frmQuanLyCongThuc =
                        new FrmQuanLyCongThuc(_nhanVienDangNhap);

                    frmQuanLyCongThuc.ShowDialog();
                    break;

                case "KHÁCH HÀNG":
                    FrmQuanLyKhachHang frmQuanLyKhachHang = new FrmQuanLyKhachHang();
                    frmQuanLyKhachHang.ShowDialog();
                    break;

                case "KHUYẾN MÃI":
                    FrmQuanLyKhuyenMai frmQuanLyKhuyenMai =
                        new FrmQuanLyKhuyenMai(_nhanVienDangNhap);

                    frmQuanLyKhuyenMai.ShowDialog();
                    break;

                case "NHÀ CUNG CẤP":
                    if (_nhanVienDangNhap.ChucVu != "Manager")
                    {
                        ThongBaoKhongCoQuyen("Nhà cung cấp");
                        return;
                    }

                    FrmNhaCungCap frmNhaCungCap = new FrmNhaCungCap();
                    frmNhaCungCap.ShowDialog();
                    break;

                case "KHO NGUYÊN LIỆU":
                    FrmQuanLyKho frmQuanLyKho = new FrmQuanLyKho();
                    frmQuanLyKho.ShowDialog();
                    break;

                case "PHIẾU NHẬP":
                    FrmPhieuNhap frmPhieuNhap = new FrmPhieuNhap(_nhanVienDangNhap);
                    frmPhieuNhap.ShowDialog();
                    break;

                case "PHIẾU XUẤT":
                    FrmPhieuXuat frmPhieuXuat = new FrmPhieuXuat();
                    frmPhieuXuat.ShowDialog();
                    break;

                case "HÓA ĐƠN":
                    FrmQuanLyHoaDon frmQuanLyHoaDon = new FrmQuanLyHoaDon(_nhanVienDangNhap);
                    frmQuanLyHoaDon.ShowDialog();
                    break;

                case "ĐỔI MẬT KHẨU":
                    if (_nhanVienDangNhap.ChucVu != "Manager")
                    {
                        ThongBaoKhongCoQuyen("Đổi mật khẩu");
                        return;
                    }

                    FrmDoiMatKhau frmDoiMatKhau = new FrmDoiMatKhau();
                    frmDoiMatKhau.ShowDialog();
                    break;

                case "BÁO CÁO DOANH THU":
                    FrmBaoCaoDoanhThu frmBaoCaoDoanhThu = new FrmBaoCaoDoanhThu();
                    frmBaoCaoDoanhThu.ShowDialog();
                    break;

                case "DASHBOARD":
                    FrmDashboard frmDashboard = new FrmDashboard();
                    frmDashboard.ShowDialog();
                    break;

                case "ĐĂNG XUẤT":
                    DialogResult ketQua = MessageBox.Show(
                        "Bạn có chắc muốn đăng xuất không?",
                        "Xác nhận đăng xuất",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (ketQua == DialogResult.Yes)
                    {
                        this.Hide();

                        FrmDangNhap frmDangNhap = new FrmDangNhap();
                        frmDangNhap.ShowDialog();

                        this.Close();
                    }

                    break;
            }
        }

        private void ThongBaoKhongCoQuyen(string tenChucNang)
        {
            MessageBox.Show(
                $"Bạn không có quyền truy cập chức năng {tenChucNang}.",
                "Không có quyền truy cập",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        private void XuLyTrangThaiBanManager(Ban ban, Panel pnlBan)
        {
            if (ban.TrangThai == "Đang sử dụng")
            {
                MessageBox.Show(
                    "Bàn đang có khách, không thể thay đổi trạng thái trực tiếp.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string trangThaiMoi;

            if (ban.TrangThai == "Trống")
            {
                trangThaiMoi = "Đang bảo trì";
            }
            else
            {
                trangThaiMoi = "Trống";
            }

            DialogResult ketQua = MessageBox.Show(
                $"Bạn có muốn chuyển bàn {ban.SoBan} từ \"{ban.TrangThai}\" sang \"{trangThaiMoi}\" không?",
                "Chuyển trạng thái bàn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (ketQua != DialogResult.Yes)
                return;

            ban.TrangThai = trangThaiMoi;

            _banBUS.Update(ban);

            if (ban.TrangThai == "Trống")
            {
                pnlBan.BackColor = Color.FromArgb(230, 205, 175);
            }
            else if (ban.TrangThai == "Đang bảo trì")
            {
                pnlBan.BackColor = Color.FromArgb(180, 180, 180);
            }

            MessageBox.Show(
                $"Đã chuyển bàn {ban.SoBan} sang trạng thái \"{ban.TrangThai}\".",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void HienThiMenuQuanLyBan(Ban ban, Panel pnlBan)
        {
            ContextMenuStrip menu =
                new ContextMenuStrip();

            ToolStripMenuItem itemDoiTrangThai =
                new ToolStripMenuItem("Đổi trạng thái");

            ToolStripMenuItem itemXoaBan =
                new ToolStripMenuItem("Xóa bàn");

            itemDoiTrangThai.Click += (s, e) =>
            {
                XuLyTrangThaiBanManager(
                    ban,
                    pnlBan);
            };

            itemXoaBan.Click += (s, e) =>
            {
                XoaBanManager(ban);
            };

            menu.Items.Add(itemDoiTrangThai);
            menu.Items.Add(itemXoaBan);

            menu.Show(
                pnlBan,
                new Point(
                    pnlBan.Width / 2,
                    pnlBan.Height / 2));
        }
        private void XoaBanManager(Ban ban)
        {
            if (ban == null)
                return;

            // 1. KHÔNG XÓA BÀN ĐANG SỬ DỤNG
            if (ban.TrangThai == "Đang sử dụng")
            {
                MessageBox.Show(
                    "Bàn đang có khách, không thể xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // 2. XÁC NHẬN XÓA
            DialogResult ketQua = MessageBox.Show(
                $"Bạn có chắc muốn xóa bàn {ban.SoBan} không?",
                "Xác nhận xóa bàn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (ketQua != DialogResult.Yes)
                return;

            // 3. THỰC HIỆN XÓA
            string ketQuaXoa =
                _banBUS.Delete(ban.MaBan);

            MessageBox.Show(
                ketQuaXoa,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQuaXoa == "Xóa bàn thành công."
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            // 4. LOAD LẠI DANH SÁCH BÀN
            if (ketQuaXoa == "Xóa bàn thành công.")
            {
                LoadDanhSachBan();
            }
        }

        private void FlpBan_MouseClick(object sender, MouseEventArgs e)
        {
            if (_nhanVienDangNhap.ChucVu != "Manager")
                return;

            Control controlDuocClick =
                flpBan.GetChildAtPoint(e.Location);

            // 1. CLICK TRÚNG BÀN THÌ KHÔNG XỬ LÝ
            if (controlDuocClick != null)
                return;

            // 2. CLICK VÙNG TRỐNG -> HIỆN MENU THÊM BÀN
            ContextMenuStrip menu =
                new ContextMenuStrip();

            ToolStripMenuItem itemThemBan =
                new ToolStripMenuItem("Thêm bàn");

            itemThemBan.Click += (s, args) =>
            {
                ThemBanManager();
            };

            menu.Items.Add(itemThemBan);

            menu.Show(
                flpBan,
                e.Location);
        }

        private void ThemBanManager()
        {
            Form frmThemBan = new Form();

            frmThemBan.Text = "Thêm bàn";
            frmThemBan.StartPosition = FormStartPosition.CenterParent;
            frmThemBan.Size = new Size(420, 270);
            frmThemBan.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmThemBan.MaximizeBox = false;
            frmThemBan.MinimizeBox = false;
            frmThemBan.BackColor = Color.FromArgb(250, 247, 242);

            // 1. SỐ BÀN
            Label lblSoBan = new Label();

            lblSoBan.Text = "Số bàn:";
            lblSoBan.Location = new Point(35, 35);
            lblSoBan.Size = new Size(100, 30);
            lblSoBan.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            TextBox txtSoBan = new TextBox();

            txtSoBan.Location = new Point(140, 35);
            txtSoBan.Size = new Size(210, 30);
            txtSoBan.Font =
                new Font("Segoe UI", 10);

            // 2. GHI CHÚ
            Label lblGhiChu = new Label();

            lblGhiChu.Text = "Ghi chú:";
            lblGhiChu.Location = new Point(35, 85);
            lblGhiChu.Size = new Size(100, 30);
            lblGhiChu.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            TextBox txtGhiChu = new TextBox();

            txtGhiChu.Location = new Point(140, 85);
            txtGhiChu.Size = new Size(210, 60);
            txtGhiChu.Multiline = true;
            txtGhiChu.Font =
                new Font("Segoe UI", 10);

            // 3. NÚT THÊM
            Button btnThem = new Button();

            btnThem.Text = "THÊM";
            btnThem.Location = new Point(140, 170);
            btnThem.Size = new Size(100, 40);
            btnThem.BackColor =
                Color.FromArgb(78, 47, 32);
            btnThem.ForeColor = Color.White;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            // 4. NÚT HỦY
            Button btnHuy = new Button();

            btnHuy.Text = "HỦY";
            btnHuy.Location = new Point(250, 170);
            btnHuy.Size = new Size(100, 40);
            btnHuy.BackColor =
                Color.FromArgb(230, 205, 175);
            btnHuy.ForeColor =
                Color.FromArgb(78, 47, 32);
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            frmThemBan.Controls.Add(lblSoBan);
            frmThemBan.Controls.Add(txtSoBan);
            frmThemBan.Controls.Add(lblGhiChu);
            frmThemBan.Controls.Add(txtGhiChu);
            frmThemBan.Controls.Add(btnThem);
            frmThemBan.Controls.Add(btnHuy);

            btnHuy.Click += (s, e) =>
            {
                frmThemBan.Close();
            };

            btnThem.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSoBan.Text))
                {
                    MessageBox.Show(
                        "Vui lòng nhập số bàn.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtSoBan.Focus();
                    return;
                }

                Ban banMoi = new Ban
                {
                    MaBan = TaoMaBanMoi(),
                    SoBan = txtSoBan.Text.Trim(),
                    TrangThai = "Trống",
                    GhiChu = txtGhiChu.Text.Trim()
                };

                string ketQua =
                    _banBUS.Add(banMoi);

                MessageBox.Show(
                    ketQua,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    ketQua == "Thêm bàn thành công."
                        ? MessageBoxIcon.Information
                        : MessageBoxIcon.Warning
                );

                if (ketQua != "Thêm bàn thành công.")
                    return;

                frmThemBan.DialogResult =
                    DialogResult.OK;

                frmThemBan.Close();
            };

            if (frmThemBan.ShowDialog(this)
                == DialogResult.OK)
            {
                LoadDanhSachBan();
            }
        }

        private string TaoMaBanMoi()
        {
            var danhSachBan = _banBUS.GetAll();

            int soLonNhat = 0;

            foreach (var ban in danhSachBan)
            {
                if (string.IsNullOrWhiteSpace(ban.MaBan))
                    continue;

                string phanSo = ban.MaBan
                    .Replace("B", "");

                if (int.TryParse(phanSo, out int so))
                {
                    if (so > soLonNhat)
                        soLonNhat = so;
                }
            }

            return "B" + (soLonNhat + 1).ToString("D3");
        }
    }
}
