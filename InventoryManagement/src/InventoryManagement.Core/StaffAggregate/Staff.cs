namespace InventoryManagement.Core.StaffAggregate;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel.BaseClasses;
using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.StaffAggregate.ValueObjects;

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
