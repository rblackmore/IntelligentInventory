namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;

using ElectroCom.IntelligentInventory.SharedKernel;
using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

public class Manufacturer : Entity<int>, IAggregateRoot
{
  private readonly List<Product> products = new ();

  public Manufacturer(
    int id,
    string name,
    string description)
    : base(id)
  {
    this.Name = name;
    this.Description = description;
  }

  public string Name { get; set; }

  public string Description { get; set; }

  public IEnumerable<Product> Products => this.products.AsReadOnly();
}
