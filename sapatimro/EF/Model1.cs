using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace sapatimro.EF
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Arsebiti> Arsebiti { get; set; }
        public virtual DbSet<Braldebuli> Braldebuli { get; set; }
        public virtual DbSet<Judge> Judge { get; set; }
        public virtual DbSet<Saqme> Saqme { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Braldebuli>()
                .HasMany(e => e.Arsebiti1)
                .WithRequired(e => e.Braldebuli)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Judge>()
                .HasMany(e => e.Saqme)
                .WithRequired(e => e.Judge)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Saqme>()
                .Property(e => e.saqme_nomeri)
                .IsUnicode(false);

            modelBuilder.Entity<Saqme>()
                .HasMany(e => e.Braldebuli)
                .WithRequired(e => e.Saqme)
                .WillCascadeOnDelete(false);
        }
    }
}
