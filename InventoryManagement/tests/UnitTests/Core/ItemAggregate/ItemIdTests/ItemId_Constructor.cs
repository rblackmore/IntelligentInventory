namespace UnitTests.Core.ItemAggregate.ItemIdTests;

using System;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;

using FluentAssertions;

using Xunit;

public class ItemId_Constructor
{
  [Fact]
  public void ThrowsGivenDefaultGuid()
  {
    Assert.Throws<ArgumentException>(() => ItemId.CreateFrom(default(Guid)));
  }

  [Fact]
  public void ThrowsGivenEmptyGuid()
  {
    Assert.Throws<ArgumentException>(() => ItemId.CreateFrom(Guid.Empty));
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
