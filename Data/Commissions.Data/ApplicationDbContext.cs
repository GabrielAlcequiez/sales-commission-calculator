using Commissions.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Commissions.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Sales> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Commission).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Total_Sales).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Discount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Total_Commission).HasColumnType("decimal(18,2)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.Id_Country);
            });
        }
    }
}
