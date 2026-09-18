using MODEL;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.DAL
{
    internal class NguyenVatLieuDAL
    {
        public List<NguyenVatLieu> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.NguyenVatLieus.ToList();
            }
        }

        public NguyenVatLieu GetById(string maNVL)
        {
            using (var context = new AppDbContext())
            {
                return context.NguyenVatLieus
                    .FirstOrDefault(x => x.MaNVL == maNVL);
            }
        }

        public List<NguyenVatLieu> Search(string keyword)
        {
            using (var context = new AppDbContext())
            {
                return context.NguyenVatLieus
                    .Where(x =>
                        x.MaNVL.Contains(keyword) ||
                        x.TenNVL.Contains(keyword))
                    .ToList();
            }
        }

        public bool Add(NguyenVatLieu nguyenVatLieu)
        {
            using (var context = new AppDbContext())
            {
                context.NguyenVatLieus.Add(nguyenVatLieu);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(NguyenVatLieu nguyenVatLieu)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.NguyenVatLieus
                    .FirstOrDefault(x => x.MaNVL == nguyenVatLieu.MaNVL);

                if (existing == null)
                    return false;

                existing.TenNVL = nguyenVatLieu.TenNVL;
                existing.SoLuongTon = nguyenVatLieu.SoLuongTon;
                existing.MucCanhBao = nguyenVatLieu.MucCanhBao;
                existing.DonViTinh = nguyenVatLieu.DonViTinh;
                existing.DonViTinhQuyDoi = nguyenVatLieu.DonViTinhQuyDoi;
                existing.HeSoQuyDoi = nguyenVatLieu.HeSoQuyDoi;
                existing.TrangThai = nguyenVatLieu.TrangThai;
                existing.GhiChu = nguyenVatLieu.GhiChu;

                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(string maNVL)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.NguyenVatLieus
                    .FirstOrDefault(x => x.MaNVL == maNVL);

                if (existing == null)
                    return false;

                context.NguyenVatLieus.Remove(existing);
                return context.SaveChanges() > 0;
            }
        }
    }
}