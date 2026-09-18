using Đồ_án_ngành.DAL;
using MODEL;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Đồ_án_ngành.BUS
{
    internal class BaoCaoDoanhThuBUS
    {
        private readonly BaoCaoDoanhThuDAL _baoCaoDAL
            = new BaoCaoDoanhThuDAL();

        public BaoCaoDoanhThuDTO GetBaoCao(
            DateTime tuNgay,
            DateTime denNgay)
        {
            // 1. KIỂM TRA THỜI GIAN
            if (tuNgay.Date > denNgay.Date)
            {
                throw new ArgumentException(
                    "Từ ngày không được lớn hơn đến ngày.");
            }

            // 2. LẤY HÓA ĐƠN ĐÃ THANH TOÁN
            var hoaDons =
                _baoCaoDAL.GetHoaDonTheoKhoangThoiGian(
                    tuNgay,
                    denNgay);

            var baoCao = new BaoCaoDoanhThuDTO();

            // 3. TÍNH TỔNG DOANH THU
            baoCao.TongDoanhThu =
                hoaDons.Sum(x => x.ThanhTien);

            // 4. TÍNH TỔNG GIẢM GIÁ
            baoCao.TongGiamGia =
                hoaDons.Sum(x => x.GiamGia);

            // 5. ĐẾM HÓA ĐƠN
            baoCao.SoHoaDon =
                hoaDons.Count;

            // 6. TÍNH TỔNG SỐ MÓN BÁN
            baoCao.TongSoMonBan =
                hoaDons
                    .SelectMany(x => x.ChiTietHoaDons)
                    .Sum(x => x.SoLuong);

            // 7. THỐNG KÊ MÓN BÁN CHẠY
            baoCao.DanhSachMonBanChay = hoaDons
                .SelectMany(x => x.ChiTietHoaDons)
                .Where(x => x.Mon != null)
                .GroupBy(x => new
                {
                    x.MaMon,
                    x.Mon.TenMon
                })
                .Select(x => new MonBanChayDTO
                {
                    MaMon = x.Key.MaMon,
                    TenMon = x.Key.TenMon,
                    SoLuongBan = x.Sum(y => y.SoLuong),
                    DoanhThu = x.Sum(y => y.ThanhTien)
                })
                .OrderByDescending(x => x.SoLuongBan)
                .ThenByDescending(x => x.DoanhThu)
                .ToList();
            return baoCao;
        }

        public List<DoanhThuTheoNgayDTO> GetDoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            // 1. KIỂM TRA THỜI GIAN
            if (tuNgay.Date > denNgay.Date)
            {
                throw new ArgumentException(
                    "Từ ngày không được lớn hơn đến ngày.");
            }

            // 2. LẤY HÓA ĐƠN
            var hoaDons =
                _baoCaoDAL.GetHoaDonTheoKhoangThoiGian(
                    tuNgay,
                    denNgay);

            // 3. NHÓM DOANH THU THEO NGÀY
            var duLieu =
                hoaDons
                    .GroupBy(x => x.NgayLap.Date)
                    .Select(x => new DoanhThuTheoNgayDTO
                    {
                        Ngay = x.Key,

                        DoanhThu =
                            x.Sum(y => y.ThanhTien),

                        SoHoaDon =
                            x.Count()
                    })
                    .OrderBy(x => x.Ngay)
                    .ToList();

            // 4. BỔ SUNG NGÀY KHÔNG CÓ DOANH THU
            var ketQua =
                new List<DoanhThuTheoNgayDTO>();

            for (DateTime ngay = tuNgay.Date;
                 ngay <= denNgay.Date;
                 ngay = ngay.AddDays(1))
            {
                var duLieuNgay =
                    duLieu.FirstOrDefault(x =>
                        x.Ngay == ngay);

                if (duLieuNgay != null)
                {
                    ketQua.Add(duLieuNgay);
                }
                else
                {
                    ketQua.Add(
                        new DoanhThuTheoNgayDTO
                        {
                            Ngay = ngay,
                            DoanhThu = 0,
                            SoHoaDon = 0
                        });
                }
            }

            return ketQua;
        }

        public List<DoanhThuTheoThangDTO> GetDoanhThuTheoThang(int nam)
        {
            // 1. KIỂM TRA NĂM
            if (nam <= 0)
                throw new ArgumentException("Năm không hợp lệ.");

            DateTime tuNgay = new DateTime(nam, 1, 1);
            DateTime denNgay = new DateTime(nam, 12, 31);

            // 2. LẤY HÓA ĐƠN TRONG NĂM
            var hoaDons =
                _baoCaoDAL.GetHoaDonTheoKhoangThoiGian(
                    tuNgay,
                    denNgay);

            // 3. NHÓM DOANH THU THEO THÁNG
            var duLieu =
                hoaDons
                    .GroupBy(x => x.NgayLap.Month)
                    .Select(x => new DoanhThuTheoThangDTO
                    {
                        Thang = x.Key,
                        Nam = nam,

                        DoanhThu =
                            x.Sum(y => y.ThanhTien),

                        SoHoaDon =
                            x.Count()
                    })
                    .ToList();

            // 4. BỔ SUNG THÁNG KHÔNG CÓ DOANH THU
            var ketQua =
                new List<DoanhThuTheoThangDTO>();

            for (int thang = 1; thang <= 12; thang++)
            {
                var duLieuThang =
                    duLieu.FirstOrDefault(x =>
                        x.Thang == thang);

                if (duLieuThang != null)
                {
                    ketQua.Add(duLieuThang);
                }
                else
                {
                    ketQua.Add(
                        new DoanhThuTheoThangDTO
                        {
                            Thang = thang,
                            Nam = nam,
                            DoanhThu = 0,
                            SoHoaDon = 0
                        });
                }
            }

            return ketQua;
        }

        public List<DoanhThuTheoNamDTO> GetDoanhThuTheoNam(int tuNam, int denNam)
        {
            // 1. KIỂM TRA KHOẢNG NĂM
            if (tuNam <= 0 || denNam <= 0)
                throw new ArgumentException("Năm không hợp lệ.");

            if (tuNam > denNam)
                throw new ArgumentException(
                    "Từ năm không được lớn hơn đến năm.");

            DateTime tuNgay = new DateTime(tuNam, 1, 1);
            DateTime denNgay = new DateTime(denNam, 12, 31);

            // 2. LẤY HÓA ĐƠN TRONG KHOẢNG NĂM
            var hoaDons =
                _baoCaoDAL.GetHoaDonTheoKhoangThoiGian(
                    tuNgay,
                    denNgay);

            // 3. NHÓM DOANH THU THEO NĂM
            var duLieu =
                hoaDons
                    .GroupBy(x => x.NgayLap.Year)
                    .Select(x => new DoanhThuTheoNamDTO
                    {
                        Nam = x.Key,

                        DoanhThu =
                            x.Sum(y => y.ThanhTien),

                        SoHoaDon =
                            x.Count()
                    })
                    .ToList();

            // 4. BỔ SUNG NĂM KHÔNG CÓ DOANH THU
            var ketQua =
                new List<DoanhThuTheoNamDTO>();

            for (int nam = tuNam; nam <= denNam; nam++)
            {
                var duLieuNam =
                    duLieu.FirstOrDefault(x =>
                        x.Nam == nam);

                if (duLieuNam != null)
                {
                    ketQua.Add(duLieuNam);
                }
                else
                {
                    ketQua.Add(
                        new DoanhThuTheoNamDTO
                        {
                            Nam = nam,
                            DoanhThu = 0,
                            SoHoaDon = 0
                        });
                }
            }

            return ketQua;
        }
    }
}