using MODEL;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.DAL
{
    internal class NhanVienDAL
    {
        public List<NhanVien> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.NhanViens.ToList();
            }
        }

        public NhanVien GetById(string maNV)
        {
            using (var context = new AppDbContext())
            {
                return context.NhanViens
                    .FirstOrDefault(x => x.MaNV == maNV);
            }
        }

        public NhanVien GetByTenDangNhap(string tenDangNhap)
        {
            using (var context = new AppDbContext())
            {
                return context.NhanViens
                    .FirstOrDefault(x =>
                        x.TenDangNhap == tenDangNhap);
            }
        }

        public NhanVien DangNhap(
            string tenDangNhap,
            string matKhau)
        {
            using (var context = new AppDbContext())
            {
                return context.NhanViens
                    .FirstOrDefault(x =>
                        x.TenDangNhap == tenDangNhap &&
                        x.MatKhau == matKhau);
            }
        }

        public List<NhanVien> Search(string keyword)
        {
            using (var context = new AppDbContext())
            {
                return context.NhanViens
                    .Where(x =>
                        x.MaNV.Contains(keyword) ||
                        x.TenDangNhap.Contains(keyword) ||
                        x.ChucVu.Contains(keyword))
                    .ToList();
            }
        }

        public bool Add(NhanVien nhanVien)
        {
            using (var context = new AppDbContext())
            {
                context.NhanViens.Add(nhanVien);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(NhanVien nhanVien)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.NhanViens
                    .FirstOrDefault(x => x.MaNV == nhanVien.MaNV);

                if (existing == null)
                    return false;

                existing.TenDangNhap = nhanVien.TenDangNhap;
                existing.MatKhau = nhanVien.MatKhau;
                existing.ChucVu = nhanVien.ChucVu;

                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(string maNV)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.NhanViens
                    .FirstOrDefault(x => x.MaNV == maNV);

                if (existing == null)
                    return false;

                context.NhanViens.Remove(existing);
                return context.SaveChanges() > 0;
            }
        }
    }
}