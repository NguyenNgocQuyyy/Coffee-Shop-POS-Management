using Microsoft.EntityFrameworkCore.Migrations;

namespace Đồ_án_ngành.Migrations
{
    public partial class ThemGiaTriChiTietPhieuXuat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DonGia",
                table: "ChiTietPhieuXuat",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ThanhTien",
                table: "ChiTietPhieuXuat",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonGia",
                table: "ChiTietPhieuXuat");

            migrationBuilder.DropColumn(
                name: "ThanhTien",
                table: "ChiTietPhieuXuat");
        }
    }
}
