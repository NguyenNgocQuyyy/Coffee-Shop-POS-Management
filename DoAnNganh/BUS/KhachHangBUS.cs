using Đồ_án_ngành.DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.BUS
{
    internal class KhachHangBUS
    {
        private readonly KhachHangDAL _khachHangDAL = new KhachHangDAL();

        public List<KhachHang> GetAll()
        {
            return _khachHangDAL.GetAll();
        }

        public KhachHang GetById(string maKH)
        {
            return _khachHangDAL.GetById(maKH);
        }

        public KhachHang GetBySDT(string sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt))
                return null;

            return _khachHangDAL.GetBySDT(sdt.Trim());
        }

        public List<KhachHang> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            return _khachHangDAL.Search(keyword.Trim());
        }

        public string Add(KhachHang khachHang)
        {
            if (khachHang == null)
                return "Dữ liệu khách hàng không hợp lệ.";

            if (string.IsNullOrWhiteSpace(khachHang.MaKH))
                return "Mã khách hàng không được để trống.";

            if (string.IsNullOrWhiteSpace(khachHang.HoTen))
                return "Họ tên khách hàng không được để trống.";

            if (string.IsNullOrWhiteSpace(khachHang.SDT))
                return "Số điện thoại không được để trống.";

            if (khachHang.NgaySinh == default(DateTime))
                return "Ngày sinh không hợp lệ.";

            if (khachHang.DiemTichLuy < 0)
                return "Điểm tích lũy không được nhỏ hơn 0.";

            if (_khachHangDAL.GetById(khachHang.MaKH) != null)
                return "Mã khách hàng đã tồn tại.";

            if (_khachHangDAL.GetBySDT(khachHang.SDT.Trim()) != null)
                return "Số điện thoại đã tồn tại.";

            khachHang.HoTen = khachHang.HoTen.Trim();
            khachHang.SDT = khachHang.SDT.Trim();

            return _khachHangDAL.Add(khachHang)
                ? "Thêm khách hàng thành công."
                : "Thêm khách hàng thất bại.";
        }

        public string Update(KhachHang khachHang)
        {
            if (khachHang == null)
                return "Dữ liệu khách hàng không hợp lệ.";

            if (string.IsNullOrWhiteSpace(khachHang.MaKH))
                return "Mã khách hàng không hợp lệ.";

            if (string.IsNullOrWhiteSpace(khachHang.HoTen))
                return "Họ tên khách hàng không được để trống.";

            if (string.IsNullOrWhiteSpace(khachHang.SDT))
                return "Số điện thoại không được để trống.";

            if (khachHang.NgaySinh == default(DateTime))
                return "Ngày sinh không hợp lệ.";

            if (khachHang.DiemTichLuy < 0)
                return "Điểm tích lũy không được nhỏ hơn 0.";

            var existing = _khachHangDAL.GetById(khachHang.MaKH);

            if (existing == null)
                return "Không tìm thấy khách hàng.";

            var trungSDT = _khachHangDAL.GetAll()
                .Any(x =>
                    x.MaKH != khachHang.MaKH &&
                    x.SDT == khachHang.SDT.Trim());

            if (trungSDT)
                return "Số điện thoại đã tồn tại.";

            khachHang.HoTen = khachHang.HoTen.Trim();
            khachHang.SDT = khachHang.SDT.Trim();

            return _khachHangDAL.Update(khachHang)
                ? "Cập nhật khách hàng thành công."
                : "Cập nhật khách hàng thất bại.";
        }

        public string Delete(string maKH)
        {
            if (string.IsNullOrWhiteSpace(maKH))
                return "Mã khách hàng không hợp lệ.";

            if (_khachHangDAL.GetById(maKH) == null)
                return "Không tìm thấy khách hàng.";

            try
            {
                return _khachHangDAL.Delete(maKH)
                    ? "Xóa khách hàng thành công."
                    : "Xóa khách hàng thất bại.";
            }
            catch
            {
                return "Không thể xóa khách hàng vì khách hàng đã có dữ liệu hóa đơn.";
            }
        }

        public string CongDiem(string maKH, int soDiem)
        {
            if (soDiem <= 0)
                return "Số điểm cộng phải lớn hơn 0.";

            var khachHang = _khachHangDAL.GetById(maKH);

            if (khachHang == null)
                return "Không tìm thấy khách hàng.";

            khachHang.DiemTichLuy += soDiem;

            return _khachHangDAL.Update(khachHang)
                ? "Cộng điểm thành công."
                : "Cộng điểm thất bại.";
        }

        public string TruDiem(string maKH, int soDiem)
        {
            if (soDiem <= 0)
                return "Số điểm sử dụng phải lớn hơn 0.";

            var khachHang = _khachHangDAL.GetById(maKH);

            if (khachHang == null)
                return "Không tìm thấy khách hàng.";

            if (khachHang.DiemTichLuy < soDiem)
                return "Khách hàng không đủ điểm.";

            khachHang.DiemTichLuy -= soDiem;

            return _khachHangDAL.Update(khachHang)
                ? "Sử dụng điểm thành công."
                : "Sử dụng điểm thất bại.";
        }

        public string TaoMaKhachHang()
        {
            var danhSach = _khachHangDAL.GetAll();

            if (danhSach == null || danhSach.Count == 0)
                return "KH001";

            int soLonNhat = 0;

            foreach (var kh in danhSach)
            {
                if (!string.IsNullOrWhiteSpace(kh.MaKH) &&
                    kh.MaKH.StartsWith("KH") &&
                    int.TryParse(kh.MaKH.Substring(2), out int so))
                {
                    if (so > soLonNhat)
                        soLonNhat = so;
                }
            }

            return "KH" + (soLonNhat + 1).ToString("D3");
        }

        public string GetHangHoiVien(int diemTichLuy)
        {
            if (diemTichLuy >= 10000)
                return "Kim cương";

            if (diemTichLuy >= 1000)
                return "Vàng";

            if (diemTichLuy >= 100)
                return "Bạc";

            return "Đồng";
        }
    }
}