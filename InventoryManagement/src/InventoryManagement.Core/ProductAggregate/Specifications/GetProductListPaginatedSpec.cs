namespace InventoryManagement.Core.ProductAggregate.Specifications;

using Ardalis.Specification;

public class GetProductListPaginatedSpec : Specification<Product>
{
  private const int MINPageSize = 5;
  private const int MAXPageSize = 20;

  public GetProductListPaginatedSpec(int pageNo, int pageSize)
  {
    pageSize = pageSize < MINPageSize ? MINPageSize
      : pageSize > MAXPageSize ? MAXPageSize
      : pageSize;

    int skip = (pageNo - 1) * pageSize;

    this.Query.Include(p => p.Categories);

    this.Query.AsNoTracking()
      .Skip(skip)
      .Take(pageSize);
  }
}
