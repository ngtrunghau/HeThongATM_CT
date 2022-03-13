namespace TN213_DoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [Key]
        public int MATK { get; set; }

        [Required]
        [StringLength(50)]
        public string TENTK { get; set; }

        [Required]
        [StringLength(10)]
        public string SDTTK { get; set; }

        [Required]
        [StringLength(50)]
        public string MATKHAU { get; set; }

        [Column("TAIKHOAN")]
        [Required]
        [StringLength(50)]
        public string TAIKHOAN1 { get; set; }
    }
}
