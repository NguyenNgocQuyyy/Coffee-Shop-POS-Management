using Đồ_án_ngành.BUS;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace Đồ_án_ngành.GUI
{
    public partial class FrmQuanLyMenu : Form
    {
        private readonly DanhMucBUS _danhMucBUS = new DanhMucBUS();
        private readonly MonBUS _monBUS = new MonBUS();

        public FrmQuanLyMenu()
        {
            InitializeComponent();
            colGiaBan.DefaultCellStyle.Format = "N0";
            LoadDanhMuc();
            LoadDanhMucGrid();
            LoadMon();
        }

        private void LoadDanhMuc()
        {
            var danhSach = _danhMucBUS.GetAll();

            // ComboBox dùng để lọc
            var danhSachLoc = new List<DanhMuc>
            {
                new DanhMuc
                {
            MaDanhMuc = "",
            TenDanhMuc = "Tất cả danh mục"
                }
            };
            danhSachLoc.AddRange(danhSach);

            cboDanhMuc.DataSource = null;
            cboDanhMuc.DisplayMember = "TenDanhMuc";
            cboDanhMuc.ValueMember = "MaDanhMuc";
            cboDanhMuc.DataSource = danhSachLoc;

            // ComboBox dùng khi thêm/sửa món
            cboDanhMucMon.DataSource = null;
            cboDanhMucMon.DisplayMember = "TenDanhMuc";
            cboDanhMucMon.ValueMember = "MaDanhMuc";
            cboDanhMucMon.DataSource = new List<DanhMuc>(danhSach);
        }

        private void LoadMon()
        {
            LocMon();
        }

        private void dgvMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string maMon = dgvMon.Rows[e.RowIndex]
                .Cells["colMaMon"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(maMon))
                return;

            var mon = _monBUS.GetById(maMon);

            if (mon == null)
                return;

            txtMaMon.Text = mon.MaMon;
            txtTenMon.Text = mon.TenMon;
            txtGiaBan.Text = mon.GiaBan.ToString("N0");

            cboDanhMucMon.SelectedValue = mon.MaDanhMuc;
            cboTrangThai.SelectedItem = mon.TrangThai;
        }

        private string TaoMaMonMoi()
        {
            var danhSach = _monBUS.GetAll();

            if (danhSach == null || danhSach.Count == 0)
                return "M001";

            int soLonNhat = danhSach
                .Where(x => !string.IsNullOrWhiteSpace(x.MaMon)
                            && x.MaMon.StartsWith("M"))
                .Select(x =>
                {
                    int.TryParse(x.MaMon.Substring(1), out int so);
                    return so;
                })
                .DefaultIfEmpty(0)
                .Max();

            return $"M{soLonNhat + 1:D3}";
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            txtMaMon.Text = TaoMaMonMoi();
            txtTenMon.Clear();
            txtGiaBan.Clear();

            if (cboDanhMucMon.Items.Count > 0)
                cboDanhMucMon.SelectedIndex = 0;

            cboTrangThai.SelectedItem = "Đang bán";

            txtTenMon.Focus();
        }

        private void btnLuu_Click(object sender, System.EventArgs e)
        {
            if (!decimal.TryParse(txtGiaBan.Text.Trim(), out decimal giaBan))
            {
                MessageBox.Show(
                    "Giá bán không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var mon = new Mon
            {
                MaMon = txtMaMon.Text.Trim(),
                TenMon = txtTenMon.Text.Trim(),
                GiaBan = giaBan,
                MaDanhMuc = cboDanhMucMon.SelectedValue?.ToString(),
                TrangThai = cboTrangThai.SelectedItem?.ToString()
            };

            string ketQua = _monBUS.Add(mon);

            MessageBox.Show(
                ketQua,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua == "Thêm món thành công."
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua == "Thêm món thành công.")
            {
                LoadMon();
            }
        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMon.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn món cần sửa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (!decimal.TryParse(txtGiaBan.Text.Trim(), out decimal giaBan))
            {
                MessageBox.Show(
                    "Giá bán không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var mon = new Mon
            {
                MaMon = txtMaMon.Text.Trim(),
                TenMon = txtTenMon.Text.Trim(),
                GiaBan = giaBan,
                MaDanhMuc = cboDanhMucMon.SelectedValue?.ToString(),
                TrangThai = cboTrangThai.SelectedItem?.ToString()
            };

            string ketQua = _monBUS.Update(mon);

            MessageBox.Show(
                ketQua,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua == "Cập nhật món thành công."
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua == "Cập nhật món thành công.")
            {
                LoadMon();
            }

        }

        private void LoadDanhMucGrid()
        {
            var danhSach = _danhMucBUS.GetAll()
                .OrderBy(x => x.MaDanhMuc)
                .ToList();

            dgvDanhMuc.DataSource = null;
            dgvDanhMuc.AutoGenerateColumns = false;
            dgvDanhMuc.DataSource = danhSach;
        }

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtTenDanhMuc.Text = dgvDanhMuc.Rows[e.RowIndex]
                .Cells["colTenDanhMuc"].Value?.ToString();
        }

        private string TaoMaDanhMucMoi()
        {
            var danhSach = _danhMucBUS.GetAll();

            if (danhSach == null || danhSach.Count == 0)
                return "DM001";

            int soLonNhat = danhSach
                .Where(x => !string.IsNullOrWhiteSpace(x.MaDanhMuc)
                            && x.MaDanhMuc.StartsWith("DM"))
                .Select(x =>
                {
                    int.TryParse(x.MaDanhMuc.Substring(2), out int so);
                    return so;
                })
                .DefaultIfEmpty(0)
                .Max();

            return $"DM{soLonNhat + 1:D3}";
        }

        private void btnThemDanhMuc_Click(object sender, System.EventArgs e)
        {
            var danhMuc = new DanhMuc
            {
                MaDanhMuc = TaoMaDanhMucMoi(),
                TenDanhMuc = txtTenDanhMuc.Text.Trim()
            };

            string ketQua = _danhMucBUS.Add(danhMuc);

            MessageBox.Show(
                ketQua,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua == "Thêm danh mục thành công."
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua == "Thêm danh mục thành công.")
            {
                txtTenDanhMuc.Clear();

                LoadDanhMucGrid();
                LoadDanhMuc();
            }
        }

        private void btnSuaDanhMuc_Click(object sender, System.EventArgs e)
        {
            if (dgvDanhMuc.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn danh mục cần sửa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string maDanhMuc = dgvDanhMuc.CurrentRow
                .Cells["colMaDanhMuc"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(maDanhMuc))
            {
                MessageBox.Show(
                    "Mã danh mục không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var danhMuc = new DanhMuc
            {
                MaDanhMuc = maDanhMuc,
                TenDanhMuc = txtTenDanhMuc.Text.Trim()
            };

            string ketQua = _danhMucBUS.Update(danhMuc);

            MessageBox.Show(
                ketQua,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua == "Cập nhật danh mục thành công."
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua == "Cập nhật danh mục thành công.")
            {
                LoadDanhMucGrid();
                LoadDanhMuc();
                LoadMon();
            }
        }

        private void btnXoaDanhMuc_Click(object sender, System.EventArgs e)
        {
            if (dgvDanhMuc.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn danh mục cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string maDanhMuc = dgvDanhMuc.CurrentRow
                .Cells["colMaDanhMuc"].Value?.ToString();

            string tenDanhMuc = dgvDanhMuc.CurrentRow
                .Cells["colTenDanhMuc"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(maDanhMuc))
                return;

            DialogResult xacNhan = MessageBox.Show(
                $"Bạn có chắc muốn xóa danh mục \"{tenDanhMuc}\" không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (xacNhan != DialogResult.Yes)
                return;

            string ketQua = _danhMucBUS.Delete(maDanhMuc);

            MessageBox.Show(
                ketQua,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua == "Xóa danh mục thành công."
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua == "Xóa danh mục thành công.")
            {
                txtTenDanhMuc.Clear();

                LoadDanhMucGrid();
                LoadDanhMuc();
                LoadMon();
            }
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            if (dgvMon.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn món cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string maMon = dgvMon.CurrentRow
                .Cells["colMaMon"].Value?.ToString();

            string tenMon = dgvMon.CurrentRow
                .Cells["colTenMon"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(maMon))
                return;

            DialogResult xacNhan = MessageBox.Show(
                $"Bạn có chắc muốn xóa món \"{tenMon}\" không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (xacNhan != DialogResult.Yes)
                return;

            string ketQua = _monBUS.Delete(maMon);

            MessageBox.Show(
                ketQua,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua == "Xóa món thành công."
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua == "Xóa món thành công.")
            {
                txtMaMon.Clear();
                txtTenMon.Clear();
                txtGiaBan.Clear();

                if (cboDanhMucMon.Items.Count > 0)
                    cboDanhMucMon.SelectedIndex = 0;

                if (cboTrangThai.Items.Count > 0)
                    cboTrangThai.SelectedIndex = 0;

                LoadMon();
            }
        }

        private void btnTimKiem_Click(object sender, System.EventArgs e)
        {
            LocMon();
        }

        private void btnTimKiemDanhMuc_Click(object sender, EventArgs e)
        {
            string keyword = txtTenDanhMuc.Text.Trim();

            var danhSach = _danhMucBUS.Search(keyword)
                .OrderBy(x => x.MaDanhMuc)
                .ToList();

            dgvDanhMuc.DataSource = null;
            dgvDanhMuc.AutoGenerateColumns = false;
            dgvDanhMuc.DataSource = danhSach;
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LocMon();
        }

        private void LocMon()
        {
            string keyword = txtTimKiem.Text.Trim();

            var danhSachMon = _monBUS.Search(keyword);
            danhSachMon = danhSachMon.OrderBy(x => x.MaMon).ToList();
            var danhSachDanhMuc = _danhMucBUS.GetAll();

            string maDanhMuc = cboDanhMuc.SelectedValue?.ToString();

            // Nếu không phải "Tất cả danh mục" thì lọc tiếp theo danh mục
            if (!string.IsNullOrWhiteSpace(maDanhMuc))
            {
                danhSachMon = danhSachMon
                    .Where(x => x.MaDanhMuc == maDanhMuc)
                    .ToList();
            }

            var duLieu = danhSachMon.Select(mon => new
            {
                mon.MaMon,
                mon.TenMon,

                TenDanhMuc = danhSachDanhMuc
                    .FirstOrDefault(dm => dm.MaDanhMuc == mon.MaDanhMuc)?
                    .TenDanhMuc ?? mon.MaDanhMuc,

                mon.GiaBan,
                mon.TrangThai
            }).ToList();

            dgvMon.DataSource = null;
            dgvMon.AutoGenerateColumns = false;
            dgvMon.DataSource = duLieu;
        }
    }
}