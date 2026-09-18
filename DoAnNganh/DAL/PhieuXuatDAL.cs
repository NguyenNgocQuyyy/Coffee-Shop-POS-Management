using Microsoft.EntityFrameworkCore;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.DAL
{
    internal class PhieuXuatDAL
    {
        public List<PhieuXuat> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.PhieuXuats
                    .Include(x => x.ChiTietPhieuXuats)
                        .ThenInclude(x => x.NguyenVatLieu)
                    .Include(x => x.ChiTietPhieuXuats)
                        .ThenInclude(x => x.Topping)
                    .OrderByDescending(x => x.NgayXuat)
                    .ToList();
            }
        }

        public PhieuXuat GetById(string maPhieuXuat)
        {
            using (var context = new AppDbContext())
            {
                return context.PhieuXuats
                    .Include(x => x.ChiTietPhieuXuats)
                        .ThenInclude(x => x.NguyenVatLieu)
                    .Include(x => x.ChiTietPhieuXuats)
                        .ThenInclude(x => x.Topping)
                    .FirstOrDefault(x =>
                        x.MaPhieuXuat == maPhieuXuat);
            }
        }

        public List<PhieuXuat> Search(string keyword)
        {
            using (var context = new AppDbContext())
            {
                return context.PhieuXuats
                    .Where(x =>
                        x.MaPhieuXuat.Contains(keyword) ||
                        x.LyDoXuat.Contains(keyword))
                    .OrderByDescending(x => x.NgayXuat)
                    .ToList();
            }
        }

        public bool Add(
            PhieuXuat phieuXuat,
            List<ChiTietPhieuXuat> chiTiets)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // 1. LƯU PHIẾU XUẤT
                    context.PhieuXuats.Add(phieuXuat);
                    context.SaveChanges();

                    // 2. LƯU CHI TIẾT VÀ TRỪ TỒN KHO
                    foreach (var chiTiet in chiTiets)
                    {
                        chiTiet.MaPhieuXuat =
                            phieuXuat.MaPhieuXuat;

                        context.ChiTietPhieuXuats.Add(chiTiet);

                        if (!string.IsNullOrWhiteSpace(
                            chiTiet.MaNVL))
                        {
                            var nvl = context.NguyenVatLieus
                                .FirstOrDefault(x =>
                                    x.MaNVL == chiTiet.MaNVL);

                            if (nvl == null)
                                throw new Exception(
                                    "Không tìm thấy nguyên vật liệu.");

                            if (nvl.SoLuongTon < chiTiet.SoLuong)
                                throw new Exception(
                                    $"Nguyên vật liệu {nvl.TenNVL} không đủ tồn kho.");

                            nvl.SoLuongTon -= chiTiet.SoLuong;

                            CapNhatTrangThaiNVL(nvl);
                        }
                        else if (!string.IsNullOrWhiteSpace(
                            chiTiet.MaTopping))
                        {
                            var topping = context.Toppings
                                .FirstOrDefault(x =>
                                    x.MaTopping == chiTiet.MaTopping);

                            if (topping == null)
                                throw new Exception(
                                    "Không tìm thấy topping.");

                            if (chiTiet.SoLuong % 1 != 0)
                                throw new Exception(
                                    "Số lượng topping phải là số nguyên.");

                            int soLuongXuat =
                                (int)chiTiet.SoLuong;

                            if (topping.SoLuongTon < soLuongXuat)
                                throw new Exception(
                                    $"Topping {topping.TenTopping} không đủ tồn kho.");

                            topping.SoLuongTon -= soLuongXuat;

                            CapNhatTrangThaiTopping(topping);
                        }
                        else
                        {
                            throw new Exception(
                                "Chi tiết phiếu xuất không có mặt hàng.");
                        }
                    }

                    context.SaveChanges();

                    // 3. XÁC NHẬN GIAO DỊCH
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
    }
}