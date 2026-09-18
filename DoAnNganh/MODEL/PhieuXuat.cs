using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL
{
    [Table("PhieuXuat")]
    public class PhieuXuat
    {
        [Key]
        [StringLength(20)]
        public string MaPhieuXuat { get; set; }

        public DateTime NgayXuat { get; set; }

        [Required]
        [StringLength(150)]
        public string LyDoXuat { get; set; }

        public bool LaHaoHut { get; set; }

        public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
            = new List<ChiTietPhieuXuat>();
    }
}