using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    [Table("DanhMuc")]
    public class DanhMuc
    {
        [Key]
        [StringLength(20)]
        public string MaDanhMuc { get; set; }

        [Required]
        [StringLength(100)]
        public string TenDanhMuc { get; set; }

        public virtual ICollection<Mon> Mons { get; set; } = new List<Mon>();
    }
}