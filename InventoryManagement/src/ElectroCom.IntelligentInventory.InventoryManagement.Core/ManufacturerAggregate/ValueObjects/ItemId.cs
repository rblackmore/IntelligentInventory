namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel.BaseClasses;

public class ItemId : ValueObject
{
  private ItemId(Guid value)
  {
    this.Value = Guard.Against.Default(value, nameof(value));
  }

  public Guid Value { get; }

  public override string ToString()
  {
    return this.Value.ToString();
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return this.Value;
  }

  public static ItemId Create()
  {
    return new ItemId(Guid.NewGuid());
  }

  public static ItemId CreateFrom(Guid guid)
  {
    return new ItemId(guid);
  }
}
