namespace InventoryManagement.Core.ManufacturerAggregate.Specifications;

using Ardalis.Specification;

using InventoryManagement.Core.ManufacturerAggregate;

public class GetManufacturerByName : Specification<Manufacturer>
{
  public GetManufacturerByName(string name)
  {
    this.Query.Where(m => m.Name == name);
  }
}
