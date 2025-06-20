﻿using Microsoft.EntityFrameworkCore;
using WarehouseAccounting.Contract.DTOs;
using WarehouseAccounting.Database.Context;
using WarehouseAccounting.Infrastructure.Interfaces;

namespace WarehouseAccounting.Infrastructure.Services;

public class WarehouseAccountingService
    (IDbContextFactory<AppDbContext> dbContextFactory) : IWarehouseAccountingService
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory = dbContextFactory;

    /// <inheritdoc/>
    public async Task<IReadOnlyCollection<PalletsGroupedByExpirationDate>> GetPalletsGroupedByExpirationDate()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        // Плохо что in-memory
        var pallets = context.Pallets
            .Include(x => x.Boxes)
            .AsNoTracking()
            .ToArray()
            .Select(x => new Pallet
            {
                Id = x.Id,
                Depth = x.Depth,
                Height = x.Height,
                Width = x.Width,
                Boxes = x.Boxes.Select(y => new Box
                {
                    Id = y.Id,
                    Depth = y.Depth,
                    Height = y.Height,
                    Width = y.Width,
                    ExpirationDate = y.ExpirationDate,
                    ProductionDate = y.ProductionDate,
                    PalletId = y.Id,
                    Weight = y.Weight
                }).ToArray()
            }).ToArray();

        var groupedPallets = pallets
            .Where(x => x.ExpirationDate.HasValue)
            .GroupBy(x => x.ExpirationDate)
            .OrderBy(x => x.Key)
            .Select(x => new PalletsGroupedByExpirationDate
            {
                ExpirationDate = x.Key!.Value,
                Pallets = x.OrderBy(y => y.Weight).ToArray()
            }).ToArray();

        return groupedPallets;
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyCollection<Pallet>> GetTop3PalletsByBoxesExpiration()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        // Плохо что in-memory
        var data = await context.Pallets
            .Include(x => x.Boxes)
            .Where(x => x.Boxes.Any())
            .AsNoTracking()
            .ToArrayAsync();

        var result = data
            .Select(x => new Pallet
            {
                Id = x.Id,
                Depth = x.Depth,
                Height = x.Height,
                Width = x.Width,
                Boxes = x.Boxes.Select(y => new Box
                {
                    Id = y.Id,
                    Depth = y.Depth,
                    Height = y.Height,
                    Width = y.Width,
                    ExpirationDate = y.ExpirationDate,
                    ProductionDate = y.ProductionDate,
                    PalletId = y.Id,
                    Weight = y.Weight
                }).ToArray()
            })
            .OrderByDescending(x => x.Boxes.Max(y => y.ActualExpirationDate))
            .Take(3)
            .OrderBy(x => x.Volume)
            .ToArray();

        return result;
    }
}
