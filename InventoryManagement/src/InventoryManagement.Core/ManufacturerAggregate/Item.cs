namespace InventoryManagement.Core.ManufacturerAggregate;

using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.BaseClasses;

using InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

public class Item : Entity<ItemId>
{
  public Item(
    ItemId id,
    SerialNumber serialNumber,
    int productId,
    DateCode dateCode = null!)
    : base(id)
  {
    this.SerialNumber = Guard.Against.Null(serialNumber, nameof(serialNumber));

    this.DateCode = dateCode ?? DateCode.None;

    this.Product_Id = Guard.Against.NegativeOrZero(productId, nameof(productId));
  }

  private Item()
  {
    // EF Core.
  }

  public int Product_Id { get; private set; }

  public SerialNumber SerialNumber { get; private set; }

  public DateCode DateCode { get; private set; }

  public void SetSerialNumber(SerialNumber serialNumber)
  {
    this.SerialNumber = Guard.Against.Null(serialNumber, nameof(serialNumber));
  }

  public void SetDateCode(DateCode dateCode)
  {
    this.DateCode = Guard.Against.Null(dateCode, nameof(dateCode));
  }

  public void RemoveDateCode()
  {
    this.DateCode = DateCode.None;
  }
}
