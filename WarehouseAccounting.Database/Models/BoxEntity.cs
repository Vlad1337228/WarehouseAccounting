namespace WarehouseAccounting.Database.Models;

public class BoxEntity : WarehouseFacilityBaseEntity
{
    public override decimal Weight { get; set; }
    public DateOnly? ProductionDate { get; set; }
    public DateOnly? ExpirationDate { get; set; }
    public DateOnly? ActualExpirationDate => ExpirationDate ?? (ProductionDate?.AddDays(100));
    public override decimal Volume => Width * Height * Depth;

    public int PalletId { get; set; }
    public PalletEntity? Pallet { get; set; }
}
