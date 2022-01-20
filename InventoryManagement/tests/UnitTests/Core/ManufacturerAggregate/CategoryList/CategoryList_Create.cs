namespace UnitTests.Core.ManufacturerAggregate.CategoryList;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class CategoryList_Create
{
  private Category[] categories =
    new[] { new Category("Reader"), new Category("Antenna") };

  [Fact]
  public void CreateSuccess()
  {
    var categoryList = new CategoryList(this.categories);

    Assert.NotNull(categoryList);

    categoryList.Count.Should().Be(2);
  }

  [Fact]
  public void CreateEmptySuccess()
  {
    var list = new CategoryList();

    Assert.NotNull(list);

    list.Count.Should().Be(0);
  }
}
