using Đồ_án_ngành.DAL;
using MODEL;
using System.Collections.Generic;
using System.Linq;

namespace Đồ_án_ngành.BUS
{
    internal class BanBUS
    {
        private readonly BanDAL _banDAL = new BanDAL();

        public List<Ban> GetAll()
        {
            return _banDAL.GetAll();
        }

        public Ban GetById(string maBan)
        {
            return _banDAL.GetById(maBan);
        }

        public List<Ban> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            return _banDAL.Search(keyword.Trim());
        }

        public string Add(Ban ban)
        {
            if (ban == null)
                return "Dữ liệu bàn không hợp lệ.";

            if (string.IsNullOrWhiteSpace(ban.MaBan))
                return "Mã bàn không được để trống.";

            if (string.IsNullOrWhiteSpace(ban.SoBan))
                return "Số bàn không được để trống.";

            if (_banDAL.GetById(ban.MaBan) != null)
                return "Mã bàn đã tồn tại.";

            var trungSoBan = _banDAL.GetAll()
                .Any(x => x.SoBan.Trim().ToLower()
                       == ban.SoBan.Trim().ToLower());

            if (trungSoBan)
                return "Số bàn đã tồn tại.";

            if (!TrangThaiHopLe(ban.TrangThai))
                ban.TrangThai = "Trống";

            ban.SoBan = ban.SoBan.Trim();

            return _banDAL.Add(ban)
                ? "Thêm bàn thành công."
                : "Thêm bàn thất bại.";
        }

        public string Update(Ban ban)
        {
            if (ban == null)
                return "Dữ liệu bàn không hợp lệ.";

            if (string.IsNullOrWhiteSpace(ban.MaBan))
                return "Mã bàn không hợp lệ.";

            if (string.IsNullOrWhiteSpace(ban.SoBan))
                return "Số bàn không được để trống.";

            var existing = _banDAL.GetById(ban.MaBan);

            if (existing == null)
                return "Không tìm thấy bàn.";

            var trungSoBan = _banDAL.GetAll()
                .Any(x =>
                    x.MaBan != ban.MaBan &&
                    x.SoBan.Trim().ToLower()
                    == ban.SoBan.Trim().ToLower());

            if (trungSoBan)
                return "Số bàn đã tồn tại.";

            if (!TrangThaiHopLe(ban.TrangThai))
                return "Trạng thái bàn không hợp lệ.";

            ban.SoBan = ban.SoBan.Trim();

            return _banDAL.Update(ban)
                ? "Cập nhật bàn thành công."
                : "Cập nhật bàn thất bại.";
        }

        public string Delete(string maBan)
        {
            if (string.IsNullOrWhiteSpace(maBan))
                return "Mã bàn không hợp lệ.";

            var ban = _banDAL.GetById(maBan);

            if (ban == null)
                return "Không tìm thấy bàn.";

            if (ban.TrangThai == "Đang sử dụng")
                return "Không thể xóa bàn đang sử dụng.";

            try
            {
                return _banDAL.Delete(maBan)
                    ? "Xóa bàn thành công."
                    : "Xóa bàn thất bại.";
            }
            catch
            {
                return "Không thể xóa bàn vì đang được sử dụng trong dữ liệu hóa đơn.";
            }
        }

        private bool TrangThaiHopLe(string trangThai)
        {
            return trangThai == "Trống"
                || trangThai == "Đang sử dụng"
                || trangThai == "Đang bảo trì";
        }
    }
}