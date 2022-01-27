namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.StaffAggregate.ValueObjects;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel.BaseClasses;

public class StaffId : ValueObject
{
  private StaffId(Guid value)
  {
    this.Value = Guard.Against.Default(value, nameof(value));
  }

  public Guid Value { get; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return this.Value;
  }

  public static StaffId Create()
  {
    return new StaffId(Guid.NewGuid());
  }

  public static StaffId CreateFrom(Guid value)
  {
    return new StaffId(value);
  }
}
