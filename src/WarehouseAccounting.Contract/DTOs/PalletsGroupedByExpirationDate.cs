namespace WarehouseAccounting.Contract.DTOs;

public class PalletsGroupedByExpirationDate
{
    public DateOnly ExpirationDate { get; set; }

    public IReadOnlyCollection<Pallet> Pallets { get; set; } = [];
}
