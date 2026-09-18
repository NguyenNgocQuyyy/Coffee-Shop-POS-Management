using Microsoft.EntityFrameworkCore.Migrations;

namespace Đồ_án_ngành.Migrations
{
    public partial class CapNhatSoLuongTonToppingDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SoLuongTon",
                table: "Topping",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "MucCanhBao",
                table: "Topping",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Topping",
                keyColumn: "MaTopping",
                keyValue: "TP001",
                columns: new[] { "MucCanhBao", "SoLuongTon" },
                values: new object[] { 5m, 30m });

            migrationBuilder.UpdateData(
                table: "Topping",
                keyColumn: "MaTopping",
                keyValue: "TP002",
                columns: new[] { "MucCanhBao", "SoLuongTon" },
                values: new object[] { 5m, 40m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SoLuongTon",
                table: "Topping",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "MucCanhBao",
                table: "Topping",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Topping",
                keyColumn: "MaTopping",
                keyValue: "TP001",
                columns: new[] { "MucCanhBao", "SoLuongTon" },
                values: new object[] { 5, 30 });

            migrationBuilder.UpdateData(
                table: "Topping",
                keyColumn: "MaTopping",
                keyValue: "TP002",
                columns: new[] { "MucCanhBao", "SoLuongTon" },
                values: new object[] { 5, 40 });
        }
    }
}
