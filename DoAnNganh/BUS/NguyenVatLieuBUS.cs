using Đồ_án_ngành.DAL;
using MODEL;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.BUS
{
    internal class NguyenVatLieuBUS
    {
        private readonly NguyenVatLieuDAL _nguyenVatLieuDAL
            = new NguyenVatLieuDAL();

        public List<NguyenVatLieu> GetAll()
        {
            return _nguyenVatLieuDAL.GetAll();
        }

        public NguyenVatLieu GetById(string maNVL)
        {
            return _nguyenVatLieuDAL.GetById(maNVL);
        }

        public List<NguyenVatLieu> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            return _nguyenVatLieuDAL.Search(keyword.Trim());
        }

        public string Add(NguyenVatLieu nguyenVatLieu)
        {
            if (nguyenVatLieu == null)
                return "Dữ liệu nguyên vật liệu không hợp lệ.";

            if (string.IsNullOrWhiteSpace(nguyenVatLieu.MaNVL))
                return "Mã nguyên vật liệu không được để trống.";

            if (string.IsNullOrWhiteSpace(nguyenVatLieu.TenNVL))
                return "Tên nguyên vật liệu không được để trống.";

            if (nguyenVatLieu.SoLuongTon < 0)
                return "Số lượng tồn không được nhỏ hơn 0.";

            if (nguyenVatLieu.MucCanhBao < 0)
                return "Mức cảnh báo không được nhỏ hơn 0.";

            if (string.IsNullOrWhiteSpace(nguyenVatLieu.DonViTinh))
                return "Đơn vị tính không được để trống.";

            if (string.IsNullOrWhiteSpace(nguyenVatLieu.DonViTinhQuyDoi))
                return "Đơn vị công thức không được để trống.";

            if (nguyenVatLieu.HeSoQuyDoi <= 0)
                return "Hệ số quy đổi phải lớn hơn 0.";

            if (_nguyenVatLieuDAL.GetById(nguyenVatLieu.MaNVL) != null)
                return "Mã nguyên vật liệu đã tồn tại.";

            var trungTen = _nguyenVatLieuDAL.GetAll()
                .Any(x =>
                    x.TenNVL.ToLower()
                    == nguyenVatLieu.TenNVL.Trim().ToLower());

            if (trungTen)
                return "Tên nguyên vật liệu đã tồn tại.";

            // Chuẩn hóa dữ liệu
            nguyenVatLieu.TenNVL =
                nguyenVatLieu.TenNVL.Trim();

            nguyenVatLieu.DonViTinh =
                nguyenVatLieu.DonViTinh.Trim();

            nguyenVatLieu.DonViTinhQuyDoi =
                nguyenVatLieu.DonViTinhQuyDoi.Trim();

            // Tự xác định trạng thái tồn kho
            nguyenVatLieu.TrangThai = XacDinhTrangThai(
                nguyenVatLieu.SoLuongTon,
                nguyenVatLieu.MucCanhBao
            );

            return _nguyenVatLieuDAL.Add(nguyenVatLieu)
                ? "Thêm nguyên vật liệu thành công."
                : "Thêm nguyên vật liệu thất bại.";
        }

        public string Update(NguyenVatLieu nguyenVatLieu)
        {
            if (nguyenVatLieu == null)
                return "Dữ liệu nguyên vật liệu không hợp lệ.";

            if (string.IsNullOrWhiteSpace(nguyenVatLieu.MaNVL))
                return "Mã nguyên vật liệu không hợp lệ.";

            if (string.IsNullOrWhiteSpace(nguyenVatLieu.TenNVL))
                return "Tên nguyên vật liệu không được để trống.";

            if (nguyenVatLieu.SoLuongTon < 0)
                return "Số lượng tồn không được nhỏ hơn 0.";

            if (nguyenVatLieu.MucCanhBao < 0)
                return "Mức cảnh báo không được nhỏ hơn 0.";

            if (string.IsNullOrWhiteSpace(nguyenVatLieu.DonViTinh))
                return "Đơn vị tính không được để trống.";

            if (string.IsNullOrWhiteSpace(nguyenVatLieu.DonViTinhQuyDoi))
                return "Đơn vị công thức không được để trống.";

            if (nguyenVatLieu.HeSoQuyDoi <= 0)
                return "Hệ số quy đổi phải lớn hơn 0.";

            var existing =
                _nguyenVatLieuDAL.GetById(nguyenVatLieu.MaNVL);

            if (existing == null)
                return "Không tìm thấy nguyên vật liệu.";

            var trungTen = _nguyenVatLieuDAL.GetAll()
                .Any(x =>
                    x.MaNVL != nguyenVatLieu.MaNVL &&
                    x.TenNVL.ToLower()
                    == nguyenVatLieu.TenNVL.Trim().ToLower());

            if (trungTen)
                return "Tên nguyên vật liệu đã tồn tại.";

            // Chuẩn hóa dữ liệu
            nguyenVatLieu.TenNVL =
                nguyenVatLieu.TenNVL.Trim();

            nguyenVatLieu.DonViTinh =
                nguyenVatLieu.DonViTinh.Trim();

            nguyenVatLieu.DonViTinhQuyDoi =
                nguyenVatLieu.DonViTinhQuyDoi.Trim();

            // Tự xác định trạng thái tồn kho
            nguyenVatLieu.TrangThai = XacDinhTrangThai(
                nguyenVatLieu.SoLuongTon,
                nguyenVatLieu.MucCanhBao
            );

            return _nguyenVatLieuDAL.Update(nguyenVatLieu)
                ? "Cập nhật nguyên vật liệu thành công."
                : "Cập nhật nguyên vật liệu thất bại.";
        }

        public string Delete(string maNVL)
        {
            if (string.IsNullOrWhiteSpace(maNVL))
                return "Mã nguyên vật liệu không hợp lệ.";

            if (_nguyenVatLieuDAL.GetById(maNVL) == null)
                return "Không tìm thấy nguyên vật liệu.";

            try
            {
                return _nguyenVatLieuDAL.Delete(maNVL)
                    ? "Xóa nguyên vật liệu thành công."
                    : "Xóa nguyên vật liệu thất bại.";
            }
            catch
            {
                return "Không thể xóa nguyên vật liệu vì đang được sử dụng trong dữ liệu khác.";
            }
        }

        private string XacDinhTrangThai(
            decimal soLuongTon,
            decimal mucCanhBao)
        {
            if (soLuongTon <= 0)
                return "Hết hàng";

            if (soLuongTon <= mucCanhBao)
                return "Sắp hết";

            return "Còn hàng";
        }
    }
}