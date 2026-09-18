using System;
using System.Drawing;
using System.Windows.Forms;
using Đồ_án_ngành.BUS;
using MODEL;

namespace Đồ_án_ngành
{
    public partial class FrmDangNhap : Form
    {
        private readonly NhanVienBUS _nhanVienBUS
            = new NhanVienBUS();

        private string _tenDangNhapDuocChon = "";

        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            _tenDangNhapDuocChon = "Manager";

            CapNhatNutDangChon(btnManager);
            txtPassword.Focus();
        }

        private void btnCash1_Click(object sender, EventArgs e)
        {
            _tenDangNhapDuocChon = "Cash1";

            CapNhatNutDangChon(btnCash1);
            txtPassword.Focus();
        }

        private void btnCash2_Click(object sender, EventArgs e)
        {
            _tenDangNhapDuocChon = "Cash2";

            CapNhatNutDangChon(btnCash2);
            txtPassword.Focus();
        }

        private void CapNhatNutDangChon(Button nutDangChon)
        {
            Button[] danhSachNut =
            {
                btnManager,
                btnCash1,
                btnCash2
            };

            foreach (var button in danhSachNut)
            {
                button.BackColor = Color.White;
                button.ForeColor = Color.FromArgb(78, 47, 32);
            }

            nutDangChon.BackColor =
                Color.FromArgb(78, 47, 32);

            nutDangChon.ForeColor =
                Color.White;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // 1. KIỂM TRA NHÂN VIÊN
            if (string.IsNullOrWhiteSpace(_tenDangNhapDuocChon))
            {
                MessageBox.Show(
                    "Vui lòng chọn nhân viên.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // 2. KIỂM TRA MẬT KHẨU
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập mật khẩu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Focus();
                return;
            }

            // 3. ĐĂNG NHẬP
            NhanVien nhanVien = _nhanVienBUS.DangNhap(
                _tenDangNhapDuocChon,
                txtPassword.Text,
                out string thongBao);

            if (nhanVien == null)
            {
                MessageBox.Show(
                    thongBao,
                    "Đăng nhập thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtPassword.Clear();
                txtPassword.Focus();

                return;
            }

            MessageBox.Show(
                thongBao,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            FrmMain frmMain = new FrmMain(nhanVien);

            this.Hide();
            frmMain.ShowDialog();
            this.Close();
        }
    }
}