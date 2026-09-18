using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    [Table("ChiTietPhieuNhap")]
    public class ChiTietPhieuNhap
    {
        [Key]
        [StringLength(20)]
        public string MaChiTietPN { get; set; }

        [Required]
        [StringLength(20)]
        public string MaPhieuNhap { get; set; }

        [StringLength(20)]
        public string MaNVL { get; set; }

        [StringLength(20)]
        public string MaTopping { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SoLuong { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DonGia { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ThanhTien { get; set; }

        [ForeignKey(nameof(MaPhieuNhap))]
        public virtual PhieuNhap PhieuNhap { get; set; }

        [ForeignKey(nameof(MaNVL))]
        public virtual NguyenVatLieu NguyenVatLieu { get; set; }

        [ForeignKey(nameof(MaTopping))]
        public virtual Topping Topping { get; set; }
    }
}