namespace Test.Core.Entities.CategoryTests;

using System;

using AutoFixture.Xunit2;

using FluentAssertions;

using InventoryManagement.Core.CategoryAggregate;
using InventoryManagement.Core.CategoryAggregate.ValueObjects;

using Test.Core.AutoFixtureCustomizations;

using Xunit;

public class Construction
{
  [Theory]
  [CoreAutoData]
  public void CreateSuccess_AndAssignsValues(
    int categoryId,
    CategoryName categoryName)
  {
    // Act.
    var category = new Category(categoryId, categoryName);

    // Assert.
    category.Id.Should().Be(categoryId);
    category.CategoryName.Should().Be(categoryName);
  }

  [Theory]
  [AutoData]
  public void Throws_ArgumentNullException_GivenNullCategoryName(int categoryId)
  {
    // Act.
    var create = () => new Category(categoryId, null!);

    // Assert.
    create.Should().Throw<ArgumentNullException>();
  }
}
