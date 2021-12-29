namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.Enums;
using ElectroCom.IntelligentInventory.SharedKernel;

public class Product : Entity<int>
{
  private readonly List<Item> items = new ();

  public Product(
    int productid,
    int manufacturer_id,
    string description,
    ProductCode productCode,
    Frequency frequency = null!)
    : base(productid)
  {
    this.Manufacturer_id = Guard.Against.NegativeOrZero(manufacturer_id, nameof(manufacturer_id));
    this.Description = Guard.Against.Null(description, nameof(description));
    this.ProductCode = Guard.Against.Null(productCode, nameof(productCode));
    this.Frequency = frequency ?? Frequency.None;
  }

  public Product(int productid, int manufacturer_id)
  : base(productid)
  {
    this.Manufacturer_id = manufacturer_id;
  }

  public int Manufacturer_id { get; private set; }

  public string Description { get; private set; }

  public ProductCode ProductCode { get; private set; }

  public Frequency Frequency { get; private set; } = Frequency.None;

  public IEnumerable<Item> Items => this.items.AsReadOnly();

  public void AddItem(Item newItem)
  {
    Guard.Against.Null(newItem, nameof(newItem));

    this.items.Add(newItem);
  }

  public void UpdateProductCode(ProductCode productCode)
  {
    this.ProductCode = Guard.Against.Null(productCode, nameof(productCode));
  }

  public void UpdateDescription(string description)
  {
    this.Description = Guard.Against.Null(description, nameof(description));
  }
}
