namespace UnitTests.Core.Entities.ItemTests.ItemIdTests;

using System;

using AutoFixture.Xunit2;

using FluentAssertions;

using InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using Xunit;

public class Construction
{
  [Fact]
  public void CreateSuccess_WithValidGuid()
  {
    // Act.
    var itemId = ItemId.Create();

    // Assert.
    itemId.Value.Should().NotBe(default(Guid));
    itemId.Value.Should().NotBe(Guid.Empty);
  }

  [Theory]
  [AutoData]
  public void CreateSuccess_AssignsValidGuid(Guid guid)
  {
    // Act.
    var itemId = ItemId.CreateFrom(guid);

    // Assert.
    itemId.Value.Should().Be(guid);
  }

  [Fact]
  public void Throws_ArgumentException_Given_DefaultOrEmptyGuid()
  {
    // Act.
    var createDefault = () => ItemId.CreateFrom(default);
    var createEmpty = () => ItemId.CreateFrom(Guid.Empty);

    createDefault.Should().Throw<ArgumentException>();
    createEmpty.Should().Throw<ArgumentException>();
  }
}
