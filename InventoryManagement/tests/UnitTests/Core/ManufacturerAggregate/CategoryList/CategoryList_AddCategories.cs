namespace UnitTests.Core.ManufacturerAggregate.CategoryList;

using System.Collections.Generic;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class CategoryList_AddCategories
{

  [Theory]
  [InlineData("Reader")]
  [InlineData("Reader", "Antenna")]
  [InlineData("Reader", "Antenna", "Power Supply")]
  public void AddCategory_ListSize_Increased(params string[] categories)
  {
    int count = categories.Length;

    var items = new List<Category>();
    
    for (int i = 0; i < count; i++)
      items.Add(new Category(categories[i]));

    var categoryList = new CategoryList(items.ToArray());

    var result = categoryList.AddCategories(new Category("New Category"));
    
    var expected = count + 1;

    result.Count.Should().Be(expected);
  }
}
