using MODEL;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.DAL
{
    internal class KhachHangDAL
    {
        public List<KhachHang> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.KhachHangs.ToList();
            }
        }

        public KhachHang GetById(string maKH)
        {
            using (var context = new AppDbContext())
            {
                return context.KhachHangs
                    .FirstOrDefault(x => x.MaKH == maKH);
            }
        }

        public KhachHang GetBySDT(string sdt)
        {
            using (var context = new AppDbContext())
            {
                return context.KhachHangs
                    .FirstOrDefault(x => x.SDT == sdt);
            }
        }

        public List<KhachHang> Search(string keyword)
        {
            using (var context = new AppDbContext())
            {
                return context.KhachHangs
                    .Where(x =>
                        x.MaKH.Contains(keyword) ||
                        x.HoTen.Contains(keyword) ||
                        x.SDT.Contains(keyword))
                    .ToList();
            }
        }

        public bool Add(KhachHang khachHang)
        {
            using (var context = new AppDbContext())
            {
                context.KhachHangs.Add(khachHang);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(KhachHang khachHang)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.KhachHangs
                    .FirstOrDefault(x => x.MaKH == khachHang.MaKH);

                if (existing == null)
                    return false;

                existing.HoTen = khachHang.HoTen;
                existing.SDT = khachHang.SDT;
                existing.NgaySinh = khachHang.NgaySinh;
                existing.DiemTichLuy = khachHang.DiemTichLuy;

                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(string maKH)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.KhachHangs
                    .FirstOrDefault(x => x.MaKH == maKH);

                if (existing == null)
                    return false;

                context.KhachHangs.Remove(existing);
                return context.SaveChanges() > 0;
            }
        }
    }
}