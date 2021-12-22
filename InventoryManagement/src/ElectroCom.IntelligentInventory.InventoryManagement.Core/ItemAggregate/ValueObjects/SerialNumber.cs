namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.ItemAggregate;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel;

public class SerialNumber : ValueObject
{
  public SerialNumber(string value)
  {
    this.Value = Guard.Against.NullOrEmpty(value, nameof(value));
  }

  public string Value { get; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return this.Value;
  }
}
