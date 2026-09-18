using Microsoft.EntityFrameworkCore;
using System;

namespace MODEL
{
    public class AppDbContext : DbContext
    {
        // DBSET
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<Ban> Bans { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<Mon> Mons { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }
        public DbSet<ChiTietKhuyenMai> ChiTietKhuyenMais { get; set; }
        public DbSet<PhuongThucThanhToan> PhuongThucThanhToans { get; set; }

        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public DbSet<NguyenVatLieu> NguyenVatLieus { get; set; }
        public DbSet<CongThuc> CongThucs { get; set; }

        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

        public DbSet<PhieuXuat> PhieuXuats { get; set; }
        public DbSet<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }

        // KẾT NỐI SQL SERVER
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Data Source=.;
                    Initial Catalog=QuanLyQuanCaPhePOS;
                    Integrated Security=True;
                    TrustServerCertificate=True");
            }
        }

        // FLUENT API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. UNIQUE
            modelBuilder.Entity<NhanVien>()
                .HasIndex(x => x.TenDangNhap)
                .IsUnique();

            modelBuilder.Entity<Ban>()
                .HasIndex(x => x.SoBan)
                .IsUnique();

            modelBuilder.Entity<DanhMuc>()
                .HasIndex(x => x.TenDanhMuc)
                .IsUnique();

            modelBuilder.Entity<Mon>()
                .HasIndex(x => x.TenMon)
                .IsUnique();

            modelBuilder.Entity<Topping>()
                .HasIndex(x => x.TenTopping)
                .IsUnique();

            modelBuilder.Entity<KhachHang>()
                .HasIndex(x => x.SDT)
                .IsUnique();

            modelBuilder.Entity<NguyenVatLieu>()
                .HasIndex(x => x.TenNVL)
                .IsUnique();

            modelBuilder.Entity<NhaCungCap>()
                .HasIndex(x => x.TenNCC)
                .IsUnique();

            modelBuilder.Entity<NhaCungCap>()
                .HasIndex(x => x.SDT)
                .IsUnique();

            // 2. DANHMUC - MON            
            modelBuilder.Entity<Mon>()
                .HasOne(x => x.DanhMuc)
                .WithMany(x => x.Mons)
                .HasForeignKey(x => x.MaDanhMuc)
                .OnDelete(DeleteBehavior.Restrict);

            // 3. CONGTHUC
            modelBuilder.Entity<CongThuc>()
                .HasKey(x => new
                {
                    x.MaMon,
                    x.MaNVL
                });

            modelBuilder.Entity<CongThuc>()
                .HasOne(x => x.Mon)
                .WithMany(x => x.CongThucs)
                .HasForeignKey(x => x.MaMon)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CongThuc>()
                .HasOne(x => x.NguyenVatLieu)
                .WithMany(x => x.CongThucs)
                .HasForeignKey(x => x.MaNVL)
                .OnDelete(DeleteBehavior.Restrict);

            // 4. CHI TIẾT KHUYẾN MÃI
            modelBuilder.Entity<ChiTietKhuyenMai>()
                .HasKey(x => new
                {
                    x.MaKhuyenMai,
                    x.MaMon
                });

            modelBuilder.Entity<ChiTietKhuyenMai>()
                .HasOne(x => x.KhuyenMai)
                .WithMany(x => x.ChiTietKhuyenMais)
                .HasForeignKey(x => x.MaKhuyenMai)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChiTietKhuyenMai>()
                .HasOne(x => x.Mon)
                .WithMany(x => x.ChiTietKhuyenMais)
                .HasForeignKey(x => x.MaMon)
                .OnDelete(DeleteBehavior.Restrict);

            // 5. HÓA ĐƠN
            modelBuilder.Entity<HoaDon>()
                .HasOne(x => x.Ban)
                .WithMany()
                .HasForeignKey(x => x.MaBan)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HoaDon>()
                .HasOne(x => x.NhanVien)
                .WithMany()
                .HasForeignKey(x => x.MaNV)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HoaDon>()
                .HasOne(x => x.KhachHang)
                .WithMany()
                .HasForeignKey(x => x.MaKH)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HoaDon>()
                .HasOne(x => x.KhuyenMai)
                .WithMany()
                .HasForeignKey(x => x.MaKhuyenMai)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HoaDon>()
                .HasOne(x => x.PhuongThucThanhToan)
                .WithMany()
                .HasForeignKey(x => x.MaPhuongThuc)
                .OnDelete(DeleteBehavior.Restrict);

            // 6. CHI TIẾT HÓA ĐƠN
            modelBuilder.Entity<ChiTietHoaDon>()
                .HasOne(x => x.HoaDon)
                .WithMany(x => x.ChiTietHoaDons)
                .HasForeignKey(x => x.MaHoaDon)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChiTietHoaDon>()
                .HasOne(x => x.Mon)
                .WithMany()
                .HasForeignKey(x => x.MaMon)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChiTietHoaDon>()
                .HasOne(x => x.Topping)
                .WithMany()
                .HasForeignKey(x => x.MaTopping)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChiTietHoaDon>()
                .HasCheckConstraint(
                "CK_ChiTietHoaDon_LoaiHang",
                @"([MaMon] IS NOT NULL AND [MaTopping] IS NULL) OR ([MaMon] IS NULL AND [MaTopping] IS NOT NULL)");

            // 8. NHÀ CUNG CẤP - PHIẾU NHẬP           
            modelBuilder.Entity<PhieuNhap>()
                .HasOne(x => x.NhaCungCap)
                .WithMany(x => x.PhieuNhaps)
                .HasForeignKey(x => x.MaNCC)
                .OnDelete(DeleteBehavior.Restrict);

            // 9. CHI TIẾT PHIẾU NHẬP
            modelBuilder.Entity<ChiTietPhieuNhap>()
                .HasOne(x => x.PhieuNhap)
                .WithMany(x => x.ChiTietPhieuNhaps)
                .HasForeignKey(x => x.MaPhieuNhap)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChiTietPhieuNhap>()
                .HasOne(x => x.NguyenVatLieu)
                .WithMany()
                .HasForeignKey(x => x.MaNVL)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChiTietPhieuNhap>()
                .HasOne(x => x.Topping)
                .WithMany()
                .HasForeignKey(x => x.MaTopping)
                .OnDelete(DeleteBehavior.Restrict);


            // Mỗi dòng chỉ được nhập NVL HOẶC Topping
            modelBuilder.Entity<ChiTietPhieuNhap>()
                .HasCheckConstraint(
                    "CK_ChiTietPhieuNhap_LoaiHang",
                    @"([MaNVL] IS NOT NULL AND [MaTopping] IS NULL)
                    OR
                    ([MaNVL] IS NULL AND [MaTopping] IS NOT NULL)"
                );

            // 10. CHI TIẾT PHIẾU XUẤT
            modelBuilder.Entity<ChiTietPhieuXuat>()
                .HasOne(x => x.PhieuXuat)
                .WithMany(x => x.ChiTietPhieuXuats)
                .HasForeignKey(x => x.MaPhieuXuat)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChiTietPhieuXuat>()
                .HasOne(x => x.NguyenVatLieu)
                .WithMany()
                .HasForeignKey(x => x.MaNVL)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChiTietPhieuXuat>()
                .HasOne(x => x.Topping)
                .WithMany()
                .HasForeignKey(x => x.MaTopping)
                .OnDelete(DeleteBehavior.Restrict);


            // Mỗi dòng chỉ được xuất NVL HOẶC Topping
            modelBuilder.Entity<ChiTietPhieuXuat>()
                .HasCheckConstraint(
                    "CK_ChiTietPhieuXuat_LoaiHang",
                    @"([MaNVL] IS NOT NULL AND [MaTopping] IS NULL)
                    OR
                    ([MaNVL] IS NULL AND [MaTopping] IS NOT NULL)"
                );

            // 11. SEED DỮ LIỆU MẪU
            modelBuilder.Entity<NhanVien>().HasData(
                new NhanVien
                {
                    MaNV = "NV001",
                    TenDangNhap = "Cash1",
                    MatKhau = "123456",
                    ChucVu = "Cashier 1"
                },
                new NhanVien
                {
                    MaNV = "NV002",
                    TenDangNhap = "Cash2",
                    MatKhau = "123456",
                    ChucVu = "Cashier 2"
                },
                new NhanVien
                {
                    MaNV = "NV003",
                    TenDangNhap = "Manager",
                    MatKhau = "123456",
                    ChucVu = "Manager"
                }
            );

            var danhSachBan = new Ban[30];

            for (int i = 1; i <= 30; i++)
            {
                danhSachBan[i - 1] = new Ban
                {
                    MaBan = $"B{i:D3}",
                    SoBan = i.ToString(),
                    TrangThai = i == 3 ? "Đang bảo trì" : "Trống",
                    GhiChu = i == 3 ? "Kiểm tra bàn" : null
                };
            }

            modelBuilder.Entity<Ban>().HasData(danhSachBan);

            modelBuilder.Entity<DanhMuc>().HasData(
                new DanhMuc
                {
                    MaDanhMuc = "DM001",
                    TenDanhMuc = "Cà phê"
                },
                new DanhMuc
                {
                    MaDanhMuc = "DM002",
                    TenDanhMuc = "Trà sữa"
                },
                new DanhMuc
                {
                    MaDanhMuc = "DM003",
                    TenDanhMuc = "Trà"
                },
                new DanhMuc
                {
                    MaDanhMuc = "DM004",
                    TenDanhMuc = "Bánh"
                }
            );

            modelBuilder.Entity<Mon>().HasData(
                new Mon
                {
                    MaMon = "M001",
                    TenMon = "Cà phê đen",
                    GiaBan = 25000,
                    TrangThai = "Đang bán",
                    MaDanhMuc = "DM001"
                },
                new Mon
                {
                    MaMon = "M002",
                    TenMon = "Cà phê sữa",
                    GiaBan = 30000,
                    TrangThai = "Đang bán",
                    MaDanhMuc = "DM001"
                },
                new Mon
                {
                    MaMon = "M003",
                    TenMon = "Matcha Latte",
                    GiaBan = 39000,
                    TrangThai = "Đang bán",
                    MaDanhMuc = "DM002"
                },
                new Mon
                {
                    MaMon = "M004",
                    TenMon = "Trà đào",
                    GiaBan = 35000,
                    TrangThai = "Đang bán",
                    MaDanhMuc = "DM003"
                },
                new Mon
                {
                    MaMon = "M005",
                    TenMon = "Tiramisu",
                    GiaBan = 45000,
                    TrangThai = "Đang bán",
                    MaDanhMuc = "DM004"
                }
            );

            modelBuilder.Entity<Topping>().HasData(
                new Topping
                {
                    MaTopping = "TP001",
                    TenTopping = "Pudding",
                    GiaBan = 10000,
                    SoLuongTon = 30,
                    MucCanhBao = 5,
                    DonViTinh = "phần",
                    TrangThai = "Đang bán"
                },
                new Topping
                {
                    MaTopping = "TP002",
                    TenTopping = "Thạch",
                    GiaBan = 8000,
                    SoLuongTon = 40,
                    MucCanhBao = 5,
                    DonViTinh = "phần",
                    TrangThai = "Đang bán"
                }
            );

            modelBuilder.Entity<KhachHang>().HasData(
                new KhachHang
                {
                    MaKH = "KH001",
                    HoTen = "Nguyễn Văn A",
                    SDT = "0900000001",
                    NgaySinh = new DateTime(2000, 1, 15),
                    DiemTichLuy = 20
                },
                new KhachHang
                {
                    MaKH = "KH002",
                    HoTen = "Trần Thị B",
                    SDT = "0900000002",
                    NgaySinh = new DateTime(2001, 5, 20),
                    DiemTichLuy = 10
                }
            );

            modelBuilder.Entity<NguyenVatLieu>().HasData(
                new NguyenVatLieu
                {
                    MaNVL = "NVL001",
                    TenNVL = "Cà phê",
                    SoLuongTon = 5000,
                    MucCanhBao = 500,
                    DonViTinh = "g",
                    TrangThai = "Còn hàng",
                    GhiChu = null
                },
                new NguyenVatLieu
                {
                    MaNVL = "NVL002",
                    TenNVL = "Sữa",
                    SoLuongTon = 10000,
                    MucCanhBao = 1000,
                    DonViTinh = "ml",
                    TrangThai = "Còn hàng",
                    GhiChu = null
                },
                new NguyenVatLieu
                {
                    MaNVL = "NVL003",
                    TenNVL = "Matcha",
                    SoLuongTon = 1000,
                    MucCanhBao = 100,
                    DonViTinh = "g",
                    TrangThai = "Còn hàng",
                    GhiChu = null
                },
                new NguyenVatLieu
                {
                    MaNVL = "NVL004",
                    TenNVL = "Bánh Tiramisu",
                    SoLuongTon = 20,
                    MucCanhBao = 5,
                    DonViTinh = "cái",
                    TrangThai = "Còn hàng",
                    GhiChu = null
                }
            );

            modelBuilder.Entity<NhaCungCap>().HasData(
                new NhaCungCap
                {
                    MaNCC = "NCC001",
                    TenNCC = "Nhà cung cấp A",
                    SDT = "0911111111",
                    Email = "ncca@example.com",
                    DiaChi = "TP.HCM"
                },
                new NhaCungCap
                {
                    MaNCC = "NCC002",
                    TenNCC = "Nhà cung cấp B",
                    SDT = "0922222222",
                    Email = "nccb@example.com",
                    DiaChi = "TP.HCM"
                }
            );

            modelBuilder.Entity<PhuongThucThanhToan>().HasData(
                new PhuongThucThanhToan
                {
                    MaPhuongThuc = "PT01",
                    TenPhuongThuc = "Tiền mặt",
                    LaTienMat = true
                },
                new PhuongThucThanhToan
                {
                    MaPhuongThuc = "PT02",
                    TenPhuongThuc = "Chuyển khoản",
                    LaTienMat = false
                },
                new PhuongThucThanhToan
                {
                    MaPhuongThuc = "PT03",
                    TenPhuongThuc = "Thẻ",
                    LaTienMat = false
                }
            );

            modelBuilder.Entity<KhuyenMai>().HasData(
                new KhuyenMai
                {
                    MaKhuyenMai = "KM001",
                    TenKhuyenMai = "Giảm 20% trà sữa",
                    LoaiKhuyenMai = "Phần trăm",
                    GiaTriKhuyenMai = 20,
                    NgayBatDau = new DateTime(2026, 8, 1),
                    NgayKetThuc = new DateTime(2026, 12, 31),
                    TrangThai = "Đang áp dụng",
                    GhiChu = null
                }
            );
        }
    }
}