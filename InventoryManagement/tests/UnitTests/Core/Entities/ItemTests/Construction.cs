namespace UnitTests.Core.Entities.ItemTests;

using System;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;
using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class Construction
{
  private readonly ItemId itemId = ItemId.Create();
  private readonly SerialNumber serialNumber = new SerialNumber(Guid.NewGuid().ToString());
  private readonly int productId = 7;
  private readonly DateCode dateCode = new DateCode("2322");

  [Fact]
  public void CreateSuccess_WithCorrectlyAssignedValue()
  {
    var item = new Item(this.itemId, this.serialNumber, this.productId, this.dateCode);

    item.Id.Should().Be(this.itemId);
    item.SerialNumber.Should().Be(this.serialNumber);
    item.Product_Id.Should().Be(this.productId);
    item.DateCode.Should().Be(this.dateCode);
  }

  [Theory]
  [InlineData(0)]
  [InlineData(-1)]
  public void Throws_ArgumentException_When_PassedInvalidProductId(int invalidProductId)
  {
    Action create = () => new Item(this.itemId, this.serialNumber, invalidProductId, this.dateCode);

    create.Should().Throw<ArgumentException>();
  }

  [Fact]
  public void Throws_ArgumentNullException_When_SerialNumberIsNull()
  {
    Action create = () => new Item(this.itemId, null!, this.productId, this.dateCode);

    create.Should().Throw<ArgumentNullException>();
  }

  [Fact]
  public void AssignsDateCodeNone_When_DateCodeIsOmitted()
  {
    var item = new Item(this.itemId, this.serialNumber, this.productId);

    item.DateCode.Should().Be(DateCode.None);
  }
}
