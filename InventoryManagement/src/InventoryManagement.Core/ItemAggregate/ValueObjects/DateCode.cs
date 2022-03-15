namespace InventoryManagement.Core.ItemAggregate.ValueObjects;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.BaseClasses;

public class DateCode : ValueObject
{
  public DateCode(string value)
  {
    Value = Guard.Against.NullOrEmpty(value, nameof(value));
  }

  public string Value { get; }

  // Nullable.
  public static DateCode None =>
    new("None");

  public override string ToString()
  {
    return Value;
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
