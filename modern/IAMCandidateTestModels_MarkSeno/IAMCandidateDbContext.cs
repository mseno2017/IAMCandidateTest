using Microsoft.EntityFrameworkCore;
using IAMCandidateTestModels_MarkSeno;

namespace IAMCandidateTestModels_MarkSeno
{
    public partial class IAMCandidateDbContext : DbContext
    {
        public IAMCandidateDbContext()
        {
        }

        public IAMCandidateDbContext(DbContextOptions<IAMCandidateDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Vegetable> Vegetables { get; set; }
        public virtual DbSet<Mineral> Minerals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.ToTable("Animal");
                entity.Property(e => e.CommonName).IsUnicode(false);
                entity.Property(e => e.TaxClass).IsUnicode(false);
                entity.Property(e => e.TaxPhylum).IsUnicode(false);
                entity.Property(e => e.TaxOrder).IsUnicode(false);
                entity.Property(e => e.TaxFamily).IsUnicode(false);
                entity.Property(e => e.TaxGenus).IsUnicode(false);
                entity.Property(e => e.TaxSpecies).IsUnicode(false);
            });

            modelBuilder.Entity<Mineral>(entity =>
            {
                entity.ToTable("Mineral");
            });

            modelBuilder.Entity<Vegetable>(entity =>
            {
                entity.ToTable("Vegetable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
