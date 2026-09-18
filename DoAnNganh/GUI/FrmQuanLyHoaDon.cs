using Đồ_án_ngành.BUS;
using MODEL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace Đồ_án_ngành.GUI
{
    public partial class FrmQuanLyHoaDon : Form
    {
        private readonly HoaDonBUS _hoaDonBUS = new HoaDonBUS();
        private HoaDon _hoaDonDangChon;
        private readonly NhanVien _nhanVienDangNhap;

        public FrmQuanLyHoaDon(NhanVien nhanVienDangNhap)
        {
            InitializeComponent();

            _nhanVienDangNhap = nhanVienDangNhap;
        }

        private void FrmQuanLyHoaDon_Load(object sender, System.EventArgs e)
        {
            cboTrangThai.Items.Clear();

            cboTrangThai.Items.Add("Tất cả");
            cboTrangThai.Items.Add("Chưa thanh toán");
            cboTrangThai.Items.Add("Đã thanh toán");
            cboTrangThai.Items.Add("Đã hủy");

            cboTrangThai.SelectedIndex = 0;

            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;

            LoadDanhSachHoaDon();

            btnHuyHoaDon.Enabled = false;
        }

        private void LoadDanhSachHoaDon()
        {
            var danhSach = _hoaDonBUS.GetAll();

            dgvHoaDon.AutoGenerateColumns = false;

            dgvHoaDon.DataSource = danhSach.Select(x => new
            {
                MaHoaDon = x.MaHoaDon,
                NgayLap = x.NgayLap,
                KhachHang = x.KhachHang != null
                    ? x.KhachHang.HoTen
                    : "Khách lẻ",
                NhanVien = x.NhanVien != null
                    ? x.NhanVien.ChucVu
                    : x.MaNV,
                ThanhTien = x.ThanhTien,
                PhuongThuc = x.PhuongThucThanhToan != null
                    ? x.PhuongThucThanhToan.TenPhuongThuc
                    : "---",
                TrangThai = x.TrangThai
            }).ToList();

            dgvHoaDon.Columns["colNgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            dgvHoaDon.Columns["colThanhTien"].DefaultCellStyle.Format = "N0";
        }

        private void HienThiThongTinHoaDon(HoaDon hoaDon)
        {
            if (hoaDon == null)
                return;

            lblMaHD.Text = hoaDon.MaHoaDon;
            lblTrangThai.Text = hoaDon.TrangThai;

            lblNgayLap.Text = hoaDon.NgayLap.ToString("dd/MM/yyyy HH:mm");

            lblBan.Text = hoaDon.Ban != null
                ? hoaDon.Ban.SoBan.ToString()
                : "Mang về";

            lblKhachHang.Text = hoaDon.KhachHang != null
                ? hoaDon.KhachHang.HoTen
                : "Khách lẻ";

            lblNhanVien.Text = hoaDon.NhanVien != null
                ? hoaDon.NhanVien.ChucVu
                : hoaDon.MaNV;

            lblPTTT.Text = hoaDon.PhuongThucThanhToan != null
                ? hoaDon.PhuongThucThanhToan.TenPhuongThuc
                : "---";

            lblKhuyenMai.Text = hoaDon.KhuyenMai != null
                ? hoaDon.KhuyenMai.TenKhuyenMai
                : "Không";

            lblGhiChu.Text = string.IsNullOrWhiteSpace(hoaDon.GhiChu)
                ? "---"
                : hoaDon.GhiChu;

            lblTongTien.Text = hoaDon.TongTien.ToString("N0");
            lblGiamGia.Text = hoaDon.GiamGia.ToString("N0");
            lblThanhTien.Text = hoaDon.ThanhTien.ToString("N0");

            btnHuyHoaDon.Enabled = _nhanVienDangNhap != null && _nhanVienDangNhap.ChucVu == "Manager" &&
                (hoaDon.TrangThai == "Chưa thanh toán" || hoaDon.TrangThai == "Đã thanh toán");
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string maHoaDon = dgvHoaDon.Rows[e.RowIndex]
                .Cells["colMaHoaDon"]
                .Value?.ToString();

            if (string.IsNullOrWhiteSpace(maHoaDon))
                return;

            _hoaDonDangChon = _hoaDonBUS.GetById(maHoaDon);

            HienThiThongTinHoaDon(_hoaDonDangChon);

            LoadChiTietHoaDon(_hoaDonDangChon);
        }

        private void LoadChiTietHoaDon(HoaDon hoaDon)
        {
            if (hoaDon == null)
            {
                dgvChiTietHoaDon.DataSource = null;
                return;
            }

            dgvChiTietHoaDon.AutoGenerateColumns = false;

            dgvChiTietHoaDon.DataSource = hoaDon.ChiTietHoaDons.Select(x => new
            {
                TenMon = x.Mon != null
                    ? x.Mon.TenMon
                    : x.Topping != null
                        ? x.Topping.TenTopping + " (Topping)"
                        : "---",

                SoLuong = x.SoLuong,
                GiaBan = x.GiaBan,
                ThanhTien = x.ThanhTien,
                GhiChu = string.IsNullOrWhiteSpace(x.GhiChu)
                    ? ""
                    : x.GhiChu
            }).ToList();

            dgvChiTietHoaDon.Columns["colGiaBanCT"]
                .DefaultCellStyle.Format = "N0";

            dgvChiTietHoaDon.Columns["colThanhTienCT"]
                .DefaultCellStyle.Format = "N0";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show(
                    "Từ ngày không được lớn hơn đến ngày.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string maHoaDon = txtMaHoaDon.Text.Trim();
            string trangThai = cboTrangThai.SelectedItem?.ToString();

            var danhSach = _hoaDonBUS.Filter(
                maHoaDon,
                trangThai,
                dtpTuNgay.Value,
                dtpDenNgay.Value
            );

            dgvHoaDon.DataSource = danhSach.Select(x => new
            {
                MaHoaDon = x.MaHoaDon,
                NgayLap = x.NgayLap,

                KhachHang = x.KhachHang != null
                    ? x.KhachHang.HoTen
                    : "Khách lẻ",

                NhanVien = x.NhanVien != null
                    ? x.NhanVien.ChucVu
                    : x.MaNV,

                ThanhTien = x.ThanhTien,

                PhuongThuc = x.PhuongThucThanhToan != null
                    ? x.PhuongThucThanhToan.TenPhuongThuc
                    : "---",

                TrangThai = x.TrangThai
            }).ToList();
        }

        private void LamMoiChiTiet()
        {
            _hoaDonDangChon = null;

            lblMaHD.Text = "---";
            lblTrangThai.Text = "---";
            lblNgayLap.Text = "---";
            lblBan.Text = "---";
            lblKhachHang.Text = "---";
            lblNhanVien.Text = "---";
            lblPTTT.Text = "---";
            lblKhuyenMai.Text = "---";
            lblGhiChu.Text = "---";

            lblTongTien.Text = "0";
            lblGiamGia.Text = "0";
            lblThanhTien.Text = "0";

            dgvChiTietHoaDon.DataSource = null;

            dgvHoaDon.ClearSelection();

            btnHuyHoaDon.Enabled = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHoaDon.Clear();

            cboTrangThai.SelectedIndex = 0;

            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;

            LoadDanhSachHoaDon();

            LamMoiChiTiet();
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (_nhanVienDangNhap == null || _nhanVienDangNhap.ChucVu != "Manager")
            {
                MessageBox.Show(
                    "Chỉ Manager mới có quyền hủy hóa đơn.",
                    "Không có quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (_hoaDonDangChon == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn hóa đơn cần hủy.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (_hoaDonDangChon.TrangThai == "Đã hủy")
            {
                MessageBox.Show(
                    "Hóa đơn này đã được hủy trước đó.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                $"Bạn có chắc chắn muốn hủy hóa đơn {_hoaDonDangChon.MaHoaDon} không?",
                "Xác nhận hủy hóa đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (xacNhan != DialogResult.Yes)
                return;

            string ketQua = _hoaDonBUS.HuyHoaDon(
                _hoaDonDangChon.MaHoaDon, _nhanVienDangNhap
            );

            MessageBox.Show(
                ketQua,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua.StartsWith("Hủy hóa đơn thành công")
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua.StartsWith("Hủy hóa đơn thành công"))
            {
                LoadDanhSachHoaDon();
                LamMoiChiTiet();
            }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name != "colTrangThai")
                return;

            string trangThai = e.Value?.ToString();

            if (trangThai == "Đã thanh toán")
            {
                e.CellStyle.ForeColor = Color.FromArgb(46, 125, 50);
            }
            else if (trangThai == "Chưa thanh toán")
            {
                e.CellStyle.ForeColor = Color.FromArgb(230, 126, 34);
            }
            else if (trangThai == "Đã hủy")
            {
                e.CellStyle.ForeColor = Color.FromArgb(181, 74, 65);
            }

            e.CellStyle.Font = new Font(
                dgvHoaDon.Font,
                FontStyle.Bold
            );
        }
    }
}
