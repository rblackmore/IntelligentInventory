namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.CategoryAggregate;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;
using ElectroCom.IntelligentInventory.SharedKernel;
using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

public class Category : Entity<int>, IAggregateRoot
{
  public CategoryName CategoryName { get; private set; }
}
