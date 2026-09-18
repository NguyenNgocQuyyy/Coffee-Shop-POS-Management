using Microsoft.EntityFrameworkCore;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.DAL
{
    internal class DashboardDAL
    {
        public decimal GetDoanhThuHomNay()
        {
            using (var context = new AppDbContext())
            {
                DateTime homNay = DateTime.Today;
                DateTime ngayMai = homNay.AddDays(1);

                return context.HoaDons
                    .Where(x =>
                        x.NgayLap >= homNay &&
                        x.NgayLap < ngayMai &&
                        x.TrangThai == "Đã thanh toán")
                    .Sum(x => (decimal?)x.ThanhTien) ?? 0;
            }
        }

        public int GetSoHoaDonHomNay()
        {
            using (var context = new AppDbContext())
            {
                DateTime homNay = DateTime.Today;
                DateTime ngayMai = homNay.AddDays(1);

                return context.HoaDons.Count(x =>
                    x.NgayLap >= homNay &&
                    x.NgayLap < ngayMai &&
                    x.TrangThai == "Đã thanh toán");
            }
        }

        public int GetTongKhachHang()
        {
            using (var context = new AppDbContext())
            {
                return context.KhachHangs.Count();
            }
        }

        public List<HoaDon> GetBanChuaThanhToan()
        {
            using (var context = new AppDbContext())
            {
                return context.HoaDons
                    .Where(x =>
                        x.MaBan != null &&
                        x.TrangThai == "Chưa thanh toán")
                    .Include(x => x.Ban)
                    .OrderBy(x => x.Ban.SoBan)
                    .ToList();
            }
        }

        public int GetSoBanChuaThanhToan()
        {
            using (var context = new AppDbContext())
            {
                return context.HoaDons
                    .Where(x =>
                        x.MaBan != null &&
                        x.TrangThai == "Chưa thanh toán")
                    .Select(x => x.MaBan)
                    .Distinct()
                    .Count();
            }
        }

        public List<NguyenVatLieu> GetNguyenVatLieuSapHet()
        {
            using (var context = new AppDbContext())
            {
                return context.NguyenVatLieus
                    .Where(x => x.SoLuongTon <= x.MucCanhBao)
                    .OrderBy(x => x.SoLuongTon)
                    .ToList();
            }
        }

        public int GetSoMatHangSapHet()
        {
            using (var context = new AppDbContext())
            {
                int soNVLSapHet = context.NguyenVatLieus
                    .Count(x => x.SoLuongTon <= x.MucCanhBao);

                int soToppingSapHet = context.Toppings
                    .Count(x => x.SoLuongTon <= x.MucCanhBao);

                return soNVLSapHet + soToppingSapHet;
            }
        }

        public List<Topping> GetToppingSapHet()
        {
            using (var context = new AppDbContext())
            {
                return context.Toppings
                    .Where(x => x.SoLuongTon <= x.MucCanhBao)
                    .OrderBy(x => x.SoLuongTon)
                    .ToList();
            }
        }

        public int GetSoNguyenVatLieuSapHet()
        {
            using (var context = new AppDbContext())
            {
                return context.NguyenVatLieus
                    .Count(x => x.SoLuongTon <= x.MucCanhBao);
            }
        }

        public List<Ban> GetBanDangBaoTri()
        {
            using (var context = new AppDbContext())
            {
                return context.Bans
                    .Where(x => x.TrangThai == "Đang bảo trì")
                    .OrderBy(x => x.SoBan)
                    .ToList();
            }
        }

        public List<Mon> GetMonNgungBan()
        {
            using (var context = new AppDbContext())
            {
                return context.Mons
                    .Where(x => x.TrangThai == "Ngừng bán")
                    .OrderBy(x => x.MaMon)
                    .ToList();
            }
        }

        public List<Topping> GetToppingNgungBan()
        {
            using (var context = new AppDbContext())
            {
                return context.Toppings
                    .Where(x => x.TrangThai == "Ngừng bán")
                    .OrderBy(x => x.MaTopping)
                    .ToList();
            }
        }
    }
}