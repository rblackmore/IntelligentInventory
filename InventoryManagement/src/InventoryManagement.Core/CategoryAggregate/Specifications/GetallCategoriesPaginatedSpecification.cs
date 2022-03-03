namespace InventoryManagement.Core.CategoryAggregate.Specifications;

using System.Linq;

using Ardalis.Specification;

public class GetallCategoriesPaginatedSpecification : Specification<Category>
{
  public GetallCategoriesPaginatedSpecification(int pageNo, int pageSize)
  {
    this.Query
      .Skip((pageNo - 1) * pageSize)
      .Take(pageSize);
  }
}
