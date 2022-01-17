namespace UnitTests.Core.ManufacturerAggregate.ItemEntity.ItemTests;

using System;
using System.Threading.Tasks;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;
using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class Item_Create
{
  private readonly ItemId itemId = ItemId.Create();
  private readonly SerialNumber serialNumber = new SerialNumber(Guid.NewGuid().ToString());
  private readonly int productId = 1;
  private readonly DateCode dateCode = new DateCode("2322");

  [Fact]
  public void CreateSuccess()
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
  public void ThrowsException_When_PassedInvalidProductId(int invalidProductId)
  {
    Action create = () => new Item(this.itemId, this.serialNumber, invalidProductId, this.dateCode);

    create.Should().Throw<ArgumentException>();
  }

  [Fact]
  public void ThrowsException_When_SerialNumberIsNull()
  {
    Action create = () => new Item(this.itemId, null!, this.productId, this.dateCode);

    create.Should().Throw<ArgumentNullException>();
  }

  [Fact]
  public void ThrowsException_When_DateCodeIsNull()
  {
    Action create = () => new Item(this.itemId, this.serialNumber, this.productId, null!);

    create.Should().Throw<ArgumentNullException>();
  }
}
