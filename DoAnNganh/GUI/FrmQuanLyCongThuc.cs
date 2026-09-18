using Đồ_án_ngành.BUS;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Đồ_án_ngành.GUI
{
    public partial class FrmQuanLyCongThuc : Form
    {
        private readonly CongThucBUS _congThucBUS = new CongThucBUS();
        private readonly MonBUS _monBUS = new MonBUS();
        private readonly NguyenVatLieuBUS _nguyenVatLieuBUS
            = new NguyenVatLieuBUS();

        private readonly DanhMucBUS _danhMucBUS = new DanhMucBUS();

        private List<CongThuc> _danhSachCongThuc
            = new List<CongThuc>();

        private bool _dangLoadDuLieu = false;

        private readonly NhanVien _nhanVienDangNhap;

        public FrmQuanLyCongThuc(NhanVien nhanVienDangNhap)
        {
            InitializeComponent();

            _nhanVienDangNhap = nhanVienDangNhap;
        }

        private void LoadDanhSachMon()
        {
            var danhSachMon = _monBUS.GetAll();

            cboMon.DataSource = danhSachMon;
            cboMon.DisplayMember = "TenMon";
            cboMon.ValueMember = "MaMon";
            cboMon.SelectedIndex = -1;
        }

        private void FrmQuanLyCongThuc_Load(object sender, EventArgs e)
        {
            _dangLoadDuLieu = true;

            LoadDanhMuc();
            LoadDanhSachMon();
            LoadNguyenVatLieu();

            cboDanhMuc.SelectedIndex = -1;
            cboMon.SelectedIndex = -1;

            _dangLoadDuLieu = false;

            PhanQuyen();
        }

        private void LoadDanhMuc()
        {
            var danhSachDanhMuc = _danhMucBUS.GetAll();

            cboDanhMuc.DataSource = danhSachDanhMuc;
            cboDanhMuc.DisplayMember = "TenDanhMuc";
            cboDanhMuc.ValueMember = "MaDanhMuc";
            cboDanhMuc.SelectedIndex = -1;
        }

        private void LoadMonTheoDanhMuc(string maDanhMuc)
        {
            if (string.IsNullOrWhiteSpace(maDanhMuc))
            {
                cboMon.DataSource = null;
                return;
            }

            var danhSachMon = _monBUS.GetAll()
                .Where(x => x.MaDanhMuc == maDanhMuc)
                .ToList();

            cboMon.DataSource = danhSachMon;
            cboMon.DisplayMember = "TenMon";
            cboMon.ValueMember = "MaMon";
            cboMon.SelectedIndex = -1;
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dangLoadDuLieu)
                return;

            if (cboDanhMuc.SelectedValue == null)
            {
                cboMon.DataSource = null;
                return;
            }

            string maDanhMuc = cboDanhMuc.SelectedValue.ToString();

            LoadMonTheoDanhMuc(maDanhMuc);
        }

        private void cboMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dangLoadDuLieu)
                return;

            Mon monDangChon = cboMon.SelectedItem as Mon;

            if (monDangChon == null)
            {
                dgvCongThuc.Rows.Clear();
                return;
            }

            if (!string.IsNullOrWhiteSpace(monDangChon.MaDanhMuc))
            {
                if (cboDanhMuc.SelectedValue == null ||
                    cboDanhMuc.SelectedValue.ToString() != monDangChon.MaDanhMuc)
                {
                    cboDanhMuc.SelectedValue = monDangChon.MaDanhMuc;
                }
            }

            LoadCongThucTheoMon(monDangChon.MaMon);
        }

        private void LoadCongThucTheoMon(string maMon)
        {
            _danhSachCongThuc = _congThucBUS.GetByMon(maMon);

            dgvCongThuc.Rows.Clear();

            foreach (var ct in _danhSachCongThuc)
            {
                dgvCongThuc.Rows.Add(
                    ct.MaNVL,
                    ct.NguyenVatLieu != null ? ct.NguyenVatLieu.TenNVL : "",
                    ct.DinhLuong,
                    ct.NguyenVatLieu != null ? ct.NguyenVatLieu.DonViTinhQuyDoi : ""
                );
            }
        }

        private void LoadNguyenVatLieu()
        {
            var danhSachNVL = _nguyenVatLieuBUS.GetAll();

            cboNguyenVatLieu.DataSource = danhSachNVL;
            cboNguyenVatLieu.DisplayMember = "TenNVL";
            cboNguyenVatLieu.ValueMember = "MaNVL";
            cboNguyenVatLieu.SelectedIndex = -1;

            lblDonViTinh.Text = "";
        }

        private void cboNguyenVatLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            NguyenVatLieu nvl = cboNguyenVatLieu.SelectedItem as NguyenVatLieu;

            if (nvl == null)
            {
                lblDonViTinh.Text = "";
                return;
            }

            lblDonViTinh.Text = nvl.DonViTinhQuyDoi;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Mon monDangChon = cboMon.SelectedItem as Mon;

            if (monDangChon == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn món trước.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            NguyenVatLieu nvl =
                cboNguyenVatLieu.SelectedItem as NguyenVatLieu;

            if (nvl == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn nguyên vật liệu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            decimal dinhLuong = nudSoLuong.Value;

            if (dinhLuong <= 0)
            {
                MessageBox.Show(
                    "Định lượng phải lớn hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Kiểm tra NVL đã có trong công thức chưa
            foreach (DataGridViewRow row in dgvCongThuc.Rows)
            {
                string maNVL = row.Cells["colMaNVL"].Value?.ToString();

                if (maNVL == nvl.MaNVL)
                {
                    MessageBox.Show(
                        "Nguyên vật liệu này đã có trong công thức.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            // Thêm NVL vào danh sách tạm
            dgvCongThuc.Rows.Add(
                nvl.MaNVL,
                nvl.TenNVL,
                dinhLuong,
                nvl.DonViTinhQuyDoi
            );

            cboNguyenVatLieu.SelectedIndex = -1;
            nudSoLuong.Value = nudSoLuong.Minimum;
            lblDonViTinh.Text = "";
        }

        private void btnXoaNguyenLieu_Click(object sender, EventArgs e)
        {
            if (dgvCongThuc.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn nguyên vật liệu cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc muốn xóa nguyên vật liệu này khỏi công thức?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (ketQua != DialogResult.Yes)
                return;

            dgvCongThuc.Rows.Remove(dgvCongThuc.CurrentRow);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Mon monDangChon = cboMon.SelectedItem as Mon;

            if (monDangChon == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn món cần lưu công thức.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (dgvCongThuc.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Công thức phải có ít nhất một nguyên vật liệu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            List<CongThuc> danhSachMoi = new List<CongThuc>();

            foreach (DataGridViewRow row in dgvCongThuc.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string maNVL =
                    row.Cells["colMaNVL"].Value?.ToString();

                decimal dinhLuong;

                if (string.IsNullOrWhiteSpace(maNVL) ||
                    !decimal.TryParse(
                        row.Cells["colSoLuong"].Value?.ToString(),
                        out dinhLuong) ||
                    dinhLuong <= 0)
                {
                    MessageBox.Show(
                        "Dữ liệu công thức không hợp lệ.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                danhSachMoi.Add(new CongThuc
                {
                    MaMon = monDangChon.MaMon,
                    MaNVL = maNVL,
                    DinhLuong = dinhLuong
                });
            }

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc muốn lưu công thức cho món " +
                monDangChon.TenMon + "?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (xacNhan != DialogResult.Yes)
                return;

            string ketQua =
                _congThucBUS.SaveByMon(monDangChon.MaMon, danhSachMoi);

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
                LoadCongThucTheoMon(monDangChon.MaMon);
            }
        }

        private void btnXoaCongThuc_Click(object sender, EventArgs e)
        {
            Mon monDangChon = cboMon.SelectedItem as Mon;

            if (monDangChon == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn món cần xóa công thức.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            List<CongThuc> danhSach =
                _congThucBUS.GetByMon(monDangChon.MaMon);

            if (danhSach == null || danhSach.Count == 0)
            {
                MessageBox.Show(
                    "Món này chưa có công thức.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc muốn xóa toàn bộ công thức của món " +
                monDangChon.TenMon + "?",
                "Xác nhận xóa công thức",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (xacNhan != DialogResult.Yes)
                return;

            string ketQua =
                _congThucBUS.DeleteByMon(monDangChon.MaMon);

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
                LoadCongThucTheoMon(monDangChon.MaMon);
            }
        }

        private void PhanQuyen()
        {
            bool laManager =
                _nhanVienDangNhap != null &&
                _nhanVienDangNhap.ChucVu == "Manager";

            btnThem.Enabled = laManager;
            btnXoaNguyenLieu.Enabled = laManager;
            btnLuu.Enabled = laManager;
            btnXoaCongThuc.Enabled = laManager;

            cboNguyenVatLieu.Enabled = laManager;
            nudSoLuong.Enabled = laManager;

            dgvCongThuc.ReadOnly = !laManager;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
