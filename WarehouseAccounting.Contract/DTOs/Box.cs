namespace WarehouseAccounting.Contract.DTOs;

public class Box : WarehouseFacility
{
    public override decimal Weight { get; set; }
    public DateOnly? ProductionDate { get; set; }
    public DateOnly? ExpirationDate { get; set; }
    public DateOnly? ActualExpirationDate => ExpirationDate ?? (ProductionDate?.AddDays(100));
    public override decimal Volume => Width * Height * Depth;
    public int PalletId { get; set; }
}
