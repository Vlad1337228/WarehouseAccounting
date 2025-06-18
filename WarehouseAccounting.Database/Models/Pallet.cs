using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseAccounting.Database.Models;

public class Pallet : WarehouseFacility
{
    //public override decimal Weight => Boxes.Sum(b => b.Weight) + 30;
    public override decimal Volume => Boxes.Sum(b => b.Volume) + (Width * Height * Depth);
    public DateOnly? ExpirationDate => Boxes.Any() ? Boxes.Min(b => b.ActualExpirationDate) : null;


    public List<Box> Boxes { get; set; } = [];
}
