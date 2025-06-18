using WarehouseAccounting.Contract.DTOs;

namespace WarehouseAccounting.Infrastructure.Interfaces;

public interface IWarehouseAccountingService
{
    Task<IReadOnlyCollection<PalletsGroupedByExpirationDate>> GetPallets();
}
