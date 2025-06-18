using Microsoft.EntityFrameworkCore;
using WarehouseAccounting.Contract.DTOs;
using WarehouseAccounting.Database.Context;
using WarehouseAccounting.Infrastructure.Interfaces;

namespace WarehouseAccounting.Infrastructure.Services;

public class WarehouseAccountingService
    (IDbContextFactory<AppDbContext> dbContextFactory): IWarehouseAccountingService
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory = dbContextFactory;

    public async Task<IReadOnlyCollection<PalletsGroupedByExpirationDate>> GetPallets()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        var pallets = context.Pallets.Include(x => x.Boxes).AsNoTracking().ToArray();

        var groupedPallets = pallets
            .Where(x => x.ExpirationDate.HasValue)
            .GroupBy(x => x.ExpirationDate)
            .OrderBy(x => x.Key)
            .Select(x => new PalletsGroupedByExpirationDate
            {
                ExpirationDate = x.Key!.Value,
                Pallets = x.OrderBy(y => y.Weight).Select(x => new Pallet
                {
                    Id = x.Id,
                    Weight = x.Weight,
                    Depth = x.Depth,
                    Height = x.Height,
                    Width = x.Width,
                    Boxes = x.Boxes.Select(y => new Box
                    {
                        Id = y.Id,
                        Weight = y.Weight,
                        Depth = y.Depth,    
                        Height = y.Height,
                        Width = y.Width,
                        PalletId = y.PalletId,
                    }).ToArray()
                }).ToArray()
            }).ToArray();

        return groupedPallets;
    }
}
