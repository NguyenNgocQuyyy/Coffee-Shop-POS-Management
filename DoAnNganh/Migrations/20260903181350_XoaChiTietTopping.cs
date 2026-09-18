using Microsoft.EntityFrameworkCore.Migrations;

namespace Đồ_án_ngành.Migrations
{
    public partial class XoaChiTietTopping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietTopping");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiTietTopping",
                columns: table => new
                {
                    MaChiTietHoaDon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaTopping = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GiaBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietTopping", x => new { x.MaChiTietHoaDon, x.MaTopping });
                    table.ForeignKey(
                        name: "FK_ChiTietTopping_ChiTietHoaDon_MaChiTietHoaDon",
                        column: x => x.MaChiTietHoaDon,
                        principalTable: "ChiTietHoaDon",
                        principalColumn: "MaChiTietHoaDon",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietTopping_Topping_MaTopping",
                        column: x => x.MaTopping,
                        principalTable: "Topping",
                        principalColumn: "MaTopping",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietTopping_MaTopping",
                table: "ChiTietTopping",
                column: "MaTopping");
        }
    }
}
