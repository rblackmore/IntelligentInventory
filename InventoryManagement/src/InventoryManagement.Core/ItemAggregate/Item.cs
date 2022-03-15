namespace InventoryManagement.Core.ItemAggregate;

using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.BaseClasses;
using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.ItemAggregate.ValueObjects;
using InventoryManagement.Core.ProductAggregate.ValueObjects;

public class Item : Entity<ItemId>, IAggregateRoot
{
  public Item(
    ItemId id,
    SerialNumber serialNumber,
    ProductId productId,
    DateCode dateCode = null!)
    : base(id)
  {
    SerialNumber = Guard.Against.Null(serialNumber, nameof(serialNumber));

    DateCode = dateCode ?? DateCode.None;

    Product_Id = Guard.Against.Null(productId, nameof(productId));
  }

  private Item()
  {
    // EF Core.
  }

  public ProductId Product_Id { get; private set; }

  public SerialNumber SerialNumber { get; private set; }

  public DateCode DateCode { get; private set; }

  public void SetSerialNumber(SerialNumber serialNumber)
  {
    SerialNumber = Guard.Against.Null(serialNumber, nameof(serialNumber));
  }

  public void SetDateCode(DateCode dateCode)
  {
    DateCode = Guard.Against.Null(dateCode, nameof(dateCode));
  }

  public void RemoveDateCode()
  {
    DateCode = DateCode.None;
  }
}
