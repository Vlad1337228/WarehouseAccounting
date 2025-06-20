using Microsoft.Extensions.DependencyInjection;
using System.Text;
using WarehouseAccounting.Contract.DTOs;
using WarehouseAccounting.Contract.Interfaces;
using WarehouseAccounting.Infrastructure.Interfaces;

namespace WarehouseAccounting.Infrastructure.Services;

public class OutputPalletsGroupedByExpirationDate
    (IServiceProvider serviceProvider) : IOutputhHandler<IReadOnlyCollection<PalletsGroupedByExpirationDate>>
{
    public async Task OutputObject(IReadOnlyCollection<PalletsGroupedByExpirationDate> groupedPallets, bool insertEndString = true)
    {
        var outputDispatcher = serviceProvider.GetRequiredService<IOutputDispatcher>();

        foreach (var group in groupedPallets)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nПаллеты со сроком годности: {group.ExpirationDate.ToString("dd-MM-yyyy")}");
            Console.ResetColor();

            await outputDispatcher.OutputObject(group.Pallets, false);
        }

        if (insertEndString)
            Console.WriteLine(string.Join("", [new string('-', 25), "ВЫВОД ОБЪЕКТА ЗАКОНЧЕН", new string('-', 25)]));
    }
}
