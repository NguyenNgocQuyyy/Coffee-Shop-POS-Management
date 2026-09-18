using Microsoft.EntityFrameworkCore.Migrations;

namespace Đồ_án_ngành.Migrations
{
    public partial class CapNhatChiTietHoaDonHoTroTopping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Cho phép MaMon null
            migrationBuilder.AlterColumn<string>(
                name: "MaMon",
                table: "ChiTietHoaDon",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            // 2. Thêm MaTopping
            migrationBuilder.AddColumn<string>(
                name: "MaTopping",
                table: "ChiTietHoaDon",
                maxLength: 20,
                nullable: true);

            // 3. Tạo index cho MaTopping
            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_MaTopping",
                table: "ChiTietHoaDon",
                column: "MaTopping");

            // 4. Tạo khóa ngoại tới Topping
            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_Topping_MaTopping",
                table: "ChiTietHoaDon",
                column: "MaTopping",
                principalTable: "Topping",
                principalColumn: "MaTopping",
                onDelete: ReferentialAction.Restrict);

            // 5. Mỗi dòng chỉ được là Món HOẶC Topping
            migrationBuilder.CreateCheckConstraint(
                name: "CK_ChiTietHoaDon_LoaiHang",
                table: "ChiTietHoaDon",
                sql: @"([MaMon] IS NOT NULL AND [MaTopping] IS NULL)
               OR
               ([MaMon] IS NULL AND [MaTopping] IS NOT NULL)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_Topping_MaTopping",
                table: "ChiTietHoaDon");

            migrationBuilder.DropCheckConstraint(
                name: "CK_ChiTietHoaDon_LoaiHang",
                table: "ChiTietHoaDon");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHoaDon_MaTopping",
                table: "ChiTietHoaDon");

            migrationBuilder.DropColumn(
                name: "MaTopping",
                table: "ChiTietHoaDon");

            // Khôi phục MaMon thành bắt buộc như cấu trúc cũ
            migrationBuilder.AlterColumn<string>(
                name: "MaMon",
                table: "ChiTietHoaDon",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
