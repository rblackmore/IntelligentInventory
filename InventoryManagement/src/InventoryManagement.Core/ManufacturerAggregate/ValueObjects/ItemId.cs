namespace InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel.BaseClasses;

using IntelligentInventory.SharedKernel.BaseClasses;

public class ItemId : SingleValueObject<Guid, ItemId>
{
  protected override void Validate()
  {
    Guard.Against.Default(this.Value, nameof(this.Value));
  }

  public static new ItemId New()
  {
    return From(Guid.NewGuid());
  }
}
