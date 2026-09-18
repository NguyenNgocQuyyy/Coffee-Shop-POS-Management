using Microsoft.EntityFrameworkCore.Migrations;

namespace Đồ_án_ngành.Migrations
{
    public partial class SeedCompositeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed CongThuc
            migrationBuilder.InsertData(
                table: "CongThuc",
                columns: new[] { "MaMon", "MaNVL", "DinhLuong" },
                values: new object[,]
                {
                    { "M001", "NVL001", 20m },
                    { "M002", "NVL001", 20m },
                    { "M002", "NVL002", 50m },
                    { "M003", "NVL003", 5m },
                    { "M003", "NVL002", 150m },
                    { "M005", "NVL004", 1m }
                });

            // Seed ChiTietKhuyenMai
            migrationBuilder.InsertData(
                table: "ChiTietKhuyenMai",
                columns: new[] { "MaKhuyenMai", "MaMon" },
                values: new object[,]
                {
                    { "KM001", "M003" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Xóa ChiTietKhuyenMai
            migrationBuilder.DeleteData(
                table: "ChiTietKhuyenMai",
                keyColumns: new[] { "MaKhuyenMai", "MaMon" },
                keyValues: new object[] { "KM001", "M003" });

            // Xóa CongThuc
            migrationBuilder.DeleteData(
                table: "CongThuc",
                keyColumns: new[] { "MaMon", "MaNVL" },
                keyValues: new object[] { "M001", "NVL001" });

            migrationBuilder.DeleteData(
                table: "CongThuc",
                keyColumns: new[] { "MaMon", "MaNVL" },
                keyValues: new object[] { "M002", "NVL001" });

            migrationBuilder.DeleteData(
                table: "CongThuc",
                keyColumns: new[] { "MaMon", "MaNVL" },
                keyValues: new object[] { "M002", "NVL002" });

            migrationBuilder.DeleteData(
                table: "CongThuc",
                keyColumns: new[] { "MaMon", "MaNVL" },
                keyValues: new object[] { "M003", "NVL003" });

            migrationBuilder.DeleteData(
                table: "CongThuc",
                keyColumns: new[] { "MaMon", "MaNVL" },
                keyValues: new object[] { "M003", "NVL002" });

            migrationBuilder.DeleteData(
                table: "CongThuc",
                keyColumns: new[] { "MaMon", "MaNVL" },
                keyValues: new object[] { "M005", "NVL004" });
        }
    }
}