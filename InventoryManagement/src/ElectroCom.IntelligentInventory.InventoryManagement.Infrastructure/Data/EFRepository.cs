namespace ElectroCom.IntelligentInventory.InventoryManagement.Infrastructure.Data;

using ElectroCom.IntelligentInventory.SharedKernel;
using ElectroCom.IntelligentInventory.SharedKernel.EntityFrameworkCore;
using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

public class EFRepository<T> : RepositoryBase<T>
  where T : Entity<T>, IAggregateRoot
{
  public EFRepository(AppDbContext dbContext)
    : base(dbContext)
  {
  }
}
