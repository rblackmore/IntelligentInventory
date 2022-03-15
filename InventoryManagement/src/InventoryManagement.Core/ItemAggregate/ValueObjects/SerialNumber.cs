namespace InventoryManagement.Core.ItemAggregate.ValueObjects;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.BaseClasses;

public class SerialNumber : ValueObject
{
  public SerialNumber(string value)
  {
    Value = Guard.Against.NullOrEmpty(value, nameof(value));
  }

  public string Value { get; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
