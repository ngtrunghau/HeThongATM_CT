namespace TN213_DoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ATM")]
    public partial class ATM
    {
        [Key]
        public int MAATM { get; set; }

        public int MAXP { get; set; }

        public int MAAT { get; set; }

        [Required]
        [StringLength(100)]
        public string TENATM { get; set; }

        [StringLength(100)]
        public string DIACHIATM { get; set; }

        [StringLength(12)]
        public string SDTATM { get; set; }

        [StringLength(10)]
        public string MOCUAATM { get; set; }

        [StringLength(10)]
        public string DONGCUAATM { get; set; }

        public int? MANH { get; set; }

        public int? MAANH { get; set; }

        [Required]
        public DbGeometry POINTATM { get; set; }

        public virtual ANHATM ANHATM { get; set; }

        public virtual ANTOAN ANTOAN { get; set; }

        public virtual NGANHANG NGANHANG { get; set; }

        public virtual XAPHUONG XAPHUONG { get; set; }
    }
}
