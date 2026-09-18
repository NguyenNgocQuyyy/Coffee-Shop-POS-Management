using Đồ_án_ngành.BUS;
using MODEL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Đồ_án_ngành.GUI
{
    public partial class FrmQuanLyTopping : Form
    {
        private readonly ToppingBUS _toppingBUS = new ToppingBUS();
        private bool _dangThemMoi = false;

        public FrmQuanLyTopping()
        {
            InitializeComponent();

            dgvTopping.AutoGenerateColumns = false;

            LoadTrangThai();
            LoadTopping();
        }

        private void LoadTrangThai()
        {
            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.Add("Tất cả");
            cboLocTrangThai.Items.Add("Đang bán");
            cboLocTrangThai.Items.Add("Ngừng bán");

            cboLocTrangThai.SelectedIndex = 0;

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Đang bán");
            cboTrangThai.Items.Add("Ngừng bán");

            cboTrangThai.SelectedIndex = 0;
        }

        private void LoadTopping()
        {
            dgvTopping.DataSource = null;
            dgvTopping.DataSource = _toppingBUS.GetAll();

            dgvTopping.Columns["colSoLuongTon"]
                .DefaultCellStyle.Format = "0.##";

            dgvTopping.Columns["colMucCanhBao"]
                .DefaultCellStyle.Format = "0.##";

            dgvTopping.Columns["colHeSoQuyDoi"]
                .DefaultCellStyle.Format = "0.##";
        }

        private void HienThiThongTinTopping()
        {
            if (dgvTopping.CurrentRow == null)
                return;

            Topping topping =
                dgvTopping.CurrentRow.DataBoundItem as Topping;

            if (topping == null)
                return;

            txtMaTopping.Text = topping.MaTopping;
            txtTenTopping.Text = topping.TenTopping;
            txtGiaBan.Text = topping.GiaBan.ToString("N0");
            txtSoLuongTon.Text = topping.SoLuongTon.ToString("0.##");
            txtMucCanhBao.Text = topping.MucCanhBao.ToString("0.##");
            txtDonViTinh.Text = topping.DonViTinh;

            txtDonViTinhQuyDoi.Text =
                topping.DonViTinhQuyDoi ?? "";

            nudHeSoQuyDoi.Value =
                topping.HeSoQuyDoi >= nudHeSoQuyDoi.Minimum &&
                topping.HeSoQuyDoi <= nudHeSoQuyDoi.Maximum
                    ? topping.HeSoQuyDoi
                    : 0;

            cboTrangThai.Text = topping.TrangThai;
        }

        private void dgvTopping_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _dangThemMoi = false;
                btnThem.Text = "+ THÊM TOPPING";

                HienThiThongTinTopping();
            }
        }

        private string TaoMaToppingMoi()
        {
            var ds = _toppingBUS.GetAll();

            if (ds == null || ds.Count == 0)
                return "TP001";

            int max = ds
                .Select(x => int.Parse(x.MaTopping.Substring(2)))
                .Max();

            return $"TP{max + 1:000}";
        }

        private void LamMoiForm()
        {
            txtMaTopping.Text = TaoMaToppingMoi();
            txtTenTopping.Clear();
            txtGiaBan.Clear();
            txtSoLuongTon.Clear();
            txtMucCanhBao.Clear();
            txtDonViTinh.Clear();
            txtDonViTinhQuyDoi.Clear();
            nudHeSoQuyDoi.Value = 0;

            cboTrangThai.SelectedItem = "Đang bán";

            txtTenTopping.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!_dangThemMoi)
            {
                _dangThemMoi = true;

                LamMoiForm();

                btnThem.Text = "LƯU TOPPING";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenTopping.Text))
            {
                MessageBox.Show("Vui lòng nhập tên topping.");
                txtTenTopping.Focus();
                return;
            }

            if (!decimal.TryParse(
                txtGiaBan.Text.Replace(",", ""),
                out decimal giaBan) || giaBan < 0)
            {
                MessageBox.Show("Giá bán không hợp lệ.");
                txtGiaBan.Focus();
                return;
            }

            if (!decimal.TryParse(txtMucCanhBao.Text, out decimal mucCanhBao) || mucCanhBao < 0)
            {
                MessageBox.Show("Mức cảnh báo không hợp lệ.");
                txtMucCanhBao.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDonViTinh.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính.");
                txtDonViTinh.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDonViTinhQuyDoi.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn vị quy đổi.");
                txtDonViTinhQuyDoi.Focus();
                return;
            }

            if (nudHeSoQuyDoi.Value <= 0)
            {
                MessageBox.Show("Hệ số quy đổi phải lớn hơn 0.");
                nudHeSoQuyDoi.Focus();
                return;
            }

            Topping topping = new Topping
            {
                MaTopping = txtMaTopping.Text.Trim(),
                TenTopping = txtTenTopping.Text.Trim(),
                GiaBan = giaBan,
                SoLuongTon = 0,
                MucCanhBao = mucCanhBao,
                DonViTinh = txtDonViTinh.Text.Trim(),
                DonViTinhQuyDoi = txtDonViTinhQuyDoi.Text.Trim(),
                HeSoQuyDoi = nudHeSoQuyDoi.Value,
                TrangThai = cboTrangThai.Text
            };

            _toppingBUS.Add(topping);

            MessageBox.Show("Thêm topping thành công.");

            _dangThemMoi = false;
            btnThem.Text = "+ THÊM TOPPING";

            LoadTopping();
            ChonToppingTheoMa(topping.MaTopping);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTopping.Text))
            {
                MessageBox.Show("Vui lòng chọn topping cần sửa.");
                return;
            }

            if (_dangThemMoi)
            {
                MessageBox.Show("Bạn đang thêm topping mới.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenTopping.Text))
            {
                MessageBox.Show("Vui lòng nhập tên topping.");
                txtTenTopping.Focus();
                return;
            }

            if (!decimal.TryParse(
                txtGiaBan.Text.Replace(",", ""),
                out decimal giaBan) || giaBan < 0)
            {
                MessageBox.Show("Giá bán không hợp lệ.");
                txtGiaBan.Focus();
                return;
            }

            if (!decimal.TryParse(txtSoLuongTon.Text, out decimal soLuongTon) || soLuongTon < 0)
            {
                MessageBox.Show("Số lượng tồn không hợp lệ.");
                txtSoLuongTon.Focus();
                return;
            }

            if (!decimal.TryParse(txtMucCanhBao.Text, out decimal mucCanhBao) || mucCanhBao < 0)
            {
                MessageBox.Show("Mức cảnh báo không hợp lệ.");
                txtMucCanhBao.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDonViTinh.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính.");
                txtDonViTinh.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDonViTinhQuyDoi.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn vị quy đổi.");
                txtDonViTinhQuyDoi.Focus();
                return;
            }

            if (nudHeSoQuyDoi.Value <= 0)
            {
                MessageBox.Show("Hệ số quy đổi phải lớn hơn 0.");
                nudHeSoQuyDoi.Focus();
                return;
            }

            Topping topping = new Topping
            {
                MaTopping = txtMaTopping.Text.Trim(),
                TenTopping = txtTenTopping.Text.Trim(),
                GiaBan = giaBan,
                SoLuongTon = soLuongTon,
                MucCanhBao = mucCanhBao,
                DonViTinh = txtDonViTinh.Text.Trim(),
                DonViTinhQuyDoi = txtDonViTinhQuyDoi.Text.Trim(),
                HeSoQuyDoi = nudHeSoQuyDoi.Value,
                TrangThai = cboTrangThai.Text
            };

            _toppingBUS.Update(topping);

            MessageBox.Show("Cập nhật topping thành công.");

            _dangThemMoi = false;
            btnThem.Text = "+ THÊM TOPPING";

            LoadTopping();
            ChonToppingTheoMa(topping.MaTopping);
        }

        private void LocVaTimKiemTopping()
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            string trangThai = cboLocTrangThai.Text;

            var ds = _toppingBUS.GetAll();

            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                ds = ds
                    .Where(x =>
                        x.MaTopping.ToLower().Contains(tuKhoa) ||
                        x.TenTopping.ToLower().Contains(tuKhoa))
                    .ToList();
            }

            if (trangThai != "Tất cả")
            {
                ds = ds
                    .Where(x => x.TrangThai == trangThai)
                    .ToList();
            }

            dgvTopping.DataSource = null;
            dgvTopping.DataSource = ds;

            if (dgvTopping.Rows.Count == 0)
            {
                XoaThongTinTopping();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LocVaTimKiemTopping();
        }

        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocVaTimKiemTopping();
        }

        private void ChonToppingTheoMa(string maTopping)
        {
            foreach (DataGridViewRow row in dgvTopping.Rows)
            {
                if (row.Cells["colMaTopping"].Value?.ToString() == maTopping)
                {
                    row.Selected = true;
                    dgvTopping.CurrentCell = row.Cells["colMaTopping"];

                    HienThiThongTinTopping();
                    break;
                }
            }
        }

        private void XoaThongTinTopping()
        {
            txtMaTopping.Clear();
            txtTenTopping.Clear();
            txtGiaBan.Clear();
            txtSoLuongTon.Clear();
            txtMucCanhBao.Clear();
            txtDonViTinh.Clear();
            txtDonViTinhQuyDoi.Clear();
            nudHeSoQuyDoi.Value = 0;

            cboTrangThai.SelectedIndex = -1;
        }

        private void pnlThongTin_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
