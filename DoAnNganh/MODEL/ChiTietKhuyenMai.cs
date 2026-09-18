using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    [Table("ChiTietKhuyenMai")]
    public class ChiTietKhuyenMai
    {
        [Required]
        [StringLength(30)]
        public string MaKhuyenMai { get; set; }

        [Required]
        [StringLength(20)]
        public string MaMon { get; set; }

        [ForeignKey(nameof(MaKhuyenMai))]
        public virtual KhuyenMai KhuyenMai { get; set; }

        [ForeignKey(nameof(MaMon))]
        public virtual Mon Mon { get; set; }
    }
}