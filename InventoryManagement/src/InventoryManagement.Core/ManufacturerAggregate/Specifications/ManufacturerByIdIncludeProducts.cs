namespace InventoryManagement.Core.ManufacturerAggregate.Specifications;
using System.Linq;

using Ardalis.Specification;

using InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

internal class ManufacturerByIdIncludeProducts : Specification<Manufacturer>, ISingleResultSpecification
{
  public ManufacturerByIdIncludeProducts(ManufacturerId manufacturerId, int pageNo, int pageSize)
  {
    this.Query
      .Where(m => m.Id == manufacturerId)
      .Include(m => m.Products); // Includes ALL Products;
  }
}
