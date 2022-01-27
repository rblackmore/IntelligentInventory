namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.Specifications;

using ElectroCom.IntelligentInventory.SharedKernel.Specifications;

public class GetManufacturerByName : Specification<Manufacturer>
{
  public GetManufacturerByName(string name)
  {
    this.Where(m => m.Name == name);
  }
}
