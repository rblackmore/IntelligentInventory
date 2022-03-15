namespace InventoryManagement.Core.ManufacturerAggregate;

using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.BaseClasses;
using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.ManufacturerAggregate.ValueObjects;
using InventoryManagement.Core.ProductAggregate;

public class Manufacturer : Entity<ManufacturerId>, IAggregateRoot
{
  private readonly List<Product> products = new();

  public Manufacturer(
    string name,
    string description)
  {
    this.Name = name;
    this.Description = description;
  }

  private Manufacturer()
  {
    // EF Core.
  }

  public string Name { get; set; }

  public string Description { get; set; }

  public IEnumerable<Product> Products => this.products.AsReadOnly();

  public void AddProduct(Product product)
  {
    Guard.Against.Null(product, nameof(product));

    this.products.Add(product);
  }
}
