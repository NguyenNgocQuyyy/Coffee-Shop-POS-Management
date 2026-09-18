using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Đồ_án_ngành.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ban",
                columns: table => new
                {
                    MaBan = table.Column<string>(maxLength: 20, nullable: false),
                    SoBan = table.Column<string>(maxLength: 20, nullable: false),
                    TrangThai = table.Column<string>(maxLength: 30, nullable: false),
                    GhiChu = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ban", x => x.MaBan);
                });

            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    MaDanhMuc = table.Column<string>(maxLength: 20, nullable: false),
                    TenDanhMuc = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x.MaDanhMuc);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKH = table.Column<string>(maxLength: 20, nullable: false),
                    HoTen = table.Column<string>(maxLength: 100, nullable: false),
                    SDT = table.Column<string>(maxLength: 15, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: false),
                    DiemTichLuy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMai",
                columns: table => new
                {
                    MaKhuyenMai = table.Column<string>(maxLength: 30, nullable: false),
                    TenKhuyenMai = table.Column<string>(maxLength: 150, nullable: false),
                    LoaiKhuyenMai = table.Column<string>(maxLength: 50, nullable: false),
                    GiaTriKhuyenMai = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgayBatDau = table.Column<DateTime>(nullable: false),
                    NgayKetThuc = table.Column<DateTime>(nullable: false),
                    TrangThai = table.Column<string>(maxLength: 30, nullable: false),
                    GhiChu = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMai", x => x.MaKhuyenMai);
                });

            migrationBuilder.CreateTable(
                name: "NguyenVatLieu",
                columns: table => new
                {
                    MaNVL = table.Column<string>(maxLength: 20, nullable: false),
                    TenNVL = table.Column<string>(maxLength: 100, nullable: false),
                    SoLuongTon = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MucCanhBao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DonViTinh = table.Column<string>(maxLength: 20, nullable: false),
                    TrangThai = table.Column<string>(maxLength: 30, nullable: false),
                    GhiChu = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguyenVatLieu", x => x.MaNVL);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    MaNCC = table.Column<string>(maxLength: 20, nullable: false),
                    TenNCC = table.Column<string>(maxLength: 150, nullable: false),
                    SDT = table.Column<string>(maxLength: 15, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    DiaChi = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCap", x => x.MaNCC);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNV = table.Column<string>(maxLength: 20, nullable: false),
                    TenDangNhap = table.Column<string>(maxLength: 20, nullable: false),
                    MatKhau = table.Column<string>(maxLength: 100, nullable: false),
                    ChucVu = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNV);
                });

            migrationBuilder.CreateTable(
                name: "PhieuXuat",
                columns: table => new
                {
                    MaPhieuXuat = table.Column<string>(maxLength: 20, nullable: false),
                    NgayXuat = table.Column<DateTime>(nullable: false),
                    LyDoXuat = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuXuat", x => x.MaPhieuXuat);
                });

            migrationBuilder.CreateTable(
                name: "PhuongThucThanhToan",
                columns: table => new
                {
                    MaPhuongThuc = table.Column<string>(maxLength: 20, nullable: false),
                    TenPhuongThuc = table.Column<string>(maxLength: 50, nullable: false),
                    LaTienMat = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuongThucThanhToan", x => x.MaPhuongThuc);
                });

            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    MaTopping = table.Column<string>(maxLength: 20, nullable: false),
                    TenTopping = table.Column<string>(maxLength: 100, nullable: false),
                    GiaBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoLuongTon = table.Column<int>(nullable: false),
                    MucCanhBao = table.Column<int>(nullable: false),
                    DonViTinh = table.Column<string>(maxLength: 20, nullable: false),
                    TrangThai = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.MaTopping);
                });

            migrationBuilder.CreateTable(
                name: "Mon",
                columns: table => new
                {
                    MaMon = table.Column<string>(maxLength: 20, nullable: false),
                    TenMon = table.Column<string>(maxLength: 100, nullable: false),
                    GiaBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<string>(maxLength: 30, nullable: false),
                    MaDanhMuc = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mon", x => x.MaMon);
                    table.ForeignKey(
                        name: "FK_Mon_DanhMuc_MaDanhMuc",
                        column: x => x.MaDanhMuc,
                        principalTable: "DanhMuc",
                        principalColumn: "MaDanhMuc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhap",
                columns: table => new
                {
                    MaPhieuNhap = table.Column<string>(maxLength: 20, nullable: false),
                    NgayNhap = table.Column<DateTime>(nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GhiChu = table.Column<string>(maxLength: 100, nullable: true),
                    MaNCC = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhap", x => x.MaPhieuNhap);
                    table.ForeignKey(
                        name: "FK_PhieuNhap_NhaCungCap_MaNCC",
                        column: x => x.MaNCC,
                        principalTable: "NhaCungCap",
                        principalColumn: "MaNCC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(maxLength: 20, nullable: false),
                    NgayLap = table.Column<DateTime>(nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GiamGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TienKhachDua = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TienThoi = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrangThai = table.Column<string>(maxLength: 30, nullable: false),
                    GhiChu = table.Column<string>(maxLength: 100, nullable: true),
                    MaBan = table.Column<string>(maxLength: 20, nullable: true),
                    MaNV = table.Column<string>(maxLength: 20, nullable: false),
                    MaKH = table.Column<string>(maxLength: 20, nullable: true),
                    MaKhuyenMai = table.Column<string>(maxLength: 30, nullable: true),
                    MaPhuongThuc = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.MaHoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDon_Ban_MaBan",
                        column: x => x.MaBan,
                        principalTable: "Ban",
                        principalColumn: "MaBan",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhuyenMai_MaKhuyenMai",
                        column: x => x.MaKhuyenMai,
                        principalTable: "KhuyenMai",
                        principalColumn: "MaKhuyenMai",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDon_NhanVien_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDon_PhuongThucThanhToan_MaPhuongThuc",
                        column: x => x.MaPhuongThuc,
                        principalTable: "PhuongThucThanhToan",
                        principalColumn: "MaPhuongThuc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuXuat",
                columns: table => new
                {
                    MaChiTietPX = table.Column<string>(maxLength: 20, nullable: false),
                    MaPhieuXuat = table.Column<string>(maxLength: 20, nullable: false),
                    MaNVL = table.Column<string>(maxLength: 20, nullable: true),
                    MaTopping = table.Column<string>(maxLength: 20, nullable: true),
                    SoLuong = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuXuat", x => x.MaChiTietPX);
                    table.CheckConstraint("CK_ChiTietPhieuXuat_LoaiHang", @"([MaNVL] IS NOT NULL AND [MaTopping] IS NULL)
                    OR
                    ([MaNVL] IS NULL AND [MaTopping] IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuXuat_NguyenVatLieu_MaNVL",
                        column: x => x.MaNVL,
                        principalTable: "NguyenVatLieu",
                        principalColumn: "MaNVL",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuXuat_PhieuXuat_MaPhieuXuat",
                        column: x => x.MaPhieuXuat,
                        principalTable: "PhieuXuat",
                        principalColumn: "MaPhieuXuat",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuXuat_Topping_MaTopping",
                        column: x => x.MaTopping,
                        principalTable: "Topping",
                        principalColumn: "MaTopping",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietKhuyenMai",
                columns: table => new
                {
                    MaKhuyenMai = table.Column<string>(maxLength: 30, nullable: false),
                    MaMon = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietKhuyenMai", x => new { x.MaKhuyenMai, x.MaMon });
                    table.ForeignKey(
                        name: "FK_ChiTietKhuyenMai_KhuyenMai_MaKhuyenMai",
                        column: x => x.MaKhuyenMai,
                        principalTable: "KhuyenMai",
                        principalColumn: "MaKhuyenMai",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietKhuyenMai_Mon_MaMon",
                        column: x => x.MaMon,
                        principalTable: "Mon",
                        principalColumn: "MaMon",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CongThuc",
                columns: table => new
                {
                    MaMon = table.Column<string>(maxLength: 20, nullable: false),
                    MaNVL = table.Column<string>(maxLength: 20, nullable: false),
                    DinhLuong = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongThuc", x => new { x.MaMon, x.MaNVL });
                    table.ForeignKey(
                        name: "FK_CongThuc_Mon_MaMon",
                        column: x => x.MaMon,
                        principalTable: "Mon",
                        principalColumn: "MaMon",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CongThuc_NguyenVatLieu_MaNVL",
                        column: x => x.MaNVL,
                        principalTable: "NguyenVatLieu",
                        principalColumn: "MaNVL",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuNhap",
                columns: table => new
                {
                    MaChiTietPN = table.Column<string>(maxLength: 20, nullable: false),
                    MaPhieuNhap = table.Column<string>(maxLength: 20, nullable: false),
                    MaNVL = table.Column<string>(maxLength: 20, nullable: true),
                    MaTopping = table.Column<string>(maxLength: 20, nullable: true),
                    SoLuong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuNhap", x => x.MaChiTietPN);
                    table.CheckConstraint("CK_ChiTietPhieuNhap_LoaiHang", @"([MaNVL] IS NOT NULL AND [MaTopping] IS NULL)
                    OR
                    ([MaNVL] IS NULL AND [MaTopping] IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhap_NguyenVatLieu_MaNVL",
                        column: x => x.MaNVL,
                        principalTable: "NguyenVatLieu",
                        principalColumn: "MaNVL",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhap_PhieuNhap_MaPhieuNhap",
                        column: x => x.MaPhieuNhap,
                        principalTable: "PhieuNhap",
                        principalColumn: "MaPhieuNhap",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhap_Topping_MaTopping",
                        column: x => x.MaTopping,
                        principalTable: "Topping",
                        principalColumn: "MaTopping",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    MaChiTietHoaDon = table.Column<string>(maxLength: 20, nullable: false),
                    MaHoaDon = table.Column<string>(maxLength: 20, nullable: false),
                    MaMon = table.Column<string>(maxLength: 20, nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    GiaBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GhiChu = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDon", x => x.MaChiTietHoaDon);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_HoaDon_MaHoaDon",
                        column: x => x.MaHoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "MaHoaDon",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_Mon_MaMon",
                        column: x => x.MaMon,
                        principalTable: "Mon",
                        principalColumn: "MaMon",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietTopping",
                columns: table => new
                {
                    MaChiTietHoaDon = table.Column<string>(maxLength: 20, nullable: false),
                    MaTopping = table.Column<string>(maxLength: 20, nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    GiaBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GhiChu = table.Column<string>(maxLength: 100, nullable: true)
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
                name: "IX_Ban_SoBan",
                table: "Ban",
                column: "SoBan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_MaHoaDon",
                table: "ChiTietHoaDon",
                column: "MaHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_MaMon",
                table: "ChiTietHoaDon",
                column: "MaMon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietKhuyenMai_MaMon",
                table: "ChiTietKhuyenMai",
                column: "MaMon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhap_MaNVL",
                table: "ChiTietPhieuNhap",
                column: "MaNVL");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhap_MaPhieuNhap",
                table: "ChiTietPhieuNhap",
                column: "MaPhieuNhap");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhap_MaTopping",
                table: "ChiTietPhieuNhap",
                column: "MaTopping");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuXuat_MaNVL",
                table: "ChiTietPhieuXuat",
                column: "MaNVL");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuXuat_MaPhieuXuat",
                table: "ChiTietPhieuXuat",
                column: "MaPhieuXuat");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuXuat_MaTopping",
                table: "ChiTietPhieuXuat",
                column: "MaTopping");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietTopping_MaTopping",
                table: "ChiTietTopping",
                column: "MaTopping");

            migrationBuilder.CreateIndex(
                name: "IX_CongThuc_MaNVL",
                table: "CongThuc",
                column: "MaNVL");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMuc_TenDanhMuc",
                table: "DanhMuc",
                column: "TenDanhMuc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaBan",
                table: "HoaDon",
                column: "MaBan");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaKH",
                table: "HoaDon",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaKhuyenMai",
                table: "HoaDon",
                column: "MaKhuyenMai");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaNV",
                table: "HoaDon",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaPhuongThuc",
                table: "HoaDon",
                column: "MaPhuongThuc");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_SDT",
                table: "KhachHang",
                column: "SDT",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mon_MaDanhMuc",
                table: "Mon",
                column: "MaDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_Mon_TenMon",
                table: "Mon",
                column: "TenMon",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NguyenVatLieu_TenNVL",
                table: "NguyenVatLieu",
                column: "TenNVL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhaCungCap_SDT",
                table: "NhaCungCap",
                column: "SDT",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhaCungCap_TenNCC",
                table: "NhaCungCap",
                column: "TenNCC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_TenDangNhap",
                table: "NhanVien",
                column: "TenDangNhap",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhap_MaNCC",
                table: "PhieuNhap",
                column: "MaNCC");

            migrationBuilder.CreateIndex(
                name: "IX_Topping_TenTopping",
                table: "Topping",
                column: "TenTopping",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietKhuyenMai");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuNhap");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuXuat");

            migrationBuilder.DropTable(
                name: "ChiTietTopping");

            migrationBuilder.DropTable(
                name: "CongThuc");

            migrationBuilder.DropTable(
                name: "PhieuNhap");

            migrationBuilder.DropTable(
                name: "PhieuXuat");

            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "Topping");

            migrationBuilder.DropTable(
                name: "NguyenVatLieu");

            migrationBuilder.DropTable(
                name: "NhaCungCap");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "Mon");

            migrationBuilder.DropTable(
                name: "Ban");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "KhuyenMai");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "PhuongThucThanhToan");

            migrationBuilder.DropTable(
                name: "DanhMuc");
        }
    }
}
