using Microsoft.EntityFrameworkCore.Migrations;

namespace Đồ_án_ngành.Migrations
{
    public partial class ThemQuyDoiDonViTopping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DonViTinhQuyDoi",
                table: "Topping",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HeSoQuyDoi",
                table: "Topping",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonViTinhQuyDoi",
                table: "Topping");

            migrationBuilder.DropColumn(
                name: "HeSoQuyDoi",
                table: "Topping");
        }
    }
}
