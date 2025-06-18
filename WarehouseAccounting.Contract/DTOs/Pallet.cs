namespace WarehouseAccounting.Contract.DTOs;

public class Pallet : WarehouseFacility
{
    public override decimal Weight => (Boxes?.Sum(b => b.Weight) ?? 0) + 30;
    public override decimal Volume => Boxes?.Sum(b => b.Volume) + (Width * Height * Depth) ?? 0;
    public DateOnly? ExpirationDate => Boxes?.Min(b => b.ActualExpirationDate) ?? null;

    public IReadOnlyCollection<Box>? Boxes { get; set; }
}
