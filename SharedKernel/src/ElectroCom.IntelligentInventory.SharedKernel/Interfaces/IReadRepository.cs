namespace ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

public interface IReadRepository<T>
  where T : Entity<T>, IAggregateRoot
{
  // TODO: Add Methods that accept a Specificaiton Param. (Implement Specifications first).

  /// <summary>
  /// Finds an entity of type <typeparamref name="T"/> with the given primary key value.
  /// </summary>
  /// <typeparam name="TId">The type of the primary key.</typeparam>
  /// <param name="id">The value of the primary key.</param>
  /// <param name="cancellationToken">Cancellation token.</param>
  /// <returns>A task that represents the asynchronous operation.
  /// The task result contains a single matching entity of type <typeparamref name="T"/> or null if not found.</returns>
  Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default)
    where TId : notnull;

  /// <summary>
  /// Finds all entities of <typeparamref name="T"/> from the data store.
  /// </summary>
  /// <param name="cancellationToken">Cancellation Token.</param>
  /// <returns>A task that represents the asynchronous operation.
  /// The task result contains a <see cref="List{T}"/> that contains all entities from the data store.</returns>
  Task<List<T>> ListAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Returns the total number of records in the data store.
  /// </summary>
  /// <param name="cancellationToken">Cancelation Token.</param>
  /// <returns>A task that represents the asynchronous operation.
  /// The task result contains the number of elements in the data store.</returns>
  Task<int> CountAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Returns a boolean whether any entity exists or not.
  /// </summary>
  /// <param name="cancellationToken">Cancellation Token.</param>
  /// <returns>A task that represents the asynchronous operation.
  /// The task result contains true if any entity exists; otherwise, false.</returns>
  Task<bool> AnyAsync(CancellationToken cancellationToken = default);
}
