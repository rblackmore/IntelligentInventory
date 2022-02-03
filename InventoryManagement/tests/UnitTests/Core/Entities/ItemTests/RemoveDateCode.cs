namespace UnitTests.Core.Entities.ItemTests;

using AutoFixture;
using AutoFixture.Xunit2;

using FluentAssertions;

using InventoryManagement.Core.ManufacturerAggregate;
using InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using Xunit;

public class RemoveDateCode
{
  [Theory]
  [AutoData]
  public void Assigns_DateCodeNone(Item item)
  {
    // Act.
    item.RemoveDateCode();

    // Assert.
    item.DateCode.Should().Be(DateCode.None);
  }
}
