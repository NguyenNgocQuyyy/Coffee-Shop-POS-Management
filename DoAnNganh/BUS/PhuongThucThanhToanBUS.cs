using Đồ_án_ngành.DAL;
using MODEL;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.BUS
{
    internal class PhuongThucThanhToanBUS
    {
        private readonly PhuongThucThanhToanDAL _phuongThucDAL
            = new PhuongThucThanhToanDAL();

        public List<PhuongThucThanhToan> GetAll()
        {
            return _phuongThucDAL.GetAll();
        }

        public PhuongThucThanhToan GetById(string maPhuongThuc)
        {
            if (string.IsNullOrWhiteSpace(maPhuongThuc))
                return null;

            return _phuongThucDAL.GetById(
                maPhuongThuc.Trim());
        }

        public List<PhuongThucThanhToan> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            return _phuongThucDAL.Search(
                keyword.Trim());
        }

        public string Add(PhuongThucThanhToan phuongThuc)
        {
            // 1. KIỂM TRA DỮ LIỆU
            if (phuongThuc == null)
                return "Dữ liệu phương thức thanh toán không hợp lệ.";

            if (string.IsNullOrWhiteSpace(
                    phuongThuc.MaPhuongThuc))
            {
                return "Mã phương thức không được để trống.";
            }

            if (string.IsNullOrWhiteSpace(
                    phuongThuc.TenPhuongThuc))
            {
                return "Tên phương thức không được để trống.";
            }

            phuongThuc.MaPhuongThuc =
                phuongThuc.MaPhuongThuc.Trim();

            phuongThuc.TenPhuongThuc =
                phuongThuc.TenPhuongThuc.Trim();

            if (_phuongThucDAL.GetById(
                    phuongThuc.MaPhuongThuc) != null)
            {
                return "Mã phương thức đã tồn tại.";
            }

            var trungTen = _phuongThucDAL.GetAll()
                .Any(x =>
                    x.TenPhuongThuc.ToLower()
                    == phuongThuc.TenPhuongThuc.ToLower());

            if (trungTen)
                return "Tên phương thức thanh toán đã tồn tại.";

            return _phuongThucDAL.Add(phuongThuc)
                ? "Thêm phương thức thanh toán thành công."
                : "Thêm phương thức thanh toán thất bại.";
        }

        public string Update(PhuongThucThanhToan phuongThuc)
        {
            // 2. KIỂM TRA CẬP NHẬT
            if (phuongThuc == null)
                return "Dữ liệu phương thức thanh toán không hợp lệ.";

            if (string.IsNullOrWhiteSpace(
                    phuongThuc.MaPhuongThuc))
            {
                return "Mã phương thức không hợp lệ.";
            }

            if (string.IsNullOrWhiteSpace(
                    phuongThuc.TenPhuongThuc))
            {
                return "Tên phương thức không được để trống.";
            }

            phuongThuc.MaPhuongThuc =
                phuongThuc.MaPhuongThuc.Trim();

            phuongThuc.TenPhuongThuc =
                phuongThuc.TenPhuongThuc.Trim();

            if (_phuongThucDAL.GetById(
                    phuongThuc.MaPhuongThuc) == null)
            {
                return "Không tìm thấy phương thức thanh toán.";
            }

            var trungTen = _phuongThucDAL.GetAll()
                .Any(x =>
                    x.MaPhuongThuc != phuongThuc.MaPhuongThuc &&
                    x.TenPhuongThuc.ToLower()
                    == phuongThuc.TenPhuongThuc.ToLower());

            if (trungTen)
                return "Tên phương thức thanh toán đã tồn tại.";

            return _phuongThucDAL.Update(phuongThuc)
                ? "Cập nhật phương thức thanh toán thành công."
                : "Cập nhật phương thức thanh toán thất bại.";
        }

        public string Delete(string maPhuongThuc)
        {
            // 3. XÓA PHƯƠNG THỨC
            if (string.IsNullOrWhiteSpace(maPhuongThuc))
                return "Mã phương thức không hợp lệ.";

            maPhuongThuc = maPhuongThuc.Trim();

            if (_phuongThucDAL.GetById(maPhuongThuc) == null)
                return "Không tìm thấy phương thức thanh toán.";

            try
            {
                return _phuongThucDAL.Delete(maPhuongThuc)
                    ? "Xóa phương thức thanh toán thành công."
                    : "Xóa phương thức thanh toán thất bại.";
            }
            catch
            {
                return "Không thể xóa phương thức vì đã có hóa đơn liên quan.";
            }
        }
    }
}