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
    DateCode dateCode = null!)
    : base(id)
  {
    this.SerialNumber = Guard.Against.Null(serialNumber, nameof(serialNumber));

    this.DateCode = dateCode ?? new NullDateCode();
    this.Product_Id = productId;
  }

  public Item(ItemId id, int productid)
    : base(id)
  {
    this.Product_Id = productid;
  }

  public int Product_Id { get; private set; }

  public SerialNumber SerialNumber { get; private set; }

  public DateCode DateCode { get; private set; } = new NullDateCode();

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
    this.DateCode = new NullDateCode();
  }
}
