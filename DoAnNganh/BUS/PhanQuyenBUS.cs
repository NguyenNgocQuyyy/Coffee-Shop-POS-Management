using MODEL;

namespace Đồ_án_ngành.BUS
{
    internal class PhanQuyenBUS
    {
        public bool LaManager(NhanVien nhanVien)
        {
            return nhanVien != null &&
                   nhanVien.ChucVu == "Manager";
        }

        public bool LaCashier(NhanVien nhanVien)
        {
            return nhanVien != null &&
                   (nhanVien.ChucVu == "Cashier 1" ||
                    nhanVien.ChucVu == "Cashier 2");
        }

        public bool DuocQuanLyNhanVien(NhanVien nhanVien)
        {
            return LaManager(nhanVien);
        }

        public bool DuocQuanLyMenu(NhanVien nhanVien)
        {
            return LaManager(nhanVien);
        }

        public bool DuocQuanLyTopping(NhanVien nhanVien)
        {
            return LaManager(nhanVien);
        }

        public bool DuocQuanLyKho(NhanVien nhanVien)
        {
            return LaManager(nhanVien);
        }

        public bool DuocQuanLyNhaCungCap(NhanVien nhanVien)
        {
            return LaManager(nhanVien);
        }

        public bool DuocNhapXuatKho(NhanVien nhanVien)
        {
            return LaManager(nhanVien);
        }

        public bool DuocQuanLyKhuyenMai(NhanVien nhanVien)
        {
            return LaManager(nhanVien);
        }

        public bool DuocXemBaoCao(NhanVien nhanVien)
        {
            return LaManager(nhanVien);
        }

        public bool DuocXemDashboard(NhanVien nhanVien)
        {
            return LaManager(nhanVien);
        }

        public bool DuocBanHang(NhanVien nhanVien)
        {
            return LaManager(nhanVien) ||
                   LaCashier(nhanVien);
        }

        public bool DuocThanhToan(NhanVien nhanVien)
        {
            return LaManager(nhanVien) ||
                   LaCashier(nhanVien);
        }

        public bool DuocQuanLyBan(NhanVien nhanVien)
        {
            return LaManager(nhanVien) ||
                   LaCashier(nhanVien);
        }

        public bool DuocQuanLyKhachHang(NhanVien nhanVien)
        {
            return LaManager(nhanVien) ||
                   LaCashier(nhanVien);
        }
    }
}