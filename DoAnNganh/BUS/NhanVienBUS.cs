using Đồ_án_ngành.DAL;
using MODEL;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.BUS
{
    internal class NhanVienBUS
    {
        private readonly NhanVienDAL _nhanVienDAL
            = new NhanVienDAL();

        public List<NhanVien> GetAll()
        {
            return _nhanVienDAL.GetAll();
        }

        public NhanVien GetById(string maNV)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                return null;

            return _nhanVienDAL.GetById(maNV.Trim());
        }

        public List<NhanVien> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            return _nhanVienDAL.Search(keyword.Trim());
        }

        public NhanVien DangNhap(
            string tenDangNhap,
            string matKhau,
            out string thongBao)
        {
            // 1. KIỂM TRA THÔNG TIN ĐĂNG NHẬP
            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                thongBao = "Tên đăng nhập không được để trống.";
                return null;
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                thongBao = "Mật khẩu không được để trống.";
                return null;
            }

            tenDangNhap = tenDangNhap.Trim();

            var nhanVien = _nhanVienDAL.DangNhap(
                tenDangNhap,
                matKhau);

            if (nhanVien == null)
            {
                thongBao = "Mật khẩu không chính xác.";
                return null;
            }

            thongBao = "Đăng nhập thành công.";
            return nhanVien;
        }

        public string Add(NhanVien nhanVien)
        {
            // 2. KIỂM TRA DỮ LIỆU NHÂN VIÊN
            if (nhanVien == null)
                return "Dữ liệu nhân viên không hợp lệ.";

            if (string.IsNullOrWhiteSpace(nhanVien.MaNV))
                return "Mã nhân viên không được để trống.";

            if (string.IsNullOrWhiteSpace(nhanVien.TenDangNhap))
                return "Tên đăng nhập không được để trống.";

            if (string.IsNullOrWhiteSpace(nhanVien.MatKhau))
                return "Mật khẩu không được để trống.";

            if (string.IsNullOrWhiteSpace(nhanVien.ChucVu))
                return "Chức vụ không được để trống.";

            nhanVien.MaNV = nhanVien.MaNV.Trim();
            nhanVien.TenDangNhap = nhanVien.TenDangNhap.Trim();
            nhanVien.ChucVu = nhanVien.ChucVu.Trim();

            if (!ChucVuHopLe(nhanVien.ChucVu))
                return "Chức vụ chỉ được là Cashier 1, Cashier 2 hoặc Manager.";

            if (_nhanVienDAL.GetById(nhanVien.MaNV) != null)
                return "Mã nhân viên đã tồn tại.";

            if (_nhanVienDAL.GetByTenDangNhap(
                    nhanVien.TenDangNhap) != null)
            {
                return "Tên đăng nhập đã tồn tại.";
            }

            return _nhanVienDAL.Add(nhanVien)
                ? "Thêm nhân viên thành công."
                : "Thêm nhân viên thất bại.";
        }

        public string Update(NhanVien nhanVien)
        {
            // 3. KIỂM TRA DỮ LIỆU CẬP NHẬT
            if (nhanVien == null)
                return "Dữ liệu nhân viên không hợp lệ.";

            if (string.IsNullOrWhiteSpace(nhanVien.MaNV))
                return "Mã nhân viên không hợp lệ.";

            if (string.IsNullOrWhiteSpace(nhanVien.TenDangNhap))
                return "Tên đăng nhập không được để trống.";

            if (string.IsNullOrWhiteSpace(nhanVien.MatKhau))
                return "Mật khẩu không được để trống.";

            if (string.IsNullOrWhiteSpace(nhanVien.ChucVu))
                return "Chức vụ không được để trống.";

            nhanVien.MaNV = nhanVien.MaNV.Trim();
            nhanVien.TenDangNhap = nhanVien.TenDangNhap.Trim();
            nhanVien.ChucVu = nhanVien.ChucVu.Trim();

            if (!ChucVuHopLe(nhanVien.ChucVu))
                return "Chức vụ chỉ được là Cashier 1, Cashier 2 hoặc Manager.";

            var existing = _nhanVienDAL.GetById(nhanVien.MaNV);

            if (existing == null)
                return "Không tìm thấy nhân viên.";

            var trungTenDangNhap = _nhanVienDAL.GetAll()
                .Any(x =>
                    x.MaNV != nhanVien.MaNV &&
                    x.TenDangNhap.ToLower()
                    == nhanVien.TenDangNhap.ToLower());

            if (trungTenDangNhap)
                return "Tên đăng nhập đã tồn tại.";

            return _nhanVienDAL.Update(nhanVien)
                ? "Cập nhật nhân viên thành công."
                : "Cập nhật nhân viên thất bại.";
        }

        public string DoiMatKhau(string maNV, string matKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(maNV))
                return "Mã nhân viên không hợp lệ.";

            if (string.IsNullOrWhiteSpace(matKhauMoi))
                return "Mật khẩu mới không được để trống.";

            var nhanVien = _nhanVienDAL.GetById(maNV.Trim());

            if (nhanVien == null)
                return "Không tìm thấy tài khoản.";

            // Kiểm tra mật khẩu mới không được trùng mật khẩu hiện tại
            if (nhanVien.MatKhau == matKhauMoi)
                return "Mật khẩu mới không được trùng với mật khẩu hiện tại.";

            nhanVien.MatKhau = matKhauMoi;

            return _nhanVienDAL.Update(nhanVien)
                ? "Đổi mật khẩu thành công."
                : "Đổi mật khẩu thất bại.";
        }

        public string Delete(string maNV)
        {
            // 4. XÓA NHÂN VIÊN
            if (string.IsNullOrWhiteSpace(maNV))
                return "Mã nhân viên không hợp lệ.";

            maNV = maNV.Trim();

            if (_nhanVienDAL.GetById(maNV) == null)
                return "Không tìm thấy nhân viên.";

            try
            {
                return _nhanVienDAL.Delete(maNV)
                    ? "Xóa nhân viên thành công."
                    : "Xóa nhân viên thất bại.";
            }
            catch
            {
                return "Không thể xóa nhân viên vì đã có hóa đơn liên quan.";
            }
        }

        private bool ChucVuHopLe(string chucVu)
        {
            return chucVu == "Cashier 1"
                || chucVu == "Cashier 2"
                || chucVu == "Manager";
        }
    }
}