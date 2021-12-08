namespace ElectroCom.IntelligentInventory.ItemBooking.Core.ItemAggregate;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel;

public class SerialNumber : ValueObject
{
  public SerialNumber(string value)
  {
    this.Value = Guard.Against.NullOrWhiteSpace(value, nameof(value));
  }

  public string Value { get; set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    throw new NotImplementedException();
  }
}
