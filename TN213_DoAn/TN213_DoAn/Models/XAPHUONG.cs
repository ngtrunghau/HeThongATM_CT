namespace TN213_DoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XAPHUONG")]
    public partial class XAPHUONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XAPHUONG()
        {
            ATMs = new HashSet<ATM>();
            CONGANKHUVUCs = new HashSet<CONGANKHUVUC>();
        }

        [Key]
        public int MAXP { get; set; }

        public int? MAQH { get; set; }

        [Required]
        [StringLength(50)]
        public string TENXP { get; set; }

        public DbGeometry POLYGONXP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ATM> ATMs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONGANKHUVUC> CONGANKHUVUCs { get; set; }

        public virtual QUANHUYEN QUANHUYEN { get; set; }
    }
}
