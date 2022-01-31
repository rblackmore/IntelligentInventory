namespace UnitTests.Core.Entities.ItemTests.ItemIdTests;

using System;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class Construction
{
  private Guid guid = Guid.NewGuid();

  [Fact]
  public void CreateSuccess_WithValidGuid()
  {
    // Act.
    var itemId = ItemId.Create();

    // Assert.
    itemId.Value.Should().NotBe(default(Guid));
    itemId.Value.Should().NotBe(Guid.Empty);
  }

  [Fact]
  public void CreateSuccess_AssignsValidGuid()
  {
    // Act.
    var itemId = ItemId.CreateFrom(this.guid);

    // Assert.
    itemId.Value.Should().Be(this.guid);
  }

  [Fact]
  public void Throws_ArgumentException_Given_DefaultOrEmptyGuid()
  {
    Assert.Throws<ArgumentException>(() => ItemId.CreateFrom(default));
    Assert.Throws<ArgumentException>(() => ItemId.CreateFrom(Guid.Empty));
  }
}
