namespace sapatimro.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Judge")]
    public partial class Judge
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Judge()
        {
            Saqme = new HashSet<Saqme>();
        }

        [Key]
        public int judge_id { get; set; }

        [Required]
        [StringLength(50)]
        public string judge_login { get; set; }

        [Required]
        [StringLength(50)]
        public string judge_passwd { get; set; }

        [Required]
        [StringLength(250)]
        public string judge_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Saqme> Saqme { get; set; }
    }
}
