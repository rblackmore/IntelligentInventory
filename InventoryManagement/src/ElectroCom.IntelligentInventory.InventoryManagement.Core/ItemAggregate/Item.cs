namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.ItemAggregate;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel;
using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

public class Item : Entity<ItemId>, IAggregateRoot
{
  public Item(
    ItemId id,
    SerialNumber serialNumber,
    DateCode dateCode,
    int productId)
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

  public DateCode DateCode { get; private set; }

  public void SetSerialNumber(SerialNumber serialNumber)
  {
    this.SerialNumber = serialNumber;
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
