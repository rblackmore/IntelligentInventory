namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.Enums;
using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;
using ElectroCom.IntelligentInventory.SharedKernel;
using ElectroCom.IntelligentInventory.SharedKernel.Guards;

public class Product : Entity<int>
{
  private readonly List<Item> items = new ();

  private string categories = string.Empty;

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

  public CategoryList Categories
  {
    get { return (CategoryList)this.categories; }
    set { this.categories = value; }
  }

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

  public void AddCategories(params Category[] categories)
  {
    Guard.Against.Null(categories, nameof(categories));
    Guard.Against.NegativeOrZero(categories.Count(), nameof(categories));
    Guard.Against.AnyNull(categories, nameof(categories));

    this.Categories = this.Categories.AddCategories(categories);
  }
}
