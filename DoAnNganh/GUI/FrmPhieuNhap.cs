using Đồ_án_ngành.BUS;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Đồ_án_ngành.GUI
{
    public partial class FrmPhieuNhap : Form
    {
        private readonly NhaCungCapBUS _nhaCungCapBUS = new NhaCungCapBUS();
        private readonly NguyenVatLieuBUS _nguyenVatLieuBUS = new NguyenVatLieuBUS();
        private readonly PhieuNhapBUS _phieuNhapBUS = new PhieuNhapBUS();
        private readonly ToppingBUS _toppingBUS = new ToppingBUS();
        private decimal _soLuongNhapCu;
        private bool _dangXemLichSu = false;
        private bool _dangXemChiTietLichSu = false;
        private readonly NhanVien _nhanVienDangNhap;

        public FrmPhieuNhap(NhanVien nhanVienDangNhap)
        {
            InitializeComponent();

            _nhanVienDangNhap = nhanVienDangNhap;
        }

        private void FrmPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadNhaCungCap();
            LoadNguyenVatLieu();

            dtpNgayNhap.Value = DateTime.Now;
            txtDonViTinh.Clear();

            dgvChiTietPhieuNhap.Columns["colDonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTietPhieuNhap.Columns["colThanhTien"].DefaultCellStyle.Format = "N0";

            cboLoaiMatHang.Items.Clear();
            cboLoaiMatHang.Items.Add("Nguyên vật liệu");
            cboLoaiMatHang.Items.Add("Topping");
            cboLoaiMatHang.SelectedIndex = 0;

            PhanQuyenDonGiaNhap();
        }

        private void LoadNhaCungCap()
        {
            var danhSach = _nhaCungCapBUS.GetAll();

            cboNhaCungCap.DataSource = danhSach;
            cboNhaCungCap.DisplayMember = "TenNCC";
            cboNhaCungCap.ValueMember = "MaNCC";
            cboNhaCungCap.SelectedIndex = -1;
        }

        private void LoadNguyenVatLieu()
        {
            var danhSach = _nguyenVatLieuBUS.GetAll();

            cboNguyenVatLieu.DataSource = null;
            cboNguyenVatLieu.DataSource = danhSach;
            cboNguyenVatLieu.DisplayMember = "TenNVL";
            cboNguyenVatLieu.ValueMember = "MaNVL";
            cboNguyenVatLieu.SelectedIndex = -1;
        }

        private void cboNguyenVatLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            NguyenVatLieu nvl = cboNguyenVatLieu.SelectedItem as NguyenVatLieu;

            if (nvl != null)
            {
                txtDonViTinh.Text = nvl.DonViTinh;
                nudSoLuongNhap.DecimalPlaces = 2;

                decimal? donGiaGanNhat =
                    _phieuNhapBUS.LayDonGiaNhapGanNhat(
                        nvl.MaNVL,
                        null
                    );

                nudDonGiaNhap.Value =
                    donGiaGanNhat ?? 0;

                return;
            }

            Topping topping =
                cboNguyenVatLieu.SelectedItem as Topping;

            if (topping != null)
            {
                txtDonViTinh.Text = topping.DonViTinh;

                // Topping nhập theo đơn vị gốc
                nudSoLuongNhap.DecimalPlaces = 0;

                decimal? donGiaGanNhat =
                    _phieuNhapBUS.LayDonGiaNhapGanNhat(
                        null,
                        topping.MaTopping
                    );

                nudDonGiaNhap.Value =
                    donGiaGanNhat ?? 0;

                return;
            }

            txtDonViTinh.Clear();
            nudDonGiaNhap.Value = 0;
        }

        private void btnThemNguyenVatLieu_Click(object sender, EventArgs e)
        {
            if (cboNguyenVatLieu.SelectedItem == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn mặt hàng.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            decimal soLuong = nudSoLuongNhap.Value;
            decimal donGia = nudDonGiaNhap.Value;

            bool laManager = _nhanVienDangNhap != null && _nhanVienDangNhap.ChucVu == "Manager";

            if (!laManager && donGia <= 0)
            {
                MessageBox.Show(
                    "Mặt hàng này chưa có đơn giá nhập trước đó.\nVui lòng liên hệ Manager để thiết lập đơn giá.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (soLuong <= 0)
            {
                MessageBox.Show(
                    "Số lượng nhập phải lớn hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (donGia <= 0)
            {
                MessageBox.Show(
                    "Đơn giá nhập phải lớn hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string loaiMatHang;
            string maMatHang;
            string tenMatHang;
            string donViTinh;

            NguyenVatLieu nvl =
                cboNguyenVatLieu.SelectedItem as NguyenVatLieu;

            Topping topping =
                cboNguyenVatLieu.SelectedItem as Topping;

            if (nvl != null)
            {
                loaiMatHang = "Nguyên vật liệu";
                maMatHang = nvl.MaNVL;
                tenMatHang = nvl.TenNVL;
                donViTinh = nvl.DonViTinh;
            }
            else if (topping != null)
            {
                loaiMatHang = "Topping";
                maMatHang = topping.MaTopping;
                tenMatHang = topping.TenTopping;
                donViTinh = topping.DonViTinh;
            }
            else
            {
                MessageBox.Show(
                    "Mặt hàng không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
            {
                string loaiTrongBang =
                    row.Cells["colLoaiMatHang"].Value?.ToString();

                string maTrongBang =
                    row.Cells["colMaNVL"].Value?.ToString();

                if (loaiTrongBang == loaiMatHang &&
                    maTrongBang == maMatHang)
                {
                    MessageBox.Show(
                        "Mặt hàng này đã có trong phiếu nhập.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }
            }

            decimal thanhTien =
                soLuong * donGia;

            int index = dgvChiTietPhieuNhap.Rows.Add(
                maMatHang,
                tenMatHang,
                donViTinh,
                soLuong,
                donGia,
                thanhTien
            );

            dgvChiTietPhieuNhap
                .Rows[index]
                .Cells["colLoaiMatHang"]
                .Value = loaiMatHang;

            TinhTongTien();

            nudSoLuongNhap.Value =
                nudSoLuongNhap.Minimum;

            nudDonGiaNhap.Value = 0;
        }

        private void TinhTongTien()
        {
            decimal tongTien = 0;

            foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
            {
                if (row.Cells["colThanhTien"].Value != null)
                {
                    tongTien += Convert.ToDecimal(
                        row.Cells["colThanhTien"].Value
                    );
                }
            }

            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvChiTietPhieuNhap.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn nguyên vật liệu cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc muốn xóa nguyên vật liệu này khỏi phiếu nhập?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (ketQua == DialogResult.Yes)
            {
                dgvChiTietPhieuNhap.Rows.Remove(
                    dgvChiTietPhieuNhap.CurrentRow
                );

                TinhTongTien();
            }
        }

        private string TaoMaPhieuNhap()
        {
            var danhSach = _phieuNhapBUS.GetAll();

            if (danhSach == null || danhSach.Count == 0)
                return "PN001";

            int soLonNhat = 0;

            foreach (var phieu in danhSach)
            {
                if (string.IsNullOrWhiteSpace(phieu.MaPhieuNhap))
                    continue;

                string phanSo = phieu.MaPhieuNhap.Replace("PN", "");

                if (int.TryParse(phanSo, out int so))
                {
                    if (so > soLonNhat)
                        soLonNhat = so;
                }
            }

            return $"PN{soLonNhat + 1:D3}";
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (cboNhaCungCap.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn nhà cung cấp.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (dgvChiTietPhieuNhap.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Phiếu nhập phải có ít nhất một mặt hàng.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaPhieuNhap.Text))
            {
                txtMaPhieuNhap.Text = TaoMaPhieuNhap();
            }

            PhieuNhap phieuNhap = new PhieuNhap
            {
                MaPhieuNhap = txtMaPhieuNhap.Text.Trim(),
                NgayNhap = dtpNgayNhap.Value,
                MaNCC = cboNhaCungCap.SelectedValue.ToString(),
                GhiChu = txtGhiChu.Text.Trim()
            };

            List<ChiTietPhieuNhap> danhSachChiTiet =
                new List<ChiTietPhieuNhap>();

            int stt = 1;

            foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
            {
                string loaiMatHang =
                    row.Cells["colLoaiMatHang"].Value.ToString();

                string maMatHang =
                    row.Cells["colMaNVL"].Value.ToString();

                ChiTietPhieuNhap chiTiet = new ChiTietPhieuNhap
                {
                    MaChiTietPN =
                        phieuNhap.MaPhieuNhap + "-" + stt,

                    MaPhieuNhap =
                        phieuNhap.MaPhieuNhap,

                    SoLuong =
                        Convert.ToDecimal(
                            row.Cells["colSoLuong"].Value
                        ),

                    DonGia =
                        Convert.ToDecimal(
                            row.Cells["colDonGia"].Value
                        )
                };

                // Xác định loại mặt hàng
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

            string ketQua = _phieuNhapBUS.Add(
                phieuNhap,
                danhSachChiTiet
            );

            MessageBox.Show(
                ketQua,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua == "Nhập hàng thành công."
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua == "Nhập hàng thành công.")
            {
                LamMoiPhieuNhap();
            }
        }

        private void LamMoiPhieuNhap()
        {
            _dangXemLichSu = false;
            _dangXemChiTietLichSu = false;

            // Mở lại các chức năng lập phiếu
            dgvChiTietPhieuNhap.ReadOnly = false;

            btnThemNguyenVatLieu.Enabled = true;
            btnXoaDong.Enabled = true;
            btnLuuPhieu.Enabled = true;

            // Trả tiêu đề DataGridView về chế độ lập phiếu
            dgvChiTietPhieuNhap.Columns["colMaNVL"].HeaderText =
                "Mã mặt hàng";

            dgvChiTietPhieuNhap.Columns["colTenNVL"].HeaderText =
                "Tên mặt hàng";

            dgvChiTietPhieuNhap.Columns["colDonViTinh"].HeaderText =
                "Đơn vị tính";

            dgvChiTietPhieuNhap.Columns["colSoLuong"].HeaderText =
                "Số lượng";

            dgvChiTietPhieuNhap.Columns["colDonGia"].HeaderText =
                "Đơn giá";

            dgvChiTietPhieuNhap.Columns["colThanhTien"].HeaderText =
                "Thành tiền";

            // Xóa thông tin phiếu
            txtMaPhieuNhap.Clear();
            cboNhaCungCap.SelectedIndex = -1;
            dtpNgayNhap.Value = DateTime.Now;
            txtGhiChu.Clear();

            // Xóa thông tin nguyên vật liệu
            cboNguyenVatLieu.SelectedIndex = -1;
            txtDonViTinh.Clear();
            nudSoLuongNhap.Value = nudSoLuongNhap.Minimum;
            nudDonGiaNhap.Value = 0;

            // Xóa chi tiết phiếu
            dgvChiTietPhieuNhap.Rows.Clear();

            // Đặt lại tổng tiền
            lblTongTien.Text = "0 VNĐ";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if (CoDuLieuChuaLuu())
            {
                DialogResult ketQua = MessageBox.Show(
                    "Phiếu nhập hiện tại chưa được lưu.\nBạn có chắc muốn làm mới?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (ketQua == DialogResult.No)
                    return;
            }

            LamMoiPhieuNhap();
        }

        private void cboLoaiMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiMatHang.SelectedItem == null)
                return;

            string loaiMatHang = cboLoaiMatHang.SelectedItem.ToString();

            if (loaiMatHang == "Nguyên vật liệu")
            {
                LoadNguyenVatLieu();
            }
            else if (loaiMatHang == "Topping")
            {
                LoadTopping();
            }

            txtDonViTinh.Clear();
        }

        private void LoadTopping()
        {
            var danhSach = _toppingBUS.GetAll();

            cboNguyenVatLieu.DataSource = null;
            cboNguyenVatLieu.DataSource = danhSach;
            cboNguyenVatLieu.DisplayMember = "TenTopping";
            cboNguyenVatLieu.ValueMember = "MaTopping";
            cboNguyenVatLieu.SelectedIndex = -1;
        }

        private bool CoDuLieuChuaLuu()
        {
            if (_dangXemLichSu || _dangXemChiTietLichSu)
                return false;

            return dgvChiTietPhieuNhap.Rows.Count > 0;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (CoDuLieuChuaLuu())
            {
                DialogResult ketQua = MessageBox.Show(
                    "Phiếu nhập hiện tại chưa được lưu.\nBạn có chắc muốn đóng?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (ketQua == DialogResult.No)
                    return;
            }

            this.Close();
        }

        private void dgvChiTietPhieuNhap_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvChiTietPhieuNhap.Columns[e.ColumnIndex].Name != "colSoLuong")
                return;

            DataGridViewRow row = dgvChiTietPhieuNhap.Rows[e.RowIndex];

            if (!decimal.TryParse(
                row.Cells["colSoLuong"].Value?.ToString(),
                out decimal soLuong) || soLuong <= 0)
            {
                MessageBox.Show(
                    "Số lượng nhập không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                row.Cells["colSoLuong"].Value = _soLuongNhapCu;
                return;
            }

            decimal donGia = Convert.ToDecimal(
                row.Cells["colDonGia"].Value
            );

            row.Cells["colThanhTien"].Value =
                soLuong * donGia;

            TinhTongTien();
        }

        private void dgvChiTietPhieuNhap_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvChiTietPhieuNhap.Columns[e.ColumnIndex].Name != "colSoLuong")
                return;

            decimal.TryParse(
                dgvChiTietPhieuNhap.Rows[e.RowIndex]
                    .Cells["colSoLuong"]
                    .Value?.ToString(),
                out _soLuongNhapCu
            );
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            // Không cho bỏ phiếu đang lập dở
            if (CoDuLieuChuaLuu() && !_dangXemLichSu)
            {
                DialogResult ketQua = MessageBox.Show(
                    "Phiếu nhập hiện tại chưa được lưu.\nBạn có chắc muốn xem lịch sử?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (ketQua == DialogResult.No)
                    return;
            }

            var danhSach = _phieuNhapBUS.GetAll();

            dgvChiTietPhieuNhap.Rows.Clear();

            _dangXemLichSu = true;
            _dangXemChiTietLichSu = false;

            // Đổi tiêu đề cột sang chế độ lịch sử
            dgvChiTietPhieuNhap.Columns["colMaNVL"].HeaderText =
                "Mã phiếu";

            dgvChiTietPhieuNhap.Columns["colTenNVL"].HeaderText =
                "Nhà cung cấp";

            dgvChiTietPhieuNhap.Columns["colDonViTinh"].HeaderText =
                "Ngày nhập";

            dgvChiTietPhieuNhap.Columns["colSoLuong"].HeaderText =
                "Số mặt hàng";

            dgvChiTietPhieuNhap.Columns["colDonGia"].HeaderText =
                "Tổng tiền";

            dgvChiTietPhieuNhap.Columns["colThanhTien"].HeaderText =
                "Ghi chú";

            foreach (var phieu in danhSach)
            {
                int index = dgvChiTietPhieuNhap.Rows.Add(
                    phieu.MaPhieuNhap,
                    phieu.NhaCungCap?.TenNCC ?? "",
                    phieu.NgayNhap.ToString("dd/MM/yyyy HH:mm"),
                    phieu.ChiTietPhieuNhaps?.Count ?? 0,
                    phieu.TongTien,
                    phieu.GhiChu ?? ""
                );

                // Lưu mã phiếu vào Tag để lát nữa mở chi tiết
                dgvChiTietPhieuNhap.Rows[index].Tag =
                    phieu.MaPhieuNhap;
            }

            dgvChiTietPhieuNhap.Columns["colDonGia"]
                .DefaultCellStyle.Format = "N0";

            // Khóa chỉnh sửa khi xem lịch sử
            dgvChiTietPhieuNhap.ReadOnly = true;

            btnThemNguyenVatLieu.Enabled = false;
            btnXoaDong.Enabled = false;
            btnLuuPhieu.Enabled = false;

            lblTongTien.Text =
                $"Có {danhSach.Count} phiếu nhập";
        }

        private void dgvChiTietPhieuNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!_dangXemLichSu)
                return;

            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvChiTietPhieuNhap.Rows[e.RowIndex];

            string maPhieuNhap =
                row.Tag?.ToString();

            if (string.IsNullOrWhiteSpace(maPhieuNhap))
                return;

            HienThiChiTietPhieuNhapCu(maPhieuNhap);
        }

        private void HienThiChiTietPhieuNhapCu(string maPhieuNhap)
        {
            PhieuNhap phieu =
                _phieuNhapBUS.GetById(maPhieuNhap);

            if (phieu == null)
            {
                MessageBox.Show(
                    "Không tìm thấy phiếu nhập.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            _dangXemLichSu = true;
            _dangXemChiTietLichSu = true;

            txtMaPhieuNhap.Text =
                phieu.MaPhieuNhap;

            cboNhaCungCap.SelectedValue =
                phieu.MaNCC;

            dtpNgayNhap.Value =
                phieu.NgayNhap;

            txtGhiChu.Text =
                phieu.GhiChu ?? "";

            // Trả tiêu đề cột về chế độ chi tiết
            dgvChiTietPhieuNhap.Columns["colMaNVL"].HeaderText =
                "Mã mặt hàng";

            dgvChiTietPhieuNhap.Columns["colTenNVL"].HeaderText =
                "Tên mặt hàng";

            dgvChiTietPhieuNhap.Columns["colDonViTinh"].HeaderText =
                "Đơn vị tính";

            dgvChiTietPhieuNhap.Columns["colSoLuong"].HeaderText =
                "Số lượng";

            dgvChiTietPhieuNhap.Columns["colDonGia"].HeaderText =
                "Đơn giá";

            dgvChiTietPhieuNhap.Columns["colThanhTien"].HeaderText =
                "Thành tiền";

            dgvChiTietPhieuNhap.Rows.Clear();

            foreach (ChiTietPhieuNhap chiTiet
                     in phieu.ChiTietPhieuNhaps)
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

                int index =
                    dgvChiTietPhieuNhap.Rows.Add(
                        maMatHang,
                        tenMatHang,
                        donViTinh,
                        chiTiet.SoLuong,
                        chiTiet.DonGia,
                        chiTiet.ThanhTien
                    );

                dgvChiTietPhieuNhap
                    .Rows[index]
                    .Cells["colLoaiMatHang"]
                    .Value = loaiMatHang;
            }

            lblTongTien.Text =
                phieu.TongTien.ToString("N0") +
                " VNĐ";

            dgvChiTietPhieuNhap.ReadOnly = true;

            btnThemNguyenVatLieu.Enabled = false;
            btnXoaDong.Enabled = false;
            btnLuuPhieu.Enabled = false;
        }

        private void PhanQuyenDonGiaNhap()
        {
            bool laManager =
                _nhanVienDangNhap != null &&
                _nhanVienDangNhap.ChucVu == "Manager";

            nudDonGiaNhap.ReadOnly = !laManager;
        }
    }
}
