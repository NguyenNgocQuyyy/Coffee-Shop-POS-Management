using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    [Table("KhuyenMai")]
    public class KhuyenMai
    {
        [Key]
        [StringLength(30)]
        public string MaKhuyenMai { get; set; }

        [Required]
        [StringLength(150)]
        public string TenKhuyenMai { get; set; }

        [Required]
        [StringLength(50)]
        public string LoaiKhuyenMai { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal GiaTriKhuyenMai { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        [Required]
        [StringLength(30)]
        public string TrangThai { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        public virtual ICollection<ChiTietKhuyenMai> ChiTietKhuyenMais { get; set; }
            = new List<ChiTietKhuyenMai>();
    }
}