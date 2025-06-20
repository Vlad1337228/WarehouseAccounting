using WarehouseAccounting.Database.Context;
using WarehouseAccounting.Database.Models;

namespace WarehouseAccounting.Database.Extensions;

public static class DatabaseInitializer
{
    public static async Task Initialize(AppDbContext context)
    {
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        await context.Pallets.AddRangeAsync([
            new PalletEntity
            {
                Id = 1,
                Width = 1000,
                Height = 20,
                Depth = 1000,
            },
            new PalletEntity
            {
                Id = 2,
                Width = 500,
                Height = 10,
                Depth = 500,
            },
            new PalletEntity
            {
                Id = 3,
                Width = 700,
                Height = 35,
                Depth = 700,
            },
            new PalletEntity
            {
                Id = 4,
                Width = 600,
                Height = 45,
                Depth = 800,
            },
        ]);

        await context.Boxes.AddRangeAsync(new List<BoxEntity>()
        {
            new BoxEntity
            {
                Id = 5,
                Depth = 33,
                Height = 34,
                Width = 43,
                PalletId = 1,
                ProductionDate = new DateOnly(2025, 5, 21),
                ExpirationDate = null,
                Weight = 10
            },

            new BoxEntity
            {
                Id = 6,
                Depth = 54,
                Height = 65,
                Width = 76,
                PalletId = 2,
                ProductionDate = new DateOnly(2024, 3, 15),
                ExpirationDate = null,
                Weight = 45
            },
            new BoxEntity
            {
                Id = 7,
                Depth = 56,
                Height = 67,
                Width = 56,
                PalletId = 1,
                ProductionDate = null,
                ExpirationDate = new DateOnly(2024, 8, 20),
                Weight = 144
            },
            new BoxEntity
            {
                Id = 8,
                Depth = 56,
                Height = 34,
                Width = 23,
                PalletId = 3,
                ProductionDate = new DateOnly(2024, 1, 10),
                ExpirationDate = null,
                Weight = 51
            },
            new BoxEntity
            {
                Id = 9,
                Depth = 43,
                Height = 54,
                Width = 65,
                PalletId = 1,
                ProductionDate = new DateOnly(2024, 5, 5),
                ExpirationDate = null,
                Weight = 64
            },
            new BoxEntity
            {
                Id = 10,
                Depth = 65,
                Height = 23,
                Width = 34,
                PalletId = 2,
                ProductionDate = null,
                ExpirationDate = new DateOnly(2024, 11, 30),
                Weight = 75
            },
            new BoxEntity
            {
                Id = 11,
                Depth = 54,
                Height = 65,
                Width = 23,
                PalletId = 3,
                ProductionDate = new DateOnly(2024, 2, 28),
                ExpirationDate = null,
                Weight = 86.3M
            },
            new BoxEntity
            {
                Id = 12,
                Depth = 45,
                Height = 65,
                Width = 23,
                PalletId = 1,
                ProductionDate = null,
                ExpirationDate = new DateOnly(2024, 10, 10),
                Weight = 53.3M
            },
            new BoxEntity
            {
                Id = 13,
                Depth = 34,
                Height = 54,
                Width = 65,
                PalletId = 2,
                ProductionDate = null,
                ExpirationDate = new DateOnly(2024, 12, 15),
                Weight = 34
            },
            new BoxEntity
            {
                Id = 14,
                Depth = 76,
                Height = 34,
                Width = 34,
                PalletId = 3,
                ProductionDate = new DateOnly(2024, 6, 20),
                ExpirationDate = null,
                Weight = 52
            },
            new BoxEntity
            {
                Id = 15,
                Depth = 65,
                Height = 65,
                Width = 65,
                PalletId = 1,
                ProductionDate = null,
                ExpirationDate = new DateOnly(2024, 12, 31),
                Weight = 88
            },
            new BoxEntity
            {
                Id = 16,
                Depth = 54,
                Height = 43,
                Width = 53,
                PalletId = 1,
                ProductionDate = new DateOnly(2025, 1, 1),
                ExpirationDate = null,
                Weight = 56
            },
            new BoxEntity
            {
                Id = 17,
                Depth = 22,
                Height = 23,
                Width = 43,
                PalletId = 1,
                ProductionDate = new DateOnly(2025, 2, 15),
                ExpirationDate = null,
                Weight = 76
            },
            new BoxEntity
            {
                Id = 18,
                Depth = 34,
                Height = 54,
                Width = 65,
                PalletId = 1,
                ProductionDate = new DateOnly(2025, 2, 16),
                ExpirationDate = null,
                Weight = 87
            },
            new BoxEntity
            {
                Id = 19,
                Depth = 65,
                Height = 45,
                Width = 45,
                PalletId = 1,
                ProductionDate = new DateOnly(2025, 3, 22),
                ExpirationDate = null,
                Weight = 98
            },
            new BoxEntity
            {
                Id = 20,
                Depth = 98,
                Height = 78,
                Width = 46,
                PalletId = 4,
                ProductionDate = null,
                ExpirationDate = new DateOnly(2024, 8, 13),
                Weight = 23
            },
            new BoxEntity
            {
                Id = 21,
                Depth = 83,
                Height = 85,
                Width = 83,
                PalletId = 4,
                ProductionDate = new DateOnly(2025, 1, 6),
                ExpirationDate = null,
                Weight = 33
            },
        });

        await context.SaveChangesAsync();
    }
}
