namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.Specifications;

using System.Linq;

using Ardalis.Specification;

public class GetManufacturerByIdSpecification : Specification<Manufacturer>, ISingleResultSpecification
{
  public GetManufacturerByIdSpecification(int id)
  {
    this.Query.Where(m => m.Id == id);
  }
}
