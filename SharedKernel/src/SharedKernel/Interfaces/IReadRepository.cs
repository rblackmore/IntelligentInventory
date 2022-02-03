namespace IntelligentInventory.SharedKernel.Interfaces;

using Ardalis.Specification;

public interface IReadRepository<T> : IReadRepositoryBase<T>
  where T : class, IAggregateRoot
{
}
