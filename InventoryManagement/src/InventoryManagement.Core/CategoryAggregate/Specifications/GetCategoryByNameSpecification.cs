namespace InventoryManagement.Core.CategoryAggregate.Specifications;

using Ardalis.Specification;

using InventoryManagement.Core.CategoryAggregate.ValueObjects;

public class GetCategoryByNameSpecification :
  Specification<Category>,
  ISingleResultSpecification<Category>
{
  public GetCategoryByNameSpecification(CategoryName name)
  {
    this.Query.Search(c => c.CategoryName.Name, name.Name);
  }
}
