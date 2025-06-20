namespace WarehouseAccounting.Contract.Interfaces;

public interface IOutputhHandler<T>
{
    Task OutputObject(T obj, bool insertEndString = true);
}
