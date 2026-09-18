using Microsoft.EntityFrameworkCore.Migrations;

namespace Đồ_án_ngành.Migrations
{
    public partial class ThemQuyDoiDonViNguyenVatLieu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DonViTinhQuyDoi",
                table: "NguyenVatLieu",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HeSoQuyDoi",
                table: "NguyenVatLieu",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonViTinhQuyDoi",
                table: "NguyenVatLieu");

            migrationBuilder.DropColumn(
                name: "HeSoQuyDoi",
                table: "NguyenVatLieu");
        }
    }
}
