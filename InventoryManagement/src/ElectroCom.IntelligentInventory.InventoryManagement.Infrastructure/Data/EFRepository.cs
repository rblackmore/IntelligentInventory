namespace ElectroCom.IntelligentInventory.InventoryManagement.Infrastructure.Data;

using ElectroCom.IntelligentInventory.SharedKernel.EntityFrameworkCore;
using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

public class EFRepository<T> : RepositoryBase<T>
  where T : class, IAggregateRoot
{
  public EFRepository(AppDbContext dbContext)
    : base(dbContext)
  {
  }
}
