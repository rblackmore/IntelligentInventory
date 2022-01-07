namespace UnitTests.Core.ManufacturerAggregate.ItemEntity.ItemIdTests;

using System;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;

using FluentAssertions;

using Xunit;

public class ItemId_Constructor
{
  [Fact]
  public void ThrowsGivenDefaultOrEmptyGuid()
  {
    Assert.Throws<ArgumentException>(() => ItemId.CreateFrom(default));
    Assert.Throws<ArgumentException>(() => ItemId.CreateFrom(Guid.Empty));
  }

  [Fact]
  public void CreatesItemIdWithNewGuid()
  {
    // Act.
    var itemId = ItemId.Create();

    // Assert.
    itemId.Value.Should().NotBe(default(Guid));
    itemId.Value.Should().NotBe(Guid.Empty);
  }

  [Fact]
  public void CreatesItemIdWithProvidedGuid()
  {
    // Arrange.
    var guid = Guid.NewGuid();

    // Act.
    var itemId = ItemId.CreateFrom(guid);

    // Assert.
    itemId.Value.Should().Be(guid);
  }
}
