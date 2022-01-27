namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel.BaseClasses;

public class ProductCode : ValueObject
{
  public ProductCode(string value)
  {
    this.Value = Guard.Against.NullOrEmpty(value, nameof(value));
  }

  public string Value { get; private set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return this.Value;
  }
}
