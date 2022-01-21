namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel;

public class CategoryName : ValueObject
{
  private static readonly int MINIMUM = 3;
  private static readonly int MAXIMUM = 20;

  public CategoryName(string tagName)
  {
    Guard.Against.NullOrEmpty(tagName, nameof(tagName));

    Guard.Against
      .OutOfRange(
      tagName.Length,
      nameof(tagName),
      MINIMUM,
      MAXIMUM,
      $"{nameof(tagName)} must have length betwee {MINIMUM} and {MAXIMUM}");

    this.Name = tagName.ToLowerInvariant();
  }

  public string Name { get; set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
     yield return this.Name;
  }
}
