namespace InventoryManagement.Core.ProductAggregate.ValueObjects;

using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.BaseClasses;

public class ProductId : SingleValueObject<int, ProductId>
{
  protected override void Validate()
  {
    Guard.Against.NegativeOrZero(Value, nameof(Value));
  }
}
