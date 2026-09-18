using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    [Table("Ban")]
    public class Ban
    {
        [Key]
        [StringLength(20)]
        public string MaBan { get; set; }

        [Required]
        [StringLength(20)]
        public string SoBan { get; set; }

        [Required]
        [StringLength(30)]
        public string TrangThai { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }
    }
}