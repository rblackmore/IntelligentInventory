namespace Test.Core.Entities.CategoryTests.CategoryNameTests;

using System;
using System.ComponentModel.DataAnnotations;

using AutoFixture.Xunit2;

using FluentAssertions;

using InventoryManagement.Core.CategoryAggregate.ValueObjects;

using Xunit;

public class Construction
{
  [Theory]
  [AutoData]
  public void CreateSuccess_AssignValues([StringLength(20, MinimumLength = 3)] string categoryName)
  {
    // Act.
    var sut = new CategoryName(categoryName);

    // Assert.
    sut.Name.Should().Be(categoryName);
  }

  [Theory]
  [AutoData]
  public void Throws_ArgumentOutOfRangeException_WithNameLenthLessthan3([StringLength(20)] string categoryName)
  {
    // Arrange.
    var rng = new Random();

    var length = rng.Next(3);

    var name = categoryName[..length];

    // Act.
    var create = () => new CategoryName(name);

    // Assert.
    create.Should().Throw<ArgumentOutOfRangeException>();
  }

  [Theory]
  [AutoData]
  public void Throws_ArgumentOutOfRangeException_WithNameLengthGreaterThan20([StringLength(21)] string categoryName)
  {
    // Arrange.

    // Act.
    var create = () => new CategoryName(categoryName);

    // Assert.
    create.Should().Throw<ArgumentOutOfRangeException>();
  }
}
