namespace UnitTests.Core.Entities.ItemTests;

using System;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;
using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class SetDateCode
{
  private readonly DateCode dateCode = new DateCode("1218");

  private readonly Item item = new (ItemId.Create(), new SerialNumber("ABCD"), 7);

  [Fact]
  public void AssignsDateCodeProperty()
  {
    this.item.SetDateCode(this.dateCode);

    this.item.DateCode.Should().Be(this.dateCode);
  }

  [Fact]
  public void Throws_ArgumentNullException_GivenNull()
  {
    var setDateCodeNull = () => this.item.SetDateCode(null!);

    setDateCodeNull.Should().Throw<ArgumentNullException>();
  }
}
