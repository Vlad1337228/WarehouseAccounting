using WarehouseAccounting.Tests.GetPalletsGroupedByExpirationDateTests;
using Xunit;
using Xunit.Abstractions;

namespace WarehouseAccounting.Tests.WarehouseAccountingServiceTests.Tests;

public class GetPalletsGroupedByExpirationDateTests
    (ITestOutputHelper testOutputHelper, ServiceFixture fixture) : WarehouseAccountingServiceTests_BaseService<ServiceFixture>(testOutputHelper, fixture)
{
    [Fact]
    public async Task GetPalletsGroupedByExpirationDate_4PalletsWithExpirationDateAnd1PalletWithout_SuccessfulResult()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        await GetPalletsGroupedByExpirationDateTests_4PalletsWithExpirationDateAnd1PalletWithout_3Groups_TestData(context);

        var result = await _warehouseAccountingService.GetPalletsGroupedByExpirationDate();

        Assert.Multiple(() =>
        {
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        });
    }
}
