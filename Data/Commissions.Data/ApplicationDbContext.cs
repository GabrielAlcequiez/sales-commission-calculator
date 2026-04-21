using Commissions.Domain.Entities;
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

                entity.HasData(
                    new Country { Id = Guid.Parse("019349e5-8e2b-7000-a000-000000000001"), Name = "India", Commission = 10m, IsActive = true },
                    new Country { Id = Guid.Parse("019349e5-8e2b-7000-a000-000000000002"), Name = "Estados_Unidos", Commission = 15m, IsActive = true },
                    new Country { Id = Guid.Parse("019349e5-8e2b-7000-a000-000000000003"), Name = "Reino_Unido", Commission = 12m, IsActive = true }
                );
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

            // Convertir tablas y columnas a minúsculas (para PostgreSQL)
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.GetTableName()?.ToLower());

                foreach (var property in entityType.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName()?.ToLower());
                }

                foreach (var key in entityType.GetKeys())
                {
                    key.SetName(key.GetName()?.ToLower());
                }

                foreach (var foreignKey in entityType.GetForeignKeys())
                {
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName()?.ToLower());
                }

                foreach (var index in entityType.GetIndexes())
                {
                    index.SetDatabaseName(index.GetDatabaseName()?.ToLower());
                }
            }
        }
    }
}
