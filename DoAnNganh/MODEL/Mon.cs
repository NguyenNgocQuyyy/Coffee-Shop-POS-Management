using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    [Table("Mon")]
    public class Mon
    {
        [Key]
        [StringLength(20)]
        public string MaMon { get; set; }

        [Required]
        [StringLength(100)]
        public string TenMon { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal GiaBan { get; set; }

        [Required]
        [StringLength(30)]
        public string TrangThai { get; set; }

        [Required]
        [StringLength(20)]
        public string MaDanhMuc { get; set; }

        [ForeignKey(nameof(MaDanhMuc))]
        public virtual DanhMuc DanhMuc { get; set; }

        public virtual ICollection<CongThuc> CongThucs { get; set; }
            = new List<CongThuc>();

        public virtual ICollection<ChiTietKhuyenMai> ChiTietKhuyenMais { get; set; }
            = new List<ChiTietKhuyenMai>();
    }
}