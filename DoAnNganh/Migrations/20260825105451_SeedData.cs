using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Đồ_án_ngành.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ban",
                columns: new[] { "MaBan", "GhiChu", "SoBan", "TrangThai" },
                values: new object[,]
                {
                    { "B001", null, "1", "Trống" },
                    { "B002", null, "2", "Trống" },
                    { "B003", "Kiểm tra bàn", "3", "Đang bảo trì" }
                });

            migrationBuilder.InsertData(
                table: "DanhMuc",
                columns: new[] { "MaDanhMuc", "TenDanhMuc" },
                values: new object[,]
                {
                    { "DM001", "Cà phê" },
                    { "DM002", "Trà sữa" },
                    { "DM003", "Trà" },
                    { "DM004", "Bánh" }
                });

            migrationBuilder.InsertData(
                table: "KhachHang",
                columns: new[] { "MaKH", "DiemTichLuy", "HoTen", "NgaySinh", "SDT" },
                values: new object[,]
                {
                    { "KH001", 20, "Nguyễn Văn A", new DateTime(2000, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "0900000001" },
                    { "KH002", 10, "Trần Thị B", new DateTime(2001, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "0900000002" }
                });

            migrationBuilder.InsertData(
                table: "KhuyenMai",
                columns: new[] { "MaKhuyenMai", "GhiChu", "GiaTriKhuyenMai", "LoaiKhuyenMai", "NgayBatDau", "NgayKetThuc", "TenKhuyenMai", "TrangThai" },
                values: new object[] { "KM001", null, 20m, "Phần trăm", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giảm 20% trà sữa", "Đang áp dụng" });

            migrationBuilder.InsertData(
                table: "NguyenVatLieu",
                columns: new[] { "MaNVL", "DonViTinh", "GhiChu", "MucCanhBao", "SoLuongTon", "TenNVL", "TrangThai" },
                values: new object[,]
                {
                    { "NVL004", "cái", null, 5m, 20m, "Bánh Tiramisu", "Còn hàng" },
                    { "NVL003", "g", null, 100m, 1000m, "Matcha", "Còn hàng" },
                    { "NVL002", "ml", null, 1000m, 10000m, "Sữa", "Còn hàng" },
                    { "NVL001", "g", null, 500m, 5000m, "Cà phê", "Còn hàng" }
                });

            migrationBuilder.InsertData(
                table: "NhaCungCap",
                columns: new[] { "MaNCC", "DiaChi", "Email", "SDT", "TenNCC" },
                values: new object[,]
                {
                    { "NCC001", "TP.HCM", "ncca@example.com", "0911111111", "Nhà cung cấp A" },
                    { "NCC002", "TP.HCM", "nccb@example.com", "0922222222", "Nhà cung cấp B" }
                });

            migrationBuilder.InsertData(
                table: "NhanVien",
                columns: new[] { "MaNV", "ChucVu", "MatKhau", "TenDangNhap" },
                values: new object[,]
                {
                    { "NV001", "Cashier 1", "123456", "Cash1" },
                    { "NV002", "Cashier 2", "123456", "Cash2" },
                    { "NV003", "Manager", "123456", "Manager" }
                });

            migrationBuilder.InsertData(
                table: "PhuongThucThanhToan",
                columns: new[] { "MaPhuongThuc", "LaTienMat", "TenPhuongThuc" },
                values: new object[,]
                {
                    { "PT01", true, "Tiền mặt" },
                    { "PT02", false, "Chuyển khoản" },
                    { "PT03", false, "Thẻ" }
                });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "MaTopping", "DonViTinh", "GiaBan", "MucCanhBao", "SoLuongTon", "TenTopping", "TrangThai" },
                values: new object[,]
                {
                    { "TP001", "phần", 10000m, 5, 30, "Pudding", "Đang bán" },
                    { "TP002", "phần", 8000m, 5, 40, "Thạch", "Đang bán" }
                });

            migrationBuilder.InsertData(
                table: "Mon",
                columns: new[] { "MaMon", "GiaBan", "MaDanhMuc", "TenMon", "TrangThai" },
                values: new object[,]
                {
                    { "M001", 25000m, "DM001", "Cà phê đen", "Đang bán" },
                    { "M002", 30000m, "DM001", "Cà phê sữa", "Đang bán" },
                    { "M003", 39000m, "DM002", "Matcha Latte", "Đang bán" },
                    { "M004", 35000m, "DM003", "Trà đào", "Đang bán" },
                    { "M005", 45000m, "DM004", "Tiramisu", "Đang bán" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B001");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B002");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B003");

            migrationBuilder.DeleteData(
                table: "KhachHang",
                keyColumn: "MaKH",
                keyValue: "KH001");

            migrationBuilder.DeleteData(
                table: "KhachHang",
                keyColumn: "MaKH",
                keyValue: "KH002");

            migrationBuilder.DeleteData(
                table: "KhuyenMai",
                keyColumn: "MaKhuyenMai",
                keyValue: "KM001");

            migrationBuilder.DeleteData(
                table: "Mon",
                keyColumn: "MaMon",
                keyValue: "M001");

            migrationBuilder.DeleteData(
                table: "Mon",
                keyColumn: "MaMon",
                keyValue: "M002");

            migrationBuilder.DeleteData(
                table: "Mon",
                keyColumn: "MaMon",
                keyValue: "M003");

            migrationBuilder.DeleteData(
                table: "Mon",
                keyColumn: "MaMon",
                keyValue: "M004");

            migrationBuilder.DeleteData(
                table: "Mon",
                keyColumn: "MaMon",
                keyValue: "M005");

            migrationBuilder.DeleteData(
                table: "NguyenVatLieu",
                keyColumn: "MaNVL",
                keyValue: "NVL001");

            migrationBuilder.DeleteData(
                table: "NguyenVatLieu",
                keyColumn: "MaNVL",
                keyValue: "NVL002");

            migrationBuilder.DeleteData(
                table: "NguyenVatLieu",
                keyColumn: "MaNVL",
                keyValue: "NVL003");

            migrationBuilder.DeleteData(
                table: "NguyenVatLieu",
                keyColumn: "MaNVL",
                keyValue: "NVL004");

            migrationBuilder.DeleteData(
                table: "NhaCungCap",
                keyColumn: "MaNCC",
                keyValue: "NCC001");

            migrationBuilder.DeleteData(
                table: "NhaCungCap",
                keyColumn: "MaNCC",
                keyValue: "NCC002");

            migrationBuilder.DeleteData(
                table: "NhanVien",
                keyColumn: "MaNV",
                keyValue: "NV001");

            migrationBuilder.DeleteData(
                table: "NhanVien",
                keyColumn: "MaNV",
                keyValue: "NV002");

            migrationBuilder.DeleteData(
                table: "NhanVien",
                keyColumn: "MaNV",
                keyValue: "NV003");

            migrationBuilder.DeleteData(
                table: "PhuongThucThanhToan",
                keyColumn: "MaPhuongThuc",
                keyValue: "PT01");

            migrationBuilder.DeleteData(
                table: "PhuongThucThanhToan",
                keyColumn: "MaPhuongThuc",
                keyValue: "PT02");

            migrationBuilder.DeleteData(
                table: "PhuongThucThanhToan",
                keyColumn: "MaPhuongThuc",
                keyValue: "PT03");

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "MaTopping",
                keyValue: "TP001");

            migrationBuilder.DeleteData(
                table: "Topping",
                keyColumn: "MaTopping",
                keyValue: "TP002");

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: "DM001");

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: "DM002");

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: "DM003");

            migrationBuilder.DeleteData(
                table: "DanhMuc",
                keyColumn: "MaDanhMuc",
                keyValue: "DM004");
        }
    }
}
