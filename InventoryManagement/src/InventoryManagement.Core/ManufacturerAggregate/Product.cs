namespace InventoryManagement.Core.ManufacturerAggregate;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel.BaseClasses;
using ElectroCom.IntelligentInventory.SharedKernel.Guards;

using InventoryManagement.Core.CategoryAggregate;
using InventoryManagement.Core.ManufacturerAggregate.Enums;
using InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

public class Product : Entity<int>
{
  private readonly List<Item> items = new();

  private readonly List<Category> categories = new();

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
    this.Manufacturer_id = Guard.Against.NegativeOrZero(manufacturer_id, nameof(manufacturer_id));
  }

  private Product()
  {
    // EF Core.
  }

  public int Manufacturer_id { get; private set; }

  public string Description { get; private set; }

  public ProductCode ProductCode { get; private set; }

  public Frequency Frequency { get; private set; } = Frequency.None;

  public IReadOnlyList<Item> Items => this.items.AsReadOnly();

  public IReadOnlyList<Category> Categories => this.categories.AsReadOnly();

  public void AddItem(Item newItem)
  {
    Guard.Against.Null(newItem, nameof(newItem));

    this.items.Add(newItem);
  }

  public void SetProductCode(ProductCode productCode)
  {
    this.ProductCode = Guard.Against.Null(productCode, nameof(productCode));
  }

  public void SetDescription(string description)
  {
    this.Description = Guard.Against.Null(description, nameof(description));
  }

  public void AddCategories(params Category[] categories)
  {
    Guard.Against.Null(categories, nameof(categories));
    Guard.Against.NegativeOrZero(categories.Count(), nameof(categories));
    Guard.Against.AnyNull(categories, nameof(categories));

    this.categories.AddRange(categories);
  }
}
