namespace sapatimro.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Arsebiti")]
    public partial class Arsebiti
    {
        [Key]
        public int arsebiti_id { get; set; }

        [Column("arsebiti")]
        public DateTime arsebiti1 { get; set; }

        public int braldebuli_id { get; set; }

        public virtual Braldebuli Braldebuli { get; set; }
    }
}
