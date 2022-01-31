namespace UnitTests.Core.Entities.ItemTests;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;
using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class RemoveDateCode
{
  private readonly Item item = 
    new (ItemId.Create(), new SerialNumber("ABCD"), 7, new DateCode("1217"));

  [Fact]
  public void Assigns_DateCodeNone()
  {
    this.item.RemoveDateCode();

    this.item.DateCode.Should().Be(DateCode.None);
  }
}
