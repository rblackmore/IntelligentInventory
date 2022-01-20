namespace ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

public interface IReadRepository<T>
  where T : class, IAggregateRoot
{
}
