namespace UnitTests.Core.Entities.CategoryTests;

using FluentAssertions;

using InventoryManagement.Core.CategoryAggregate;
using InventoryManagement.Core.CategoryAggregate.ValueObjects;

using UnitTests.Core.AutoFixtureCustomizations;

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
}
