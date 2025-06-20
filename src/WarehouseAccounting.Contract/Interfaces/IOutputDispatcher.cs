namespace WarehouseAccounting.Infrastructure.Interfaces;

public interface IOutputDispatcher
{
    Task OutputObject<T>(T obj, bool insertEndString = true);
}
