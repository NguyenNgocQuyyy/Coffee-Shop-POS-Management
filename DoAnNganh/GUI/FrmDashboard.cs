using Đồ_án_ngành.BUS;
using MODEL;
using System;
using System.Windows.Forms;

namespace Đồ_án_ngành.GUI
{
    public partial class FrmDashboard : Form
    {
        private readonly DashboardBUS _dashboardBUS = new DashboardBUS();

        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            DashboardDTO dashboard =
                _dashboardBUS.GetDashboard();

            lblDoanhThuHomNay.Text =
                dashboard.DoanhThuHomNay.ToString("N0") + " đ";

            lblHoaDonHomNay.Text =
                dashboard.SoHoaDonHomNay.ToString();

            lblSoKhachHang.Text =
                dashboard.TongKhachHang.ToString();

            lblSoBanChuaThanhToan.Text =
                dashboard.SoBanChuaThanhToan.ToString();

            lblSoNVLSapHet.Text =
                dashboard.SoMatHangSapHet.ToString();

            LoadCanhBaoKho(dashboard);

            LoadToppingSapHet(dashboard);

            LoadMatHangNgungBan(dashboard);

            LoadBanChuaThanhToan(dashboard);

            LoadBanBaoTri(dashboard);
        }

        private void LoadCanhBaoKho(DashboardDTO dashboard)
        {
            dgvCanhBaoKho.Rows.Clear();

            foreach (var nvl in dashboard.NguyenVatLieuSapHet)
            {
                dgvCanhBaoKho.Rows.Add(
                    nvl.MaNVL,
                    nvl.TenNVL,
                    nvl.SoLuongTon.ToString("0.##"),
                    nvl.MucCanhBao.ToString("0.##")
                );
            }
        }

        private void LoadToppingSapHet(DashboardDTO dashboard)
        {
            dgvToppingSapHet.Rows.Clear();

            foreach (var topping in dashboard.ToppingSapHet)
            {
                dgvToppingSapHet.Rows.Add(
                    topping.MaTopping,
                    topping.TenTopping,
                    topping.SoLuongTon.ToString("0.##"),
                    topping.MucCanhBao.ToString("0.##")
                );
            }
        }

        private void LoadMatHangNgungBan(DashboardDTO dashboard)
        {
            dgvMonNgungBan.Rows.Clear();

            foreach (var mon in dashboard.MonNgungBan)
            {
                dgvMonNgungBan.Rows.Add(
                    mon.MaMon,
                    mon.TenMon,
                    "Món"
                );
            }

            foreach (var topping in dashboard.ToppingNgungBan)
            {
                dgvMonNgungBan.Rows.Add(
                    topping.MaTopping,
                    topping.TenTopping,
                    "Topping"
                );
            }
        }

        private void LoadBanChuaThanhToan(DashboardDTO dashboard)
        {
            dgvBanChuaThanhToan.Rows.Clear();

            foreach (var hoaDon in dashboard.BanChuaThanhToan)
            {
                dgvBanChuaThanhToan.Rows.Add(
                    hoaDon.Ban?.SoBan,
                    hoaDon.MaHoaDon,
                    hoaDon.ThanhTien.ToString("N0")
                );
            }
        }

        private void LoadBanBaoTri(DashboardDTO dashboard)
        {
            dgvBanBaoTri.Rows.Clear();

            foreach (var ban in dashboard.BanDangBaoTri)
            {
                dgvBanBaoTri.Rows.Add(
                    ban.SoBan,
                    ban.GhiChu
                );
            }
        }
    }
}
