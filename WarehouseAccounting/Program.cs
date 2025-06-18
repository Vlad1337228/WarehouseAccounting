using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WarehouseAccounting.Database.Context;
using WarehouseAccounting.Database.Extensions;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

if (string.IsNullOrEmpty(configuration.GetConnectionString("WarehouseAccountingDb")))
{
    throw new ArgumentNullException("Не найдена строка подключения к БД");
}

var services = new ServiceCollection();
services.AddDbContextFactory<AppDbContext>(opt =>
{
    opt.UseNpgsql(configuration.GetConnectionString("WarehouseAccountingDb"));
});

var serviceProvider = services.BuildServiceProvider();

using var scope = serviceProvider.CreateScope();

using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

await DatabaseInitializer.Initialize(context);



await context.Database.EnsureDeletedAsync();