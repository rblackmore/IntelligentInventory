﻿namespace InventoryManagement.Core.CategoryAggregate;

using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.BaseClasses;
using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.CategoryAggregate.ValueObjects;
using InventoryManagement.Core.ManufacturerAggregate;

public class Category : Entity<CategoryId>, IAggregateRoot
{
  public Category(CategoryId categoryId, CategoryName categoryName)
    : base(categoryId)
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
