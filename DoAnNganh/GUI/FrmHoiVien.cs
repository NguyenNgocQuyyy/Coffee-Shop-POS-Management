using Đồ_án_ngành.BUS;
using MODEL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Đồ_án_ngành.GUI
{
    public partial class FrmHoiVien : Form
    {
        private readonly KhachHangBUS _khachHangBUS = new KhachHangBUS();
        public KhachHang KhachHangDuocChon { get; private set; }

        public FrmHoiVien()
        {
            InitializeComponent();
        }

        private void btnTimHoiVien_Click(object sender, EventArgs e)
        {
            var khachHang = _khachHangBUS.GetBySDT(txtSoDienThoai.Text);

            if (khachHang == null)
            {
                MessageBox.Show(
                    "Không tìm thấy hội viên với số điện thoại này.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }
            KhachHangDuocChon = khachHang;

            txtMaHoiVien.Text = khachHang.MaKH;
            txtHoTen.Text = khachHang.HoTen;
            txtNgaySinh.Text = khachHang.NgaySinh.ToString("dd/MM/yyyy");
            txtDiemTichLuy.Text = khachHang.DiemTichLuy.ToString();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (KhachHangDuocChon == null)
            {
                MessageBox.Show(
                    "Vui lòng tìm và chọn hội viên trước.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
