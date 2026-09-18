using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    [Table("HoaDon")]
    public class HoaDon
    {
        [Key]
        [StringLength(20)]
        public string MaHoaDon { get; set; }

        public DateTime NgayLap { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TongTien { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal GiamGia { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ThanhTien { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TienKhachDua { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TienThoi { get; set; }

        [Required]
        [StringLength(30)]
        public string TrangThai { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [StringLength(20)]
        public string MaBan { get; set; }

        [Required]
        [StringLength(20)]
        public string MaNV { get; set; }

        [StringLength(20)]
        public string MaKH { get; set; }

        [StringLength(30)]
        public string MaKhuyenMai { get; set; }

        [StringLength(20)]
        public string MaPhuongThuc { get; set; }

        [ForeignKey(nameof(MaBan))]
        public virtual Ban Ban { get; set; }

        [ForeignKey(nameof(MaNV))]
        public virtual NhanVien NhanVien { get; set; }

        [ForeignKey(nameof(MaKH))]
        public virtual KhachHang KhachHang { get; set; }

        [ForeignKey(nameof(MaKhuyenMai))]
        public virtual KhuyenMai KhuyenMai { get; set; }

        [ForeignKey(nameof(MaPhuongThuc))]
        public virtual PhuongThucThanhToan PhuongThucThanhToan { get; set; }

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
            = new List<ChiTietHoaDon>();
    }
}