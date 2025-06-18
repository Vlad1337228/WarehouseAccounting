using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WarehouseAccounting.Database.Models;

namespace WarehouseAccounting.Database.Context;

public class AppDbContext(DbContextOptions<AppDbContext> optionsBuilder) : DbContext(optionsBuilder)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WarehouseFacility>(entity =>
        {
            entity.ToTable("WarehouseFacility");
            entity.Ignore(x => x.Weight);

            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Pallet>(entity =>
        {
            entity.ToTable("Pallets");
            entity.Ignore(x => x.Weight);
            entity.Ignore(x => x.Volume);
            entity.Ignore(x => x.ExpirationDate);
        });

        modelBuilder.Entity<Box>(entity =>
        {
            entity.ToTable("Boxes", t =>
            {
                //t.HasCheckConstraint("CK_Box_Dates", "ProductionDate IS NOT NULL OR ExpirationDate IS NOT NULL");
            });

            entity.Ignore(x => x.Volume);
            entity.Ignore(x => x.ActualExpirationDate);

        });

        modelBuilder.Entity<Box>()
            .HasOne(b => b.Pallet)
            .WithMany(p => p.Boxes)
            .HasForeignKey(b => b.PalletId);
    }

    public DbSet<Pallet> Pallets { get; set; }

    public DbSet<WarehouseFacility> WarehouseFacilitys { get; set; }
    public DbSet<Box> Boxes { get; set; }
}
