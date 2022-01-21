namespace ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

using Ardalis.Specification;

public interface IReadRepository<T> : IReadRepositoryBase<T>
  where T : Entity<T>, IAggregateRoot
{
}
