namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel;

public class Category : ValueObject
{
  private Category(string value)
  {
    this.Value = value;
  }

  public string Value { get; set; }

  public static explicit operator Category(string category)
  {
    return new Category(category);
  }

  public static implicit operator string(Category category)
  {
    return category.Value;
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return this.Value;
  }

  public static Category Create(string value)
  {
    Guard.Against.NullOrEmpty(value, nameof(value));

    return new Category(value);
  }
}
