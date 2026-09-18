using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        [StringLength(20)]
        public string MaKH { get; set; }

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(15)]
        public string SDT { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        public int DiemTichLuy { get; set; }
    }
}