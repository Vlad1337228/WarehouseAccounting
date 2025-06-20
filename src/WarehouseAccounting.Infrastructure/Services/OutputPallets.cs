using System.Text;
using WarehouseAccounting.Contract.DTOs;
using WarehouseAccounting.Contract.Interfaces;

namespace WarehouseAccounting.Infrastructure.Services;

public class OutputPallets : IOutputhHandler<IReadOnlyCollection<Pallet>>
{
    public async Task OutputObject(IReadOnlyCollection<Pallet> pallets, bool insertEndString = true)
    {
        foreach (var pallet in pallets)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nПаллета ID: {pallet.Id}");
            Console.ResetColor();

            Console.WriteLine($"Габариты: {pallet.Width}x{pallet.Height}x{pallet.Depth}");
            Console.WriteLine($"Вес: {pallet.Weight} кг");
            Console.WriteLine($"Объем: {pallet.Volume} см^3");
            Console.WriteLine($"Срок годности: {pallet.ExpirationDate?.ToString("dd-MM-yyyy") ?? "-"}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nКоробки:");
            Console.ResetColor();

            if (pallet.Boxes?.Any() == true) // pallet.Boxes?.Count > 0 - лучше так, т.к. это свойство
            {
                foreach (var box in pallet.Boxes)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine($"  ID: {box.Id}");
                    sb.AppendLine($"  Габариты: {box.Width}x{box.Height}x{box.Depth}");
                    sb.AppendLine($"  Вес: {box.Weight} кг");
                    sb.AppendLine($"  Объем: {box.Volume} см^3, {box.Volume / 1000000} м^3");
                    sb.AppendLine($"  Срок годности: {box.ActualExpirationDate?.ToString("dd-MM-yyyy") ?? "-"}");
                    Console.WriteLine(sb.ToString());
                }
            }
            else
            {
                Console.WriteLine("  Нет коробок");
            }

            Console.WriteLine(new string('-', 50));
        }

        if (insertEndString)
            Console.WriteLine(string.Join("", [new string('-', 25), "ВЫВОД ОБЪЕКТА ЗАКОНЧЕН", new string('-', 25)]));
    }
}
