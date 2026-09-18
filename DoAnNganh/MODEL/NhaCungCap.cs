using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    [Table("NhaCungCap")]
    public class NhaCungCap
    {
        [Key]
        [StringLength(20)]
        public string MaNCC { get; set; }

        [Required]
        [StringLength(150)]
        public string TenNCC { get; set; }

        [Required]
        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
            = new List<PhieuNhap>();
    }
}