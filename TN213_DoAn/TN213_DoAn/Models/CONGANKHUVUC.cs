namespace TN213_DoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONGANKHUVUC")]
    public partial class CONGANKHUVUC
    {
        [Key]
        public int MACA { get; set; }

        public int? MAXP { get; set; }

        [Required]
        [StringLength(50)]
        public string TENCA { get; set; }

        [Required]
        [StringLength(20)]
        public string SDTCA { get; set; }

        public DbGeometry POINTCA { get; set; }

        [Column(TypeName = "text")]
        public string DIACHICA { get; set; }

        public virtual XAPHUONG XAPHUONG { get; set; }
    }
}
