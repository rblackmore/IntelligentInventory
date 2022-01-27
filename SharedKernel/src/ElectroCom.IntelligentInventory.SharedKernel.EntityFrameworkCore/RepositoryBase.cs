namespace ElectroCom.IntelligentInventory.SharedKernel.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;
using ElectroCom.IntelligentInventory.SharedKernel.Specifications;

using Microsoft.EntityFrameworkCore;

public abstract class RepositoryBase<T> : IRepository<T>
  where T : class, IAggregateRoot
{
  private readonly DbContext dbContext;

  protected RepositoryBase(DbContext dbContext)
  {
    this.dbContext = dbContext;
  }

  /// <inheritdoc/>
  public async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default)
    where TId : notnull
  {
    return await this.dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<T?> GetBySpecAsync<TSpec>(TSpec specification, CancellationToken cancellationToken = default) 
    where TSpec : ISpecification<T>, ISingleResultSpecification
  {
    return await this.ApplySpecification(specification).FirstOrDefaultAsync();
  }

  /// <inheritdoc/>
  public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
  {
    return await this.dbContext.Set<T>().ToListAsync(cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<List<T>> ListAsync<TSpec>(TSpec specification, CancellationToken cancellationToken = default)
    where TSpec : ISpecification<T>
  {
    return await this.ApplySpecification(specification).ToListAsync(cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
  {
    return await this.dbContext.Set<T>().AnyAsync(cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<int> CountAsync(CancellationToken cancellationToken = default)
  {
    return await this.dbContext.Set<T>().CountAsync(cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
  {
    this.dbContext.Set<T>().Add(entity);

    await this.SaveChangesAsync(cancellationToken);

    return entity;
  }

  /// <inheritdoc/>
  public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
  {
    this.dbContext.Set<T>().Update(entity);

    await this.SaveChangesAsync(cancellationToken);
  }

  /// <inheritdoc/>
  public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
  {
    this.dbContext.Set<T>().Remove(entity);

    await this.SaveChangesAsync(cancellationToken);
  }

  /// <inheritdoc/>
  public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
  {
    this.dbContext.Set<T>().RemoveRange(entities);

    await this.SaveChangesAsync(cancellationToken);
  }

  /// <inheritdoc/>
  public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    return await this.dbContext.SaveChangesAsync(cancellationToken);
  }

  protected virtual IQueryable<T> ApplySpecification(ISpecification<T> specification)
  {
    return specification.GetQuery(this.dbContext.Set<T>().AsQueryable());
  }
}
