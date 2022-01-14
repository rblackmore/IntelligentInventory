namespace UnitTests.Core.ManufacturerAggregate.ItemEntity.ItemIdTests;

using System;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class ItemId_Equality
{
  [Fact]
  public void EqualGivenMatchingData()
  {
    // Arrange.
    var guid = Guid.NewGuid();

    // Act.
    var obj1 = ItemId.CreateFrom(guid);
    var obj2 = ItemId.CreateFrom(guid);

    // Assert.

    obj1.Should().NotBeSameAs(obj2);
    obj1.Should().Be(obj2);
    obj2.Should().Be(obj1);
    obj1.Should().BeEquivalentTo(obj2);
    obj2.Should().BeEquivalentTo(obj1);
    (obj1 == obj2).Should().BeTrue();
    (obj1 != obj2).Should().BeFalse();

    (obj1.GetHashCode() == obj2.GetHashCode()).Should().BeTrue();
  }

  [Fact]
  public void UnEqualGivenMisMatchedData()
  {
    // Arrange.
    var guid1 = Guid.NewGuid();
    var guid2 = Guid.NewGuid();

    // Act.
    var obj1 = ItemId.CreateFrom(guid1);
    var obj2 = ItemId.CreateFrom(guid2);
    // Assert.

    obj1.Should().NotBeSameAs(obj2);
    obj1.Should().NotBe(obj2);
    obj2.Should().NotBe(obj1);
    obj2.Should().NotBeRankedEquallyTo(obj1);
    obj1.Should().NotBeRankedEquallyTo(obj2);
    (obj1 == obj2).Should().BeFalse();
    (obj1 != obj2).Should().BeTrue();

    (obj1.GetHashCode() == obj2.GetHashCode()).Should().BeFalse();
  }

  [Fact]
  public void UnEqualWhenCreatedWithCreateMethod()
  {
    // Arrange.

    // Act.
    var obj1 = ItemId.Create();
    var obj2 = ItemId.Create();

    // Assert.
    obj1.Should().NotBeSameAs(obj2);
    obj1.Should().NotBe(obj2);
    obj2.Should().NotBe(obj1);
    obj2.Should().NotBeRankedEquallyTo(obj1);
    obj1.Should().NotBeRankedEquallyTo(obj2);
    (obj1 == obj2).Should().BeFalse();
    (obj1 != obj2).Should().BeTrue();

    (obj1.GetHashCode() == obj2.GetHashCode()).Should().BeFalse();
  }
}
