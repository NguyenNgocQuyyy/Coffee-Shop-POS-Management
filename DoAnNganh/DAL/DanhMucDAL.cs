using MODEL;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.DAL
{
    internal class DanhMucDAL
    {
        public List<DanhMuc> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.DanhMucs.ToList();
            }
        }

        public DanhMuc GetById(string maDanhMuc)
        {
            using (var context = new AppDbContext())
            {
                return context.DanhMucs
                    .FirstOrDefault(x => x.MaDanhMuc == maDanhMuc);
            }
        }

        public List<DanhMuc> Search(string keyword)
        {
            using (var context = new AppDbContext())
            {
                return context.DanhMucs
                    .Where(x => x.MaDanhMuc.Contains(keyword)
                             || x.TenDanhMuc.Contains(keyword))
                    .ToList();
            }
        }

        public bool Add(DanhMuc danhMuc)
        {
            using (var context = new AppDbContext())
            {
                context.DanhMucs.Add(danhMuc);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(DanhMuc danhMuc)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.DanhMucs
                    .FirstOrDefault(x => x.MaDanhMuc == danhMuc.MaDanhMuc);

                if (existing == null)
                    return false;

                existing.TenDanhMuc = danhMuc.TenDanhMuc;

                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(string maDanhMuc)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.DanhMucs
                    .FirstOrDefault(x => x.MaDanhMuc == maDanhMuc);

                if (existing == null)
                    return false;

                context.DanhMucs.Remove(existing);

                return context.SaveChanges() > 0;
            }
        }
    }
}