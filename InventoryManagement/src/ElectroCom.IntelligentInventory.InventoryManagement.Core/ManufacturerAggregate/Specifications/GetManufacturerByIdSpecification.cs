namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.Specifications;

using System.Linq;

using ElectroCom.IntelligentInventory.SharedKernel.Specifications;

public class GetManufacturerByIdSpecification : Specification<Manufacturer>, ISingleResultSpecification
{
  public GetManufacturerByIdSpecification(int id)
  {
    this.Where(m => m.Id == id);
  }
}
