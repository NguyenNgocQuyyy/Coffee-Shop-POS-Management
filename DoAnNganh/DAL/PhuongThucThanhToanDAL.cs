using MODEL;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.DAL
{
    internal class PhuongThucThanhToanDAL
    {
        public List<PhuongThucThanhToan> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.PhuongThucThanhToans.ToList();
            }
        }

        public PhuongThucThanhToan GetById(string maPhuongThuc)
        {
            using (var context = new AppDbContext())
            {
                return context.PhuongThucThanhToans
                    .FirstOrDefault(x =>
                        x.MaPhuongThuc == maPhuongThuc);
            }
        }

        public List<PhuongThucThanhToan> Search(string keyword)
        {
            using (var context = new AppDbContext())
            {
                return context.PhuongThucThanhToans
                    .Where(x =>
                        x.MaPhuongThuc.Contains(keyword) ||
                        x.TenPhuongThuc.Contains(keyword))
                    .ToList();
            }
        }

        public bool Add(PhuongThucThanhToan phuongThuc)
        {
            using (var context = new AppDbContext())
            {
                context.PhuongThucThanhToans.Add(phuongThuc);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(PhuongThucThanhToan phuongThuc)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.PhuongThucThanhToans
                    .FirstOrDefault(x =>
                        x.MaPhuongThuc == phuongThuc.MaPhuongThuc);

                if (existing == null)
                    return false;

                existing.TenPhuongThuc =
                    phuongThuc.TenPhuongThuc;

                existing.LaTienMat =
                    phuongThuc.LaTienMat;

                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(string maPhuongThuc)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.PhuongThucThanhToans
                    .FirstOrDefault(x =>
                        x.MaPhuongThuc == maPhuongThuc);

                if (existing == null)
                    return false;

                context.PhuongThucThanhToans.Remove(existing);
                return context.SaveChanges() > 0;
            }
        }
    }
}