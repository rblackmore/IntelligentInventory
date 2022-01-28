namespace ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

using Ardalis.Specification;

/// <summary>
/// Base repository interface <see cref="IRepository{T}"/>.
/// can be used to query and save instances of <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of entity being operated on by this repository.
/// Must be type of <see cref="IAggregateRoot"/>.</typeparam>
public interface IRepository<T> : IReadRepository<T>, IRepositoryBase<T>
  where T : class, IAggregateRoot
{
}
