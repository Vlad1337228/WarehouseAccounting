using Microsoft.Extensions.DependencyInjection;
using WarehouseAccounting.Contract.Interfaces;
using WarehouseAccounting.Infrastructure.Interfaces;

namespace WarehouseAccounting.Infrastructure.Services;

public class OutputDispatcher
    (IServiceProvider serviceProvider) : IOutputDispatcher
{
    public async Task OutputObject<T>(T obj, bool insertEndString = true)
    {
        var handler = serviceProvider.GetService<IOutputhHandler<T>>();
        if (handler != null)
            await handler.OutputObject(obj, insertEndString);
    }
}
