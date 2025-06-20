using System.Linq;
using WarehouseAccounting.Tests.GetPalletsGroupedByExpirationDateTests;
using Xunit;
using Xunit.Abstractions;

namespace WarehouseAccounting.Tests.WarehouseAccountingServiceTests.Tests;

public class GetTop3PalletsByBoxesExpirationTests
    (ITestOutputHelper testOutputHelper, ServiceFixture fixture) : WarehouseAccountingServiceTests_BaseService<ServiceFixture>(testOutputHelper, fixture)
{
    // Просто в качестве примера сделал Theory с InlineData
    [Theory]
    [InlineData(1)]
    public async Task GetTop3PalletsByBoxesExpiration_4PalletsWithBoxesAnd1PalletWithout_SuccessfulResult(int number)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        await GetTop3PalletsByBoxesExpiration_4PalletsWithBoxesAnd1PalletWithout_SuccessfulResult_TestData(context);

        var result = await _warehouseAccountingService.GetTop3PalletsByBoxesExpiration();

        var volumes = result.Select(x => x.Volume);
        var orderedVolumes = volumes.OrderBy(x => x).ToArray();

        Assert.Multiple(() =>
        {
            Assert.NotNull(result);
            Assert.True(result.All(x => x.Boxes != null && x.Boxes.Any()));
            Assert.Equal(3, result.Count);
            Assert.True(orderedVolumes.SequenceEqual(volumes.OrderBy(x => x)));
        });
    }
}
