using Đồ_án_ngành.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_ngành.GUI
{
    public partial class FrmDoiMatKhau : Form
    {
        private readonly NhanVienBUS _nhanVienBUS = new NhanVienBUS();

        public FrmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {
            var danhSachTaiKhoan = _nhanVienBUS.GetAll();

            cboTaiKhoan.DataSource = danhSachTaiKhoan;
            cboTaiKhoan.DisplayMember = "TenDangNhap";
            cboTaiKhoan.ValueMember = "MaNV";
            cboTaiKhoan.SelectedIndex = -1;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (cboTaiKhoan.SelectedValue == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn tài khoản.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cboTaiKhoan.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhauMoi.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập mật khẩu mới.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtMatKhauMoi.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtXacNhanMatKhau.Text))
            {
                MessageBox.Show(
                    "Vui lòng xác nhận mật khẩu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtXacNhanMatKhau.Focus();
                return;
            }

            if (txtMatKhauMoi.Text != txtXacNhanMatKhau.Text)
            {
                MessageBox.Show(
                    "Mật khẩu xác nhận không khớp.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtXacNhanMatKhau.Focus();
                txtXacNhanMatKhau.SelectAll();
                return;
            }

            string maNV = cboTaiKhoan.SelectedValue.ToString();

            string ketQua = _nhanVienBUS.DoiMatKhau(
                maNV,
                txtMatKhauMoi.Text
            );

            MessageBox.Show(
                ketQua,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua == "Đổi mật khẩu thành công."
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua == "Đổi mật khẩu thành công.")
            {
                txtMatKhauMoi.Clear();
                txtXacNhanMatKhau.Clear();
                txtMatKhauMoi.Focus();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
