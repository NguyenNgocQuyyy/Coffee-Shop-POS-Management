using MODEL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.DAL
{
    internal class MonDAL
    {
        public List<Mon> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Mons
                    .Include(x => x.DanhMuc)
                    .ToList();
            }
        }

        public Mon GetById(string maMon)
        {
            using (var context = new AppDbContext())
            {
                return context.Mons
                    .Include(x => x.DanhMuc)
                    .FirstOrDefault(x => x.MaMon == maMon);
            }
        }

        public List<Mon> Search(string keyword)
        {
            using (var context = new AppDbContext())
            {
                return context.Mons
                    .Include(x => x.DanhMuc)
                    .Where(x =>
                        x.MaMon.Contains(keyword) ||
                        x.TenMon.Contains(keyword) ||
                        x.DanhMuc.TenDanhMuc.Contains(keyword))
                    .ToList();
            }
        }

        public List<Mon> GetByDanhMuc(string maDanhMuc)
        {
            using (var context = new AppDbContext())
            {
                return context.Mons
                    .Include(x => x.DanhMuc)
                    .Where(x => x.MaDanhMuc == maDanhMuc)
                    .ToList();
            }
        }

        public bool Add(Mon mon)
        {
            using (var context = new AppDbContext())
            {
                context.Mons.Add(mon);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(Mon mon)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Mons
                    .FirstOrDefault(x => x.MaMon == mon.MaMon);

                if (existing == null)
                    return false;

                existing.TenMon = mon.TenMon;
                existing.GiaBan = mon.GiaBan;
                existing.TrangThai = mon.TrangThai;
                existing.MaDanhMuc = mon.MaDanhMuc;

                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(string maMon)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Mons
                    .FirstOrDefault(x => x.MaMon == maMon);

                if (existing == null)
                    return false;

                context.Mons.Remove(existing);

                return context.SaveChanges() > 0;
            }
        }
    }
}