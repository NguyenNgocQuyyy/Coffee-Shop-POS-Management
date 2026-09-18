using Microsoft.EntityFrameworkCore;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.DAL
{
    internal class HoaDonDAL
    {
        public List<HoaDon> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.HoaDons
                    .Include(x => x.Ban)
                    .Include(x => x.NhanVien)
                    .Include(x => x.KhachHang)
                    .Include(x => x.KhuyenMai)
                    .Include(x => x.PhuongThucThanhToan)
                    .Include(x => x.ChiTietHoaDons)
                        .ThenInclude(x => x.Mon)
                    .Include(x => x.ChiTietHoaDons)
                        .ThenInclude(x => x.Topping)
                    .OrderByDescending(x => x.NgayLap)
                    .ToList();
            }
        }

        public HoaDon GetById(string maHoaDon)
        {
            using (var context = new AppDbContext())
            {
                return context.HoaDons
                    .Include(x => x.Ban)
                    .Include(x => x.NhanVien)
                    .Include(x => x.KhachHang)
                    .Include(x => x.KhuyenMai)
                    .Include(x => x.PhuongThucThanhToan)
                    .Include(x => x.ChiTietHoaDons)
                        .ThenInclude(x => x.Mon)
                    .Include(x => x.ChiTietHoaDons)
                        .ThenInclude(x => x.Topping)
                    .FirstOrDefault(x => x.MaHoaDon == maHoaDon);
            }
        }

        public HoaDon GetHoaDonChuaThanhToanTheoBan(string maBan)
        {
            using (var context = new AppDbContext())
            {
                return context.HoaDons
                    .Include(x => x.Ban)
                    .Include(x => x.NhanVien)
                    .Include(x => x.KhachHang)
                    .Include(x => x.KhuyenMai)
                    .Include(x => x.PhuongThucThanhToan)
                    .Include(x => x.ChiTietHoaDons)
                        .ThenInclude(x => x.Mon)
                    .Include(x => x.ChiTietHoaDons)
                        .ThenInclude(x => x.Topping)
                    .FirstOrDefault(x =>
                        x.MaBan == maBan &&
                        x.TrangThai == "Chưa thanh toán");
            }
        }

        public List<HoaDon> Search(string keyword)
        {
            using (var context = new AppDbContext())
            {
                return context.HoaDons
                    .Include(x => x.Ban)
                    .Include(x => x.NhanVien)
                    .Include(x => x.KhachHang)
                    .Where(x =>
                        x.MaHoaDon.Contains(keyword) ||
                        x.MaNV.Contains(keyword) ||
                        (x.MaBan != null && x.MaBan.Contains(keyword)) ||
                        (x.MaKH != null && x.MaKH.Contains(keyword)))
                    .OrderByDescending(x => x.NgayLap)
                    .ToList();
            }
        }

        public List<HoaDon> Filter(string maHoaDon, string trangThai, DateTime tuNgay, DateTime denNgay)
        {
            using (var context = new AppDbContext())
            {
                var query = context.HoaDons
                    .Include(x => x.Ban)
                    .Include(x => x.NhanVien)
                    .Include(x => x.KhachHang)
                    .Include(x => x.KhuyenMai)
                    .Include(x => x.PhuongThucThanhToan)
                    .Include(x => x.ChiTietHoaDons)
                        .ThenInclude(x => x.Mon)
                    .Include(x => x.ChiTietHoaDons)
                        .ThenInclude(x => x.Topping)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(maHoaDon))
                {
                    maHoaDon = maHoaDon.Trim();

                    query = query.Where(x =>
                        x.MaHoaDon.Contains(maHoaDon));
                }

                if (!string.IsNullOrWhiteSpace(trangThai) &&
                    trangThai != "Tất cả")
                {
                    query = query.Where(x =>
                        x.TrangThai == trangThai);
                }

                DateTime batDau = tuNgay.Date;
                DateTime ketThuc = denNgay.Date.AddDays(1);

                query = query.Where(x =>
                    x.NgayLap >= batDau &&
                    x.NgayLap < ketThuc);

                return query
                    .OrderByDescending(x => x.NgayLap)
                    .ToList();
            }
        }

        public bool Add(HoaDon hoaDon, List<ChiTietHoaDon> chiTietHoaDons)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // 1. KIỂM TRA VÀ CẬP NHẬT BÀN
                    if (!string.IsNullOrWhiteSpace(hoaDon.MaBan))
                    {
                        var ban = context.Bans
                            .FirstOrDefault(x =>
                                x.MaBan == hoaDon.MaBan);

                        if (ban == null)
                            throw new Exception("Không tìm thấy bàn.");

                        if (ban.TrangThai == "Đang bảo trì")
                        {
                            throw new Exception(
                                $"Bàn {ban.SoBan} đang bảo trì!");
                        }

                        ban.TrangThai = "Đang sử dụng";
                    }

                    // 2. LƯU HÓA ĐƠN
                    context.HoaDons.Add(hoaDon);
                    context.SaveChanges();

                    // 3. LƯU CHI TIẾT HÓA ĐƠN
                    foreach (var chiTiet in chiTietHoaDons)
                    {
                        chiTiet.MaHoaDon = hoaDon.MaHoaDon;

                        context.ChiTietHoaDons.Add(chiTiet);
                    }

                    context.SaveChanges();

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool HuyHoaDon(string maHoaDon)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // 1. LẤY HÓA ĐƠN
                    var hoaDon = context.HoaDons
                        .Include(x => x.ChiTietHoaDons)
                        .FirstOrDefault(x =>
                            x.MaHoaDon == maHoaDon);

                    if (hoaDon == null)
                        throw new Exception("Không tìm thấy hóa đơn.");

                    if (hoaDon.TrangThai == "Đã hủy")
                    {
                        throw new Exception(
                            "Hóa đơn đã được hủy trước đó.");
                    }

                    bool daThanhToan =
                        hoaDon.TrangThai == "Đã thanh toán";

                    // 2. HOÀN KHO NẾU ĐÃ THANH TOÁN
                    if (daThanhToan)
                    {
                        foreach (var chiTiet in hoaDon.ChiTietHoaDons)
                        {
                            // MÓN → HOÀN NGUYÊN VẬT LIỆU
                            if (!string.IsNullOrWhiteSpace(
                                    chiTiet.MaMon))
                            {
                                var congThucs = context.CongThucs
                                    .Where(x =>
                                        x.MaMon == chiTiet.MaMon)
                                    .ToList();

                                foreach (var congThuc in congThucs)
                                {
                                    var nvl = context.NguyenVatLieus
                                        .FirstOrDefault(x =>
                                            x.MaNVL == congThuc.MaNVL);

                                    if (nvl == null)
                                    {
                                        throw new Exception(
                                            $"Không tìm thấy nguyên vật liệu {congThuc.MaNVL}.");
                                    }

                                    if (nvl.HeSoQuyDoi <= 0)
                                    {
                                        throw new Exception(
                                            $"Nguyên vật liệu {nvl.TenNVL} chưa có hệ số quy đổi hợp lệ.");
                                    }

                                    decimal soLuongTheoCongThuc =
                                        congThuc.DinhLuong *
                                        chiTiet.SoLuong;

                                    decimal soLuongHoan =
                                        soLuongTheoCongThuc /
                                        nvl.HeSoQuyDoi;

                                    nvl.SoLuongTon += soLuongHoan;

                                    CapNhatTrangThaiNVL(nvl);
                                }
                            }

                            // TOPPING → HOÀN TỒN TOPPING
                            else if (!string.IsNullOrWhiteSpace(
                                         chiTiet.MaTopping))
                            {
                                var topping = context.Toppings
                                    .FirstOrDefault(x =>
                                        x.MaTopping ==
                                        chiTiet.MaTopping);

                                if (topping == null)
                                {
                                    throw new Exception(
                                        $"Không tìm thấy topping {chiTiet.MaTopping}.");
                                }

                                if (topping.HeSoQuyDoi <= 0)
                                {
                                    throw new Exception(
                                        $"Topping {topping.TenTopping} chưa có hệ số quy đổi hợp lệ.");
                                }

                                decimal soLuongHoan =
                                    chiTiet.SoLuong / topping.HeSoQuyDoi;

                                topping.SoLuongTon += soLuongHoan;

                                CapNhatTrangThaiTopping(topping);
                            }
                        }

                        // 3. HOÀN ĐIỂM KHÁCH HÀNG
                        if (!string.IsNullOrWhiteSpace(
                                hoaDon.MaKH))
                        {
                            var khachHang = context.KhachHangs
                                .FirstOrDefault(x =>
                                    x.MaKH == hoaDon.MaKH);

                            if (khachHang == null)
                            {
                                throw new Exception(
                                    "Không tìm thấy khách hàng.");
                            }

                            int diemDaCong =
                                (int)(hoaDon.ThanhTien / 10000);

                            khachHang.DiemTichLuy -= diemDaCong;

                            if (khachHang.DiemTichLuy < 0)
                                khachHang.DiemTichLuy = 0;
                        }
                    }

                    // 4. TRẢ BÀN VỀ TRỐNG
                    if (!string.IsNullOrWhiteSpace(
                            hoaDon.MaBan))
                    {
                        var ban = context.Bans
                            .FirstOrDefault(x =>
                                x.MaBan == hoaDon.MaBan);

                        if (ban == null)
                        {
                            throw new Exception(
                                "Không tìm thấy bàn.");
                        }

                        ban.TrangThai = "Trống";
                    }

                    // 5. ĐỔI TRẠNG THÁI HÓA ĐƠN
                    hoaDon.TrangThai = "Đã hủy";

                    context.SaveChanges();

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool ThanhToan(
            HoaDon hoaDon,
            int diemCong)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // 1. LẤY HÓA ĐƠN VÀ CHI TIẾT
                    var existing = context.HoaDons
                        .Include(x => x.ChiTietHoaDons)
                        .FirstOrDefault(x =>
                            x.MaHoaDon == hoaDon.MaHoaDon);

                    if (existing == null)
                        throw new Exception("Không tìm thấy hóa đơn.");

                    if (existing.TrangThai == "Đã thanh toán")
                    {
                        throw new Exception(
                            "Hóa đơn đã được thanh toán.");
                    }

                    if (existing.TrangThai == "Đã hủy")
                    {
                        throw new Exception(
                            "Hóa đơn đã bị hủy.");
                    }

                    // 2. TRỪ KHO
                    foreach (var chiTiet in existing.ChiTietHoaDons)
                    {
                        // MÓN → TRỪ NVL THEO CÔNG THỨC
                        if (!string.IsNullOrWhiteSpace(
                                chiTiet.MaMon))
                        {
                            var congThucs = context.CongThucs
                                .Where(x =>
                                    x.MaMon == chiTiet.MaMon)
                                .ToList();

                            foreach (var congThuc in congThucs)
                            {
                                var nvl = context.NguyenVatLieus
                                    .FirstOrDefault(x =>
                                        x.MaNVL ==
                                        congThuc.MaNVL);

                                if (nvl == null)
                                {
                                    throw new Exception(
                                        $"Không tìm thấy nguyên vật liệu {congThuc.MaNVL}.");
                                }

                                if (nvl.HeSoQuyDoi <= 0)
                                {
                                    throw new Exception(
                                        $"Nguyên vật liệu {nvl.TenNVL} chưa có hệ số quy đổi hợp lệ.");
                                }

                                decimal soLuongTheoCongThuc =
                                    congThuc.DinhLuong *
                                    chiTiet.SoLuong;

                                decimal soLuongCanTru =
                                    soLuongTheoCongThuc /
                                    nvl.HeSoQuyDoi;

                                if (nvl.SoLuongTon < soLuongCanTru)
                                {
                                    throw new Exception(
                                        $"Nguyên vật liệu {nvl.TenNVL} không đủ tồn kho.");
                                }

                                nvl.SoLuongTon -= soLuongCanTru;

                                CapNhatTrangThaiNVL(nvl);
                            }
                        }

                        // TOPPING → TRỪ TRỰC TIẾP TỒN TOPPING
                        else if (!string.IsNullOrWhiteSpace(
                                     chiTiet.MaTopping))
                        {
                            var topping = context.Toppings
                                .FirstOrDefault(x =>
                                    x.MaTopping ==
                                    chiTiet.MaTopping);

                            if (topping == null)
                            {
                                throw new Exception(
                                    $"Không tìm thấy topping {chiTiet.MaTopping}.");
                            }

                            if (topping.HeSoQuyDoi <= 0)
                            {
                                throw new Exception(
                                    $"Topping {topping.TenTopping} chưa có hệ số quy đổi hợp lệ.");
                            }

                            decimal soLuongCanTru =
                                chiTiet.SoLuong / topping.HeSoQuyDoi;

                            if (topping.SoLuongTon < soLuongCanTru)
                            {
                                throw new Exception(
                                    $"Topping {topping.TenTopping} không đủ tồn kho.");
                            }

                            topping.SoLuongTon -= soLuongCanTru;

                            CapNhatTrangThaiTopping(topping);
                        }
                    }

                    // 3. CẬP NHẬT THÔNG TIN THANH TOÁN
                    existing.TongTien = hoaDon.TongTien;
                    existing.GiamGia = hoaDon.GiamGia;
                    existing.ThanhTien = hoaDon.ThanhTien;
                    existing.TienKhachDua = hoaDon.TienKhachDua;
                    existing.TienThoi = hoaDon.TienThoi;
                    existing.MaKhuyenMai = hoaDon.MaKhuyenMai;
                    existing.MaPhuongThuc = hoaDon.MaPhuongThuc;
                    existing.MaKH = hoaDon.MaKH;
                    existing.TrangThai = "Đã thanh toán";

                    // 4. CỘNG ĐIỂM KHÁCH HÀNG
                    if (!string.IsNullOrWhiteSpace(
                            existing.MaKH))
                    {
                        var khachHang = context.KhachHangs
                            .FirstOrDefault(x =>
                                x.MaKH == existing.MaKH);

                        if (khachHang == null)
                        {
                            throw new Exception(
                                "Không tìm thấy khách hàng.");
                        }

                        khachHang.DiemTichLuy += diemCong;
                    }

                    // 5. CẬP NHẬT TRẠNG THÁI BÀN
                    if (!string.IsNullOrWhiteSpace(
                            existing.MaBan))
                    {
                        var ban = context.Bans
                            .FirstOrDefault(x =>
                                x.MaBan == existing.MaBan);

                        if (ban == null)
                        {
                            throw new Exception(
                                "Không tìm thấy bàn.");
                        }

                        ban.TrangThai = "Trống";
                    }

                    context.SaveChanges();

                    // 6. XÁC NHẬN GIAO DỊCH
                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private void CapNhatTrangThaiNVL(
            NguyenVatLieu nguyenVatLieu)
        {
            if (nguyenVatLieu.SoLuongTon <= 0)
            {
                nguyenVatLieu.TrangThai = "Hết hàng";
            }
            else if (nguyenVatLieu.SoLuongTon
                     <= nguyenVatLieu.MucCanhBao)
            {
                nguyenVatLieu.TrangThai = "Sắp hết";
            }
            else
            {
                nguyenVatLieu.TrangThai = "Còn hàng";
            }
        }

        private void CapNhatTrangThaiTopping(
            Topping topping)
        {
            if (topping.TrangThai == "Ngừng bán")
                return;

            if (topping.SoLuongTon <= 0)
            {
                topping.TrangThai = "Hết hàng";
            }
            else if (topping.SoLuongTon
                     <= topping.MucCanhBao)
            {
                topping.TrangThai = "Sắp hết";
            }
            else
            {
                topping.TrangThai = "Đang bán";
            }
        }

        public string TaoMaHoaDonMoi()
        {
            using (var context = new AppDbContext())
            {
                var danhSachMa = context.HoaDons
                    .Select(x => x.MaHoaDon)
                    .ToList();

                int soLonNhat = 0;

                foreach (string ma in danhSachMa)
                {
                    if (string.IsNullOrWhiteSpace(ma))
                        continue;

                    if (!ma.StartsWith("HD"))
                        continue;

                    string phanSo = ma.Substring(2);

                    if (int.TryParse(phanSo, out int so))
                    {
                        if (so > soLonNhat)
                            soLonNhat = so;
                    }
                }

                return "HD" + (soLonNhat + 1).ToString("D3");
            }
        }

        public bool CapNhatHoaDonChuaThanhToan(HoaDon hoaDon, List<ChiTietHoaDon> chiTietHoaDons)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var existing = context.HoaDons
                        .Include(x => x.ChiTietHoaDons)
                        .FirstOrDefault(x => x.MaHoaDon == hoaDon.MaHoaDon);

                    if (existing == null)
                        throw new Exception("Không tìm thấy hóa đơn.");

                    if (existing.TrangThai != "Chưa thanh toán")
                        throw new Exception("Chỉ được cập nhật hóa đơn chưa thanh toán.");

                    context.ChiTietHoaDons.RemoveRange(existing.ChiTietHoaDons);

                    existing.MaBan = hoaDon.MaBan;
                    existing.MaNV = hoaDon.MaNV;
                    existing.MaKH = hoaDon.MaKH;
                    existing.GhiChu = hoaDon.GhiChu;
                    existing.NgayLap = hoaDon.NgayLap;

                    existing.TongTien = chiTietHoaDons.Sum(x => x.ThanhTien);
                    existing.GiamGia = 0;
                    existing.ThanhTien = existing.TongTien;

                    foreach (var chiTiet in chiTietHoaDons)
                    {
                        chiTiet.MaHoaDon = existing.MaHoaDon;

                        context.ChiTietHoaDons.Add(chiTiet);
                    }

                    context.SaveChanges();

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool ChuyenBanHoaDon(string maHoaDon, string maBanMoi)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var hoaDon = context.HoaDons
                        .FirstOrDefault(x => x.MaHoaDon == maHoaDon);

                    if (hoaDon == null)
                        throw new Exception("Không tìm thấy hóa đơn.");

                    if (hoaDon.TrangThai != "Chưa thanh toán")
                        throw new Exception("Chỉ được chuyển bàn cho hóa đơn chưa thanh toán.");

                    var banMoi = context.Bans
                        .FirstOrDefault(x => x.MaBan == maBanMoi);

                    if (banMoi == null)
                        throw new Exception("Không tìm thấy bàn mới.");

                    hoaDon.MaBan = maBanMoi;

                    context.SaveChanges();
                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}