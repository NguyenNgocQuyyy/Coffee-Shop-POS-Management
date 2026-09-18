using Đồ_án_ngành.DAL;
using MODEL;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.BUS
{
    internal class ToppingBUS
    {
        private readonly ToppingDAL _toppingDAL = new ToppingDAL();

        public List<Topping> GetAll()
        {
            return _toppingDAL.GetAll();
        }

        public Topping GetById(string maTopping)
        {
            return _toppingDAL.GetById(maTopping);
        }

        public List<Topping> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            return _toppingDAL.Search(keyword.Trim());
        }

        public string Add(Topping topping)
        {
            if (topping == null)
                return "Dữ liệu topping không hợp lệ.";

            if (string.IsNullOrWhiteSpace(topping.MaTopping))
                return "Mã topping không được để trống.";

            if (string.IsNullOrWhiteSpace(topping.TenTopping))
                return "Tên topping không được để trống.";

            if (topping.GiaBan <= 0)
                return "Giá bán phải lớn hơn 0.";

            if (topping.SoLuongTon < 0)
                return "Số lượng tồn không được nhỏ hơn 0.";

            if (topping.MucCanhBao < 0)
                return "Mức cảnh báo không được nhỏ hơn 0.";

            if (string.IsNullOrWhiteSpace(topping.DonViTinh))
                return "Đơn vị tính không được để trống.";

            if (string.IsNullOrWhiteSpace(topping.DonViTinhQuyDoi))
                return "Đơn vị quy đổi không được để trống.";

            if (topping.HeSoQuyDoi <= 0)
                return "Hệ số quy đổi phải lớn hơn 0.";

            if (_toppingDAL.GetById(topping.MaTopping) != null)
                return "Mã topping đã tồn tại.";

            var trungTen = _toppingDAL.GetAll()
                .Any(x => x.TenTopping.ToLower()
                    == topping.TenTopping.Trim().ToLower());

            if (trungTen)
                return "Tên topping đã tồn tại.";

            topping.TenTopping = topping.TenTopping.Trim();
            topping.DonViTinh = topping.DonViTinh.Trim();

            topping.TrangThai = XacDinhTrangThai(
                topping.SoLuongTon,
                topping.MucCanhBao,
                topping.TrangThai
            );

            return _toppingDAL.Add(topping)
                ? "Thêm topping thành công."
                : "Thêm topping thất bại.";
        }

        public string Update(Topping topping)
        {
            if (topping == null)
                return "Dữ liệu topping không hợp lệ.";

            if (string.IsNullOrWhiteSpace(topping.MaTopping))
                return "Mã topping không hợp lệ.";

            if (string.IsNullOrWhiteSpace(topping.TenTopping))
                return "Tên topping không được để trống.";

            if (topping.GiaBan <= 0)
                return "Giá bán phải lớn hơn 0.";

            if (topping.SoLuongTon < 0)
                return "Số lượng tồn không được nhỏ hơn 0.";

            if (topping.MucCanhBao < 0)
                return "Mức cảnh báo không được nhỏ hơn 0.";

            if (string.IsNullOrWhiteSpace(topping.DonViTinh))
                return "Đơn vị tính không được để trống.";

            if (string.IsNullOrWhiteSpace(topping.DonViTinhQuyDoi))
                return "Đơn vị quy đổi không được để trống.";

            if (topping.HeSoQuyDoi <= 0)
                return "Hệ số quy đổi phải lớn hơn 0.";

            var existing = _toppingDAL.GetById(topping.MaTopping);

            if (existing == null)
                return "Không tìm thấy topping.";

            var trungTen = _toppingDAL.GetAll()
                .Any(x =>
                    x.MaTopping != topping.MaTopping &&
                    x.TenTopping.ToLower()
                    == topping.TenTopping.Trim().ToLower());

            if (trungTen)
                return "Tên topping đã tồn tại.";

            topping.TenTopping = topping.TenTopping.Trim();
            topping.DonViTinh = topping.DonViTinh.Trim();
            topping.DonViTinhQuyDoi = topping.DonViTinhQuyDoi.Trim();

            topping.TrangThai = XacDinhTrangThai(
                topping.SoLuongTon,
                topping.MucCanhBao,
                topping.TrangThai
            );

            return _toppingDAL.Update(topping)
                ? "Cập nhật topping thành công."
                : "Cập nhật topping thất bại.";
        }

        public string Delete(string maTopping)
        {
            if (string.IsNullOrWhiteSpace(maTopping))
                return "Mã topping không hợp lệ.";

            if (_toppingDAL.GetById(maTopping) == null)
                return "Không tìm thấy topping.";

            try
            {
                return _toppingDAL.Delete(maTopping)
                    ? "Xóa topping thành công."
                    : "Xóa topping thất bại.";
            }
            catch
            {
                return "Không thể xóa topping vì topping đang được sử dụng trong dữ liệu khác.";
            }
        }

        private string XacDinhTrangThai(
            decimal soLuongTon,
            decimal mucCanhBao,
            string trangThaiHienTai)
        {
            // Nếu quản lý chủ động ngừng bán thì giữ nguyên
            if (trangThaiHienTai == "Ngừng bán")
                return "Ngừng bán";

            if (soLuongTon <= 0)
                return "Hết hàng";

            if (soLuongTon <= mucCanhBao)
                return "Sắp hết";

            return "Đang bán";
        }
    }
}