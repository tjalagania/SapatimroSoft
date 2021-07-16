namespace sapatimro.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Saqme")]
    public partial class Saqme
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Saqme()
        {
            Braldebuli = new HashSet<Braldebuli>();
        }

        [Key]
        public int saqme_id { get; set; }

        [Required]
        [StringLength(50)]
        public string saqme_nomeri { get; set; }

        public int judge_id { get; set; }

        public int mimdinare { get; set; }

        public string shedegi { get; set; }

        public DateTime? dasrulebi_tarigi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Braldebuli> Braldebuli { get; set; }

        public virtual Judge Judge { get; set; }
    }
}
