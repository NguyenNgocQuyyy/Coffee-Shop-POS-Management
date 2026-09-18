using Microsoft.EntityFrameworkCore;
using MODEL;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.DAL
{
    internal class CongThucDAL
    {
        public List<CongThuc> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.CongThucs
                    .Include(x => x.Mon)
                    .Include(x => x.NguyenVatLieu)
                    .ToList();
            }
        }

        public CongThuc GetById(string maMon, string maNVL)
        {
            using (var context = new AppDbContext())
            {
                return context.CongThucs
                    .Include(x => x.Mon)
                    .Include(x => x.NguyenVatLieu)
                    .FirstOrDefault(x =>
                        x.MaMon == maMon &&
                        x.MaNVL == maNVL);
            }
        }

        public List<CongThuc> GetByMon(string maMon)
        {
            using (var context = new AppDbContext())
            {
                return context.CongThucs
                    .Include(x => x.NguyenVatLieu)
                    .Where(x => x.MaMon == maMon)
                    .ToList();
            }
        }

        public List<CongThuc> GetByNguyenVatLieu(string maNVL)
        {
            using (var context = new AppDbContext())
            {
                return context.CongThucs
                    .Include(x => x.Mon)
                    .Where(x => x.MaNVL == maNVL)
                    .ToList();
            }
        }

        public bool Add(CongThuc congThuc)
        {
            using (var context = new AppDbContext())
            {
                context.CongThucs.Add(congThuc);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(CongThuc congThuc)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.CongThucs
                    .FirstOrDefault(x =>
                        x.MaMon == congThuc.MaMon &&
                        x.MaNVL == congThuc.MaNVL);

                if (existing == null)
                    return false;

                existing.DinhLuong = congThuc.DinhLuong;

                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(string maMon, string maNVL)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.CongThucs
                    .FirstOrDefault(x =>
                        x.MaMon == maMon &&
                        x.MaNVL == maNVL);

                if (existing == null)
                    return false;

                context.CongThucs.Remove(existing);
                return context.SaveChanges() > 0;
            }
        }

        public bool DeleteByMon(string maMon)
        {
            using (var context = new AppDbContext())
            {
                var danhSach = context.CongThucs
                    .Where(x => x.MaMon == maMon)
                    .ToList();

                if (danhSach.Count == 0)
                    return false;

                context.CongThucs.RemoveRange(danhSach);

                return context.SaveChanges() > 0;
            }
        }
    }
}