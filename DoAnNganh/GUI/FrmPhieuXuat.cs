using Đồ_án_ngành.BUS;
using MODEL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Đồ_án_ngành.GUI
{
    public partial class FrmPhieuXuat : Form
    {
        private readonly NguyenVatLieuBUS _nguyenVatLieuBUS = new NguyenVatLieuBUS();
        private readonly ToppingBUS _toppingBUS = new ToppingBUS();
        private readonly PhieuXuatBUS _phieuXuatBUS = new PhieuXuatBUS();
        private decimal _soLuongCu;
        private bool _dangXemLichSu = false;
        private bool _dangXemChiTietLichSu = false;

        public FrmPhieuXuat()
        {
            InitializeComponent();
        }

        private void FrmPhieuXuat_Load(object sender, EventArgs e)
        {
            dtpNgayXuat.Value = System.DateTime.Now;

            cboLoaiMatHang.Items.Clear();
            cboLoaiMatHang.Items.Add("Nguyên vật liệu");
            cboLoaiMatHang.Items.Add("Topping");

            cboLoaiMatHang.SelectedIndex = 0;
        }

        private void cboLoaiMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMatHang.DataSource = null;

            if (cboLoaiMatHang.SelectedItem == null)
                return;

            string loaiMatHang = cboLoaiMatHang.SelectedItem.ToString();

            if (loaiMatHang == "Nguyên vật liệu")
            {
                var danhSach = _nguyenVatLieuBUS.GetAll();

                cboMatHang.DataSource = danhSach;
                cboMatHang.DisplayMember = "TenNVL";
                cboMatHang.ValueMember = "MaNVL";
            }
            else if (loaiMatHang == "Topping")
            {
                var danhSach = _toppingBUS.GetAll();

                cboMatHang.DataSource = danhSach;
                cboMatHang.DisplayMember = "TenTopping";
                cboMatHang.ValueMember = "MaTopping";
            }
        }

        private void btnThemMatHang_Click(object sender, EventArgs e)
        {
            if (cboLoaiMatHang.SelectedItem == null || cboMatHang.SelectedItem == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn mặt hàng.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            decimal soLuong = nudSoLuongXuat.Value;

            if (soLuong <= 0)
            {
                MessageBox.Show(
                    "Số lượng xuất phải lớn hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string loaiMatHang = cboLoaiMatHang.SelectedItem.ToString();

            string maMatHang = "";

            if (loaiMatHang == "Nguyên vật liệu")
            {
                NguyenVatLieu nvl = cboMatHang.SelectedItem as NguyenVatLieu;

                if (nvl == null)
                    return;

                maMatHang = nvl.MaNVL;
            }
            else if (loaiMatHang == "Topping")
            {
                Topping topping = cboMatHang.SelectedItem as Topping;

                if (topping == null)
                    return;

                maMatHang = topping.MaTopping;
            }

            foreach (DataGridViewRow row in dgvChiTietXuat.Rows)
            {
                if (row.Cells["colMaMatHang"].Value?.ToString() == maMatHang)
                {
                    MessageBox.Show(
                        "Mặt hàng này đã có trong danh sách xuất.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }
            }

            if (loaiMatHang == "Nguyên vật liệu")
            {
                NguyenVatLieu nvl = cboMatHang.SelectedItem as NguyenVatLieu;

                if (nvl == null)
                    return;

                if (soLuong > nvl.SoLuongTon)
                {
                    MessageBox.Show(
                        $"Số lượng xuất vượt quá tồn kho. Hiện còn {nvl.SoLuongTon} {nvl.DonViTinh}.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                dgvChiTietXuat.Rows.Add(
                    "Nguyên vật liệu",
                    nvl.MaNVL,
                    nvl.TenNVL,
                    soLuong,
                    nvl.DonViTinh
                );
            }
            else if (loaiMatHang == "Topping")
            {
                Topping topping = cboMatHang.SelectedItem as Topping;

                if (topping == null)
                    return;

                if (soLuong > topping.SoLuongTon)
                {
                    MessageBox.Show(
                        $"Số lượng xuất vượt quá tồn kho. Hiện còn {topping.SoLuongTon} {topping.DonViTinh}.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                dgvChiTietXuat.Rows.Add(
                    "Topping",
                    topping.MaTopping,
                    topping.TenTopping,
                    soLuong,
                    topping.DonViTinh
                );
            }

            nudSoLuongXuat.Value = nudSoLuongXuat.Minimum;

            TinhGiaTriHaoHut();
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvChiTietXuat.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn mặt hàng cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            dgvChiTietXuat.Rows.Remove(dgvChiTietXuat.CurrentRow);

            TinhGiaTriHaoHut();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _dangXemLichSu = false;
            _dangXemChiTietLichSu = false;

            // Mở lại chế độ lập phiếu
            dgvChiTietXuat.ReadOnly = false;

            btnThemMatHang.Enabled = true;
            btnXoaDong.Enabled = true;
            btnLuuPhieu.Enabled = true;

            cboLoaiMatHang.Enabled = true;
            cboMatHang.Enabled = true;
            nudSoLuongXuat.Enabled = true;

            // Trả tiêu đề DGV về mặc định
            dgvChiTietXuat.Columns["colLoaiMatHang"].HeaderText =
                "Loại mặt hàng";

            dgvChiTietXuat.Columns["colMaMatHang"].HeaderText =
                "Mã mặt hàng";

            dgvChiTietXuat.Columns["colTenMatHang"].HeaderText =
                "Tên mặt hàng";

            dgvChiTietXuat.Columns["colSoLuong"].HeaderText =
                "Số lượng";

            dgvChiTietXuat.Columns["colDonViTinh"].HeaderText =
                "Đơn vị tính";

            txtMaPhieuXuat.Clear();
            txtLyDoXuat.Clear();

            chkLaHaoHut.Checked = false;

            dtpNgayXuat.Value = System.DateTime.Now;

            cboLoaiMatHang.SelectedIndex = 0;

            if (cboMatHang.Items.Count > 0)
                cboMatHang.SelectedIndex = 0;

            nudSoLuongXuat.Value = nudSoLuongXuat.Minimum;

            dgvChiTietXuat.Rows.Clear();

        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLyDoXuat.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập lý do xuất.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtLyDoXuat.Focus();
                return;
            }

            if (dgvChiTietXuat.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng thêm ít nhất một mặt hàng vào phiếu xuất.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaPhieuXuat.Text))
            {
                txtMaPhieuXuat.Text = TaoMaPhieuXuatMoi();
            }

            PhieuXuat phieuXuat = new PhieuXuat
            {
                MaPhieuXuat = txtMaPhieuXuat.Text.Trim(),
                NgayXuat = dtpNgayXuat.Value.Date,
                LyDoXuat = txtLyDoXuat.Text.Trim(),
                LaHaoHut = chkLaHaoHut.Checked
            };

            List<ChiTietPhieuXuat> danhSachChiTiet = new List<ChiTietPhieuXuat>();

            int stt = 1;

            foreach (DataGridViewRow row in dgvChiTietXuat.Rows)
            {
                string loaiMatHang = row.Cells["colLoaiMatHang"].Value?.ToString();
                string maMatHang = row.Cells["colMaMatHang"].Value?.ToString();

                decimal soLuong = Convert.ToDecimal(
                    row.Cells["colSoLuong"].Value
                );

                ChiTietPhieuXuat chiTiet = new ChiTietPhieuXuat
                {
                    MaChiTietPX = $"{phieuXuat.MaPhieuXuat}-CT{stt:D2}",
                    MaPhieuXuat = phieuXuat.MaPhieuXuat,
                    SoLuong = soLuong
                };

                if (loaiMatHang == "Nguyên vật liệu")
                {
                    chiTiet.MaNVL = maMatHang;
                    chiTiet.MaTopping = null;
                }
                else if (loaiMatHang == "Topping")
                {
                    chiTiet.MaNVL = null;
                    chiTiet.MaTopping = maMatHang;
                }

                danhSachChiTiet.Add(chiTiet);
                stt++;
            }

            string ketQua = _phieuXuatBUS.Add(phieuXuat,danhSachChiTiet);

            MessageBox.Show(
                ketQua,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua == "Xuất kho thành công."
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua == "Xuất kho thành công.")
            {
                txtMaPhieuXuat.Clear();
                txtLyDoXuat.Clear();

                chkLaHaoHut.Checked = false;

                dtpNgayXuat.Value = System.DateTime.Now;

                cboLoaiMatHang.SelectedIndex = 0;

                if (cboMatHang.Items.Count > 0)
                    cboMatHang.SelectedIndex = 0;

                nudSoLuongXuat.Value = nudSoLuongXuat.Minimum;

                dgvChiTietXuat.Rows.Clear();
            }
        }

        private string TaoMaPhieuXuatMoi()
        {
            var danhSach = _phieuXuatBUS.GetAll();

            if (danhSach == null || danhSach.Count == 0)
                return "PX001";

            int soLonNhat = 0;

            foreach (var phieu in danhSach)
            {
                if (string.IsNullOrWhiteSpace(phieu.MaPhieuXuat))
                    continue;

                string phanSo = phieu.MaPhieuXuat.Replace("PX", "");

                if (int.TryParse(phanSo, out int so))
                {
                    if (so > soLonNhat)
                        soLonNhat = so;
                }
            }

            return $"PX{soLonNhat + 1:D3}";
        }

        private void dgvChiTietXuat_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvChiTietXuat.Columns[e.ColumnIndex].Name != "colSoLuong")
                return;

            DataGridViewRow row = dgvChiTietXuat.Rows[e.RowIndex];

            if (!decimal.TryParse(
                row.Cells["colSoLuong"].Value?.ToString(),
                out decimal soLuong) || soLuong <= 0)
            {
                MessageBox.Show(
                    "Số lượng xuất không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                row.Cells["colSoLuong"].Value = _soLuongCu;
                return;
            }

            string loaiMatHang =
                row.Cells["colLoaiMatHang"].Value?.ToString();

            string maMatHang =
                row.Cells["colMaMatHang"].Value?.ToString();

            if (loaiMatHang == "Nguyên vật liệu")
            {
                NguyenVatLieu nvl =
                    _nguyenVatLieuBUS.GetById(maMatHang);

                if (nvl != null && soLuong > nvl.SoLuongTon)
                {
                    MessageBox.Show(
                        $"Số lượng xuất vượt quá tồn kho. Hiện còn {nvl.SoLuongTon} {nvl.DonViTinh}.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    row.Cells["colSoLuong"].Value = nvl.SoLuongTon;
                }
            }
            else if (loaiMatHang == "Topping")
            {
                Topping topping =
                    _toppingBUS.GetById(maMatHang);

                if (topping != null && soLuong > topping.SoLuongTon)
                {
                    MessageBox.Show(
                        $"Số lượng xuất vượt quá tồn kho. Hiện còn {topping.SoLuongTon} {topping.DonViTinh}.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    row.Cells["colSoLuong"].Value = topping.SoLuongTon;
                }
            }

            TinhGiaTriHaoHut();
        }

        private void dgvChiTietXuat_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvChiTietXuat.Columns[e.ColumnIndex].Name != "colSoLuong")
                return;

            decimal.TryParse(
                dgvChiTietXuat.Rows[e.RowIndex]
                    .Cells["colSoLuong"]
                    .Value?.ToString(),
                out _soLuongCu
            );
        }

        private void chkLaHaoHut_CheckedChanged(object sender, EventArgs e)
        {
            lblGiaTriHaoHut.Visible = chkLaHaoHut.Checked;

            if (!chkLaHaoHut.Checked)
            {
                lblGiaTriHaoHut.Text = "Giá trị hao hụt: 0 VNĐ";
                return;
            }

            TinhGiaTriHaoHut();
        }

        private void TinhGiaTriHaoHut()
        {
            if (!chkLaHaoHut.Checked)
            {
                lblGiaTriHaoHut.Text = "Giá trị hao hụt: 0 VNĐ";
                return;
            }

            decimal tongHaoHut = 0;

            foreach (DataGridViewRow row in dgvChiTietXuat.Rows)
            {
                string loaiMatHang =
                    row.Cells["colLoaiMatHang"].Value?.ToString();

                string maMatHang =
                    row.Cells["colMaMatHang"].Value?.ToString();

                decimal soLuong = Convert.ToDecimal(
                    row.Cells["colSoLuong"].Value
                );

                decimal donGia = 0;

                if (loaiMatHang == "Nguyên vật liệu")
                {
                    donGia = _phieuXuatBUS.LayDonGiaNhapGanNhat(
                        maMatHang,null);
                }
                else if (loaiMatHang == "Topping")
                {
                    donGia = _phieuXuatBUS.LayDonGiaNhapGanNhat(
                        null,maMatHang);
                }

                tongHaoHut += soLuong * donGia;
            }

            lblGiaTriHaoHut.Text =
                $"Giá trị hao hụt: {tongHaoHut:N0} VNĐ";
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            var danhSach = _phieuXuatBUS.GetAll();

            dgvChiTietXuat.Rows.Clear();

            _dangXemLichSu = true;
            _dangXemChiTietLichSu = false;

            // Đổi tiêu đề cột sang chế độ lịch sử
            dgvChiTietXuat.Columns["colLoaiMatHang"].HeaderText =
                "Mã phiếu";

            dgvChiTietXuat.Columns["colMaMatHang"].HeaderText =
                "Ngày xuất";

            dgvChiTietXuat.Columns["colTenMatHang"].HeaderText =
                "Lý do xuất";

            dgvChiTietXuat.Columns["colSoLuong"].HeaderText =
                "Số mặt hàng";

            dgvChiTietXuat.Columns["colDonViTinh"].HeaderText =
                "Hao hụt";

            foreach (PhieuXuat phieu in danhSach)
            {
                int index = dgvChiTietXuat.Rows.Add(
                    phieu.MaPhieuXuat,
                    phieu.NgayXuat.ToString("dd/MM/yyyy"),
                    phieu.LyDoXuat,
                    phieu.ChiTietPhieuXuats != null
                        ? phieu.ChiTietPhieuXuats.Count
                        : 0,
                    phieu.LaHaoHut ? "Có" : "Không"
                );

                dgvChiTietXuat.Rows[index].Tag =
                    phieu.MaPhieuXuat;
            }

            dgvChiTietXuat.ReadOnly = true;

            btnThemMatHang.Enabled = false;
            btnXoaDong.Enabled = false;
            btnLuuPhieu.Enabled = false;

            cboLoaiMatHang.Enabled = false;
            cboMatHang.Enabled = false;
            nudSoLuongXuat.Enabled = false;
        }

        private void dgvChiTietXuat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!_dangXemLichSu)
                return;

            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvChiTietXuat.Rows[e.RowIndex];

            string maPhieuXuat =
                row.Tag?.ToString();

            if (string.IsNullOrWhiteSpace(maPhieuXuat))
                return;

            HienThiChiTietPhieuXuatCu(maPhieuXuat);
        }

        private void HienThiChiTietPhieuXuatCu(string maPhieuXuat)
        {
            PhieuXuat phieu =
                _phieuXuatBUS.GetById(maPhieuXuat);

            if (phieu == null)
            {
                MessageBox.Show(
                    "Không tìm thấy phiếu xuất.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            _dangXemLichSu = true;
            _dangXemChiTietLichSu = true;

            // Hiển thị thông tin phiếu cũ
            txtMaPhieuXuat.Text =
                phieu.MaPhieuXuat;

            dtpNgayXuat.Value =
                phieu.NgayXuat;

            txtLyDoXuat.Text =
                phieu.LyDoXuat;

            chkLaHaoHut.Checked =
                phieu.LaHaoHut;

            // Trả tiêu đề DGV về chế độ chi tiết
            dgvChiTietXuat.Columns["colLoaiMatHang"].HeaderText =
                "Loại mặt hàng";

            dgvChiTietXuat.Columns["colMaMatHang"].HeaderText =
                "Mã mặt hàng";

            dgvChiTietXuat.Columns["colTenMatHang"].HeaderText =
                "Tên mặt hàng";

            dgvChiTietXuat.Columns["colSoLuong"].HeaderText =
                "Số lượng";

            dgvChiTietXuat.Columns["colDonViTinh"].HeaderText =
                "Đơn vị tính";

            dgvChiTietXuat.Rows.Clear();

            foreach (ChiTietPhieuXuat chiTiet
                     in phieu.ChiTietPhieuXuats)
            {
                string loaiMatHang;
                string maMatHang;
                string tenMatHang;
                string donViTinh;

                if (!string.IsNullOrWhiteSpace(
                        chiTiet.MaNVL))
                {
                    loaiMatHang = "Nguyên vật liệu";
                    maMatHang = chiTiet.MaNVL;

                    tenMatHang =
                        chiTiet.NguyenVatLieu != null
                            ? chiTiet.NguyenVatLieu.TenNVL
                            : "";

                    donViTinh =
                        chiTiet.NguyenVatLieu != null
                            ? chiTiet.NguyenVatLieu.DonViTinh
                            : "";
                }
                else
                {
                    loaiMatHang = "Topping";
                    maMatHang = chiTiet.MaTopping;

                    tenMatHang =
                        chiTiet.Topping != null
                            ? chiTiet.Topping.TenTopping
                            : "";

                    donViTinh =
                        chiTiet.Topping != null
                            ? chiTiet.Topping.DonViTinh
                            : "";
                }

                dgvChiTietXuat.Rows.Add(
                    loaiMatHang,
                    maMatHang,
                    tenMatHang,
                    chiTiet.SoLuong,
                    donViTinh
                );
            }

            dgvChiTietXuat.ReadOnly = true;

            btnThemMatHang.Enabled = false;
            btnXoaDong.Enabled = false;
            btnLuuPhieu.Enabled = false;

            cboLoaiMatHang.Enabled = false;
            cboMatHang.Enabled = false;
            nudSoLuongXuat.Enabled = false;
        }
    }
}
