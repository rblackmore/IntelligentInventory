namespace UnitTests.Core.ManufacturerAggregate.CategoryList;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class CategoryList_Create
{
  private Category categoryReader = Category.Create("Reader");
  private Category categoryAntenna = Category.Create("Antenna");

  [Fact]
  public void CreateSuccess()
  {
    var categories = new[] { this.categoryReader, this.categoryAntenna };

    var categoryList = CategoryList.Create(categories);

    Assert.NotNull(categoryList);

    categoryList.Categories.Should().HaveCount(2);
  }

  [Fact]
  public void CreateEmptySuccess()
  {
    var list = CategoryList.Create();

    Assert.NotNull(list);

    list.Categories.Should().HaveCount(0);
  }
}
