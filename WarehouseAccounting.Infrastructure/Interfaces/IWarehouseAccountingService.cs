using WarehouseAccounting.Contract.DTOs;

namespace WarehouseAccounting.Infrastructure.Interfaces;

public interface IWarehouseAccountingService
{
    /// <summary>
    /// Сгруппированные паллеты по сроку годности, 
    /// отсортированные по возрастанию срока годности, 
    /// в каждой группе отсортированны паллеты по весу.
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyCollection<PalletsGroupedByExpirationDate>> GetPalletsGroupedByExpirationDate();

    /// <summary>
    /// 3 паллеты, которые содержат коробки с наибольшим сроком годности, отсортированные по возрастанию объема.
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyCollection<Pallet>> GetTop3PalletsByBoxesExpiration();
}
