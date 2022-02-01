namespace UnitTests.Core.Entities.ProductTests;

using Xunit;
using AutoFixture;
using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;
using FluentAssertions;
using System;
using AutoFixture.Xunit2;

public class SetDescription
{
  [Theory]
  [AutoData]
  public void AssignsPropertyDescription(string description, Product sut)
  {
    // Act.
    sut.SetDescription(description);

    // Assert.
    sut.Description.Should().Be(description);
  }

  [Theory]
  [AutoData]
  public void Throws_ArgumentNullException_GivenNullValue(Product sut)
  {
    // Act.
    var setDescription = () => sut.SetDescription(null!);

    // Assert.
    setDescription.Should().Throw<ArgumentNullException>();
  }
}
