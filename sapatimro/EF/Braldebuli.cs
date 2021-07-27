namespace sapatimro.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Windows.Controls;

    [Table("Braldebuli")]
    public partial class Braldebuli
    {
        DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Braldebuli()
        {
            Arsebiti1 = new HashSet<Arsebiti>();
        }

        public static explicit operator Braldebuli(ItemCollection v)
        {
            throw new NotImplementedException();
        }

        [Key]
        public int braldebuli_id { get; set; }

        [Required]
        [StringLength(100)]
        public string braldebuli_sax { get; set; }

        [Required]
        [StringLength(100)]
        public string braldebuli_gv { get; set; }

        [StringLength(100)]
        public string brladebuli_msax { get; set; }

        public DateTime cinasasamartlo { get; set; }

        public DateTime? arsebiti { get; set; }

        public int saqme_id { get; set; }

        public DateTime gadasingva { get; set; }
        public string FullName
        {
            get
            {
                return $"{braldebuli_sax} {braldebuli_gv}";
            }
        }
        public string Shetkobinabe
        {
            get
            {
                return $"აღკვეთი ღონისძიების შესახებ გადაწყვეტილების მიღებიდან ორი თვის გასვლამდე დარჩენილია " +
                    $"{(gadasingva.Subtract(new DateTime(dt.Year, dt.Month, dt.Day))).Days} დღე";
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Arsebiti> Arsebiti1 { get; set; }

        public virtual Saqme Saqme { get; set; }
    }
}
