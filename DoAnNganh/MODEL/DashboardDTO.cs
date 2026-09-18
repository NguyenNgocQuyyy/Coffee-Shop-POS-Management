using System.Collections.Generic;

namespace MODEL
{
    public class DashboardDTO
    {
        public decimal DoanhThuHomNay { get; set; }

        public int SoHoaDonHomNay { get; set; }

        public int TongKhachHang { get; set; }

        public int SoBanChuaThanhToan { get; set; }

        public int SoMatHangSapHet { get; set; }

        public List<HoaDon> BanChuaThanhToan { get; set; }
            = new List<HoaDon>();

        public List<NguyenVatLieu> NguyenVatLieuSapHet { get; set; }
            = new List<NguyenVatLieu>();

        public List<Topping> ToppingSapHet { get; set; }
            = new List<Topping>();

        public List<Mon> MonNgungBan { get; set; }
            = new List<Mon>();

        public List<Topping> ToppingNgungBan { get; set; }
            = new List<Topping>();

        public List<Ban> BanDangBaoTri { get; set; }
            = new List<Ban>();
    }
}