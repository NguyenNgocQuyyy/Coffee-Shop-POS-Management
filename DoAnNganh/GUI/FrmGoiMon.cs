using Đồ_án_ngành.BUS;
using Đồ_án_ngành.GUI;
using MODEL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Đồ_án_ngành
{
    public partial class FrmGoiMon : Form
    {
        private Ban _banDangChon;
        private readonly BanBUS _banBUS = new BanBUS();
        private readonly DanhMucBUS _danhMucBUS = new DanhMucBUS();
        private readonly MonBUS _monBUS = new MonBUS();
        private readonly ToppingBUS _toppingBUS = new ToppingBUS();
        private KhachHang _khachHangDangChon;
        private bool _laMangVe = false;
        private string _phuongThucThanhToan = "Tiền mặt";
        private readonly KhuyenMaiBUS _khuyenMaiBUS = new KhuyenMaiBUS();
        private KhuyenMai _khuyenMaiDangApDung;
        private readonly HoaDonBUS _hoaDonBUS = new HoaDonBUS();
        private HoaDon _hoaDonDangMo;
        private readonly NhanVien _nhanVienDangNhap;

        public FrmGoiMon(Ban ban, NhanVien nhanVien)
        {
            InitializeComponent();

            _banDangChon = ban;
            _nhanVienDangNhap = nhanVien;

            _hoaDonDangMo = _hoaDonBUS.GetHoaDonChuaThanhToanTheoBan(_banDangChon.MaBan);
            LoadHoaDonDangMo();

            lblBanHienTai.Text = "Bàn: " + _banDangChon.SoBan;

            LoadDanhMuc();

            ChonPhuongThucThanhToan("Tiền mặt");

            this.Shown += FrmGoiMon_Shown;
        }

        private void LoadDanhMuc()
        {
            var danhSachDanhMuc = _danhMucBUS.GetAll();

            flpDanhMuc.Controls.Clear();

            foreach (var danhMuc in danhSachDanhMuc)
            {
                Button btnDanhMuc = new Button();

                btnDanhMuc.Text = danhMuc.TenDanhMuc;
                btnDanhMuc.Tag = danhMuc.MaDanhMuc;
                btnDanhMuc.Width = 180;
                btnDanhMuc.Height = 55;
                btnDanhMuc.BackColor = Color.FromArgb(78, 47, 32);
                btnDanhMuc.ForeColor = Color.White;
                btnDanhMuc.FlatStyle = FlatStyle.Flat;
                btnDanhMuc.FlatAppearance.BorderSize = 0;
                btnDanhMuc.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btnDanhMuc.Cursor = Cursors.Hand;

                btnDanhMuc.Click += BtnDanhMuc_Click;
                flpDanhMuc.Controls.Add(btnDanhMuc);
            }

            // Tạo danh mục ảo Topping
            Button btnTopping = new Button();

            btnTopping.Text = "Topping";
            btnTopping.Tag = "TOPPING";
            btnTopping.Width = 180;
            btnTopping.Height = 55;
            btnTopping.BackColor = Color.FromArgb(78, 47, 32);
            btnTopping.ForeColor = Color.White;
            btnTopping.FlatStyle = FlatStyle.Flat;
            btnTopping.FlatAppearance.BorderSize = 0;
            btnTopping.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnTopping.Cursor = Cursors.Hand;

            btnTopping.Click += BtnDanhMuc_Click;

            flpDanhMuc.Controls.Add(btnTopping);
        }

        private void BtnDanhMuc_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null)
                return;

            string maDanhMuc = btn.Tag.ToString();

            if (maDanhMuc == "TOPPING")
            {
                LoadTopping();
                return;
            }

            LoadMonTheoDanhMuc(maDanhMuc);
        }

        private void LoadMonTheoDanhMuc(string maDanhMuc)
        {
            var danhSachMon = _monBUS.GetByDanhMuc(maDanhMuc);

            flpMon.Controls.Clear();

            foreach (var mon in danhSachMon)
            {
                Button btnMon = new Button();

                btnMon.Text = mon.TenMon + "\n" + mon.GiaBan.ToString("N0") + " đ";
                btnMon.Tag = mon.MaMon;
                btnMon.Width = 150;
                btnMon.Height = 80;
                btnMon.BackColor = Color.FromArgb(250, 247, 242);
                btnMon.ForeColor = Color.FromArgb(78, 47, 32);
                btnMon.FlatStyle = FlatStyle.Flat;
                btnMon.FlatAppearance.BorderSize = 1;
                btnMon.FlatAppearance.BorderColor = Color.FromArgb(230, 205, 175);
                btnMon.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btnMon.Cursor = Cursors.Hand;

                btnMon.Click += BtnMon_Click;
                flpMon.Controls.Add(btnMon);
            }
        }

        private void BtnMon_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null)
                return;

            string maMon = btn.Tag.ToString();

            var mon = _monBUS.GetById(maMon);

            if (mon == null)
                return;

            dgvHoaDon.Rows.Add(
                mon.MaMon,
                mon.TenMon,
                1,
                mon.GiaBan,
                mon.GiaBan,
                "");

            CapNhatTongTien();

            dgvHoaDon.ClearSelection();
            dgvHoaDon.CurrentCell = null;
        }

        private void dgvHoaDon_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvHoaDon.Columns[e.ColumnIndex].Name
                != "colSoLuong")
            {
                return;
            }

            DataGridViewRow row =
                dgvHoaDon.Rows[e.RowIndex];

            int soLuong;

            if (!int.TryParse(
                row.Cells["colSoLuong"].Value?.ToString(),
                out soLuong))
            {
                MessageBox.Show(
                    "Số lượng không hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                row.Cells["colSoLuong"].Value = 1;

                CapNhatThanhTienDong(row);
                CapNhatTongTien();

                return;
            }

            if (soLuong <= 0)
            {
                MessageBox.Show(
                    "Số lượng phải lớn hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                row.Cells["colSoLuong"].Value = 1;
            }

            Topping topping = row.Tag as Topping;

            if (topping != null)
            {
                if (topping.HeSoQuyDoi <= 0)
                {
                    MessageBox.Show(
                        $"Topping {topping.TenTopping} chưa có hệ số quy đổi hợp lệ.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    row.Cells["colSoLuong"].Value = 1;
                }
                else
                {
                    decimal soPhanCoTheBan =
                        topping.SoLuongTon * topping.HeSoQuyDoi;

                    if (soLuong > soPhanCoTheBan)
                    {
                        MessageBox.Show(
                            $"Topping {topping.TenTopping} chỉ còn tối đa {soPhanCoTheBan:0.##} {topping.DonViTinhQuyDoi}.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        row.Cells["colSoLuong"].Value =
                            (int)Math.Floor(soPhanCoTheBan);
                    }
                }
            }

            CapNhatThanhTienDong(row);
            CapNhatTongTien();
        }

        private void CapNhatTongTien()
        {
            decimal tongTien = 0;

            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.Cells["colThanhTien"].Value != null)
                {
                    tongTien += Convert.ToDecimal(
                        row.Cells["colThanhTien"].Value
                    );
                }
            }

            txtTienMat.Text = tongTien.ToString("N0");

            if (_khuyenMaiDangApDung != null)
            {
                decimal tienGiam = TinhTienGiam();

                if (tienGiam > 0)
                {
                    txtGiamGia.Text = tienGiam.ToString("N0");
                }
                else
                {
                    _khuyenMaiDangApDung = null;
                    txtKhuyenMai.Clear();
                    txtGiamGia.Text = "0";
                }
            }
            else
            {
                txtGiamGia.Text = "0";
            }

            CapNhatThanhTien();
        }

        private void btnBoMon_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
                return;

            dgvHoaDon.Rows.Remove(dgvHoaDon.CurrentRow);

            CapNhatTongTien();
        }

        private void btnHoiVien_Click(object sender, EventArgs e)
        {
            FrmHoiVien frm = new FrmHoiVien();

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                _khachHangDangChon = frm.KhachHangDuocChon;
                btnKhachHang.Text = _khachHangDangChon.HoTen;
            }
        }

        private void btnHinhThucPhucVu_Click(object sender, EventArgs e)
        {
            _laMangVe = !_laMangVe;

            btnHinhThucPhucVu.Text = _laMangVe
                ? "Mang về"
                : "Tại chỗ";
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            if (_banDangChon == null)
                return;

            FrmChuyenBan frm = new FrmChuyenBan(_banDangChon);

            if (frm.ShowDialog(this) != DialogResult.OK)
                return;

            Ban banMoi = frm.BanDuocChon;

            if (banMoi == null)
                return;

            // Nếu order đã lưu thì cập nhật MaBan của hóa đơn trước
            if (_hoaDonDangMo != null)
            {
                string ketQua = _hoaDonBUS.ChuyenBanHoaDon(
                    _hoaDonDangMo.MaHoaDon,
                    banMoi.MaBan
                );

                if (ketQua != "Chuyển bàn hóa đơn thành công.")
                {
                    MessageBox.Show(
                        ketQua,
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }
            }

            // Trả bàn cũ
            _banDangChon.TrangThai = "Trống";
            _banBUS.Update(_banDangChon);

            // Đánh dấu bàn mới đang sử dụng
            banMoi.TrangThai = "Đang sử dụng";
            _banBUS.Update(banMoi);

            _banDangChon = banMoi;

            // Đồng bộ object hóa đơn đang giữ trên Form
            if (_hoaDonDangMo != null)
                _hoaDonDangMo.MaBan = banMoi.MaBan;

            lblBanHienTai.Text =
                "Bàn: " + _banDangChon.SoBan;

            MessageBox.Show(
                "Chuyển bàn thành công.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void CapNhatThanhTien()
        {
            decimal tienMat = 0;
            decimal giamGia = 0;

            decimal.TryParse(
                txtTienMat.Text.Replace(",", "").Replace(".", ""),
                out tienMat
            );

            decimal.TryParse(
                txtGiamGia.Text.Replace(",", "").Replace(".", ""),
                out giamGia
            );

            decimal thanhTien = tienMat - giamGia;

            if (thanhTien < 0)
                thanhTien = 0;

            txtThanhTien.Text = thanhTien.ToString("N0");
            txtTongTien.Text = thanhTien.ToString("N0");
        }

        private void txtKhachDua_TextChanged(object sender, EventArgs e)
        {
            string text = txtKhachDua.Text
                .Replace(".", "")
                .Replace(",", "");

            if (!decimal.TryParse(text, out decimal khachDua))
            {
                txtTienThoi.Text = "0";
                return;
            }

            // Định dạng tiền khách đưa
            txtKhachDua.TextChanged -= txtKhachDua_TextChanged;

            txtKhachDua.Text = khachDua.ToString("N0");
            txtKhachDua.SelectionStart = txtKhachDua.Text.Length;

            txtKhachDua.TextChanged += txtKhachDua_TextChanged;

            // Tính tiền thối
            decimal thanhTien = 0;

            decimal.TryParse(
                txtThanhTien.Text.Replace(",", "").Replace(".", ""),
                out thanhTien
            );

            decimal tienThoi = khachDua - thanhTien;

            if (tienThoi < 0)
                tienThoi = 0;

            txtTienThoi.Text = tienThoi.ToString("N0");
        }

        private void ChonPhuongThucThanhToan(string phuongThuc)
        {
            _phuongThucThanhToan = phuongThuc;

            // Đưa cả 3 nút về màu mặc định
            btnTienMat.BackColor = Color.FromArgb(230, 205, 175);
            btnTienMat.ForeColor = Color.FromArgb(78, 47, 32);

            btnChuyenKhoan.BackColor = Color.FromArgb(230, 205, 175);
            btnChuyenKhoan.ForeColor = Color.FromArgb(78, 47, 32);

            btnThe.BackColor = Color.FromArgb(230, 205, 175);
            btnThe.ForeColor = Color.FromArgb(78, 47, 32);

            // Xác định nút đang được chọn
            Button btnDuocChon = null;

            if (phuongThuc == "Tiền mặt")
                btnDuocChon = btnTienMat;
            else if (phuongThuc == "Chuyển khoản")
                btnDuocChon = btnChuyenKhoan;
            else if (phuongThuc == "Thẻ")
                btnDuocChon = btnThe;

            // Làm nổi bật nút đang chọn
            if (btnDuocChon != null)
            {
                btnDuocChon.BackColor = Color.FromArgb(198, 120, 90);
                btnDuocChon.ForeColor = Color.White;
            }

            // Xử lý khách đưa theo phương thức thanh toán
            if (phuongThuc == "Tiền mặt")
            {
                txtKhachDua.ReadOnly = false;
                txtKhachDua.Text = "0";
                txtTienThoi.Text = "0";
            }
            else
            {
                txtKhachDua.ReadOnly = true;
                txtKhachDua.Text = "0";
                txtTienThoi.Text = "0";
            }
        }

        private void btnTienMat_Click(object sender, EventArgs e)
        {
            ChonPhuongThucThanhToan("Tiền mặt");
        }

        private void btnChuyenKhoan_Click(object sender, EventArgs e)
        {
            ChonPhuongThucThanhToan("Chuyển khoản");
        }

        private void btnThe_Click(object sender, EventArgs e)
        {
            ChonPhuongThucThanhToan("Thẻ");
        }

        private void txtKhuyenMai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;

            string maKhuyenMai = txtKhuyenMai.Text.Trim();

            if (string.IsNullOrWhiteSpace(maKhuyenMai))
                return;

            _khuyenMaiDangApDung =
                _khuyenMaiBUS.GetById(maKhuyenMai);

            if (_khuyenMaiDangApDung == null)
            {
                MessageBox.Show(
                    "Mã khuyến mãi không tồn tại.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (_khuyenMaiDangApDung.TrangThai != "Đang áp dụng")
            {
                MessageBox.Show(
                    "Khuyến mãi hiện không áp dụng.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                _khuyenMaiDangApDung = null;
                return;
            }

            decimal tienGiam = TinhTienGiam();

            if (tienGiam <= 0)
            {
                MessageBox.Show(
                    "Hóa đơn không có món áp dụng khuyến mãi này.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                _khuyenMaiDangApDung = null;
                txtGiamGia.Text = "0";
                CapNhatThanhTien();

                return;
            }

            txtGiamGia.Text = tienGiam.ToString("N0");

            CapNhatThanhTien();

            MessageBox.Show(
                "Áp dụng khuyến mãi thành công.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private decimal TinhTienGiam()
        {
            if (_khuyenMaiDangApDung == null)
                return 0;

            decimal tongTienDuocKhuyenMai = 0;
            int tongSoLuongDuocKhuyenMai = 0;

            bool apDungToanHoaDon =
                _khuyenMaiDangApDung.ChiTietKhuyenMais == null ||
                _khuyenMaiDangApDung.ChiTietKhuyenMais.Count == 0;

            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.IsNewRow)
                    continue;

                decimal thanhTien = Convert.ToDecimal(
                    row.Cells["colThanhTien"].Value);

                int soLuong = Convert.ToInt32(
                    row.Cells["colSoLuong"].Value);

                // 1. KHUYẾN MÃI TOÀN HÓA ĐƠN
                if (apDungToanHoaDon)
                {
                    tongTienDuocKhuyenMai += thanhTien;
                    continue;
                }

                // 2. KHUYẾN MÃI THEO MÓN
                if (row.Tag is Topping)
                    continue;

                string maMon =
                    row.Cells["colMaMon"].Value?.ToString();

                bool duocApDung =
                    _khuyenMaiDangApDung.ChiTietKhuyenMais
                        .Any(x => x.MaMon == maMon);

                if (!duocApDung)
                    continue;

                tongTienDuocKhuyenMai += thanhTien;
                tongSoLuongDuocKhuyenMai += soLuong;
            }

            // 3. GIẢM THEO PHẦN TRĂM
            if (_khuyenMaiDangApDung.LoaiKhuyenMai == "Phần trăm")
            {
                return tongTienDuocKhuyenMai
                    * _khuyenMaiDangApDung.GiaTriKhuyenMai / 100;
            }

            // 4. GIẢM TIỀN CỐ ĐỊNH
            if (_khuyenMaiDangApDung.LoaiKhuyenMai == "Tiền cố định")
            {
                decimal tienGiam;

                if (apDungToanHoaDon)
                {
                    tienGiam =
                        _khuyenMaiDangApDung.GiaTriKhuyenMai;
                }
                else
                {
                    tienGiam =
                        _khuyenMaiDangApDung.GiaTriKhuyenMai
                        * tongSoLuongDuocKhuyenMai;
                }

                return Math.Min(
                    tienGiam,
                    tongTienDuocKhuyenMai);
            }

            return 0;
        }

        private void LoadTopping()
        {
            var danhSachTopping = _toppingBUS.GetAll()
                .Where(x => x.TrangThai == "Đang bán")
                .ToList();

            flpMon.Controls.Clear();

            foreach (var topping in danhSachTopping)
            {
                Button btnTopping = new Button();

                btnTopping.Text =
                    topping.TenTopping + "\n" +
                    topping.GiaBan.ToString("N0") + " đ";

                btnTopping.Tag = topping;

                btnTopping.Width = 150;
                btnTopping.Height = 80;

                btnTopping.BackColor = Color.FromArgb(250, 247, 242);
                btnTopping.ForeColor = Color.FromArgb(78, 47, 32);

                btnTopping.FlatStyle = FlatStyle.Flat;
                btnTopping.FlatAppearance.BorderSize = 1;
                btnTopping.FlatAppearance.BorderColor =
                    Color.FromArgb(230, 205, 175);

                btnTopping.Font =
                    new Font("Segoe UI", 10, FontStyle.Bold);

                btnTopping.Cursor = Cursors.Hand;

                btnTopping.Click += BtnTopping_Click;
                flpMon.Controls.Add(btnTopping);
            }
        }

        private void BtnTopping_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null)
                return;

            Topping topping = btn.Tag as Topping;

            if (topping == null)
                return;

            if (topping.SoLuongTon <= 0)
            {
                MessageBox.Show(
                    $"Topping {topping.TenTopping} đã hết hàng.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow dongDangChon = dgvHoaDon.CurrentRow;

            // 1. Bill trống hoặc không chọn dòng nào -> thêm topping bán lẻ ở cuối
            if (dongDangChon == null || dongDangChon.IsNewRow)
            {
                ThemToppingCuoiBill(topping);
                return;
            }

            // 2. Nếu đang chọn một dòng topping -> vẫn xem là bán lẻ
            Topping toppingDangChon = dongDangChon.Tag as Topping;

            if (toppingDangChon != null)
            {
                ThemToppingCuoiBill(topping);
                return;
            }

            // 3. Đang chọn món -> chèn topping ngay dưới món đó
            int viTriMon = dongDangChon.Index;
            int viTriChen = viTriMon + 1;

            while (viTriChen < dgvHoaDon.Rows.Count)
            {
                DataGridViewRow row = dgvHoaDon.Rows[viTriChen];

                if (row.IsNewRow)
                    break;

                Topping toppingTrongDong = row.Tag as Topping;

                // Gặp món tiếp theo thì dừng
                if (toppingTrongDong == null)
                    break;

                // Topping đã tồn tại ngay dưới món này -> tăng số lượng
                if (toppingTrongDong.MaTopping == topping.MaTopping)
                {
                    int soLuong =
                        Convert.ToInt32(row.Cells["colSoLuong"].Value);

                    decimal soPhanCoTheBan = topping.SoLuongTon * topping.HeSoQuyDoi;

                    if (soLuong >= soPhanCoTheBan)
                    {
                        MessageBox.Show(
                            $"Topping {topping.TenTopping} chỉ còn tối đa {soPhanCoTheBan:0.##} {topping.DonViTinhQuyDoi}.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    row.Cells["colSoLuong"].Value = soLuong + 1;

                    CapNhatThanhTienDong(row);
                    CapNhatTongTien();

                    return;
                }

                viTriChen++;
            }

            dgvHoaDon.Rows.Insert(
                viTriChen,
                null,
                topping.TenTopping,
                1,
                topping.GiaBan,
                topping.GiaBan,
                "");

            dgvHoaDon.Rows[viTriChen].Tag = topping;

            CapNhatTongTien();

            dgvHoaDon.ClearSelection();
            dgvHoaDon.CurrentCell = null;
        }

        private void ThemToppingCuoiBill(Topping topping)
        {
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                if (row.IsNewRow)
                    continue;

                Topping toppingTrongDong = row.Tag as Topping;

                if (toppingTrongDong == null)
                    continue;

                if (toppingTrongDong.MaTopping == topping.MaTopping)
                {
                    int soLuong =
                        Convert.ToInt32(row.Cells["colSoLuong"].Value);

                    decimal soPhanCoTheBan = topping.SoLuongTon * topping.HeSoQuyDoi;

                    if (soLuong >= soPhanCoTheBan)
                    {
                        MessageBox.Show(
                            $"Topping {topping.TenTopping} chỉ còn tối đa {soPhanCoTheBan:0.##} {topping.DonViTinhQuyDoi}.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    row.Cells["colSoLuong"].Value = soLuong + 1;

                    CapNhatThanhTienDong(row);
                    CapNhatTongTien();

                    return;
                }
            }

            int rowIndex = dgvHoaDon.Rows.Add(
                null,
                topping.TenTopping,
                1,
                topping.GiaBan,
                topping.GiaBan,
                "");

            dgvHoaDon.Rows[rowIndex].Tag = topping;

            CapNhatTongTien();

            dgvHoaDon.ClearSelection();
            dgvHoaDon.CurrentCell = null;
        }

        private void CapNhatThanhTienDong(DataGridViewRow row)
        {
            if (row == null)
                return;

            int soLuong;

            if (!int.TryParse(
                row.Cells["colSoLuong"].Value?.ToString(),
                out soLuong))
            {
                return;
            }

            if (soLuong <= 0)
                return;

            decimal giaBan;

            if (!decimal.TryParse(
                row.Cells["colGiaBan"].Value?.ToString(),
                out giaBan))
            {
                return;
            }

            row.Cells["colThanhTien"].Value =
                giaBan * soLuong;
        }

        private List<ChiTietHoaDon> TaoDanhSachChiTietHoaDon(string maHoaDon)
        {
            List<ChiTietHoaDon> danhSach =
                new List<ChiTietHoaDon>();

            int stt = 1;

            foreach (DataGridViewRow row
                     in dgvHoaDon.Rows)
            {
                if (row.IsNewRow)
                    continue;

                int soLuong =
                    Convert.ToInt32(
                        row.Cells["colSoLuong"].Value);

                decimal giaBan =
                    Convert.ToDecimal(
                        row.Cells["colGiaBan"].Value);

                decimal thanhTien =
                    Convert.ToDecimal(
                        row.Cells["colThanhTien"].Value);

                string ghiChu =
                    row.Cells["colGhiChu"]
                        .Value?.ToString();

                ChiTietHoaDon chiTiet =
                    new ChiTietHoaDon
                    {
                        MaChiTietHoaDon =
                            maHoaDon + "-CT" + stt,

                        MaHoaDon = maHoaDon,
                        SoLuong = soLuong,
                        GiaBan = giaBan,
                        ThanhTien = thanhTien,
                        GhiChu = ghiChu
                    };

                // TOPPING
                Topping topping =
                    row.Tag as Topping;

                if (topping != null)
                {
                    chiTiet.MaMon = null;
                    chiTiet.MaTopping =
                        topping.MaTopping;
                }
                // MÓN
                else
                {
                    string maMon =
                        row.Cells["colMaMon"]
                            .Value?.ToString();

                    if (string.IsNullOrWhiteSpace(
                            maMon))
                    {
                        continue;
                    }

                    chiTiet.MaMon = maMon;
                    chiTiet.MaTopping = null;
                }

                danhSach.Add(chiTiet);

                stt++;
            }

            return danhSach;
        }

        private string TaoMaHoaDon()
        {
            return _hoaDonBUS.TaoMaHoaDonMoi();
        }

        private HoaDon TaoHoaDon(string maHoaDon)
        {
            HoaDon hoaDon = new HoaDon
            {
                MaHoaDon = maHoaDon,
                NgayLap = DateTime.Now,
                MaNV = _nhanVienDangNhap.MaNV,
                MaBan = _banDangChon?.MaBan,
                GhiChu = _laMangVe
                    ? "Mang về"
                    : "Tại chỗ"
            };

            return hoaDon;
        }

        private void FrmGoiMon_Shown(object sender, EventArgs e)
        {
            dgvHoaDon.ClearSelection();
            dgvHoaDon.CurrentCell = null;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Hóa đơn chưa có món.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (_phuongThucThanhToan == "Tiền mặt")
            {
                string textKhachDua = txtKhachDua.Text
                    .Replace(".", "")
                    .Replace(",", "");

                string textThanhTien = txtThanhTien.Text
                    .Replace(".", "")
                    .Replace(",", "");

                if (!decimal.TryParse(
                    textKhachDua,
                    out decimal khachDua))
                {
                    MessageBox.Show(
                        "Tiền khách đưa không hợp lệ.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtKhachDua.Focus();
                    return;
                }

                decimal.TryParse(
                    textThanhTien,
                    out decimal thanhTien);

                if (khachDua < thanhTien)
                {
                    MessageBox.Show(
                        "Tiền khách đưa không đủ.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtKhachDua.Focus();
                    return;
                }
            }

            string maPhuongThuc = LayMaPhuongThucThanhToan();

            if (string.IsNullOrWhiteSpace(maPhuongThuc))
            {
                MessageBox.Show(
                    "Vui lòng chọn phương thức thanh toán.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!string.IsNullOrWhiteSpace(txtKhuyenMai.Text) && _khuyenMaiDangApDung == null)
            {
                MessageBox.Show(
                    "Mã khuyến mãi chưa được áp dụng hợp lệ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtKhuyenMai.Focus();
                return;
            }

            string maHoaDon;

            if (_hoaDonDangMo == null)
            {
                maHoaDon = TaoMaHoaDon();

                HoaDon hoaDon = TaoHoaDon(maHoaDon);

                if (_khachHangDangChon != null)
                    hoaDon.MaKH = _khachHangDangChon.MaKH;

                List<ChiTietHoaDon> chiTietHoaDons =
                    TaoDanhSachChiTietHoaDon(maHoaDon);

                string ketQuaTaoHoaDon =
                    _hoaDonBUS.TaoHoaDon(
                        hoaDon,
                        chiTietHoaDons
                    );

                if (ketQuaTaoHoaDon != "Tạo hóa đơn thành công.")
                {
                    MessageBox.Show(
                        ketQuaTaoHoaDon,
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                _hoaDonDangMo =
                    _hoaDonBUS.GetById(maHoaDon);
            }
            else
            {
                maHoaDon =
                    _hoaDonDangMo.MaHoaDon;

                HoaDon hoaDonCapNhat =
                    TaoHoaDon(maHoaDon);

                if (_khachHangDangChon != null)
                    hoaDonCapNhat.MaKH = _khachHangDangChon.MaKH;
                else
                    hoaDonCapNhat.MaKH = _hoaDonDangMo.MaKH;

                List<ChiTietHoaDon> chiTietCapNhat =
                    TaoDanhSachChiTietHoaDon(maHoaDon);

                string ketQuaCapNhat =
                    _hoaDonBUS.CapNhatHoaDonChuaThanhToan(
                        hoaDonCapNhat,
                        chiTietCapNhat
                    );

                if (ketQuaCapNhat != "Cập nhật order thành công.")
                {
                    MessageBox.Show(
                        ketQuaCapNhat,
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }
            }

            string maKhuyenMai =
                _khuyenMaiDangApDung?.MaKhuyenMai;

            string maKH =
                _khachHangDangChon?.MaKH;

            decimal? tienKhachDua = null;

            if (_phuongThucThanhToan == "Tiền mặt")
            {
                string textKhachDua = txtKhachDua.Text
                    .Replace(".", "")
                    .Replace(",", "");

                if (!decimal.TryParse(
                    textKhachDua,
                    out decimal soTienKhachDua))
                {
                    MessageBox.Show(
                        "Tiền khách đưa không hợp lệ.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                tienKhachDua = soTienKhachDua;
            }

            string ketQuaThanhToan = _hoaDonBUS.ThanhToan(
                maHoaDon, maPhuongThuc, maKhuyenMai, maKH, tienKhachDua);

            MessageBox.Show(
                ketQuaThanhToan,"Thông báo",
                MessageBoxButtons.OK,
                ketQuaThanhToan.StartsWith("Thanh toán thành công")
                ? MessageBoxIcon.Information
                : MessageBoxIcon.Warning);

            if (!ketQuaThanhToan.StartsWith("Thanh toán thành công"))
                return;

            this.Close();
        }

        private string LayMaPhuongThucThanhToan()
        {
            if (_phuongThucThanhToan == "Tiền mặt")
                return "PT01";

            if (_phuongThucThanhToan == "Chuyển khoản")
                return "PT02";

            if (_phuongThucThanhToan == "Thẻ")
                return "PT03";

            return null;
        }

        private void LoadHoaDonDangMo()
        {
            if (_hoaDonDangMo == null)
                return;

            // Khôi phục khách hàng
            if (_hoaDonDangMo.KhachHang != null)
            {
                _khachHangDangChon = _hoaDonDangMo.KhachHang;
                btnKhachHang.Text = _khachHangDangChon.HoTen;
            }
            else
            {
                _khachHangDangChon = null;
                btnKhachHang.Text = "Khách lẻ";
            }

            // Khôi phục hình thức phục vụ
            _laMangVe = _hoaDonDangMo.GhiChu == "Mang về";

            btnHinhThucPhucVu.Text = _laMangVe
                ? "Mang về"
                : "Tại chỗ";

            dgvHoaDon.Rows.Clear();

            foreach (var chiTiet in _hoaDonDangMo.ChiTietHoaDons)
            {
                int rowIndex;

                if (chiTiet.Topping != null)
                {
                    rowIndex = dgvHoaDon.Rows.Add(
                        null,
                        chiTiet.Topping.TenTopping,
                        chiTiet.SoLuong,
                        chiTiet.GiaBan,
                        chiTiet.ThanhTien,
                        chiTiet.GhiChu ?? ""
                    );

                    dgvHoaDon.Rows[rowIndex].Tag = chiTiet.Topping;
                }
                else if (chiTiet.Mon != null)
                {
                    rowIndex = dgvHoaDon.Rows.Add(
                        chiTiet.MaMon,
                        chiTiet.Mon.TenMon,
                        chiTiet.SoLuong,
                        chiTiet.GiaBan,
                        chiTiet.ThanhTien,
                        chiTiet.GhiChu ?? ""
                    );
                }
            }

            CapNhatTongTien();

            dgvHoaDon.ClearSelection();
            dgvHoaDon.CurrentCell = null;
        }

        private void btnLuuOrder_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Order chưa có món.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // 1. ORDER CHƯA ĐƯỢC LƯU
            if (_hoaDonDangMo == null)
            {
                string maHoaDon = TaoMaHoaDon();

                HoaDon hoaDon = TaoHoaDon(maHoaDon);

                if (_khachHangDangChon != null)
                    hoaDon.MaKH = _khachHangDangChon.MaKH;

                List<ChiTietHoaDon> chiTietHoaDons =
                    TaoDanhSachChiTietHoaDon(maHoaDon);

                string ketQua = _hoaDonBUS.TaoHoaDon(
                    hoaDon,
                    chiTietHoaDons
                );

                MessageBox.Show(
                    ketQua,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    ketQua == "Tạo hóa đơn thành công."
                        ? MessageBoxIcon.Information
                        : MessageBoxIcon.Warning
                );

                if (ketQua != "Tạo hóa đơn thành công.")
                    return;

                _hoaDonDangMo =
                    _hoaDonBUS.GetById(maHoaDon);

                return;
            }

            // 2. ORDER ĐÃ ĐƯỢC LƯU TRƯỚC ĐÓ
            HoaDon hoaDonCapNhat = TaoHoaDon(
                _hoaDonDangMo.MaHoaDon
            );

            hoaDonCapNhat.MaHoaDon =
                _hoaDonDangMo.MaHoaDon;

            if (_khachHangDangChon != null)
                hoaDonCapNhat.MaKH = _khachHangDangChon.MaKH;
            else
                hoaDonCapNhat.MaKH = _hoaDonDangMo.MaKH;

            List<ChiTietHoaDon> chiTietCapNhat =
                TaoDanhSachChiTietHoaDon(
                    _hoaDonDangMo.MaHoaDon
                );

            string ketQuaCapNhat =
                _hoaDonBUS.CapNhatHoaDonChuaThanhToan(
                    hoaDonCapNhat,
                    chiTietCapNhat
                );

            MessageBox.Show(
                ketQuaCapNhat,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQuaCapNhat == "Cập nhật order thành công."
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQuaCapNhat != "Cập nhật order thành công.")
                return;

            _hoaDonDangMo =
                _hoaDonBUS.GetById(
                    _hoaDonDangMo.MaHoaDon
                );
        }
    }
}