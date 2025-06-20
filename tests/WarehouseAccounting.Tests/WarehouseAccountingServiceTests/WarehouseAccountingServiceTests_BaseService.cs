using Microsoft.EntityFrameworkCore;
using WarehouseAccounting.Database.Context;
using WarehouseAccounting.Database.Models;
using WarehouseAccounting.Infrastructure.Interfaces;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace WarehouseAccounting.Tests.GetPalletsGroupedByExpirationDateTests;

public class WarehouseAccountingServiceTests_BaseService<T> : TestBed<T> where T : TestBedFixture, IDisposable
{
    protected IDbContextFactory<AppDbContext> _dbContextFactory;
    protected IWarehouseAccountingService _warehouseAccountingService;

    public WarehouseAccountingServiceTests_BaseService(ITestOutputHelper testOutputHelper, T fixture) : 
        base(testOutputHelper, fixture)
    {
        _dbContextFactory = fixture.GetService<IDbContextFactory<AppDbContext>>(testOutputHelper)!;
        _warehouseAccountingService = fixture.GetService<IWarehouseAccountingService>(testOutputHelper)!;
    }

    public new void Dispose()
    {
        base.Dispose();
    }

    protected async Task GetPalletsGroupedByExpirationDateTests_4PalletsWithExpirationDateAnd1PalletWithout_3Groups_TestData(AppDbContext context)
    {
        var rnd = new Random();

        await context.Pallets.AddRangeAsync([
            new PalletEntity
            {
                Id = 1,
                Depth = rnd.Next(10, 500),
                Height = rnd.Next(10, 500),
                Width = rnd.Next(10, 500),
            },
            new PalletEntity
            {
                Id = 2,
                Depth = rnd.Next(10, 500),
                Height = rnd.Next(10, 500),
                Width = rnd.Next(10, 500),
            },
            new PalletEntity
            {
                Id = 3,
                Depth = rnd.Next(10, 500),
                Height = rnd.Next(10, 500),
                Width = rnd.Next(10, 500),
            },
            new PalletEntity
            {
                Id = 4,
                Depth = rnd.Next(10, 500),
                Height = rnd.Next(10, 500),
                Width = rnd.Next(10, 500),
            }
        ]);

        await context.Boxes.AddRangeAsync(
            [
                new BoxEntity
                {
                    Id = 5,
                    ExpirationDate = new DateOnly(2025, 2, 13),
                    ProductionDate = null,
                    Depth = rnd.Next(10, 500),
                    Height= rnd.Next(10, 500),
                    PalletId = 1,
                    Weight = rnd.Next(10, 500),
                    Width= rnd.Next(10, 500),
                },
                new BoxEntity
                {
                    Id = 6,
                    ExpirationDate = new DateOnly(2025, 1, 22),
                    ProductionDate = null,
                    Depth = rnd.Next(10, 500),
                    Height= rnd.Next(10, 500),
                    PalletId = 2,
                    Weight = rnd.Next(10, 500),
                    Width= rnd.Next(10, 500),
                },
                new BoxEntity
                {
                    Id = 7,
                    ExpirationDate = new DateOnly(2024, 4, 7),
                    ProductionDate = null,
                    Depth = rnd.Next(10, 500),
                    Height= rnd.Next(10, 500),
                    PalletId = 3,
                    Weight = rnd.Next(10, 500),
                    Width= rnd.Next(10, 500),
                },
                new BoxEntity
                {
                    Id = 8,
                    ExpirationDate = new DateOnly(2024, 11, 13),
                    ProductionDate = null,
                    Depth = rnd.Next(10, 500),
                    Height= rnd.Next(10, 500),
                    PalletId = 3,
                    Weight = rnd.Next(10, 500),
                    Width= rnd.Next(10, 500),
                },
            ]);

        await context.SaveChangesAsync();
    }

    protected async Task GetTop3PalletsByBoxesExpiration_4PalletsWithBoxesAnd1PalletWithout_SuccessfulResult_TestData(AppDbContext context)
    {
        var rnd = new Random();

        await context.Pallets.AddRangeAsync(
            [
                new PalletEntity
                {
                    Id = 1,
                    Depth = 5,
                    Height = 5,
                    Width = 5,
                },
                new PalletEntity
                {
                    Id = 2,
                    Depth = 4,
                    Height = 4,
                    Width = 4,
                },
                new PalletEntity
                {
                    Id = 3,
                    Depth = 3,
                    Height = 3,
                    Width = 3,
                },
                new PalletEntity
                {
                    Id = 4,
                    Depth = 2 ,
                    Height = 2,
                    Width = 2,
                },
                new PalletEntity
                {
                    Id = 5,
                    Depth = 1,
                    Height = 1,
                    Width = 1,
                }
            ]);


        await context.Boxes.AddRangeAsync(
            [
                new BoxEntity
                {
                    Id = 6,
                    Depth = 5,
                    Height = 5,
                    Weight = 5,
                    Width = 5,
                    ExpirationDate = null,
                    ProductionDate = new DateOnly(2025, 1, 1),
                    PalletId = 1
                },
                new BoxEntity
                {
                    Id = 7,
                    Depth = 4,
                    Height = 4,
                    Weight = 4,
                    Width = 4,
                    ExpirationDate = null,
                    ProductionDate = new DateOnly(2025, 2, 2),
                    PalletId = 2
                },
                new BoxEntity
                {
                    Id = 8,
                    Depth = 3,
                    Height = 3,
                    Weight = 3,
                    Width = 3,
                    ExpirationDate = new DateOnly(2025, 3, 3),
                    ProductionDate = null,
                    PalletId = 3
                },
                new BoxEntity
                {
                    Id = 9,
                    Depth = 2,
                    Height = 2,
                    Weight = 2,
                    Width = 2,
                    ExpirationDate = new DateOnly(2025, 4, 4),
                    ProductionDate = null,
                    PalletId = 4
                }
            ]);

        await context.SaveChangesAsync();
    }
}
