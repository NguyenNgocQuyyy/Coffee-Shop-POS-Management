using Đồ_án_ngành.DAL;
using MODEL;
using System;
using System.Collections.Generic;

namespace Đồ_án_ngành.BUS
{
    internal class PhieuXuatBUS
    {
        private readonly PhieuXuatDAL _phieuXuatDAL
            = new PhieuXuatDAL();

        private readonly NguyenVatLieuDAL _nguyenVatLieuDAL
            = new NguyenVatLieuDAL();

        private readonly ToppingDAL _toppingDAL
            = new ToppingDAL();

        private readonly PhieuNhapDAL _phieuNhapDAL
            = new PhieuNhapDAL();
        public List<PhieuXuat> GetAll()
        {
            return _phieuXuatDAL.GetAll();
        }

        public PhieuXuat GetById(string maPhieuXuat)
        {
            return _phieuXuatDAL.GetById(maPhieuXuat);
        }

        public List<PhieuXuat> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            return _phieuXuatDAL.Search(keyword.Trim());
        }

        public string Add(
            PhieuXuat phieuXuat,
            List<ChiTietPhieuXuat> chiTiets)
        {
            // 1. KIỂM TRA PHIẾU XUẤT
            if (phieuXuat == null)
                return "Dữ liệu phiếu xuất không hợp lệ.";

            if (string.IsNullOrWhiteSpace(phieuXuat.MaPhieuXuat))
                return "Mã phiếu xuất không được để trống.";

            phieuXuat.MaPhieuXuat =
                phieuXuat.MaPhieuXuat.Trim();

            if (_phieuXuatDAL.GetById(
                    phieuXuat.MaPhieuXuat) != null)
            {
                return "Mã phiếu xuất đã tồn tại.";
            }

            if (string.IsNullOrWhiteSpace(phieuXuat.LyDoXuat))
                return "Lý do xuất không được để trống.";

            phieuXuat.LyDoXuat =
                phieuXuat.LyDoXuat.Trim();

            if (phieuXuat.NgayXuat == default(DateTime))
                phieuXuat.NgayXuat = DateTime.Now;

            // 2. KIỂM TRA CHI TIẾT
            if (chiTiets == null || chiTiets.Count == 0)
                return "Phiếu xuất phải có ít nhất một mặt hàng.";

            var maChiTietDaCo = new HashSet<string>();

            foreach (var chiTiet in chiTiets)
            {
                if (chiTiet == null)
                    return "Chi tiết phiếu xuất không hợp lệ.";

                if (string.IsNullOrWhiteSpace(
                        chiTiet.MaChiTietPX))
                {
                    return "Mã chi tiết phiếu xuất không được để trống.";
                }

                chiTiet.MaChiTietPX =
                    chiTiet.MaChiTietPX.Trim();

                if (!maChiTietDaCo.Add(
                        chiTiet.MaChiTietPX))
                {
                    return "Mã chi tiết phiếu xuất bị trùng.";
                }

                bool coNVL =
                    !string.IsNullOrWhiteSpace(chiTiet.MaNVL);

                bool coTopping =
                    !string.IsNullOrWhiteSpace(chiTiet.MaTopping);

                // 3. CHỈ ĐƯỢC CHỌN MỘT LOẠI HÀNG
                if (coNVL == coTopping)
                {
                    return "Mỗi chi tiết chỉ được chọn nguyên vật liệu hoặc topping.";
                }

                if (chiTiet.SoLuong <= 0)
                    return "Số lượng xuất phải lớn hơn 0.";

                // 4. KIỂM TRA NGUYÊN VẬT LIỆU
                if (coNVL)
                {
                    chiTiet.MaNVL = chiTiet.MaNVL.Trim();
                    chiTiet.MaTopping = null;

                    var nvl = _nguyenVatLieuDAL
                        .GetById(chiTiet.MaNVL);

                    if (nvl == null)
                        return "Nguyên vật liệu không tồn tại.";

                    if (nvl.SoLuongTon < chiTiet.SoLuong)
                    {
                        return $"Nguyên vật liệu {nvl.TenNVL} không đủ tồn kho.";
                    }
                }
                // 5. KIỂM TRA TOPPING
                else
                {
                    chiTiet.MaTopping =
                        chiTiet.MaTopping.Trim();

                    chiTiet.MaNVL = null;

                    var topping = _toppingDAL
                        .GetById(chiTiet.MaTopping);

                    if (topping == null)
                        return "Topping không tồn tại.";

                    if (topping.SoLuongTon < chiTiet.SoLuong)
                    {
                        return $"Topping {topping.TenTopping} không đủ tồn kho.";
                    }
                }

                chiTiet.DonGia = LayDonGiaNhapGanNhat(
                    chiTiet.MaNVL,
                    chiTiet.MaTopping);

                chiTiet.ThanhTien =
                    chiTiet.SoLuong * chiTiet.DonGia;

                if (phieuXuat.LaHaoHut && chiTiet.DonGia <= 0)
                {
                    return "Không xác định được đơn giá nhập của mặt hàng hao hụt.";
                }

                chiTiet.MaPhieuXuat =
                    phieuXuat.MaPhieuXuat;
            }

            // 6. LƯU PHIẾU VÀ TRỪ KHO
            try
            {
                return _phieuXuatDAL.Add(
                    phieuXuat,
                    chiTiets)
                    ? "Xuất kho thành công."
                    : "Xuất kho thất bại.";
            }
            catch (Exception ex)
            {
                return "Xuất kho thất bại: " + ex.Message;
            }
        }

        public decimal LayDonGiaNhapGanNhat(string maNVL,string maTopping)
        {
            var danhSachPhieuNhap = _phieuNhapDAL.GetAll();

            foreach (var phieuNhap in danhSachPhieuNhap)
            {
                foreach (var chiTiet in phieuNhap.ChiTietPhieuNhaps)
                {
                    if (!string.IsNullOrWhiteSpace(maNVL) &&
                        chiTiet.MaNVL == maNVL)
                    {
                        return chiTiet.DonGia;
                    }

                    if (!string.IsNullOrWhiteSpace(maTopping) &&
                        chiTiet.MaTopping == maTopping)
                    {
                        return chiTiet.DonGia;
                    }
                }
            }

            return 0;
        }
    }
}