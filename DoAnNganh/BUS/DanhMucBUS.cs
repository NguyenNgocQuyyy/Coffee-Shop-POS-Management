using Đồ_án_ngành.DAL;
using MODEL;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.BUS
{
    internal class DanhMucBUS
    {
        private readonly DanhMucDAL _danhMucDAL = new DanhMucDAL();

        public List<DanhMuc> GetAll()
        {
            return _danhMucDAL.GetAll();
        }

        public DanhMuc GetById(string maDanhMuc)
        {
            return _danhMucDAL.GetById(maDanhMuc);
        }

        public List<DanhMuc> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            return _danhMucDAL.Search(keyword.Trim());
        }

        public string Add(DanhMuc danhMuc)
        {
            if (danhMuc == null)
                return "Dữ liệu danh mục không hợp lệ.";

            if (string.IsNullOrWhiteSpace(danhMuc.MaDanhMuc))
                return "Mã danh mục không được để trống.";

            if (string.IsNullOrWhiteSpace(danhMuc.TenDanhMuc))
                return "Tên danh mục không được để trống.";

            if (_danhMucDAL.GetById(danhMuc.MaDanhMuc) != null)
                return "Mã danh mục đã tồn tại.";

            var trungTen = _danhMucDAL.GetAll()
                .Any(x => x.TenDanhMuc.ToLower() ==
                          danhMuc.TenDanhMuc.Trim().ToLower());

            if (trungTen)
                return "Tên danh mục đã tồn tại.";

            danhMuc.TenDanhMuc = danhMuc.TenDanhMuc.Trim();

            return _danhMucDAL.Add(danhMuc)
                ? "Thêm danh mục thành công."
                : "Thêm danh mục thất bại.";
        }

        public string Update(DanhMuc danhMuc)
        {
            if (danhMuc == null)
                return "Dữ liệu danh mục không hợp lệ.";

            if (string.IsNullOrWhiteSpace(danhMuc.MaDanhMuc))
                return "Mã danh mục không hợp lệ.";

            if (string.IsNullOrWhiteSpace(danhMuc.TenDanhMuc))
                return "Tên danh mục không được để trống.";

            var existing = _danhMucDAL.GetById(danhMuc.MaDanhMuc);

            if (existing == null)
                return "Không tìm thấy danh mục.";

            var trungTen = _danhMucDAL.GetAll()
                .Any(x =>
                    x.MaDanhMuc != danhMuc.MaDanhMuc &&
                    x.TenDanhMuc.ToLower() ==
                    danhMuc.TenDanhMuc.Trim().ToLower());

            if (trungTen)
                return "Tên danh mục đã tồn tại.";

            danhMuc.TenDanhMuc = danhMuc.TenDanhMuc.Trim();

            return _danhMucDAL.Update(danhMuc)
                ? "Cập nhật danh mục thành công."
                : "Cập nhật danh mục thất bại.";
        }

        public string Delete(string maDanhMuc)
        {
            if (string.IsNullOrWhiteSpace(maDanhMuc))
                return "Mã danh mục không hợp lệ.";

            var danhMuc = _danhMucDAL.GetById(maDanhMuc);

            if (danhMuc == null)
                return "Không tìm thấy danh mục.";

            try
            {
                return _danhMucDAL.Delete(maDanhMuc)
                    ? "Xóa danh mục thành công."
                    : "Xóa danh mục thất bại.";
            }
            catch
            {
                return "Không thể xóa danh mục vì đang có món thuộc danh mục này.";
            }
        }
    }
}