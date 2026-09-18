using Microsoft.EntityFrameworkCore;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.DAL
{
    internal class PhieuNhapDAL
    {
        public List<PhieuNhap> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.PhieuNhaps
                    .Include(x => x.NhaCungCap)
                    .Include(x => x.ChiTietPhieuNhaps)
                        .ThenInclude(x => x.NguyenVatLieu)
                    .Include(x => x.ChiTietPhieuNhaps)
                        .ThenInclude(x => x.Topping)
                    .OrderByDescending(x => x.NgayNhap)
                    .ToList();
            }
        }

        public PhieuNhap GetById(string maPhieuNhap)
        {
            using (var context = new AppDbContext())
            {
                return context.PhieuNhaps
                    .Include(x => x.NhaCungCap)
                    .Include(x => x.ChiTietPhieuNhaps)
                        .ThenInclude(x => x.NguyenVatLieu)
                    .Include(x => x.ChiTietPhieuNhaps)
                        .ThenInclude(x => x.Topping)
                    .FirstOrDefault(x => x.MaPhieuNhap == maPhieuNhap);
            }
        }

        public List<PhieuNhap> Search(string keyword)
        {
            using (var context = new AppDbContext())
            {
                return context.PhieuNhaps
                    .Include(x => x.NhaCungCap)
                    .Where(x =>
                        x.MaPhieuNhap.Contains(keyword) ||
                        x.MaNCC.Contains(keyword) ||
                        x.NhaCungCap.TenNCC.Contains(keyword))
                    .OrderByDescending(x => x.NgayNhap)
                    .ToList();
            }
        }

        public bool Add(
            PhieuNhap phieuNhap,
            List<ChiTietPhieuNhap> chiTiets)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Lưu phiếu nhập
                    context.PhieuNhaps.Add(phieuNhap);
                    context.SaveChanges();

                    // 2. Lưu từng chi tiết và cộng tồn kho
                    foreach (var chiTiet in chiTiets)
                    {
                        chiTiet.MaPhieuNhap = phieuNhap.MaPhieuNhap;

                        context.ChiTietPhieuNhaps.Add(chiTiet);

                        // Nếu là nguyên vật liệu
                        if (!string.IsNullOrWhiteSpace(chiTiet.MaNVL))
                        {
                            var nvl = context.NguyenVatLieus
                                .FirstOrDefault(x =>
                                    x.MaNVL == chiTiet.MaNVL);

                            if (nvl == null)
                                throw new Exception(
                                    "Không tìm thấy nguyên vật liệu.");

                            nvl.SoLuongTon += chiTiet.SoLuong;

                            CapNhatTrangThaiNVL(nvl);
                        }

                        // Nếu là topping
                        else if (!string.IsNullOrWhiteSpace(
                            chiTiet.MaTopping))
                        {
                            var topping = context.Toppings
                                .FirstOrDefault(x =>
                                    x.MaTopping == chiTiet.MaTopping);

                            if (topping == null)
                                throw new Exception(
                                    "Không tìm thấy topping.");

                            topping.SoLuongTon += chiTiet.SoLuong;

                            CapNhatTrangThaiTopping(topping);
                        }
                        else
                        {
                            throw new Exception(
                                "Chi tiết phiếu nhập không có mặt hàng.");
                        }
                    }

                    context.SaveChanges();

                    // 3. Xác nhận toàn bộ giao dịch
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
            // Nếu quản lý đã chủ động ngừng bán thì nhập thêm hàng cũng không tự mở bán lại
            if (topping.TrangThai == "Ngừng bán")
                return;

            if (topping.SoLuongTon <= 0)
            {
                topping.TrangThai = "Hết hàng";
            }
            else if (topping.SoLuongTon <= topping.MucCanhBao)
            {
                topping.TrangThai = "Sắp hết";
            }
            else
            {
                topping.TrangThai = "Đang bán";
            }
        }

        public decimal? LayDonGiaNhapGanNhat(string maNVL,string maTopping)
        {
            using (var context = new AppDbContext())
            {
                var query = context.ChiTietPhieuNhaps
                    .Include(x => x.PhieuNhap)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(maNVL))
                {
                    return query
                        .Where(x => x.MaNVL == maNVL)
                        .OrderByDescending(x => x.PhieuNhap.NgayNhap)
                        .ThenByDescending(x => x.MaChiTietPN)
                        .Select(x => (decimal?)x.DonGia)
                        .FirstOrDefault();
                }

                if (!string.IsNullOrWhiteSpace(maTopping))
                {
                    return query
                        .Where(x => x.MaTopping == maTopping)
                        .OrderByDescending(x => x.PhieuNhap.NgayNhap)
                        .ThenByDescending(x => x.MaChiTietPN)
                        .Select(x => (decimal?)x.DonGia)
                        .FirstOrDefault();
                }

                return null;
            }
        }
    }
}