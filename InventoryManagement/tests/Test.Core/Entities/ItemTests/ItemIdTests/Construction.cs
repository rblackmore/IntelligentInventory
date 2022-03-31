namespace Test.Core.Entities.ItemTests.ItemIdTests;

using System;

using AutoFixture.Xunit2;

using FluentAssertions;

using InventoryManagement.Core.ItemAggregate.ValueObjects;

using Xunit;

public class Construction
{
  [Fact]
  public void CreateSuccess_WithValidGuid()
  {
    // Act.
    var itemId = ItemId.New();

    // Assert.
    itemId.Value.Should().NotBe(default(Guid));
    itemId.Value.Should().NotBe(Guid.Empty);
  }

  [Theory]
  [AutoData]
  public void CreateSuccess_AssignsValidGuid(Guid guid)
  {
    // Act.
    var itemId = ItemId.From(guid);

    // Assert.
    itemId.Value.Should().Be(guid);
  }

  [Fact]
  public void Throws_ArgumentException_Given_DefaultOrEmptyGuid()
  {
    // Act.
    var createDefault = () => ItemId.From(default);
    var createEmpty = () => ItemId.From(Guid.Empty);

    createDefault.Should().Throw<ArgumentException>();
    createEmpty.Should().Throw<ArgumentException>();
  }
}
