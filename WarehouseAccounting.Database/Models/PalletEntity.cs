using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseAccounting.Database.Models;

public class PalletEntity : WarehouseFacilityBaseEntity
{
    public decimal Weight => (Boxes?.Sum(b => b.Weight) ?? 0) + 30;
    public override decimal Volume => Boxes.Sum(b => b.Volume) + (Width * Height * Depth);
    public DateOnly? ExpirationDate => Boxes.Min(b => b.ActualExpirationDate) ?? null;


    public ICollection<BoxEntity> Boxes { get; set; } = [];
}
