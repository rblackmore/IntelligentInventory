namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;

using System.Collections.Generic;

using ElectroCom.IntelligentInventory.SharedKernel;

public class Category : ValueObject
{
  public Category(string value)
  {
    this.Value = value;
  }

  public string Value { get; set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return this.Value;
  }
}
