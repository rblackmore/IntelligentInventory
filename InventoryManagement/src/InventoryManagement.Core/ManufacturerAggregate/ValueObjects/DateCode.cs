namespace InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel.BaseClasses;

public class DateCode : ValueObject
{
  public DateCode(string value)
  {
    this.Value = Guard.Against.NullOrEmpty(value, nameof(value));
  }

  public string Value { get; }

  // Nullable.
  public static DateCode None =>
    new("None");

  public override string ToString()
  {
    return this.Value;
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return this.Value;
  }
}
