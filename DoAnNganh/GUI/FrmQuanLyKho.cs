using Đồ_án_ngành.BUS;
using MODEL;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

namespace Đồ_án_ngành.GUI
{
    public partial class FrmQuanLyKho : Form
    {
        private readonly NguyenVatLieuBUS _nguyenVatLieuBUS = new NguyenVatLieuBUS();

        public FrmQuanLyKho()
        {
            InitializeComponent();

            LoadNguyenVatLieu();

            this.Shown += FrmQuanLyKho_Shown;
        }

        private void LoadNguyenVatLieu()
        {
            List<NguyenVatLieu> danhSach = _nguyenVatLieuBUS.GetAll();

            dgvNguyenVatLieu.AutoGenerateColumns = false;
            dgvNguyenVatLieu.DataSource = danhSach;

            dgvNguyenVatLieu.Columns["SoLuongTon"]
                .DefaultCellStyle.Format = "0.##";

            dgvNguyenVatLieu.Columns["MucCanhBao"]
                .DefaultCellStyle.Format = "0.##";

            dgvNguyenVatLieu.ClearSelection();
            dgvNguyenVatLieu.CurrentCell = null;

            dgvNguyenVatLieu.Columns["HeSoQuyDoi"]
                .DefaultCellStyle.Format = "0.##";
        }

        private void dgvNguyenVatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvNguyenVatLieu.Rows[e.RowIndex];

            txtMaNVL.Text = row.Cells["MaNVL"].Value?.ToString();
            txtTenNVL.Text = row.Cells["TenNVL"].Value?.ToString();

            if (decimal.TryParse(
                row.Cells["SoLuongTon"].Value?.ToString(),
                out decimal soLuongTon))
            {
                txtSoLuongTon.Text = soLuongTon.ToString("0.##");
            }

            if (decimal.TryParse(
                row.Cells["MucCanhBao"].Value?.ToString(),
                out decimal mucCanhBao))
            {
                txtMucCanhBao.Text = mucCanhBao.ToString("0.##");
            }
            ;

            txtDonViTinh.Text = row.Cells["DonViTinh"].Value?.ToString();

            txtDonViTinhQuyDoi.Text = row.Cells["DonViTinhQuyDoi"].Value?.ToString();

            if (decimal.TryParse(
                row.Cells["HeSoQuyDoi"].Value?.ToString(),
                out decimal heSoQuyDoi))
            {
                txtHeSoQuyDoi.Text = heSoQuyDoi.ToString("0.##");
            }
            else
            {
                txtHeSoQuyDoi.Clear();
            }

            cboTrangThaiNVL.Text = row.Cells["TrangThai"].Value?.ToString();
            txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
        }

        private void TaoMaNVLTuDong()
        {
            List<NguyenVatLieu> danhSach = _nguyenVatLieuBUS.GetAll();

            int soLonNhat = 0;

            foreach (NguyenVatLieu nvl in danhSach)
            {
                if (!string.IsNullOrWhiteSpace(nvl.MaNVL) &&
                    nvl.MaNVL.StartsWith("NVL") &&
                    int.TryParse(nvl.MaNVL.Substring(3), out int so))
                {
                    if (so > soLonNhat)
                        soLonNhat = so;
                }
            }

            txtMaNVL.Text = $"NVL{soLonNhat + 1:D3}";
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNVL.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên nguyên vật liệu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtTenNVL.Focus();
                return;
            }

            if (!decimal.TryParse(txtMucCanhBao.Text, out decimal mucCanhBao))
            {
                MessageBox.Show(
                    "Mức cảnh báo không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtMucCanhBao.Focus();
                return;
            }

            if (mucCanhBao < 0)
            {
                MessageBox.Show(
                    "Mức cảnh báo không được nhỏ hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtMucCanhBao.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDonViTinh.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập đơn vị tính.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtDonViTinh.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDonViTinhQuyDoi.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập đơn vị công thức.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtDonViTinhQuyDoi.Focus();
                return;
            }

            if (!decimal.TryParse(
                txtHeSoQuyDoi.Text,
                out decimal heSoQuyDoi))
            {
                MessageBox.Show(
                    "Hệ số quy đổi không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtHeSoQuyDoi.Focus();
                return;
            }

            if (heSoQuyDoi <= 0)
            {
                MessageBox.Show(
                    "Hệ số quy đổi phải lớn hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtHeSoQuyDoi.Focus();
                return;
            }

            TaoMaNVLTuDong();

            NguyenVatLieu nguyenVatLieu = new NguyenVatLieu
            {
                MaNVL = txtMaNVL.Text.Trim(),
                TenNVL = txtTenNVL.Text.Trim(),
                SoLuongTon = 0,
                MucCanhBao = mucCanhBao,
                DonViTinh = txtDonViTinh.Text.Trim(),
                DonViTinhQuyDoi = txtDonViTinhQuyDoi.Text.Trim(),
                HeSoQuyDoi = heSoQuyDoi,
                GhiChu = txtGhiChu.Text.Trim()
            };

            string ketQua = _nguyenVatLieuBUS.Add(nguyenVatLieu);

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
                LoadNguyenVatLieu();

                txtMaNVL.Clear();
                txtTenNVL.Clear();
                txtSoLuongTon.Clear();
                txtMucCanhBao.Clear();
                txtDonViTinh.Clear();
                txtDonViTinhQuyDoi.Clear();
                txtHeSoQuyDoi.Clear();
                cboTrangThaiNVL.SelectedIndex = -1;
                txtGhiChu.Clear();

                txtTenNVL.Focus();
            }
        }

        private void btnCapNhat_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNVL.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn nguyên vật liệu cần cập nhật.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenNVL.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên nguyên vật liệu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtTenNVL.Focus();
                return;
            }

            if (!decimal.TryParse(txtSoLuongTon.Text, out decimal soLuongTon))
            {
                MessageBox.Show(
                    "Số lượng tồn không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (!decimal.TryParse(txtMucCanhBao.Text, out decimal mucCanhBao))
            {
                MessageBox.Show(
                    "Mức cảnh báo không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtMucCanhBao.Focus();
                return;
            }

            if (mucCanhBao < 0)
            {
                MessageBox.Show(
                    "Mức cảnh báo không được nhỏ hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtMucCanhBao.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDonViTinh.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập đơn vị tính.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtDonViTinh.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDonViTinhQuyDoi.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập đơn vị công thức.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtDonViTinhQuyDoi.Focus();
                return;
            }

            if (!decimal.TryParse(
                txtHeSoQuyDoi.Text,
                out decimal heSoQuyDoi))
            {
                MessageBox.Show(
                    "Hệ số quy đổi không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtHeSoQuyDoi.Focus();
                return;
            }

            if (heSoQuyDoi <= 0)
            {
                MessageBox.Show(
                    "Hệ số quy đổi phải lớn hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtHeSoQuyDoi.Focus();
                return;
            }

            NguyenVatLieu nguyenVatLieu = new NguyenVatLieu
            {
                MaNVL = txtMaNVL.Text.Trim(),
                TenNVL = txtTenNVL.Text.Trim(),
                SoLuongTon = soLuongTon,
                MucCanhBao = mucCanhBao,
                DonViTinh = txtDonViTinh.Text.Trim(),
                DonViTinhQuyDoi = txtDonViTinhQuyDoi.Text.Trim(),
                HeSoQuyDoi = heSoQuyDoi,
                GhiChu = txtGhiChu.Text.Trim()
            };

            string ketQua = _nguyenVatLieuBUS.Update(nguyenVatLieu);

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
                LoadNguyenVatLieu();
            }
        }

        private void txtTimKiem_TextChanged(object sender, System.EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            dgvNguyenVatLieu.AutoGenerateColumns = false;
            dgvNguyenVatLieu.DataSource =
                _nguyenVatLieuBUS.Search(keyword);
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var danhSach = _nguyenVatLieuBUS.GetAll();

            string trangThai = cboTrangThai.Text;

            if (trangThai == "Tất cả" || string.IsNullOrWhiteSpace(trangThai))
            {
                dgvNguyenVatLieu.DataSource = danhSach;
                return;
            }

            dgvNguyenVatLieu.DataSource = danhSach
                .Where(x => x.TrangThai == trangThai)
                .ToList();
        }

        private void LamMoiForm()
        {
            txtTimKiem.Clear();

            cboTrangThai.SelectedIndex = 0;

            txtMaNVL.Clear();
            txtTenNVL.Clear();
            txtSoLuongTon.Clear();
            txtMucCanhBao.Clear();
            txtDonViTinh.Clear();
            txtDonViTinhQuyDoi.Clear();
            txtHeSoQuyDoi.Clear();
            cboTrangThaiNVL.SelectedIndex = -1;
            txtGhiChu.Clear();

            LoadNguyenVatLieu();

            txtTenNVL.Focus();
        }

        private void btnLamMoi_Click(object sender, System.EventArgs e)
        {
            LamMoiForm();
        }

        private void dgvNguyenVatLieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNguyenVatLieu.Rows[e.RowIndex]
        .DataBoundItem is NguyenVatLieu nvl)
            {
                if (nvl.TrangThai == "Hết hàng")
                {
                    dgvNguyenVatLieu.Rows[e.RowIndex]
                        .DefaultCellStyle.BackColor = Color.MistyRose;
                }
                else if (nvl.TrangThai == "Sắp hết")
                {
                    dgvNguyenVatLieu.Rows[e.RowIndex]
                        .DefaultCellStyle.BackColor = Color.LemonChiffon;
                }
                else
                {
                    dgvNguyenVatLieu.Rows[e.RowIndex]
                        .DefaultCellStyle.BackColor = Color.White;
                }
            }

        }

        private void FrmQuanLyKho_Shown(object sender, System.EventArgs e)
        {
            dgvNguyenVatLieu.ClearSelection();
            dgvNguyenVatLieu.CurrentCell = null;
        }
    }
}
