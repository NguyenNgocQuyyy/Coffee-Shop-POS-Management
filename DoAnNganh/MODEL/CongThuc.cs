using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    [Table("CongThuc")]
    public class CongThuc
    {
        [Required]
        [StringLength(20)]
        public string MaMon { get; set; }

        [Required]
        [StringLength(20)]
        public string MaNVL { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DinhLuong { get; set; }

        [ForeignKey(nameof(MaMon))]
        public virtual Mon Mon { get; set; }

        [ForeignKey(nameof(MaNVL))]
        public virtual NguyenVatLieu NguyenVatLieu { get; set; }
    }
}