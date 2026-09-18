using Đồ_án_ngành.BUS;
using MODEL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Đồ_án_ngành.GUI
{
    public partial class FrmQuanLyKhuyenMai : Form
    {
        private readonly KhuyenMaiBUS _khuyenMaiBUS = new KhuyenMaiBUS();
        private readonly MonBUS _monBUS = new MonBUS();
        private readonly NhanVien _nhanVienDangNhap;

        public FrmQuanLyKhuyenMai(NhanVien nhanVien)
        {
            InitializeComponent();

            _nhanVienDangNhap = nhanVien;
        }

        private void FrmQuanLyKhuyenMai_Load(object sender, EventArgs e)
        {
            // 1. LOẠI KHUYẾN MÃI
            cboLoaiKhuyenMai.Items.Clear();
            cboLoaiKhuyenMai.Items.Add("Phần trăm");
            cboLoaiKhuyenMai.Items.Add("Tiền cố định");
            cboLoaiKhuyenMai.SelectedIndex = 0;

            // 2. TRẠNG THÁI
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Đang áp dụng");
            cboTrangThai.Items.Add("Ngừng áp dụng");
            cboTrangThai.SelectedIndex = 0;

            // 3. LỌC TRẠNG THÁI
            cboTrangThaiLoc.Items.Clear();
            cboTrangThaiLoc.Items.Add("Tất cả");
            cboTrangThaiLoc.Items.Add("Đang áp dụng");
            cboTrangThaiLoc.Items.Add("Chưa bắt đầu");
            cboTrangThaiLoc.Items.Add("Đã kết thúc");
            cboTrangThaiLoc.Items.Add("Ngừng áp dụng");
            cboTrangThaiLoc.SelectedIndex = 0;

            // 4. KHOẢNG NGÀY MẶC ĐỊNH
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpDenNgay.Value = new DateTime(DateTime.Today.Year, 12, 31);

            dtpNgayBatDau.Value = DateTime.Today;
            dtpNgayKetThuc.Value = DateTime.Today;

            LoadMonApDung();

            LoadDanhSachKhuyenMai();

            txtMaKhuyenMai.Text = TaoMaKhuyenMaiMoi();

            PhanQuyen();
        }

        private void LoadMonApDung()
        {
            var danhSachMon = _monBUS.GetAll();

            clbMonApDung.Items.Clear();

            foreach (var mon in danhSachMon)
            {
                clbMonApDung.Items.Add(mon);
            }

            clbMonApDung.DisplayMember = "TenMon";
        }

        private string TaoMaKhuyenMaiMoi()
        {
            var danhSach = _khuyenMaiBUS.GetAll();

            if (danhSach == null || danhSach.Count == 0)
                return "KM001";

            int soLonNhat = 0;

            foreach (var khuyenMai in danhSach)
            {
                if (string.IsNullOrWhiteSpace(khuyenMai.MaKhuyenMai))
                    continue;

                string ma = khuyenMai.MaKhuyenMai.Trim();

                if (!ma.StartsWith("KM"))
                    continue;

                string phanSo = ma.Substring(2);

                if (int.TryParse(phanSo, out int so))
                {
                    if (so > soLonNhat)
                        soLonNhat = so;
                }
            }

            return "KM" + (soLonNhat + 1).ToString("D3");
        }

        private void LoadDanhSachKhuyenMai()
        {
            var danhSach = _khuyenMaiBUS.GetAll();

            dgvKhuyenMai.Rows.Clear();

            foreach (var khuyenMai in danhSach)
            {
                string giaTriHienThi;

                if (khuyenMai.LoaiKhuyenMai == "Phần trăm")
                {
                    giaTriHienThi =
                        khuyenMai.GiaTriKhuyenMai.ToString("0.##") + "%";
                }
                else
                {
                    giaTriHienThi =
                        khuyenMai.GiaTriKhuyenMai.ToString("N0") + " đ";
                }

                dgvKhuyenMai.Rows.Add(
                    khuyenMai.MaKhuyenMai,
                    khuyenMai.TenKhuyenMai,
                    khuyenMai.LoaiKhuyenMai,
                    giaTriHienThi,
                    khuyenMai.NgayBatDau.ToString("dd/MM/yyyy"),
                    khuyenMai.NgayKetThuc.ToString("dd/MM/yyyy"),
                    khuyenMai.TrangThai,
                    khuyenMai.GhiChu
                );
            }

            dgvKhuyenMai.ClearSelection();
        }

        private List<string> LayDanhSachMaMonApDung()
        {
            List<string> danhSachMaMon = new List<string>();

            foreach (Mon mon in clbMonApDung.CheckedItems)
            {
                danhSachMaMon.Add(mon.MaMon);
            }

            return danhSachMaMon;
        }

        private KhuyenMai LayDuLieuKhuyenMai()
        {
            KhuyenMai khuyenMai = new KhuyenMai
            {
                MaKhuyenMai = txtMaKhuyenMai.Text.Trim(),
                TenKhuyenMai = txtTenKhuyenMai.Text.Trim(),
                LoaiKhuyenMai = cboLoaiKhuyenMai.SelectedItem?.ToString(),
                GiaTriKhuyenMai = nudGiaTriKhuyenMai.Value,
                NgayBatDau = dtpNgayBatDau.Value.Date,
                NgayKetThuc = dtpNgayKetThuc.Value.Date,
                TrangThai = cboTrangThai.SelectedItem?.ToString(),
                GhiChu = txtGhiChu.Text.Trim()
            };

            return khuyenMai;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhuyenMai khuyenMai = LayDuLieuKhuyenMai();

            List<string> danhSachMaMon =
                LayDanhSachMaMonApDung();

            string ketQua =
                _khuyenMaiBUS.Add(
                    khuyenMai,
                    danhSachMaMon);

            MessageBox.Show(
                ketQua,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua.Contains("thành công")
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua.Contains("thành công"))
            {
                LoadDanhSachKhuyenMai();
                LamMoiForm();
            }
        }

        private void LamMoiForm()
        {
            txtMaKhuyenMai.Text = TaoMaKhuyenMaiMoi();
            txtTenKhuyenMai.Clear();

            cboLoaiKhuyenMai.SelectedIndex = 0;

            nudGiaTriKhuyenMai.Value = 0;

            dtpNgayBatDau.Value = DateTime.Today;
            dtpNgayKetThuc.Value = DateTime.Today;

            cboTrangThai.SelectedIndex = 0;

            txtGhiChu.Clear();

            for (int i = 0; i < clbMonApDung.Items.Count; i++)
            {
                clbMonApDung.SetItemChecked(i, false);
            }

            dgvKhuyenMai.ClearSelection();

            txtTenKhuyenMai.Focus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void dgvKhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string maKhuyenMai =
                dgvKhuyenMai.Rows[e.RowIndex]
                    .Cells["colMaKhuyenMai"]
                    .Value?.ToString();

            if (string.IsNullOrWhiteSpace(maKhuyenMai))
                return;

            KhuyenMai khuyenMai =
                _khuyenMaiBUS.GetById(maKhuyenMai);

            if (khuyenMai == null)
                return;

            // 1. HIỂN THỊ THÔNG TIN KHUYẾN MÃI
            txtMaKhuyenMai.Text = khuyenMai.MaKhuyenMai;
            txtTenKhuyenMai.Text = khuyenMai.TenKhuyenMai;
            cboLoaiKhuyenMai.SelectedItem = khuyenMai.LoaiKhuyenMai;
            nudGiaTriKhuyenMai.Value = khuyenMai.GiaTriKhuyenMai;
            dtpNgayBatDau.Value = khuyenMai.NgayBatDau;
            dtpNgayKetThuc.Value = khuyenMai.NgayKetThuc;
            if (khuyenMai.TrangThai == "Ngừng áp dụng")
            {
                cboTrangThai.SelectedItem = "Ngừng áp dụng";
            }
            else
            {
                cboTrangThai.SelectedItem = "Đang áp dụng";
            }
            txtGhiChu.Text = khuyenMai.GhiChu ?? "";

            // 2. BỎ CHECK TOÀN BỘ MÓN
            for (int i = 0; i < clbMonApDung.Items.Count; i++)
            {
                clbMonApDung.SetItemChecked(i, false);
            }

            // 3. CHECK LẠI CÁC MÓN ÁP DỤNG
            if (khuyenMai.ChiTietKhuyenMais != null)
            {
                foreach (var chiTiet in khuyenMai.ChiTietKhuyenMais)
                {
                    for (int i = 0; i < clbMonApDung.Items.Count; i++)
                    {
                        Mon mon = clbMonApDung.Items[i] as Mon;

                        if (mon != null &&
                            mon.MaMon == chiTiet.MaMon)
                        {
                            clbMonApDung.SetItemChecked(i, true);
                            break;
                        }
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhuyenMai.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn khuyến mãi cần sửa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            KhuyenMai khuyenMai = LayDuLieuKhuyenMai();

            List<string> danhSachMaMon =
                LayDanhSachMaMonApDung();

            string ketQua =
                _khuyenMaiBUS.Update(
                    khuyenMai,
                    danhSachMaMon);

            MessageBox.Show(
                ketQua,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua.Contains("thành công")
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua.Contains("thành công"))
            {
                LoadDanhSachKhuyenMai();
                LamMoiForm();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhuyenMai.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn khuyến mãi cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa khuyến mãi này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            string ketQua =
                _khuyenMaiBUS.Delete(
                    txtMaKhuyenMai.Text.Trim());

            MessageBox.Show(
                ketQua,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua.Contains("thành công")
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua.Contains("thành công"))
            {
                LoadDanhSachKhuyenMai();
                LamMoiForm();
            }
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

            string keyword = txtTimKiem.Text.Trim();
            string trangThai =
                cboTrangThaiLoc.SelectedItem?.ToString();

            var danhSach =
                _khuyenMaiBUS.Filter(
                    keyword,
                    trangThai,
                    dtpTuNgay.Value.Date,
                    dtpDenNgay.Value.Date);

            dgvKhuyenMai.Rows.Clear();

            foreach (var khuyenMai in danhSach)
            {
                string giaTriHienThi;

                if (khuyenMai.LoaiKhuyenMai == "Phần trăm")
                {
                    giaTriHienThi =
                        khuyenMai.GiaTriKhuyenMai.ToString("0.##") + "%";
                }
                else
                {
                    giaTriHienThi =
                        khuyenMai.GiaTriKhuyenMai.ToString("N0") + " đ";
                }

                dgvKhuyenMai.Rows.Add(
                    khuyenMai.MaKhuyenMai,
                    khuyenMai.TenKhuyenMai,
                    khuyenMai.LoaiKhuyenMai,
                    giaTriHienThi,
                    khuyenMai.NgayBatDau.ToString("dd/MM/yyyy"),
                    khuyenMai.NgayKetThuc.ToString("dd/MM/yyyy"),
                    khuyenMai.TrangThai,
                    khuyenMai.GhiChu
                );
            }

            dgvKhuyenMai.ClearSelection();
        }

        private void btnLamMoiLoc_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();

            cboTrangThaiLoc.SelectedIndex = 0;

            dtpTuNgay.Value =
                new DateTime(DateTime.Today.Year, 1, 1);

            dtpDenNgay.Value =
                new DateTime(DateTime.Today.Year, 12, 31);

            LoadDanhSachKhuyenMai();
        }

        private void cboLoaiKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiKhuyenMai.SelectedItem == null)
                return;

            string loaiKhuyenMai =
                cboLoaiKhuyenMai.SelectedItem.ToString();

            if (loaiKhuyenMai == "Phần trăm")
            {
                nudGiaTriKhuyenMai.Maximum = 100;
            }
            else
            {
                nudGiaTriKhuyenMai.Maximum = 100000000;
            }

            nudGiaTriKhuyenMai.Value = 0;
        }

        private void PhanQuyen()
        {
            bool laManager =
                _nhanVienDangNhap != null &&
                _nhanVienDangNhap.ChucVu == "Manager";

            // 1. MANAGER FULL CONTROL
            btnThem.Enabled = laManager;
            btnSua.Enabled = laManager;
            btnXoa.Enabled = laManager;
            btnLamMoi.Enabled = laManager;

            // 2. CASH CHỈ XEM
            txtTenKhuyenMai.ReadOnly = !laManager;
            nudGiaTriKhuyenMai.Enabled = laManager;
            cboLoaiKhuyenMai.Enabled = laManager;
            dtpNgayBatDau.Enabled = laManager;
            dtpNgayKetThuc.Enabled = laManager;
            cboTrangThai.Enabled = laManager;
            txtGhiChu.ReadOnly = !laManager;
            clbMonApDung.Enabled = laManager;
        }
    }
}
