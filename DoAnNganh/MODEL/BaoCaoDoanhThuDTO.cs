using System;
using System.Collections.Generic;

namespace MODEL
{
    public class BaoCaoDoanhThuDTO
    {
        public decimal TongDoanhThu { get; set; }

        public decimal TongGiamGia { get; set; }

        public int SoHoaDon { get; set; }

        public int TongSoMonBan { get; set; }

        public List<MonBanChayDTO> DanhSachMonBanChay { get; set; }
            = new List<MonBanChayDTO>();
    }

    public class MonBanChayDTO
    {
        public string MaMon { get; set; }

        public string TenMon { get; set; }

        public int SoLuongBan { get; set; }

        public decimal DoanhThu { get; set; }
    }

    public class DoanhThuTheoNgayDTO
    {
        public DateTime Ngay { get; set; }

        public decimal DoanhThu { get; set; }

        public int SoHoaDon { get; set; }
    }

    public class DoanhThuTheoThangDTO
    {
        public int Thang { get; set; }

        public int Nam { get; set; }

        public decimal DoanhThu { get; set; }

        public int SoHoaDon { get; set; }
    }

    public class DoanhThuTheoNamDTO
    {
        public int Nam { get; set; }

        public decimal DoanhThu { get; set; }

        public int SoHoaDon { get; set; }
    }
}