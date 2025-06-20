using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WarehouseAccounting.Database.Models;

namespace WarehouseAccounting.Database.Context;

public class AppDbContext(DbContextOptions<AppDbContext> optionsBuilder) : DbContext(optionsBuilder)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WarehouseFacilityBaseEntity>().UseTpcMappingStrategy();

        modelBuilder.Entity<PalletEntity>(entity =>
        {
            entity.ToTable("Pallets");
        });

        modelBuilder.Entity<BoxEntity>(entity =>
        {
            entity.ToTable("Boxes", t =>
            {
                t.HasCheckConstraint("CK_Box_Dates", "\"ProductionDate\" IS NOT NULL OR \"ExpirationDate\" IS NOT NULL");
            });
        });

        modelBuilder.Entity<BoxEntity>()
            .HasOne(b => b.Pallet)
            .WithMany(p => p.Boxes)
            .HasForeignKey(b => b.PalletId);
    }

    public DbSet<PalletEntity> Pallets { get; set; }
    public DbSet<WarehouseFacilityBaseEntity> WarehouseFacilitys { get; set; }
    public DbSet<BoxEntity> Boxes { get; set; }
}
