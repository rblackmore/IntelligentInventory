namespace UnitTests.Core.Entities.ItemTests;

using System;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;
using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class SetSerialNumber
{
  private readonly SerialNumber serialNumber = new ("1234");

  private readonly Item item = new (ItemId.Create(), new SerialNumber("ABCD"), 7);

  [Fact]
  public void AssignsSerialNumberProperty()
  {
    this.item.SetSerialNumber(this.serialNumber);

    this.item.SerialNumber.Should().Be(this.serialNumber);
  }

  [Fact]
  public void Throws_ArgumentNullException_GivenNull()
  {
    var setSerialNumber = () => this.item.SetSerialNumber(null!);

    setSerialNumber.Should().Throw<ArgumentNullException>();
  }
}
