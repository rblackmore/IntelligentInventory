namespace ElectroCom.IntelligentInventory.InventoryManagement.Core.StaffAggregate.ValueObjects;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel.BaseClasses;

public class Name : ValueObject
{
  public Name(string firstName, string lastName)
  {
    this.FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
    this.LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
  }

  public string FirstName { get; private set; }

  public string LastName { get; private set; }

  public string FullName => $"{this.FirstName} {this.LastName}";

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return this.FirstName;
    yield return this.LastName;
  }
}
