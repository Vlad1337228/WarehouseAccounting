namespace WarehouseAccounting.Database.Models;

public abstract class WarehouseFacilityBaseEntity
{
    public int Id { get; set; }

    /// <summary>
    /// Ширина в сантиметрах.
    /// </summary>
    public decimal Width { get; set; }

    /// <summary>
    /// Высота в сантиметрах.
    /// </summary>
    public decimal Height { get; set; }

    /// <summary>
    /// Глубина в сантиметрах.
    /// </summary>
    public decimal Depth { get; set; }

    public abstract decimal Volume { get; }
}
