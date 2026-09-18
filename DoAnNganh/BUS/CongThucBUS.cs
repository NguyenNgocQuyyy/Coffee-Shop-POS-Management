using Đồ_án_ngành.DAL;
using MODEL;
using System.Collections.Generic;

namespace Đồ_án_ngành.BUS
{
    internal class CongThucBUS
    {
        private readonly CongThucDAL _congThucDAL = new CongThucDAL();
        private readonly MonDAL _monDAL = new MonDAL();
        private readonly NguyenVatLieuDAL _nguyenVatLieuDAL
            = new NguyenVatLieuDAL();

        public List<CongThuc> GetAll()
        {
            return _congThucDAL.GetAll();
        }

        public CongThuc GetById(string maMon, string maNVL)
        {
            return _congThucDAL.GetById(maMon, maNVL);
        }

        public List<CongThuc> GetByMon(string maMon)
        {
            if (string.IsNullOrWhiteSpace(maMon))
                return new List<CongThuc>();

            return _congThucDAL.GetByMon(maMon);
        }

        public List<CongThuc> GetByNguyenVatLieu(string maNVL)
        {
            if (string.IsNullOrWhiteSpace(maNVL))
                return new List<CongThuc>();

            return _congThucDAL.GetByNguyenVatLieu(maNVL);
        }

        public string Add(CongThuc congThuc)
        {
            if (congThuc == null)
                return "Dữ liệu công thức không hợp lệ.";

            if (string.IsNullOrWhiteSpace(congThuc.MaMon))
                return "Mã món không được để trống.";

            if (string.IsNullOrWhiteSpace(congThuc.MaNVL))
                return "Mã nguyên vật liệu không được để trống.";

            if (congThuc.DinhLuong <= 0)
                return "Định lượng phải lớn hơn 0.";

            if (_monDAL.GetById(congThuc.MaMon) == null)
                return "Món không tồn tại.";

            if (_nguyenVatLieuDAL.GetById(congThuc.MaNVL) == null)
                return "Nguyên vật liệu không tồn tại.";

            if (_congThucDAL.GetById(
                    congThuc.MaMon,
                    congThuc.MaNVL) != null)
            {
                return "Nguyên vật liệu này đã có trong công thức của món.";
            }

            return _congThucDAL.Add(congThuc)
                ? "Thêm nguyên vật liệu vào công thức thành công."
                : "Thêm công thức thất bại.";
        }

        public string Update(CongThuc congThuc)
        {
            if (congThuc == null)
                return "Dữ liệu công thức không hợp lệ.";

            if (string.IsNullOrWhiteSpace(congThuc.MaMon) ||
                string.IsNullOrWhiteSpace(congThuc.MaNVL))
            {
                return "Mã món và mã nguyên vật liệu không hợp lệ.";
            }

            if (congThuc.DinhLuong <= 0)
                return "Định lượng phải lớn hơn 0.";

            if (_congThucDAL.GetById(
                    congThuc.MaMon,
                    congThuc.MaNVL) == null)
            {
                return "Không tìm thấy nguyên vật liệu trong công thức.";
            }

            return _congThucDAL.Update(congThuc)
                ? "Cập nhật định lượng thành công."
                : "Cập nhật công thức thất bại.";
        }

        public string Delete(string maMon, string maNVL)
        {
            if (string.IsNullOrWhiteSpace(maMon) ||
                string.IsNullOrWhiteSpace(maNVL))
            {
                return "Mã món và mã nguyên vật liệu không hợp lệ.";
            }

            if (_congThucDAL.GetById(maMon, maNVL) == null)
                return "Không tìm thấy nguyên vật liệu trong công thức.";

            return _congThucDAL.Delete(maMon, maNVL)
                ? "Xóa nguyên vật liệu khỏi công thức thành công."
                : "Xóa công thức thất bại.";
        }

        public string DeleteByMon(string maMon)
        {
            if (string.IsNullOrWhiteSpace(maMon))
                return "Mã món không hợp lệ.";

            var danhSach = _congThucDAL.GetByMon(maMon);

            if (danhSach == null || danhSach.Count == 0)
                return "Món này chưa có công thức.";

            return _congThucDAL.DeleteByMon(maMon)
                ? "Xóa toàn bộ công thức thành công."
                : "Xóa công thức thất bại.";
        }

        public string SaveByMon(string maMon, List<CongThuc> danhSachMoi)
        {
            if (string.IsNullOrWhiteSpace(maMon))
                return "Mã món không hợp lệ.";

            if (_monDAL.GetById(maMon) == null)
                return "Món không tồn tại.";

            if (danhSachMoi == null || danhSachMoi.Count == 0)
                return "Công thức phải có ít nhất một nguyên vật liệu.";

            foreach (CongThuc congThuc in danhSachMoi)
            {
                if (string.IsNullOrWhiteSpace(congThuc.MaNVL))
                    return "Nguyên vật liệu không hợp lệ.";

                if (congThuc.DinhLuong <= 0)
                    return "Định lượng phải lớn hơn 0.";

                if (_nguyenVatLieuDAL.GetById(congThuc.MaNVL) == null)
                    return "Có nguyên vật liệu không tồn tại.";
            }

            var congThucCu = _congThucDAL.GetByMon(maMon);

            if (congThucCu.Count > 0)
            {
                if (!_congThucDAL.DeleteByMon(maMon))
                    return "Không thể cập nhật công thức cũ.";
            }

            foreach (CongThuc congThuc in danhSachMoi)
            {
                if (!_congThucDAL.Add(congThuc))
                    return "Lưu công thức thất bại.";
            }

            return "Lưu công thức thành công.";
        }
    }
}