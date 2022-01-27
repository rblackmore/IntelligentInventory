namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.CategoryAggregate.ValueObjects;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel.BaseClasses;

public class CategoryName : ValueObject
{
  public static readonly int MINIMUM = 3;
  public static readonly int MAXIMUM = 20;

  public CategoryName(string name)
  {
    Guard.Against.NullOrEmpty(name, nameof(name));

    Guard.Against
      .OutOfRange(
      name.Length,
      nameof(name),
      MINIMUM,
      MAXIMUM,
      $"{nameof(name)} must have length betwee {MINIMUM} and {MAXIMUM}");

    this.Name = name.ToLowerInvariant();
  }

  public string Name { get; set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return this.Name;
  }
}
