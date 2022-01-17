namespace UnitTests.Core.ManufacturerAggregate.ItemEntity.SerialNumberTests;

using System;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using Xunit;

public class SerialNumber_Constructor
{
  [Fact]
  public void ThrowsGivenNullOrEmptyString()
  {
    Assert.Throws<ArgumentNullException>(() => new SerialNumber(null!));
    Assert.Throws<ArgumentException>(() => new SerialNumber(string.Empty));
  }
}
