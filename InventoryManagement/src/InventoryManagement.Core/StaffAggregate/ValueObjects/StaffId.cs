namespace InventoryManagement.Core.StaffAggregate.ValueObjects;

using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.BaseClasses;

public class StaffId : SingleValueObject<Guid, StaffId>
{
  protected override void Validate()
  {
    this.Value = Guard.Against.Default(this.Value, nameof(this.Value));
  }

  public static new StaffId New()
  {
    return From(Guid.NewGuid());
  }
}
