namespace TN213_DoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUANHUYEN")]
    public partial class QUANHUYEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUANHUYEN()
        {
            XAPHUONGs = new HashSet<XAPHUONG>();
        }

        [Key]
        public int MAQH { get; set; }

        [Required]
        [StringLength(50)]
        public string TENQH { get; set; }

        public DbGeometry POLYGONQH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XAPHUONG> XAPHUONGs { get; set; }
    }
}
