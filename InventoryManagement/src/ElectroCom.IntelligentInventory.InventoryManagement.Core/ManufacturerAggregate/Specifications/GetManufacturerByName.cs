namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.Specifications;

using Ardalis.Specification;

public class GetManufacturerByName : Specification<Manufacturer>
{
  public GetManufacturerByName(string name)
  {
    this.Query.Where(m => m.Name == name);
  }
}
