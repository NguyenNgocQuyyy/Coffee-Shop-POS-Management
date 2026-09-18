using Đồ_án_ngành.DAL;
using MODEL;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.BUS
{
    internal class MonBUS
    {
        private readonly MonDAL _monDAL = new MonDAL();
        private readonly DanhMucDAL _danhMucDAL = new DanhMucDAL();

        public List<Mon> GetAll()
        {
            return _monDAL.GetAll();
        }

        public Mon GetById(string maMon)
        {
            return _monDAL.GetById(maMon);
        }

        public List<Mon> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            return _monDAL.Search(keyword.Trim());
        }

        public List<Mon> GetByDanhMuc(string maDanhMuc)
        {
            if (string.IsNullOrWhiteSpace(maDanhMuc))
                return GetAll();

            return _monDAL.GetByDanhMuc(maDanhMuc);
        }

        public string Add(Mon mon)
        {
            if (mon == null)
                return "Dữ liệu món không hợp lệ.";

            if (string.IsNullOrWhiteSpace(mon.MaMon))
                return "Mã món không được để trống.";

            if (string.IsNullOrWhiteSpace(mon.TenMon))
                return "Tên món không được để trống.";

            if (mon.GiaBan <= 0)
                return "Giá bán phải lớn hơn 0.";

            if (string.IsNullOrWhiteSpace(mon.MaDanhMuc))
                return "Vui lòng chọn danh mục.";

            if (_danhMucDAL.GetById(mon.MaDanhMuc) == null)
                return "Danh mục không tồn tại.";

            if (_monDAL.GetById(mon.MaMon) != null)
                return "Mã món đã tồn tại.";

            var trungTen = _monDAL.GetAll()
                .Any(x => x.TenMon.ToLower() ==
                          mon.TenMon.Trim().ToLower());

            if (trungTen)
                return "Tên món đã tồn tại.";

            if (string.IsNullOrWhiteSpace(mon.TrangThai))
                mon.TrangThai = "Đang bán";

            mon.TenMon = mon.TenMon.Trim();

            return _monDAL.Add(mon)
                ? "Thêm món thành công."
                : "Thêm món thất bại.";
        }

        public string Update(Mon mon)
        {
            if (mon == null)
                return "Dữ liệu món không hợp lệ.";

            if (string.IsNullOrWhiteSpace(mon.MaMon))
                return "Mã món không hợp lệ.";

            if (string.IsNullOrWhiteSpace(mon.TenMon))
                return "Tên món không được để trống.";

            if (mon.GiaBan <= 0)
                return "Giá bán phải lớn hơn 0.";

            if (string.IsNullOrWhiteSpace(mon.MaDanhMuc))
                return "Vui lòng chọn danh mục.";

            if (_danhMucDAL.GetById(mon.MaDanhMuc) == null)
                return "Danh mục không tồn tại.";

            var existing = _monDAL.GetById(mon.MaMon);

            if (existing == null)
                return "Không tìm thấy món.";

            var trungTen = _monDAL.GetAll()
                .Any(x =>
                    x.MaMon != mon.MaMon &&
                    x.TenMon.ToLower() ==
                    mon.TenMon.Trim().ToLower());

            if (trungTen)
                return "Tên món đã tồn tại.";

            mon.TenMon = mon.TenMon.Trim();

            return _monDAL.Update(mon)
                ? "Cập nhật món thành công."
                : "Cập nhật món thất bại.";
        }

        public string Delete(string maMon)
        {
            if (string.IsNullOrWhiteSpace(maMon))
                return "Mã món không hợp lệ.";

            if (_monDAL.GetById(maMon) == null)
                return "Không tìm thấy món.";

            try
            {
                return _monDAL.Delete(maMon)
                    ? "Xóa món thành công."
                    : "Xóa món thất bại.";
            }
            catch
            {
                return "Không thể xóa món vì món đang được sử dụng trong dữ liệu khác.";
            }
        }
    }
}