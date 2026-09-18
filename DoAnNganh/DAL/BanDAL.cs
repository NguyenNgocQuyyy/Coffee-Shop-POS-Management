using MODEL;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.DAL
{
    internal class BanDAL
    {
        public List<Ban> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Bans.ToList();
            }
        }

        public Ban GetById(string maBan)
        {
            using (var context = new AppDbContext())
            {
                return context.Bans
                    .FirstOrDefault(x => x.MaBan == maBan);
            }
        }

        public List<Ban> Search(string keyword)
        {
            using (var context = new AppDbContext())
            {
                return context.Bans
                    .Where(x =>
                        x.MaBan.Contains(keyword) ||
                        x.SoBan.Contains(keyword) ||
                        x.TrangThai.Contains(keyword))
                    .ToList();
            }
        }

        public bool Add(Ban ban)
        {
            using (var context = new AppDbContext())
            {
                context.Bans.Add(ban);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(Ban ban)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Bans
                    .FirstOrDefault(x => x.MaBan == ban.MaBan);

                if (existing == null)
                    return false;

                existing.SoBan = ban.SoBan;
                existing.TrangThai = ban.TrangThai;
                existing.GhiChu = ban.GhiChu;

                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(string maBan)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Bans
                    .FirstOrDefault(x => x.MaBan == maBan);

                if (existing == null)
                    return false;

                context.Bans.Remove(existing);
                return context.SaveChanges() > 0;
            }
        }
    }
}