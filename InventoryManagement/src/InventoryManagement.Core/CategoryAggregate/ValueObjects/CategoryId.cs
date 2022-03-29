namespace InventoryManagement.Core.CategoryAggregate.ValueObjects;

using System;

using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.BaseClasses;

public class CategoryId : SingleValueObject<int, CategoryId>
{
  protected override void Validate()
  {
    Guard.Against.Negative(this.Value, nameof(this.Value));
  }
}
