namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.StaffAggregate;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel;

public class StaffId : ValueObject
{
  public StaffId(Guid value)
  {
    this.Value = Guard.Against.Default(value, nameof(value));
  }

  public Guid Value { get; set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return this.Value;
  }
}
