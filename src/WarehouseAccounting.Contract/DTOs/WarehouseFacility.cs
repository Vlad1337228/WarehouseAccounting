namespace WarehouseAccounting.Contract.DTOs;

public abstract class WarehouseFacility
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

    /// <summary>
    /// Вес в килограммах.
    /// </summary>
    public virtual decimal Weight { get; set; }

    public abstract decimal Volume { get; }
}
