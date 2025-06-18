using System;
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
            new Pallet
            {
                Id = 1,
                Width = 1000,
                Height = 20,
                Depth = 1000,
            },
            new Pallet
            {
                Id = 2,
                Width = 500,
                Height = 10,
                Depth = 500,
            },
            new Pallet
            {
                Id = 3,
                Width = 700,
                Height = 35,
                Depth = 700,
            },
        ]);

        await context.Boxes.AddRangeAsync([
            new Box
            {
                Id = 4,
                Depth = 400,
                Height = 350,
                Width = 350,
                PalletId = 1,
                ProductionDate = new DateOnly(2025, 3, 22),
                ExpirationDate = null,
                Weight = 100
            },
            new Box
            {
                Id = 5,
                Depth = 300,
                Height = 300,
                Width = 300,
                PalletId = 1,
                ProductionDate = new DateOnly(2025, 5, 21),
                ExpirationDate = null,
                Weight = 100
            },

            new Box
            {
                Id = 6,
                Depth = 450,
                Height = 320,
                Width = 280,
                PalletId = 2,
                ProductionDate = new DateOnly(2024, 3, 15),
                ExpirationDate = null,
                Weight = 4500
            },
            new Box
            {
                Id = 7,
                Depth = 120,
                Height = 80,
                Width = 90,
                PalletId = 1,
                ProductionDate = null,
                ExpirationDate = new DateOnly(2024, 8, 20),
                Weight = 1800
            },
            new Box
            {
                Id = 8,
                Depth = 750,
                Height = 600,
                Width = 500,
                PalletId = 3,
                ProductionDate = new DateOnly(2024, 1, 10),
                ExpirationDate = null,
                Weight = 8200
            },
            new Box
            {
                Id = 9,
                Depth = 300,
                Height = 200,
                Width = 250,
                PalletId = 1,
                ProductionDate = new DateOnly(2024, 5, 5),
                ExpirationDate = null,
                Weight = 3500
            },
            new Box
            {
                Id = 10,
                Depth = 600,
                Height = 400,
                Width = 350,
                PalletId = 2,
                ProductionDate = null,
                ExpirationDate = new DateOnly(2024, 11, 30),
                Weight = 7200
            },
            new Box
            {
                Id = 11,
                Depth = 150,
                Height = 100,
                Width = 120,
                PalletId = 3,
                ProductionDate = new DateOnly(2024, 2, 28),
                ExpirationDate = null,
                Weight = 2500
            },
            new Box
            {
                Id = 12,
                Depth = 900,
                Height = 700,
                Width = 800,
                PalletId = 1,
                ProductionDate = null,
                ExpirationDate = new DateOnly(2024, 10, 10),
                Weight = 9500
            },
            new Box
            {
                Id = 13,
                Depth = 200,
                Height = 150,
                Width = 180,
                PalletId = 2,
                ProductionDate = null,
                ExpirationDate = new DateOnly(2024, 12, 15),
                Weight = 3000
            },
            new Box
            {
                Id = 14,
                Depth = 350,
                Height = 250,
                Width = 300,
                PalletId = 3,
                ProductionDate = new DateOnly(2024, 6, 20),
                ExpirationDate = null,
                Weight = 4000
            },
            new Box
            {
                Id = 15,
                Depth = 500,
                Height = 450,
                Width = 400,
                PalletId = 1,
                ProductionDate = null,
                ExpirationDate = new DateOnly(2024, 12, 31),
                Weight = 6500
            },
            new Box
            {
                Id = 16,
                Depth = 100,
                Height = 100,
                Width = 100,
                PalletId = 1,
                ProductionDate = new DateOnly(2025, 1, 1),
                ExpirationDate = null,
                Weight = 100
            },
            new Box
            {
                Id = 17,
                Depth = 500,
                Height = 200,
                Width = 300,
                PalletId = 1,
                ProductionDate = new DateOnly(2025, 2, 15),
                ExpirationDate = null,
                Weight = 100
            },
            new Box
            {
                Id = 18,
                Depth = 300,
                Height = 300,
                Width = 300,
                PalletId = 1,
                ProductionDate = new DateOnly(2025, 2, 16),
                ExpirationDate = null,
                Weight = 100
            },
        ]);

        await context.SaveChangesAsync();
    }
}
