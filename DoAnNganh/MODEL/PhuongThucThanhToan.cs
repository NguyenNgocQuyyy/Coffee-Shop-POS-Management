using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    [Table("PhuongThucThanhToan")]
    public class PhuongThucThanhToan
    {
        [Key]
        [StringLength(20)]
        public string MaPhuongThuc { get; set; }

        [Required]
        [StringLength(50)]
        public string TenPhuongThuc { get; set; }

        public bool LaTienMat { get; set; }
    }
}