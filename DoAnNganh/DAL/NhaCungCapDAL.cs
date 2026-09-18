using MODEL;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.DAL
{
    internal class NhaCungCapDAL
    {
        public List<NhaCungCap> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.NhaCungCaps.ToList();
            }
        }

        public NhaCungCap GetById(string maNCC)
        {
            using (var context = new AppDbContext())
            {
                return context.NhaCungCaps
                    .FirstOrDefault(x => x.MaNCC == maNCC);
            }
        }

        public NhaCungCap GetBySDT(string sdt)
        {
            using (var context = new AppDbContext())
            {
                return context.NhaCungCaps
                    .FirstOrDefault(x => x.SDT == sdt);
            }
        }

        public List<NhaCungCap> Search(string keyword)
        {
            using (var context = new AppDbContext())
            {
                return context.NhaCungCaps
                    .Where(x =>
                        x.MaNCC.Contains(keyword) ||
                        x.TenNCC.Contains(keyword) ||
                        x.SDT.Contains(keyword) ||
                        (x.Email != null && x.Email.Contains(keyword)))
                    .ToList();
            }
        }

        public bool Add(NhaCungCap nhaCungCap)
        {
            using (var context = new AppDbContext())
            {
                context.NhaCungCaps.Add(nhaCungCap);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(NhaCungCap nhaCungCap)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.NhaCungCaps
                    .FirstOrDefault(x => x.MaNCC == nhaCungCap.MaNCC);

                if (existing == null)
                    return false;

                existing.TenNCC = nhaCungCap.TenNCC;
                existing.SDT = nhaCungCap.SDT;
                existing.Email = nhaCungCap.Email;
                existing.DiaChi = nhaCungCap.DiaChi;

                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(string maNCC)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.NhaCungCaps
                    .FirstOrDefault(x => x.MaNCC == maNCC);

                if (existing == null)
                    return false;

                context.NhaCungCaps.Remove(existing);
                return context.SaveChanges() > 0;
            }
        }
    }
}