namespace UnitTests.Core.Entities.ItemTests.ItemIdTests;

using System;

using AutoFixture.Xunit2;

using FluentAssertions;

using InventoryManagement.Core.ItemAggregate.ValueObjects;

using Xunit;

public class Equality
{
  [Theory]
  [AutoData]
  public void Equal_GivenMatchingValue(Guid guid)
  {
    // Act.
    var obj1 = ItemId.From(guid);
    var obj2 = ItemId.From(guid);

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

  [Theory]
  [AutoData]
  public void UnEqual_GivenMisMatchedValues(Guid guid1, Guid guid2)
  {
    // Act.
    var obj1 = ItemId.From(guid1);
    var obj2 = ItemId.From(guid2);

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
  public void UnEqual_WhenCreatingFromCreateMethod()
  {
    // Act.
    var obj1 = ItemId.New();
    var obj2 = ItemId.New();

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
