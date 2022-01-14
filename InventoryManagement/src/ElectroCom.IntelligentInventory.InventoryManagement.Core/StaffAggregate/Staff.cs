namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.StaffAggregate;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.StaffAggregate.ValueObjects;
using ElectroCom.IntelligentInventory.SharedKernel;
using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

public class Staff : Entity<StaffId>, IAggregateRoot
{
  public string FirstName { get; set; }

  public string LastName { get; set; }
}
