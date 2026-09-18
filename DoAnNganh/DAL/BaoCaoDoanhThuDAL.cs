using Microsoft.EntityFrameworkCore;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.DAL
{
    internal class BaoCaoDoanhThuDAL
    {
        public List<HoaDon> GetHoaDonTheoKhoangThoiGian(
            DateTime tuNgay,
            DateTime denNgay)
        {
            using (var context = new AppDbContext())
            {
                DateTime batDau = tuNgay.Date;
                DateTime ketThuc = denNgay.Date.AddDays(1);

                return context.HoaDons
                    .Include(x => x.ChiTietHoaDons)
                        .ThenInclude(x => x.Mon)
                    .Include(x => x.ChiTietHoaDons)
                        .ThenInclude(x => x.Topping)
                    .Where(x =>
                        x.TrangThai == "Đã thanh toán" &&
                        x.NgayLap >= batDau &&
                        x.NgayLap < ketThuc)
                    .OrderByDescending(x => x.NgayLap)
                    .ToList();
            }
        }
    }
}