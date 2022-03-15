namespace InventoryManagement.Core.ProductAggregate.ValueObjects;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.BaseClasses;

public class ProductCode : ValueObject
{
  public ProductCode(string value)
  {
    Value = Guard.Against.NullOrEmpty(value, nameof(value));
  }

  public string Value { get; private set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
