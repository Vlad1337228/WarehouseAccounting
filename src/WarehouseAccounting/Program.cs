﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WarehouseAccounting.Contract.DTOs;
using WarehouseAccounting.Contract.Interfaces;
using WarehouseAccounting.Database.Context;
using WarehouseAccounting.Database.Extensions;
using WarehouseAccounting.Infrastructure.Interfaces;
using WarehouseAccounting.Infrastructure.Services;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

if (string.IsNullOrEmpty(configuration.GetConnectionString("WarehouseAccountingDb")))
{
    throw new ArgumentNullException("Не найдена строка подключения к БД");
}

var services = new ServiceCollection();
AddServices(services);

var serviceProvider = services.BuildServiceProvider();
using (var scope = serviceProvider.CreateScope())
{
    using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await DatabaseInitializer.Initialize(context);
    
    var warehouseAccountingService = scope.ServiceProvider.GetRequiredService<IWarehouseAccountingService>();
    
    // Задача 1
    var groupedPallets = await warehouseAccountingService.GetPalletsGroupedByExpirationDate();
    
    // Задача 2
    var top3Pallets = await warehouseAccountingService.GetTop3PalletsByBoxesExpiration();

    await context.Database.EnsureDeletedAsync();

    // Вывод в консоль
    var outputDispatcher = serviceProvider.GetRequiredService<IOutputDispatcher>();
    await outputDispatcher.OutputObject(groupedPallets);
    await outputDispatcher.OutputObject(top3Pallets);
}

void AddServices(IServiceCollection services)
{
    services.AddDbContextFactory<AppDbContext>(opt =>
    {
        opt.UseNpgsql(configuration.GetConnectionString("WarehouseAccountingDb"));
    });

    services.AddScoped<IWarehouseAccountingService, WarehouseAccountingService>();
    services.AddScoped<IOutputDispatcher, OutputDispatcher>();
    services.AddTransient<IOutputhHandler<IReadOnlyCollection<Pallet>>, OutputPallets>();
    services.AddTransient<IOutputhHandler<IReadOnlyCollection<PalletsGroupedByExpirationDate>>, OutputPalletsGroupedByExpirationDate>();
}