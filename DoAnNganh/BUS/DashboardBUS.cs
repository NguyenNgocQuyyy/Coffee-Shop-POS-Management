using Đồ_án_ngành.DAL;
using MODEL;
using System;

namespace Đồ_án_ngành.BUS
{
    internal class DashboardBUS
    {
        private readonly DashboardDAL _dashboardDAL
            = new DashboardDAL();

        private readonly BaoCaoDoanhThuBUS _baoCaoBUS
            = new BaoCaoDoanhThuBUS();

        public DashboardDTO GetDashboard()
        {
            DateTime homNay = DateTime.Today;

            // 1. BÁO CÁO HÔM NAY
            var baoCaoHomNay =
                _baoCaoBUS.GetBaoCao(
                    homNay,
                    homNay);

            // 2. TỔNG HỢP DASHBOARD
            return new DashboardDTO
            {
                DoanhThuHomNay =
                    baoCaoHomNay.TongDoanhThu,

                SoHoaDonHomNay =
                    baoCaoHomNay.SoHoaDon,

                TongKhachHang =
                    _dashboardDAL.GetTongKhachHang(),

                SoBanChuaThanhToan =
                    _dashboardDAL.GetSoBanChuaThanhToan(),

                SoMatHangSapHet =
                _dashboardDAL.GetSoMatHangSapHet(),

                BanChuaThanhToan =
                    _dashboardDAL.GetBanChuaThanhToan(),

                NguyenVatLieuSapHet =
                    _dashboardDAL.GetNguyenVatLieuSapHet(),

                ToppingSapHet =
                    _dashboardDAL.GetToppingSapHet(),

                MonNgungBan =
                    _dashboardDAL.GetMonNgungBan(),

                ToppingNgungBan =
                    _dashboardDAL.GetToppingNgungBan(),

                BanDangBaoTri =
                    _dashboardDAL.GetBanDangBaoTri()
            };
        }
    }
}