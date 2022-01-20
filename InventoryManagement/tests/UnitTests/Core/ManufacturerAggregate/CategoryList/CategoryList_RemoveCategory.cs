namespace UnitTests.Core.ManufacturerAggregate.CategoryList;

using System;
using System.Collections.Generic;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class CategoryList_RemoveCategory
{
  [Theory]
  [InlineData("Reader")]
  [InlineData("Reader", "Antenna")]
  [InlineData("Reader", "Antenna", "Power Supply")]
  public void RemoveCategory_ListSize_Decreased(params string[] categories)
  {
    int count = categories.Length;

    var items = new List<Category>();

    for (int i = 0; i < count; i++)
      items.Add(new Category(categories[i]));

    var categoryList = new CategoryList(items.ToArray());

    var result = categoryList.RemoveCategory(new Category("Reader"));

    var expected = count - 1;

    result.Count.Should().Be(expected);
  }

  [Theory]
  [InlineData("Reader")]
  [InlineData("Reader", "Antenna")]
  [InlineData("Reader", "Antenna", "Power Supply")]
  public void RemoveCategory_ListSize_Unaltered(params string[] categories)
  {
    int count = categories.Length;

    var items = new List<Category>();

    for (int i = 0; i < count; i++)
      items.Add(new Category(categories[i]));

    var categoryList = new CategoryList(items.ToArray());

    var result = categoryList.RemoveCategory(new Category("Missing"));

    result.Count.Should().Be(count);
  }
}
