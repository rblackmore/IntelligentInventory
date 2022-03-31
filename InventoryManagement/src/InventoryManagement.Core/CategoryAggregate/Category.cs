namespace InventoryManagement.Core.CategoryAggregate;

using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.BaseClasses;
using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.CategoryAggregate.ValueObjects;
using InventoryManagement.Core.ProductAggregate;

public class Category : Entity<int>, IAggregateRoot
{
  public Category(int categoryId, CategoryName categoryName)
    : base(categoryId)
  {
    this.CategoryName = Guard.Against.Null(categoryName, nameof(categoryName));
  }

  public Category(CategoryName categoryName)
  {
    this.CategoryName = Guard.Against.Null(categoryName, nameof(categoryName));
  }

  private Category()
  {
    // EF.
  }

  public CategoryName CategoryName { get; set; }

  private IEnumerable<Product> Products { get; } = Enumerable.Empty<Product>();
}
