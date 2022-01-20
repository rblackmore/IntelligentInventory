namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using System.Collections;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel;

public class CategoryList : ValueObject, IEnumerable<Category>
{
  private List<Category> categories;

  private CategoryList(params Category[] categories)
  {
    this.categories = categories.ToList();
  }

  public IReadOnlyList<Category> Categories => this.categories.AsReadOnly();

  public static explicit operator CategoryList(string categoryList)
  {
    List<Category> categories = categoryList.Split(';')
      .Select(x => Category.Create(x))
      .ToList();

    return new CategoryList(categories.ToArray());
  }

  public static implicit operator string(CategoryList categoryList)
  {
    return string.Join(";", categoryList.Select(x => x.Value));
  }

  public CategoryList AddCategories(params Category[] categories)
  {
    Guard.Against.Null(categories, nameof(categories));

    List<Category> list = this.categories.ToList();

    foreach (var category in categories)
      list.Add(category);

    return new CategoryList(list.ToArray());
  }

  public CategoryList RemoveCategory(Category category)
  {
    Guard.Against.Null(category, nameof(category));

    List<Category> list = this.categories.ToList();

    list.Remove(category);

    return new CategoryList(list.ToArray());
  }

  public static CategoryList Create(params Category[] categories)
  {
    Guard.Against.Null(categories, nameof(categories));

    return new CategoryList(categories);
  }

  public IEnumerator<Category> GetEnumerator()
  {
    return this.categories.GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return this.GetEnumerator();
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    foreach (var category in this.categories.OrderBy(x => x.Value))
    {
      yield return category;
    }
  }
}
