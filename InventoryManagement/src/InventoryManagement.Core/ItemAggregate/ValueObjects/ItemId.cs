namespace InventoryManagement.Core.ItemAggregate.ValueObjects;

using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.BaseClasses;

public class ItemId : SingleValueObject<Guid, ItemId>
{
  protected override void Validate()
  {
    Guard.Against.Default(Value, nameof(Value));
  }

  public static new ItemId New()
  {
    return From(Guid.NewGuid());
  }
}
