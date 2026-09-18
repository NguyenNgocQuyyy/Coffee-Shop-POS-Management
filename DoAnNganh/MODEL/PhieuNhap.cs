using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    [Table("PhieuNhap")]
    public class PhieuNhap
    {
        [Key]
        [StringLength(20)]
        public string MaPhieuNhap { get; set; }

        public DateTime NgayNhap { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TongTien { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [Required]
        [StringLength(20)]
        public string MaNCC { get; set; }

        [ForeignKey(nameof(MaNCC))]
        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
            = new List<ChiTietPhieuNhap>();
    }
}