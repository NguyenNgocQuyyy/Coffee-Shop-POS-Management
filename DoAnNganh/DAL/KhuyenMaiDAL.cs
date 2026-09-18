using Microsoft.EntityFrameworkCore;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.DAL
{
    internal class KhuyenMaiDAL
    {
        public List<KhuyenMai> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.KhuyenMais
                    .Include(x => x.ChiTietKhuyenMais)
                        .ThenInclude(x => x.Mon)
                    .OrderBy(x => x.MaKhuyenMai)
                    .ToList();
            }
        }

        public KhuyenMai GetById(string maKhuyenMai)
        {
            using (var context = new AppDbContext())
            {
                return context.KhuyenMais
                    .Include(x => x.ChiTietKhuyenMais)
                        .ThenInclude(x => x.Mon)
                    .FirstOrDefault(x =>
                        x.MaKhuyenMai == maKhuyenMai);
            }
        }

        public List<KhuyenMai> Search(string keyword)
        {
            using (var context = new AppDbContext())
            {
                return context.KhuyenMais
                    .Where(x =>
                        x.MaKhuyenMai.Contains(keyword) ||
                        x.TenKhuyenMai.Contains(keyword) ||
                        x.LoaiKhuyenMai.Contains(keyword) ||
                        x.TrangThai.Contains(keyword))
                    .OrderBy(x => x.MaKhuyenMai)
                    .ToList();
            }
        }

        public List<KhuyenMai> Filter(string keyword, string trangThai, DateTime tuNgay, DateTime denNgay)
        {
            using (var context = new AppDbContext())
            {
                var query = context.KhuyenMais
                    .Include(x => x.ChiTietKhuyenMais)
                        .ThenInclude(x => x.Mon)
                    .AsQueryable();

                // 1. LỌC THEO TỪ KHÓA
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    keyword = keyword.Trim();

                    query = query.Where(x =>
                        x.MaKhuyenMai.Contains(keyword) ||
                        x.TenKhuyenMai.Contains(keyword) ||
                        x.LoaiKhuyenMai.Contains(keyword));
                }

                // 2. LỌC THEO TRẠNG THÁI
                if (!string.IsNullOrWhiteSpace(trangThai) &&
                    trangThai != "Tất cả")
                {
                    query = query.Where(x =>
                        x.TrangThai == trangThai);
                }

                // 3. LỌC THEO KHOẢNG NGÀY
                query = query.Where(x =>
                    x.NgayBatDau.Date <= denNgay.Date &&
                    x.NgayKetThuc.Date >= tuNgay.Date);

                return query
                    .OrderBy(x => x.MaKhuyenMai)
                    .ToList();
            }
        }

        public bool Add(
            KhuyenMai khuyenMai,
            List<string> danhSachMaMon)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // 1. LƯU KHUYẾN MÃI
                    context.KhuyenMais.Add(khuyenMai);
                    context.SaveChanges();

                    // 2. LƯU CÁC MÓN ÁP DỤNG
                    if (danhSachMaMon != null)
                    {
                        foreach (var maMon in danhSachMaMon)
                        {
                            context.ChiTietKhuyenMais.Add(
                                new ChiTietKhuyenMai
                                {
                                    MaKhuyenMai = khuyenMai.MaKhuyenMai,
                                    MaMon = maMon
                                });
                        }
                    }

                    context.SaveChanges();

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool Update(
            KhuyenMai khuyenMai,
            List<string> danhSachMaMon)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var existing = context.KhuyenMais
                        .FirstOrDefault(x =>
                            x.MaKhuyenMai == khuyenMai.MaKhuyenMai);

                    if (existing == null)
                        return false;

                    // 3. CẬP NHẬT THÔNG TIN KHUYẾN MÃI
                    existing.TenKhuyenMai = khuyenMai.TenKhuyenMai;
                    existing.LoaiKhuyenMai = khuyenMai.LoaiKhuyenMai;
                    existing.GiaTriKhuyenMai = khuyenMai.GiaTriKhuyenMai;
                    existing.NgayBatDau = khuyenMai.NgayBatDau;
                    existing.NgayKetThuc = khuyenMai.NgayKetThuc;
                    existing.TrangThai = khuyenMai.TrangThai;
                    existing.GhiChu = khuyenMai.GhiChu;

                    // 4. XÓA DANH SÁCH MÓN ÁP DỤNG CŨ
                    var chiTietCu = context.ChiTietKhuyenMais
                        .Where(x =>
                            x.MaKhuyenMai == khuyenMai.MaKhuyenMai)
                        .ToList();

                    context.ChiTietKhuyenMais.RemoveRange(chiTietCu);

                    // 5. THÊM DANH SÁCH MÓN ÁP DỤNG MỚI
                    if (danhSachMaMon != null)
                    {
                        foreach (var maMon in danhSachMaMon)
                        {
                            context.ChiTietKhuyenMais.Add(
                                new ChiTietKhuyenMai
                                {
                                    MaKhuyenMai = khuyenMai.MaKhuyenMai,
                                    MaMon = maMon
                                });
                        }
                    }

                    context.SaveChanges();

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool Delete(string maKhuyenMai)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var existing = context.KhuyenMais
                        .FirstOrDefault(x =>
                            x.MaKhuyenMai == maKhuyenMai);

                    if (existing == null)
                        return false;

                    // 6. XÓA CHI TIẾT ÁP DỤNG TRƯỚC
                    var chiTiets = context.ChiTietKhuyenMais
                        .Where(x =>
                            x.MaKhuyenMai == maKhuyenMai)
                        .ToList();

                    context.ChiTietKhuyenMais.RemoveRange(chiTiets);

                    context.KhuyenMais.Remove(existing);

                    context.SaveChanges();

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}