using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WarehouseAccounting.Database.Models;

namespace WarehouseAccounting.Database.Context;

public class AppDbContext(DbContextOptions<AppDbContext> optionsBuilder) : DbContext(optionsBuilder)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WarehouseFacility>().ToTable("StorageItems");
        modelBuilder.Entity<Pallet>()
            .ToTable("Pallets")
            .Ignore(x => x.Weight)
            .Ignore(x => x.Volume)
            .Ignore(x => x.ExpirationDate);

        modelBuilder.Entity<Box>()
            .ToTable("Box", t => 
            {
                t.HasCheckConstraint("CK_Box_Dates", "ProductionDate IS NOT NULL OR ExpirationDate IS NOT NULL");
            })
            .Ignore(x => x.Volume)
            .Ignore(x => x.ActualExpirationDate);

        modelBuilder.Entity<Box>()
            .HasOne(b => b.Pallet)
            .WithMany(p => p.Boxes)
            .HasForeignKey(b => b.PalletId);
    }

    public DbSet<Pallet> Pallets { get; set; }
    public DbSet<Box> Boxes { get; set; }
}
