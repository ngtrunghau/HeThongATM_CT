namespace TN213_DoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ANHATM")]
    public partial class ANHATM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ANHATM()
        {
            ATMs = new HashSet<ATM>();
        }

        [Key]
        public int MAANH { get; set; }

        [Required]
        [StringLength(50)]
        public string TENANH { get; set; }

        [Required]
        [StringLength(100)]
        public string URL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ATM> ATMs { get; set; }
    }
}
