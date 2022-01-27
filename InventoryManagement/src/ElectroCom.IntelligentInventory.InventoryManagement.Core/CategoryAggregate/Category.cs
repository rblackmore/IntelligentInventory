namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.CategoryAggregate;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.CategoryAggregate.ValueObjects;
using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;
using ElectroCom.IntelligentInventory.SharedKernel.BaseClasses;
using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

public class Category : Entity<int>, IAggregateRoot
{
  public Category(CategoryName categoryName)
  {
    this.CategoryName = Guard.Against.Null(categoryName, nameof(categoryName));
  }

  private Category()
  {
    // EF Core.
  }

  public CategoryName CategoryName { get; private set; }

  private IEnumerable<Product> Products { get; } = Enumerable.Empty<Product>();
}
