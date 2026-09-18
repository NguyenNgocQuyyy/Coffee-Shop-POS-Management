using Đồ_án_ngành.DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.BUS
{
    internal class PhieuNhapBUS
    {
        private readonly PhieuNhapDAL _phieuNhapDAL
            = new PhieuNhapDAL();

        private readonly NhaCungCapDAL _nhaCungCapDAL
            = new NhaCungCapDAL();

        private readonly NguyenVatLieuDAL _nguyenVatLieuDAL
            = new NguyenVatLieuDAL();

        private readonly ToppingDAL _toppingDAL
            = new ToppingDAL();

        public List<PhieuNhap> GetAll()
        {
            return _phieuNhapDAL.GetAll();
        }

        public PhieuNhap GetById(string maPhieuNhap)
        {
            return _phieuNhapDAL.GetById(maPhieuNhap);
        }

        public List<PhieuNhap> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            return _phieuNhapDAL.Search(keyword.Trim());
        }

        public string Add(
            PhieuNhap phieuNhap,
            List<ChiTietPhieuNhap> chiTiets)
        {

            // 1. KIỂM TRA PHIẾU NHẬP
            if (phieuNhap == null)
                return "Dữ liệu phiếu nhập không hợp lệ.";

            if (string.IsNullOrWhiteSpace(phieuNhap.MaPhieuNhap))
                return "Mã phiếu nhập không được để trống.";

            phieuNhap.MaPhieuNhap =
                phieuNhap.MaPhieuNhap.Trim();

            if (_phieuNhapDAL.GetById(
                    phieuNhap.MaPhieuNhap) != null)
            {
                return "Mã phiếu nhập đã tồn tại.";
            }

            if (string.IsNullOrWhiteSpace(phieuNhap.MaNCC))
                return "Vui lòng chọn nhà cung cấp.";

            phieuNhap.MaNCC = phieuNhap.MaNCC.Trim();

            if (_nhaCungCapDAL.GetById(
                    phieuNhap.MaNCC) == null)
            {
                return "Nhà cung cấp không tồn tại.";
            }

            if (phieuNhap.NgayNhap == default(DateTime))
                phieuNhap.NgayNhap = DateTime.Now;

            // 2. KIỂM TRA CHI TIẾT
            if (chiTiets == null || chiTiets.Count == 0)
                return "Phiếu nhập phải có ít nhất một mặt hàng.";

            var maChiTietDaCo = new HashSet<string>();

            foreach (var chiTiet in chiTiets)
            {
                if (chiTiet == null)
                    return "Chi tiết phiếu nhập không hợp lệ.";

                if (string.IsNullOrWhiteSpace(
                        chiTiet.MaChiTietPN))
                {
                    return "Mã chi tiết phiếu nhập không được để trống.";
                }

                chiTiet.MaChiTietPN =
                    chiTiet.MaChiTietPN.Trim();

                if (!maChiTietDaCo.Add(
                        chiTiet.MaChiTietPN))
                {
                    return "Mã chi tiết phiếu nhập bị trùng.";
                }

                bool coNVL =
                    !string.IsNullOrWhiteSpace(
                        chiTiet.MaNVL);

                bool coTopping =
                    !string.IsNullOrWhiteSpace(
                        chiTiet.MaTopping);

                // Phải chọn đúng 1 loại
                if (coNVL == coTopping)
                {
                    return "Mỗi chi tiết chỉ được chọn nguyên vật liệu hoặc topping.";
                }

                // 3. KIỂM TRA MẶT HÀNG
                if (coNVL)
                {
                    chiTiet.MaNVL =
                        chiTiet.MaNVL.Trim();

                    chiTiet.MaTopping = null;

                    if (_nguyenVatLieuDAL.GetById(
                            chiTiet.MaNVL) == null)
                    {
                        return "Nguyên vật liệu không tồn tại.";
                    }
                }
                else
                {
                    chiTiet.MaTopping =
                        chiTiet.MaTopping.Trim();

                    chiTiet.MaNVL = null;

                    if (_toppingDAL.GetById(
                            chiTiet.MaTopping) == null)
                    {
                        return "Topping không tồn tại.";
                    }

                    // Topping đang dùng tồn kho kiểu int
                    if (chiTiet.SoLuong % 1 != 0)
                    {
                        return "Số lượng topping phải là số nguyên.";
                    }
                }

                // 4. KIỂM TRA SỐ LƯỢNG/GIÁ
                if (chiTiet.SoLuong <= 0)
                    return "Số lượng nhập phải lớn hơn 0.";

                if (chiTiet.DonGia <= 0)
                    return "Đơn giá nhập phải lớn hơn 0.";

                // Hệ thống tự tính
                chiTiet.ThanhTien =
                    chiTiet.SoLuong * chiTiet.DonGia;

                chiTiet.MaPhieuNhap =
                    phieuNhap.MaPhieuNhap;
            }

            // 5. HỆ THỐNG TỰ TÍNH TỔNG
            phieuNhap.TongTien =
                chiTiets.Sum(x => x.ThanhTien);

            if (!string.IsNullOrWhiteSpace(
                    phieuNhap.GhiChu))
            {
                phieuNhap.GhiChu =
                    phieuNhap.GhiChu.Trim();
            }

            try
            {
                return _phieuNhapDAL.Add(
                    phieuNhap,
                    chiTiets)
                    ? "Nhập hàng thành công."
                    : "Nhập hàng thất bại.";
            }
            catch (Exception ex)
            {
                return "Nhập hàng thất bại: "
                    + ex.Message;
            }
        }

        public decimal? LayDonGiaNhapGanNhat(string maNVL,string maTopping)
        {
            return _phieuNhapDAL.LayDonGiaNhapGanNhat(
                maNVL,
                maTopping
            );
        }
    }
}