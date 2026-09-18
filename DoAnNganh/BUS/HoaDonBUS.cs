using Đồ_án_ngành.DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.BUS
{
    internal class HoaDonBUS
    {
        private readonly HoaDonDAL _hoaDonDAL
            = new HoaDonDAL();

        private readonly MonDAL _monDAL
            = new MonDAL();

        private readonly ToppingDAL _toppingDAL
            = new ToppingDAL();

        private readonly NhanVienDAL _nhanVienDAL
            = new NhanVienDAL();

        private readonly BanDAL _banDAL
            = new BanDAL();

        private readonly KhachHangDAL _khachHangDAL
            = new KhachHangDAL();

        private readonly KhuyenMaiDAL _khuyenMaiDAL
            = new KhuyenMaiDAL();

        private readonly PhuongThucThanhToanDAL _phuongThucDAL
            = new PhuongThucThanhToanDAL();

        public List<HoaDon> GetAll()
        {
            return _hoaDonDAL.GetAll();
        }

        public HoaDon GetById(string maHoaDon)
        {
            if (string.IsNullOrWhiteSpace(maHoaDon))
                return null;

            return _hoaDonDAL.GetById(maHoaDon.Trim());
        }

        public HoaDon GetHoaDonChuaThanhToanTheoBan(string maBan)
        {
            if (string.IsNullOrWhiteSpace(maBan))
                return null;

            return _hoaDonDAL.GetHoaDonChuaThanhToanTheoBan(maBan.Trim());
        }

        public List<HoaDon> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            return _hoaDonDAL.Search(keyword.Trim());
        }

        public string TaoHoaDon(
            HoaDon hoaDon,
            List<ChiTietHoaDon> chiTietHoaDons)
        {
            // 1. KIỂM TRA HÓA ĐƠN
            if (hoaDon == null)
                return "Dữ liệu hóa đơn không hợp lệ.";

            if (string.IsNullOrWhiteSpace(hoaDon.MaHoaDon))
                return "Mã hóa đơn không được để trống.";

            if (string.IsNullOrWhiteSpace(hoaDon.MaNV))
                return "Hóa đơn phải có nhân viên lập.";

            hoaDon.MaHoaDon = hoaDon.MaHoaDon.Trim();
            hoaDon.MaNV = hoaDon.MaNV.Trim();

            if (_hoaDonDAL.GetById(hoaDon.MaHoaDon) != null)
                return "Mã hóa đơn đã tồn tại.";

            if (_nhanVienDAL.GetById(hoaDon.MaNV) == null)
                return "Nhân viên không tồn tại.";

            // 2. KIỂM TRA BÀN
            if (!string.IsNullOrWhiteSpace(hoaDon.MaBan))
            {
                hoaDon.MaBan = hoaDon.MaBan.Trim();

                if (_banDAL.GetById(hoaDon.MaBan) == null)
                    return "Bàn không tồn tại.";
            }
            else
            {
                hoaDon.MaBan = null;
            }

            // 3. KIỂM TRA DANH SÁCH CHI TIẾT
            if (chiTietHoaDons == null ||
                chiTietHoaDons.Count == 0)
            {
                return "Hóa đơn phải có ít nhất một sản phẩm.";
            }

            var maChiTietDaCo = new HashSet<string>();

            foreach (var chiTiet in chiTietHoaDons)
            {
                if (chiTiet == null)
                    return "Chi tiết hóa đơn không hợp lệ.";

                if (string.IsNullOrWhiteSpace(
                        chiTiet.MaChiTietHoaDon))
                {
                    return "Mã chi tiết hóa đơn không được để trống.";
                }

                chiTiet.MaChiTietHoaDon =
                    chiTiet.MaChiTietHoaDon.Trim();

                if (!maChiTietDaCo.Add(
                        chiTiet.MaChiTietHoaDon))
                {
                    return "Mã chi tiết hóa đơn bị trùng.";
                }

                if (chiTiet.SoLuong <= 0)
                    return "Số lượng phải lớn hơn 0.";

                bool coMon =
                    !string.IsNullOrWhiteSpace(chiTiet.MaMon);

                bool coTopping =
                    !string.IsNullOrWhiteSpace(
                        chiTiet.MaTopping);

                // 4. MỖI DÒNG CHỈ ĐƯỢC LÀ MÓN HOẶC TOPPING
                if (coMon == coTopping)
                {
                    return "Chi tiết hóa đơn phải là món hoặc topping.";
                }

                // 5. XỬ LÝ MÓN
                if (coMon)
                {
                    chiTiet.MaMon =
                        chiTiet.MaMon.Trim();

                    chiTiet.MaTopping = null;

                    var mon =
                        _monDAL.GetById(chiTiet.MaMon);

                    if (mon == null)
                    {
                        return $"Món {chiTiet.MaMon} không tồn tại.";
                    }

                    if (mon.TrangThai != "Đang bán")
                    {
                        return $"Món {mon.TenMon} hiện không bán.";
                    }

                    chiTiet.GiaBan = mon.GiaBan;

                    chiTiet.ThanhTien =
                        chiTiet.GiaBan *
                        chiTiet.SoLuong;
                }

                // 6. XỬ LÝ TOPPING
                else
                {
                    chiTiet.MaTopping =
                        chiTiet.MaTopping.Trim();

                    chiTiet.MaMon = null;

                    var topping =
                        _toppingDAL.GetById(
                            chiTiet.MaTopping);

                    if (topping == null)
                    {
                        return $"Topping {chiTiet.MaTopping} không tồn tại.";
                    }

                    if (topping.TrangThai != "Đang bán")
                    {
                        return $"Topping {topping.TenTopping} hiện không bán.";
                    }

                    if (topping.SoLuongTon <
                        chiTiet.SoLuong)
                    {
                        return $"Topping {topping.TenTopping} không đủ tồn kho.";
                    }

                    chiTiet.GiaBan =
                        topping.GiaBan;

                    chiTiet.ThanhTien =
                        chiTiet.GiaBan *
                        chiTiet.SoLuong;
                }

                // 7. GÁN HÓA ĐƠN VÀ GHI CHÚ
                chiTiet.MaHoaDon =
                    hoaDon.MaHoaDon;

                if (!string.IsNullOrWhiteSpace(
                        chiTiet.GhiChu))
                {
                    chiTiet.GhiChu =
                        chiTiet.GhiChu.Trim();
                }
                else
                {
                    chiTiet.GhiChu = null;
                }
            }

            // 8. TÍNH TỔNG TIỀN
            hoaDon.TongTien =
                chiTietHoaDons.Sum(x =>
                    x.ThanhTien);

            hoaDon.GiamGia = 0;
            hoaDon.ThanhTien = hoaDon.TongTien;

            hoaDon.TienKhachDua = null;
            hoaDon.TienThoi = null;
            hoaDon.MaKhuyenMai = null;
            hoaDon.MaPhuongThuc = null;

            hoaDon.TrangThai = "Chưa thanh toán";

            if (hoaDon.NgayLap == default(DateTime))
                hoaDon.NgayLap = DateTime.Now;

            if (!string.IsNullOrWhiteSpace(
                    hoaDon.GhiChu))
            {
                hoaDon.GhiChu =
                    hoaDon.GhiChu.Trim();
            }

            // 9. LƯU HÓA ĐƠN
            try
            {
                return _hoaDonDAL.Add(hoaDon, chiTietHoaDons)
                    ? "Tạo hóa đơn thành công."
                    : "Tạo hóa đơn thất bại.";
            }
            catch (Exception ex)
            {
                string loi = ex.Message;

                if (ex.InnerException != null)
                {
                    loi += "\n\nChi tiết: "
                        + ex.InnerException.Message;
                }

                return "Tạo hóa đơn thất bại: " + loi;
            }
        }

        public string CapNhatHoaDonChuaThanhToan(HoaDon hoaDon, List<ChiTietHoaDon> chiTietHoaDons)
        {
            if (hoaDon == null)
                return "Dữ liệu hóa đơn không hợp lệ.";

            if (string.IsNullOrWhiteSpace(hoaDon.MaHoaDon))
                return "Mã hóa đơn không hợp lệ.";

            if (chiTietHoaDons == null || chiTietHoaDons.Count == 0)
                return "Order phải có ít nhất một sản phẩm.";

            foreach (var chiTiet in chiTietHoaDons)
            {
                if (chiTiet.SoLuong <= 0)
                    return "Số lượng phải lớn hơn 0.";

                bool coMon =
                    !string.IsNullOrWhiteSpace(chiTiet.MaMon);

                bool coTopping =
                    !string.IsNullOrWhiteSpace(chiTiet.MaTopping);

                if (coMon == coTopping)
                    return "Chi tiết hóa đơn phải là món hoặc topping.";
            }

            try
            {
                return _hoaDonDAL.CapNhatHoaDonChuaThanhToan(
                    hoaDon,
                    chiTietHoaDons)
                    ? "Cập nhật order thành công."
                    : "Cập nhật order thất bại.";
            }
            catch (Exception ex)
            {
                return "Cập nhật order thất bại: " + ex.Message;
            }
        }

        public List<HoaDon> Filter(string maHoaDon, string trangThai, DateTime tuNgay, DateTime denNgay)
        {
            if (tuNgay.Date > denNgay.Date)
                return new List<HoaDon>();

            return _hoaDonDAL.Filter(
                maHoaDon,
                trangThai,
                tuNgay,
                denNgay
            );
        }

        public string HuyHoaDon(string maHoaDon, NhanVien nhanVienThucHien)
        {
            // 0. KIỂM TRA QUYỀN
            if (nhanVienThucHien == null ||
                nhanVienThucHien.ChucVu != "Manager")
            {
                return "Chỉ Manager mới có quyền hủy hóa đơn.";
            }

            // 1. KIỂM TRA MÃ HÓA ĐƠN
            if (string.IsNullOrWhiteSpace(maHoaDon))
                return "Mã hóa đơn không hợp lệ.";

            maHoaDon = maHoaDon.Trim();

            var hoaDon =
                _hoaDonDAL.GetById(maHoaDon);

            if (hoaDon == null)
                return "Không tìm thấy hóa đơn.";

            // 2. KIỂM TRA TRẠNG THÁI
            if (hoaDon.TrangThai == "Đã hủy")
            {
                return "Hóa đơn đã được hủy trước đó.";
            }

            if (hoaDon.TrangThai != "Chưa thanh toán" &&
                hoaDon.TrangThai != "Đã thanh toán")
            {
                return "Trạng thái hóa đơn không cho phép hủy.";
            }

            // 3. THỰC HIỆN HỦY
            try
            {
                bool ketQua =
                    _hoaDonDAL.HuyHoaDon(maHoaDon);

                if (!ketQua)
                    return "Hủy hóa đơn thất bại.";

                if (hoaDon.TrangThai ==
                    "Đã thanh toán")
                {
                    return "Hủy hóa đơn thành công. Kho và điểm tích lũy đã được hoàn lại.";
                }

                return "Hủy hóa đơn thành công.";
            }
            catch (Exception ex)
            {
                return "Hủy hóa đơn thất bại: "
                    + ex.Message;
            }
        }

        public string ThanhToan(
            string maHoaDon,
            string maPhuongThuc,
            string maKhuyenMai,
            string maKH,
            decimal? tienKhachDua)
        {
            // 1. KIỂM TRA HÓA ĐƠN
            if (string.IsNullOrWhiteSpace(maHoaDon))
                return "Mã hóa đơn không hợp lệ.";

            maHoaDon = maHoaDon.Trim();

            var hoaDon =
                _hoaDonDAL.GetById(maHoaDon);

            if (hoaDon == null)
                return "Không tìm thấy hóa đơn.";

            if (hoaDon.TrangThai == "Đã thanh toán")
                return "Hóa đơn đã được thanh toán.";

            if (hoaDon.TrangThai == "Đã hủy")
                return "Hóa đơn đã bị hủy.";

            // 2. TÍNH LẠI TỔNG TIỀN
            hoaDon.TongTien =
                hoaDon.ChiTietHoaDons
                    .Sum(x => x.ThanhTien);

            hoaDon.GiamGia = 0;

            // 3. KIỂM TRA KHÁCH HÀNG
            if (!string.IsNullOrWhiteSpace(maKH))
            {
                maKH = maKH.Trim();

                if (_khachHangDAL.GetById(maKH) == null)
                    return "Khách hàng không tồn tại.";

                hoaDon.MaKH = maKH;
            }
            else
            {
                hoaDon.MaKH = null;
            }

            // 4. KIỂM TRA VÀ TÍNH KHUYẾN MÃI
            if (!string.IsNullOrWhiteSpace(maKhuyenMai))
            {
                maKhuyenMai =
                    maKhuyenMai.Trim();

                var khuyenMai =
                    _khuyenMaiDAL.GetById(
                        maKhuyenMai);

                if (khuyenMai == null)
                    return "Khuyến mãi không tồn tại.";

                DateTime homNay = DateTime.Today;

                // 4.1. KIỂM TRA TRẠNG THÁI
                if (khuyenMai.TrangThai == "Ngừng áp dụng")
                {
                    return "Khuyến mãi đã ngừng áp dụng.";
                }

                // 4.2. KIỂM TRA THỜI GIAN ÁP DỤNG
                if (homNay < khuyenMai.NgayBatDau.Date)
                {
                    return "Khuyến mãi chưa đến thời gian áp dụng.";
                }

                if (homNay > khuyenMai.NgayKetThuc.Date)
                {
                    return "Khuyến mãi đã hết hạn.";
                }

                var danhSachMaMonKhuyenMai = 
                    khuyenMai.ChiTietKhuyenMais?
                    .Select(x => x.MaMon)
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .ToList()
                    ?? new List<string>();

                decimal tongTienDuocGiam = 0;
                int tongSoLuongDuocGiam = 0;

                bool apDungToanHoaDon =
                    danhSachMaMonKhuyenMai.Count == 0;

                // 4.1. TÍNH TỔNG TIỀN ĐƯỢC KHUYẾN MÃI
                foreach (var chiTiet in hoaDon.ChiTietHoaDons)
                {
                    // 1. KHUYẾN MÃI TOÀN HÓA ĐƠN
                    if (apDungToanHoaDon)
                    {
                        tongTienDuocGiam +=
                            chiTiet.ThanhTien;

                        continue;
                    }

                    // 2. TOPPING KHÔNG THUỘC KM THEO MÓN
                    if (string.IsNullOrWhiteSpace(
                            chiTiet.MaMon))
                    {
                        continue;
                    }

                    // 3. MÓN ĐƯỢC ÁP DỤNG KHUYẾN MÃI
                    if (danhSachMaMonKhuyenMai
                        .Contains(chiTiet.MaMon))
                    {
                        tongTienDuocGiam +=
                            chiTiet.ThanhTien;

                        tongSoLuongDuocGiam +=
                            chiTiet.SoLuong;
                    }
                }

                if (tongTienDuocGiam <= 0)
                {
                    return apDungToanHoaDon
                        ? "Hóa đơn không có sản phẩm để áp dụng khuyến mãi."
                        : "Hóa đơn không có món áp dụng khuyến mãi.";
                }

                if (khuyenMai.LoaiKhuyenMai ==
                    "Phần trăm")
                {
                    hoaDon.GiamGia =
                        tongTienDuocGiam *
                        khuyenMai.GiaTriKhuyenMai /
                        100;
                }
                else if (khuyenMai.LoaiKhuyenMai == "Tiền cố định")
                {
                    decimal tienGiam;

                    if (apDungToanHoaDon)
                    {
                        tienGiam =
                            khuyenMai.GiaTriKhuyenMai;
                    }
                    else
                    {
                        tienGiam =
                            khuyenMai.GiaTriKhuyenMai
                            * tongSoLuongDuocGiam;
                    }

                    hoaDon.GiamGia =
                        Math.Min(
                            tienGiam,
                            tongTienDuocGiam);
                }
                else
                {
                    return "Loại khuyến mãi không hợp lệ.";
                }

                hoaDon.MaKhuyenMai =
                    maKhuyenMai;
            }
            else
            {
                hoaDon.MaKhuyenMai = null;
            }

            // 5. TÍNH THÀNH TIỀN
            hoaDon.ThanhTien =
                hoaDon.TongTien -
                hoaDon.GiamGia;

            if (hoaDon.ThanhTien < 0)
                hoaDon.ThanhTien = 0;

            // 6. KIỂM TRA PHƯƠNG THỨC THANH TOÁN
            if (string.IsNullOrWhiteSpace(
                    maPhuongThuc))
            {
                return "Vui lòng chọn phương thức thanh toán.";
            }

            maPhuongThuc =
                maPhuongThuc.Trim();

            var phuongThuc =
                _phuongThucDAL.GetById(
                    maPhuongThuc);

            if (phuongThuc == null)
            {
                return "Phương thức thanh toán không tồn tại.";
            }

            hoaDon.MaPhuongThuc =
                maPhuongThuc;

            // 7. XỬ LÝ TIỀN MẶT
            if (phuongThuc.LaTienMat)
            {
                if (!tienKhachDua.HasValue)
                {
                    return "Vui lòng nhập số tiền khách đưa.";
                }

                if (tienKhachDua.Value < 0)
                {
                    return "Tiền khách đưa không hợp lệ.";
                }

                if (tienKhachDua.Value <
                    hoaDon.ThanhTien)
                {
                    return "Tiền khách đưa không đủ.";
                }

                hoaDon.TienKhachDua =
                    tienKhachDua.Value;

                hoaDon.TienThoi =
                    tienKhachDua.Value -
                    hoaDon.ThanhTien;
            }
            else
            {
                hoaDon.TienKhachDua = null;
                hoaDon.TienThoi = null;
            }

            // 8. TÍNH ĐIỂM TÍCH LŨY
            int diemCong = 0;

            if (!string.IsNullOrWhiteSpace(
                    hoaDon.MaKH))
            {
                diemCong =
                    (int)(hoaDon.ThanhTien /
                          10000);
            }

            // 9. THỰC HIỆN THANH TOÁN
            try
            {
                bool ketQua =
                    _hoaDonDAL.ThanhToan(
                        hoaDon,
                        diemCong);

                if (!ketQua)
                    return "Thanh toán thất bại.";

                return $"Thanh toán thành công. Điểm tích lũy được cộng: {diemCong}.";
            }
            catch (Exception ex)
            {
                return "Thanh toán thất bại: "
                    + ex.Message;
            }
        }

        public string TaoMaHoaDonMoi()
        {
            return _hoaDonDAL.TaoMaHoaDonMoi();
        }

        public string ChuyenBanHoaDon(string maHoaDon, string maBanMoi)
        {
            if (string.IsNullOrWhiteSpace(maHoaDon))
                return "Mã hóa đơn không hợp lệ.";

            if (string.IsNullOrWhiteSpace(maBanMoi))
                return "Bàn mới không hợp lệ.";

            try
            {
                return _hoaDonDAL.ChuyenBanHoaDon(
                    maHoaDon.Trim(),
                    maBanMoi.Trim()
                )
                    ? "Chuyển bàn hóa đơn thành công."
                    : "Chuyển bàn hóa đơn thất bại.";
            }
            catch (Exception ex)
            {
                return "Chuyển bàn hóa đơn thất bại: " + ex.Message;
            }
        }
    }
}