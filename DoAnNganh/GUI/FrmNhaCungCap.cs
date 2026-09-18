using Đồ_án_ngành.BUS;
using MODEL;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Đồ_án_ngành.GUI
{
    public partial class FrmNhaCungCap : Form
    {
        private readonly NhaCungCapBUS _nhaCungCapBUS = new NhaCungCapBUS();

        public FrmNhaCungCap()
        {
            InitializeComponent();
        }

        private void FrmNhaCungCap_Load(object sender, System.EventArgs e)
        {
            LoadDanhSachNhaCungCap();
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvNhaCungCap.Rows[e.RowIndex];

            txtTenNCC.Text = row.Cells["colTenNCC"].Value?.ToString();
            txtSDT.Text = row.Cells["colSDT"].Value?.ToString();
            txtEmail.Text = row.Cells["colEmail"].Value?.ToString();
            txtDiaChi.Text = row.Cells["colDiaChi"].Value?.ToString();
        }

        private void LamMoiForm()
        {
            txtTenNCC.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();

            dgvNhaCungCap.ClearSelection();

            txtTenNCC.Focus();
        }

        private void btnLamMoi_Click(object sender, System.EventArgs e)
        {
            LamMoiForm();
        }

        private void btnThem_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên nhà cung cấp.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtTenNCC.Focus();
                return;
            }

            if (!KiemTraSDT())
                return;

            if (!KiemTraEmail())
                return;

            NhaCungCap ncc = new NhaCungCap
            {
                MaNCC = TaoMaNCCMoi(),
                TenNCC = txtTenNCC.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim()
            };

            string ketQua = _nhaCungCapBUS.Add(ncc);

            MessageBox.Show(
                ketQua,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua == "Thêm nhà cung cấp thành công."
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua == "Thêm nhà cung cấp thành công.")
            {
                LoadDanhSachNhaCungCap();
                LamMoiForm();
            }
        }

        private string TaoMaNCCMoi()
        {
            var danhSach = _nhaCungCapBUS.GetAll();

            if (danhSach.Count == 0)
                return "NCC001";

            int soLonNhat = danhSach
                .Select(x =>
                {
                    if (x.MaNCC != null &&
                        x.MaNCC.StartsWith("NCC") &&
                        int.TryParse(x.MaNCC.Substring(3), out int so))
                    {
                        return so;
                    }

                    return 0;
                })
                .Max();

            return $"NCC{soLonNhat + 1:D3}";
        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            if (dgvNhaCungCap.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn nhà cung cấp cần sửa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string maNCC = dgvNhaCungCap.SelectedRows[0]
                .Cells["colMaNCC"].Value?.ToString();

            NhaCungCap ncc = new NhaCungCap
            {
                MaNCC = maNCC,
                TenNCC = txtTenNCC.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim()
            };

            string ketQua = _nhaCungCapBUS.Update(ncc);

            MessageBox.Show(
                ketQua,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua == "Cập nhật nhà cung cấp thành công."
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua == "Cập nhật nhà cung cấp thành công.")
            {
                LoadDanhSachNhaCungCap();
                LamMoiForm();
            }
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            if (dgvNhaCungCap.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn nhà cung cấp cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (!KiemTraSDT())
                return;

            if (!KiemTraEmail())
                return;

            string maNCC = dgvNhaCungCap.SelectedRows[0]
                .Cells["colMaNCC"].Value?.ToString();

            string tenNCC = dgvNhaCungCap.SelectedRows[0]
                .Cells["colTenNCC"].Value?.ToString();

            DialogResult xacNhan = MessageBox.Show(
                $"Bạn có chắc muốn xóa nhà cung cấp \"{tenNCC}\" không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (xacNhan != DialogResult.Yes)
                return;

            string ketQua = _nhaCungCapBUS.Delete(maNCC);

            MessageBox.Show(
                ketQua,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua == "Xóa nhà cung cấp thành công."
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua == "Xóa nhà cung cấp thành công.")
            {
                LoadDanhSachNhaCungCap();
                LamMoiForm();
            }
        }

        private void HienThiDanhSach(List<NhaCungCap> danhSach)
        {
            dgvNhaCungCap.Rows.Clear();

            foreach (var ncc in danhSach)
            {
                dgvNhaCungCap.Rows.Add(
                    ncc.MaNCC,
                    ncc.TenNCC,
                    ncc.SDT,
                    ncc.Email,
                    ncc.DiaChi
                );
            }

            dgvNhaCungCap.ClearSelection();
        }

        private void LoadDanhSachNhaCungCap()
        {
            HienThiDanhSach(_nhaCungCapBUS.GetAll());
        }

        private void btnTimKiem_Click(object sender, System.EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            var ketQua = _nhaCungCapBUS.Search(keyword);

            HienThiDanhSach(ketQua);
        }

        private bool KiemTraSDT()
        {
            string sdt = txtSDT.Text.Trim();

            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show(
                    "Vui lòng nhập số điện thoại.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtSDT.Focus();
                return false;
            }

            if (sdt.Length != 10 || !sdt.All(char.IsDigit))
            {
                MessageBox.Show(
                    "Số điện thoại phải gồm đúng 10 chữ số.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtSDT.Focus();
                return false;
            }

            if (!sdt.StartsWith("0"))
            {
                MessageBox.Show(
                    "Số điện thoại phải bắt đầu bằng số 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtSDT.Focus();
                return false;
            }

            return true;
        }

        private bool KiemTraEmail()
        {
            string email = txtEmail.Text.Trim();

            // Email không bắt buộc
            if (string.IsNullOrWhiteSpace(email))
                return true;

            try
            {
                var diaChiEmail = new System.Net.Mail.MailAddress(email);

                if (diaChiEmail.Address != email)
                {
                    MessageBox.Show(
                        "Email không đúng định dạng.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtEmail.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show(
                    "Email không đúng định dạng.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtEmail.Focus();
                return false;
            }

            return true;
        }
    }
}
