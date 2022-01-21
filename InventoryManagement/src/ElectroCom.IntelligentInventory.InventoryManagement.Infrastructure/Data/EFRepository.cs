namespace ElectroCom.IntelligentInventory.InventoryManagement.Infrastructure.Data;

using Ardalis.Specification.EntityFrameworkCore;

using ElectroCom.IntelligentInventory.SharedKernel;
using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

using Microsoft.EntityFrameworkCore;

public class EFRepository<T> : RepositoryBase<T>, IRepository<T>
  where T : Entity<T>, IAggregateRoot
{
  public EFRepository(DbContext dbContext)
        : base(dbContext)
  {
  }
}
