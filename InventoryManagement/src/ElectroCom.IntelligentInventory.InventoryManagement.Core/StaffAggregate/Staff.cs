namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.StaffAggregate;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.StaffAggregate.ValueObjects;
using ElectroCom.IntelligentInventory.SharedKernel;
using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

public class Staff : Entity<StaffId>, IAggregateRoot
{
  public Staff(Name name)
  {
    this.Name = Guard.Against.Null(name, nameof(name));
  }

  private Staff()
  {
    // EF Core.
  }

  public Name Name { get; set; }
}
