using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WarehouseAccounting.Database.Context;
using WarehouseAccounting.Infrastructure.Interfaces;
using WarehouseAccounting.Infrastructure.Services;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace WarehouseAccounting.Tests.GetPalletsGroupedByExpirationDateTests;

public class ServiceFixture : TestBedFixture
{
    protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
    {
        services.AddDbContextFactory<AppDbContext>(opt =>
        {
            opt.UseInMemoryDatabase(databaseName: "Test_Db");
        });

        services.AddScoped<IWarehouseAccountingService, WarehouseAccountingService>();
    }

    protected override ValueTask DisposeAsyncCore()
    {
        return new ValueTask();
    }

    protected override IEnumerable<TestAppSettings> GetTestAppSettings()
    {
        yield return new()
        {
            Filename = "appsettings.Test.json",
            IsOptional = true
        };
    }
}
