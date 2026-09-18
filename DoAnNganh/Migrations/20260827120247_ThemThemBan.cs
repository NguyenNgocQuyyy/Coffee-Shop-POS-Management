using Microsoft.EntityFrameworkCore.Migrations;

namespace Đồ_án_ngành.Migrations
{
    public partial class ThemThemBan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ban",
                columns: new[] { "MaBan", "GhiChu", "SoBan", "TrangThai" },
                values: new object[,]
                {
                    { "B004", null, "4", "Trống" },
                    { "B028", null, "28", "Trống" },
                    { "B027", null, "27", "Trống" },
                    { "B026", null, "26", "Trống" },
                    { "B025", null, "25", "Trống" },
                    { "B024", null, "24", "Trống" },
                    { "B023", null, "23", "Trống" },
                    { "B022", null, "22", "Trống" },
                    { "B021", null, "21", "Trống" },
                    { "B020", null, "20", "Trống" },
                    { "B019", null, "19", "Trống" },
                    { "B018", null, "18", "Trống" },
                    { "B029", null, "29", "Trống" },
                    { "B017", null, "17", "Trống" },
                    { "B015", null, "15", "Trống" },
                    { "B014", null, "14", "Trống" },
                    { "B013", null, "13", "Trống" },
                    { "B012", null, "12", "Trống" },
                    { "B011", null, "11", "Trống" },
                    { "B010", null, "10", "Trống" },
                    { "B009", null, "9", "Trống" },
                    { "B008", null, "8", "Trống" },
                    { "B007", null, "7", "Trống" },
                    { "B006", null, "6", "Trống" },
                    { "B005", null, "5", "Trống" },
                    { "B016", null, "16", "Trống" },
                    { "B030", null, "30", "Trống" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B004");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B005");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B006");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B007");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B008");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B009");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B010");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B011");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B012");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B013");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B014");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B015");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B016");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B017");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B018");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B019");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B020");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B021");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B022");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B023");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B024");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B025");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B026");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B027");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B028");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B029");

            migrationBuilder.DeleteData(
                table: "Ban",
                keyColumn: "MaBan",
                keyValue: "B030");
        }
    }
}
