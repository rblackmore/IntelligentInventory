namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;
using ElectroCom.IntelligentInventory.SharedKernel;

public class Item : Entity<ItemId>
{
  public Item(
    ItemId id,
    SerialNumber serialNumber,
    int productId,
    DateCode dateCode)
    : base(id)
  {
    this.SerialNumber = Guard.Against.Null(serialNumber, nameof(serialNumber));

    this.DateCode = Guard.Against.Null(dateCode, nameof(dateCode));

    this.Product_Id = Guard.Against.NegativeOrZero(productId, nameof(productId));
  }

  private Item()
  {
    // EF Core.
  }

  public int Product_Id { get; private set; }

  public SerialNumber SerialNumber { get; private set; }

  public DateCode DateCode { get; private set; } = DateCode.None();

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
    this.DateCode = DateCode.None();
  }
}
