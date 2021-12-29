namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel;

public class DateCode : ValueObject
{
  public DateCode(string value)
  {
    this.Value = Guard.Against.NullOrEmpty(value, nameof(value));
  }

  public string Value { get; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return this.Value;
  }
}

public class NullDateCode : DateCode
{
  public NullDateCode()
    : base("None")
  {
  }
}
