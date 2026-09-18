using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    [Table("ChiTietHoaDon")]
    public class ChiTietHoaDon
    {
        [Key]
        [StringLength(20)]
        public string MaChiTietHoaDon { get; set; }

        [Required]
        [StringLength(20)]
        public string MaHoaDon { get; set; }

        [StringLength(20)]
        public string MaMon { get; set; }

        [StringLength(20)]
        public string MaTopping { get; set; }

        public int SoLuong { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal GiaBan { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ThanhTien { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [ForeignKey(nameof(MaHoaDon))]
        public virtual HoaDon HoaDon { get; set; }

        [ForeignKey(nameof(MaMon))]
        public virtual Mon Mon { get; set; }

        [ForeignKey(nameof(MaTopping))]
        public virtual Topping Topping { get; set; }
    }
}