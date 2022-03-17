namespace InventoryManagement.API.Logging;

using Serilog.Core;
using Serilog.Events;

public class CollectionDestructurePolicy<T> : IDestructuringPolicy
{
  public bool TryDestructure(
    object value,
    ILogEventPropertyValueFactory propertyValueFactory,
    out LogEventPropertyValue result)
  {
    throw new NotImplementedException();
  }
}
