namespace InventoryManagement.Core.ManufacturerAggregate.Specifications;
using System.Linq;

using Ardalis.Specification;

using InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

public class ManufacturerByIdIncludeProductsSpec : Specification<Manufacturer>, ISingleResultSpecification
{
  public ManufacturerByIdIncludeProductsSpec(ManufacturerId manufacturerId)
  {
    this.Query
      .Where(m => m.Id == manufacturerId)
      .Include(m => m.Products); // Includes ALL Products;
  }
}
