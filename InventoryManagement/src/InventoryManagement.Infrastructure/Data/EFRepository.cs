namespace InventoryManagement.Infrastructure.Data;

using Ardalis.Specification.EntityFrameworkCore;

using IntelligentInventory.SharedKernel.Interfaces;

public class EFRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
  where T : class, IAggregateRoot
{
  public EFRepository(AppDbContext dbContext)
    : base(dbContext)
  {
  }
}
