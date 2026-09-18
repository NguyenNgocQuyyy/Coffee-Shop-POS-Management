using Đồ_án_ngành.BUS;
using MODEL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Đồ_án_ngành.GUI
{
    public partial class FrmThongTinKhachHang : Form
    {
        private readonly KhachHangBUS _khachHangBUS = new KhachHangBUS();
        private KhachHang _khachHangSua;

        public FrmThongTinKhachHang()
        {
            InitializeComponent();
            KhoiTaoThemMoi();
        }

        public FrmThongTinKhachHang(KhachHang khachHang)
        {
            InitializeComponent();

            _khachHangSua = khachHang;
            KhoiTaoCapNhat();
        }

        private void KhoiTaoThemMoi()
        {
            lblTieuDe.Text = "THÊM KHÁCH HÀNG";

            txtMaKH.Text = _khachHangBUS.TaoMaKhachHang();
            txtHoTen.Clear();
            txtSDT.Clear();

            dtpNgaySinh.Value = DateTime.Today;

            nudDiemTichLuy.Value = 0;
            nudDiemTichLuy.Enabled = false;

            txtHoTen.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string hoTen = txtHoTen.Text.Trim();
                string sdt = txtSDT.Text.Trim();

                if (string.IsNullOrWhiteSpace(hoTen))
                {
                    MessageBox.Show(
                        "Vui lòng nhập họ tên khách hàng.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtHoTen.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(sdt))
                {
                    MessageBox.Show(
                        "Vui lòng nhập số điện thoại.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtSDT.Focus();
                    return;
                }

                if (!sdt.All(char.IsDigit))
                {
                    MessageBox.Show(
                        "Số điện thoại chỉ được chứa chữ số.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtSDT.Focus();
                    return;
                }

                if (sdt.Length != 10)
                {
                    MessageBox.Show(
                        "Số điện thoại phải gồm 10 chữ số.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtSDT.Focus();
                    return;
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
                    return;
                }

                if (dtpNgaySinh.Value.Date > DateTime.Today)
                {
                    MessageBox.Show(
                        "Ngày sinh không được lớn hơn ngày hiện tại.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    dtpNgaySinh.Focus();
                    return;
                }

                KhachHang khachHang = new KhachHang
                {
                    MaKH = txtMaKH.Text.Trim(),
                    HoTen = hoTen,
                    SDT = sdt,
                    NgaySinh = dtpNgaySinh.Value.Date,
                    DiemTichLuy = _khachHangSua == null
                    ? 0
                    : _khachHangSua.DiemTichLuy
                };

                string ketQua;

                if (_khachHangSua == null)
                {
                    ketQua = _khachHangBUS.Add(khachHang);
                }
                else
                {
                    ketQua = _khachHangBUS.Update(khachHang);
                }

                bool thanhCong =
                    ketQua == "Thêm khách hàng thành công." ||
                    ketQua == "Cập nhật khách hàng thành công.";

                MessageBoxIcon icon = thanhCong
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning;

                MessageBox.Show(
                    ketQua,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    icon
                );

                if (!thanhCong)
                    return;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể thêm khách hàng.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void KhoiTaoCapNhat()
        {
            lblTieuDe.Text = "CẬP NHẬT KHÁCH HÀNG";

            txtMaKH.Text = _khachHangSua.MaKH;
            txtHoTen.Text = _khachHangSua.HoTen;
            txtSDT.Text = _khachHangSua.SDT;

            dtpNgaySinh.Value = _khachHangSua.NgaySinh;

            nudDiemTichLuy.Value = _khachHangSua.DiemTichLuy;
            nudDiemTichLuy.Enabled = false;

            txtHoTen.Focus();
        }
    }
}
