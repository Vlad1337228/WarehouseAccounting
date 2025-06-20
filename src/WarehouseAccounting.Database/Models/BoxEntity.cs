namespace WarehouseAccounting.Database.Models;

public class BoxEntity : WarehouseFacilityBaseEntity
{
    public decimal Weight { get; set; }
    public DateOnly? ProductionDate { get; set; }
    public DateOnly? ExpirationDate { get; set; }
    public int PalletId { get; set; }
    public PalletEntity? Pallet { get; set; }
}
