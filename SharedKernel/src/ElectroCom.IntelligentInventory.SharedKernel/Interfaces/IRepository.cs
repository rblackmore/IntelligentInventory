namespace ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

/// <summary>
/// Base repository interface <see cref="IRepository{T}"/> 
/// can be used to query and save instances of <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of entity being operated on by this repository.
/// Must be type of <see cref="IAggregateRoot"/>.</typeparam>
public interface IRepository<T> : IReadRepository<T>
  where T : class, IAggregateRoot
{
  /// <summary>
  /// Adds an entity in the data store.
  /// </summary>
  /// <param name="entity">The Entity to Add.</param>
  /// <param name="cancellationToken">Cancellation token.</param>
  /// <returns>
  /// A task the represents the asynchronous operaiton.
  /// The task result contains the <typeparamref name="T"/>.
  /// </returns>
  Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

  /// <summary>
  /// Updates an entity in the data store.
  /// </summary>
  /// <param name="entity">THe Entity to update.</param>
  /// <param name="cancellationToken">Cancellation Token.</param>
  /// <returns>A task that represents the asynchrounous operation.</returns>
  Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

  /// <summary>
  /// Removes an entity from the data store.
  /// </summary>
  /// <param name="entity">The Entity to remove.</param>
  /// <param name="cancellationToken">Cancellation Token.</param>
  /// <returns>A task that represents the asynchronous operation.</returns>
  Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

  /// <summary>
  /// Removes the given entities from the data store.
  /// </summary>
  /// <param name="entities">The entities to remove.</param>
  /// <param name="cancellationToken">Cancellation token.</param>
  /// <returns>A task that represents the asynchronous operation.</returns>
  Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

  /// <summary>
  /// Persists changes to the data store.
  /// </summary>
  /// <param name="cancellationToken">Cancellation Token.</param>
  /// <returns>
  /// A task that represents the asynchrnous operation.
  /// The task result contains the number of entities affected.
  /// </returns>
  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
