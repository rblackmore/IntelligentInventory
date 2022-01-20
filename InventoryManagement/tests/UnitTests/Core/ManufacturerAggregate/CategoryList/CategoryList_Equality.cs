namespace UnitTests.Core.ManufacturerAggregate.CategoryList;

using System.Collections.Generic;
using System.Linq;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;
using ElectroCom.IntelligentInventory.SharedKernel;

using FluentAssertions;

using Xunit;

public class CategoryList_Equality
{
  private Category[] categories = 
    new[] { new Category("Reader"), new Category("Antenna") };

  [Fact]
  public void Equal_Given_MatchingData()
  {
    var obj1 = new CategoryList(this.categories.ToArray());
    var obj2 = new CategoryList(this.categories.ToArray());

    (obj1 as ValueObject).Should().NotBeSameAs(obj2);

    (obj2 as ValueObject).Should().Be(obj1);
    (obj1 as ValueObject).Should().Be(obj2);

    (obj2 as ValueObject).Should().BeEquivalentTo(obj1);
    (obj1 as ValueObject).Should().BeEquivalentTo(obj2);

    (obj1 == obj2).Should().BeTrue();
    (obj1 != obj2).Should().BeFalse();

    (obj1.Equals(obj2)).Should().BeTrue();

    (obj1.GetHashCode() == obj2.GetHashCode()).Should().BeTrue();
  }

  [Fact]
  public void UnEqual_Given_MisMatchingData()
  {
    var obj1 = new CategoryList(this.categories[0]);
    var obj2 = new CategoryList(this.categories[1]);

    (obj1 as ValueObject).Should().NotBeSameAs(obj2);

    (obj2 as ValueObject).Should().NotBe(obj1);
    (obj1 as ValueObject).Should().NotBe(obj2);

    (obj2 as ValueObject).Should().NotBeRankedEquallyTo(obj1);
    (obj1 as ValueObject).Should().NotBeRankedEquallyTo(obj2);

    (obj1 == obj2).Should().BeFalse();
    (obj1 != obj2).Should().BeTrue();
    
    (obj1.Equals(obj2)).Should().BeFalse();

    (obj1.GetHashCode() == obj2.GetHashCode()).Should().BeFalse();
  }
}
