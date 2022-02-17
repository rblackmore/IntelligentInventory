namespace InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.BaseClasses;

public class ProductId : SingleValueObject<int, ProductId>
{
  protected override void Validate()
  {
    Guard.Against.NegativeOrZero(this.Value, nameof(this.Value));
  }
}
