using Đồ_án_ngành.DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.BUS
{
    internal class KhuyenMaiBUS
    {
        private readonly KhuyenMaiDAL _khuyenMaiDAL
            = new KhuyenMaiDAL();

        private readonly MonDAL _monDAL
            = new MonDAL();

        public List<KhuyenMai> GetAll()
        {
            return _khuyenMaiDAL.GetAll();
        }

        public KhuyenMai GetById(string maKhuyenMai)
        {
            if (string.IsNullOrWhiteSpace(maKhuyenMai))
                return null;

            return _khuyenMaiDAL.GetById(
                maKhuyenMai.Trim());
        }

        public List<KhuyenMai> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            return _khuyenMaiDAL.Search(
                keyword.Trim());
        }

        public List<KhuyenMai> Filter(string keyword, string trangThai,DateTime tuNgay, DateTime denNgay)
        {
            if (tuNgay.Date > denNgay.Date)
                return new List<KhuyenMai>();

            return _khuyenMaiDAL.Filter(
                keyword,
                trangThai,
                tuNgay.Date,
                denNgay.Date);
        }

        public string Add(
            KhuyenMai khuyenMai,
            List<string> danhSachMaMon)
        {
            // 1. KIỂM TRA KHUYẾN MÃI
            string loi = KiemTraDuLieu(
                khuyenMai,
                danhSachMaMon);

            if (loi != null)
                return loi;

            khuyenMai.MaKhuyenMai =
                khuyenMai.MaKhuyenMai.Trim();

            khuyenMai.TenKhuyenMai =
                khuyenMai.TenKhuyenMai.Trim();

            khuyenMai.LoaiKhuyenMai =
                khuyenMai.LoaiKhuyenMai.Trim();

            if (!string.IsNullOrWhiteSpace(
                    khuyenMai.GhiChu))
            {
                khuyenMai.GhiChu =
                    khuyenMai.GhiChu.Trim();
            }

            if (_khuyenMaiDAL.GetById(
                    khuyenMai.MaKhuyenMai) != null)
            {
                return "Mã khuyến mãi đã tồn tại.";
            }

            // 2. LOẠI BỎ MÃ MÓN TRÙNG
            danhSachMaMon = danhSachMaMon?
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim())
                .Distinct()
                .ToList()
                ?? new List<string>();

            // 3. XÁC ĐỊNH TRẠNG THÁI
            if (khuyenMai.TrangThai != "Ngừng áp dụng")
            {
                khuyenMai.TrangThai =
                    XacDinhTrangThai(
                        khuyenMai.NgayBatDau,
                        khuyenMai.NgayKetThuc);
            }

            try
            {
                return _khuyenMaiDAL.Add(
                    khuyenMai,
                    danhSachMaMon)
                    ? "Thêm khuyến mãi thành công."
                    : "Thêm khuyến mãi thất bại.";
            }
            catch (Exception ex)
            {
                return "Thêm khuyến mãi thất bại: "
                    + ex.Message;
            }
        }

        public string Update(
            KhuyenMai khuyenMai,
            List<string> danhSachMaMon)
        {
            // 4. KIỂM TRA DỮ LIỆU CẬP NHẬT
            string loi = KiemTraDuLieu(
                khuyenMai,
                danhSachMaMon);

            if (loi != null)
                return loi;

            khuyenMai.MaKhuyenMai =
                khuyenMai.MaKhuyenMai.Trim();

            khuyenMai.TenKhuyenMai =
                khuyenMai.TenKhuyenMai.Trim();

            khuyenMai.LoaiKhuyenMai =
                khuyenMai.LoaiKhuyenMai.Trim();

            if (!string.IsNullOrWhiteSpace(
                    khuyenMai.GhiChu))
            {
                khuyenMai.GhiChu =
                    khuyenMai.GhiChu.Trim();
            }

            if (_khuyenMaiDAL.GetById(
                    khuyenMai.MaKhuyenMai) == null)
            {
                return "Không tìm thấy khuyến mãi.";
            }

            danhSachMaMon = danhSachMaMon?
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim())
                .Distinct()
                .ToList()
                ?? new List<string>();

            // 5. XÁC ĐỊNH TRẠNG THÁI
            if (khuyenMai.TrangThai != "Ngừng áp dụng")
            {
                khuyenMai.TrangThai =
                    XacDinhTrangThai(
                        khuyenMai.NgayBatDau,
                        khuyenMai.NgayKetThuc);
            }

            try
            {
                return _khuyenMaiDAL.Update(
                    khuyenMai,
                    danhSachMaMon)
                    ? "Cập nhật khuyến mãi thành công."
                    : "Cập nhật khuyến mãi thất bại.";
            }
            catch (Exception ex)
            {
                return "Cập nhật khuyến mãi thất bại: "
                    + ex.Message;
            }
        }

        public string Delete(string maKhuyenMai)
        {
            // 6. XÓA KHUYẾN MÃI
            if (string.IsNullOrWhiteSpace(maKhuyenMai))
                return "Mã khuyến mãi không hợp lệ.";

            maKhuyenMai = maKhuyenMai.Trim();

            if (_khuyenMaiDAL.GetById(
                    maKhuyenMai) == null)
            {
                return "Không tìm thấy khuyến mãi.";
            }

            try
            {
                return _khuyenMaiDAL.Delete(maKhuyenMai)
                    ? "Xóa khuyến mãi thành công."
                    : "Xóa khuyến mãi thất bại.";
            }
            catch
            {
                return "Không thể xóa khuyến mãi vì đã có hóa đơn liên quan.";
            }
        }

        private string KiemTraDuLieu(
            KhuyenMai khuyenMai,
            List<string> danhSachMaMon)
        {
            if (khuyenMai == null)
                return "Dữ liệu khuyến mãi không hợp lệ.";

            if (string.IsNullOrWhiteSpace(
                    khuyenMai.MaKhuyenMai))
            {
                return "Mã khuyến mãi không được để trống.";
            }

            if (string.IsNullOrWhiteSpace(
                    khuyenMai.TenKhuyenMai))
            {
                return "Tên khuyến mãi không được để trống.";
            }

            if (string.IsNullOrWhiteSpace(
                    khuyenMai.LoaiKhuyenMai))
            {
                return "Loại khuyến mãi không được để trống.";
            }

            // 7. KIỂM TRA LOẠI KHUYẾN MÃI
            if (khuyenMai.LoaiKhuyenMai != "Phần trăm" &&
                khuyenMai.LoaiKhuyenMai != "Tiền cố định")
            {
                return "Loại khuyến mãi không hợp lệ.";
            }

            if (khuyenMai.GiaTriKhuyenMai <= 0)
                return "Giá trị khuyến mãi phải lớn hơn 0.";

            if (khuyenMai.LoaiKhuyenMai == "Phần trăm" &&
                khuyenMai.GiaTriKhuyenMai > 100)
            {
                return "Khuyến mãi phần trăm không được vượt quá 100%.";
            }

            // 8. KIỂM TRA THỜI GIAN
            if (khuyenMai.NgayKetThuc <
                khuyenMai.NgayBatDau)
            {
                return "Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu.";
            }

            // 9. KIỂM TRA MÓN ÁP DỤNG
            if (danhSachMaMon != null)
            {
                foreach (var maMon in danhSachMaMon)
                {
                    if (string.IsNullOrWhiteSpace(maMon))
                        return "Mã món áp dụng không hợp lệ.";

                    if (_monDAL.GetById(maMon.Trim()) == null)
                    {
                        return $"Món {maMon} không tồn tại.";
                    }
                }
            }

            foreach (var maMon in danhSachMaMon)
            {
                if (string.IsNullOrWhiteSpace(maMon))
                    return "Mã món áp dụng không hợp lệ.";

                if (_monDAL.GetById(maMon.Trim()) == null)
                {
                    return $"Món {maMon} không tồn tại.";
                }
            }

            return null;
        }

        private string XacDinhTrangThai(
            DateTime ngayBatDau,
            DateTime ngayKetThuc)
        {
            DateTime homNay = DateTime.Today;

            if (homNay < ngayBatDau.Date)
                return "Chưa bắt đầu";

            if (homNay > ngayKetThuc.Date)
                return "Đã kết thúc";

            return "Đang áp dụng";
        }
    }
}