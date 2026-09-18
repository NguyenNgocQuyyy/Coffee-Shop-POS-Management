using Đồ_án_ngành.DAL;
using MODEL;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.BUS
{
    internal class NhaCungCapBUS
    {
        private readonly NhaCungCapDAL _nhaCungCapDAL
            = new NhaCungCapDAL();

        public List<NhaCungCap> GetAll()
        {
            return _nhaCungCapDAL.GetAll();
        }

        public NhaCungCap GetById(string maNCC)
        {
            return _nhaCungCapDAL.GetById(maNCC);
        }

        public List<NhaCungCap> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            return _nhaCungCapDAL.Search(keyword.Trim());
        }

        public string Add(NhaCungCap nhaCungCap)
        {
            if (nhaCungCap == null)
                return "Dữ liệu nhà cung cấp không hợp lệ.";

            if (string.IsNullOrWhiteSpace(nhaCungCap.MaNCC))
                return "Mã nhà cung cấp không được để trống.";

            if (string.IsNullOrWhiteSpace(nhaCungCap.TenNCC))
                return "Tên nhà cung cấp không được để trống.";

            if (string.IsNullOrWhiteSpace(nhaCungCap.SDT))
                return "Số điện thoại không được để trống.";

            if (_nhaCungCapDAL.GetById(nhaCungCap.MaNCC) != null)
                return "Mã nhà cung cấp đã tồn tại.";

            if (_nhaCungCapDAL.GetBySDT(nhaCungCap.SDT.Trim()) != null)
                return "Số điện thoại nhà cung cấp đã tồn tại.";

            var trungTen = _nhaCungCapDAL.GetAll()
                .Any(x =>
                    x.TenNCC.ToLower()
                    == nhaCungCap.TenNCC.Trim().ToLower());

            if (trungTen)
                return "Tên nhà cung cấp đã tồn tại.";

            nhaCungCap.TenNCC = nhaCungCap.TenNCC.Trim();
            nhaCungCap.SDT = nhaCungCap.SDT.Trim();

            if (!string.IsNullOrWhiteSpace(nhaCungCap.Email))
                nhaCungCap.Email = nhaCungCap.Email.Trim();

            if (!string.IsNullOrWhiteSpace(nhaCungCap.DiaChi))
                nhaCungCap.DiaChi = nhaCungCap.DiaChi.Trim();

            return _nhaCungCapDAL.Add(nhaCungCap)
                ? "Thêm nhà cung cấp thành công."
                : "Thêm nhà cung cấp thất bại.";
        }

        public string Update(NhaCungCap nhaCungCap)
        {
            if (nhaCungCap == null)
                return "Dữ liệu nhà cung cấp không hợp lệ.";

            if (string.IsNullOrWhiteSpace(nhaCungCap.MaNCC))
                return "Mã nhà cung cấp không hợp lệ.";

            if (string.IsNullOrWhiteSpace(nhaCungCap.TenNCC))
                return "Tên nhà cung cấp không được để trống.";

            if (string.IsNullOrWhiteSpace(nhaCungCap.SDT))
                return "Số điện thoại không được để trống.";

            var existing = _nhaCungCapDAL.GetById(nhaCungCap.MaNCC);

            if (existing == null)
                return "Không tìm thấy nhà cung cấp.";

            var trungTen = _nhaCungCapDAL.GetAll()
                .Any(x =>
                    x.MaNCC != nhaCungCap.MaNCC &&
                    x.TenNCC.ToLower()
                    == nhaCungCap.TenNCC.Trim().ToLower());

            if (trungTen)
                return "Tên nhà cung cấp đã tồn tại.";

            var trungSDT = _nhaCungCapDAL.GetAll()
                .Any(x =>
                    x.MaNCC != nhaCungCap.MaNCC &&
                    x.SDT == nhaCungCap.SDT.Trim());

            if (trungSDT)
                return "Số điện thoại nhà cung cấp đã tồn tại.";

            nhaCungCap.TenNCC = nhaCungCap.TenNCC.Trim();
            nhaCungCap.SDT = nhaCungCap.SDT.Trim();

            if (!string.IsNullOrWhiteSpace(nhaCungCap.Email))
                nhaCungCap.Email = nhaCungCap.Email.Trim();

            if (!string.IsNullOrWhiteSpace(nhaCungCap.DiaChi))
                nhaCungCap.DiaChi = nhaCungCap.DiaChi.Trim();

            return _nhaCungCapDAL.Update(nhaCungCap)
                ? "Cập nhật nhà cung cấp thành công."
                : "Cập nhật nhà cung cấp thất bại.";
        }

        public string Delete(string maNCC)
        {
            if (string.IsNullOrWhiteSpace(maNCC))
                return "Mã nhà cung cấp không hợp lệ.";

            if (_nhaCungCapDAL.GetById(maNCC) == null)
                return "Không tìm thấy nhà cung cấp.";

            try
            {
                return _nhaCungCapDAL.Delete(maNCC)
                    ? "Xóa nhà cung cấp thành công."
                    : "Xóa nhà cung cấp thất bại.";
            }
            catch
            {
                return "Không thể xóa nhà cung cấp vì đã có phiếu nhập liên quan.";
            }
        }
    }
}