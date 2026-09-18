using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    [Table("NguyenVatLieu")]
    public class NguyenVatLieu
    {
        [Key]
        [StringLength(20)]
        public string MaNVL { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNVL { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SoLuongTon { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MucCanhBao { get; set; }

        [Required]
        [StringLength(20)]
        public string DonViTinh { get; set; }

        [StringLength(20)]
        public string DonViTinhQuyDoi { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal HeSoQuyDoi { get; set; }

        [Required]
        [StringLength(30)]
        public string TrangThai { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        public virtual ICollection<CongThuc> CongThucs { get; set; }
            = new List<CongThuc>();
    }
}