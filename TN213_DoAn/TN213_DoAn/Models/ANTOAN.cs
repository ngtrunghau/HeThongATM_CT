namespace TN213_DoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ANTOAN")]
    public partial class ANTOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ANTOAN()
        {
            ATMs = new HashSet<ATM>();
        }

        [Key]
        public int MAAT { get; set; }

        [Required]
        [StringLength(15)]
        public string MUCDOAT { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string MOTAAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ATM> ATMs { get; set; }
    }
}
