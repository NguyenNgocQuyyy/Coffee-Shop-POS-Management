using Đồ_án_ngành.BUS;
using MODEL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Đồ_án_ngành.GUI
{
    public partial class FrmQuanLyKhachHang : Form
    {
        private readonly KhachHangBUS _khachHangBUS = new KhachHangBUS();

        public FrmQuanLyKhachHang()
        {
            InitializeComponent();

            cboHangHoiVien.Items.Add("Tất cả");
            cboHangHoiVien.Items.Add("Đồng");
            cboHangHoiVien.Items.Add("Bạc");
            cboHangHoiVien.Items.Add("Vàng");
            cboHangHoiVien.Items.Add("Kim cương");

            cboHangHoiVien.SelectedIndex = 0;

            LoadKhachHang();
        }

        private void LoadKhachHang()
        {
            try
            {
                dgvKhachHang.AutoGenerateColumns = false;

                dgvKhachHang.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgvKhachHang.ColumnHeadersHeight = 45;

                var danhSach = _khachHangBUS.GetAll();

                dgvKhachHang.DataSource = danhSach;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách khách hàng.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txtTimKiem.Text.Trim();

                if (string.IsNullOrWhiteSpace(tuKhoa))
                {
                    LoadKhachHang();
                    return;
                }

                var ketQua = _khachHangBUS.Search(tuKhoa);

                dgvKhachHang.DataSource = ketQua;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tìm kiếm khách hàng.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLamMoiTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadKhachHang();
            txtTimKiem.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (FrmThongTinKhachHang frm = new FrmThongTinKhachHang())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadKhachHang();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn khách hàng cần cập nhật.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string maKH = dgvKhachHang.CurrentRow.Cells["colMaKH"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(maKH))
            {
                MessageBox.Show(
                    "Không lấy được mã khách hàng.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            KhachHang khachHang = _khachHangBUS.GetById(maKH);

            if (khachHang == null)
            {
                MessageBox.Show(
                    "Không tìm thấy khách hàng.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            using (FrmThongTinKhachHang frm = new FrmThongTinKhachHang(khachHang))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadKhachHang();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn khách hàng cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string maKH = dgvKhachHang.CurrentRow.Cells["colMaKH"].Value?.ToString();
            string hoTen = dgvKhachHang.CurrentRow.Cells["colHoTen"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(maKH))
            {
                MessageBox.Show(
                    "Không lấy được mã khách hàng.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                $"Bạn có chắc muốn xóa khách hàng \"{hoTen}\" không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (xacNhan != DialogResult.Yes)
                return;

            string ketQua = _khachHangBUS.Delete(maKH);

            MessageBoxIcon icon =
                ketQua == "Xóa khách hàng thành công."
                ? MessageBoxIcon.Information
                : MessageBoxIcon.Warning;

            MessageBox.Show(
                ketQua,
                "Thông báo",
                MessageBoxButtons.OK,
                icon
            );

            if (ketQua == "Xóa khách hàng thành công.")
            {
                LoadKhachHang();
            }
        }

        private void dgvKhachHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKhachHang.Columns[e.ColumnIndex].Name != "colHangHoiVien")
                return;

            if (dgvKhachHang.Rows[e.RowIndex].DataBoundItem is KhachHang khachHang)
            {
                e.Value = _khachHangBUS.GetHangHoiVien(khachHang.DiemTichLuy);
                e.FormattingApplied = true;
            }
        }

        private void LocTheoHangHoiVien()
        {
            var danhSach = _khachHangBUS.GetAll();

            string hang = cboHangHoiVien.SelectedItem?.ToString();

            if (hang == "Tất cả" || string.IsNullOrWhiteSpace(hang))
            {
                dgvKhachHang.DataSource = danhSach;
                return;
            }

            var ketQua = danhSach
                .Where(kh => _khachHangBUS.GetHangHoiVien(kh.DiemTichLuy) == hang)
                .ToList();

            dgvKhachHang.DataSource = ketQua;
        }

        private void cboHangHoiVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocTheoHangHoiVien();
        }
    }
}
