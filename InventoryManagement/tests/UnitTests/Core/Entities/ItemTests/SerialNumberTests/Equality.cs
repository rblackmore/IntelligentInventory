namespace UnitTests.Core.Entities.ItemTests.SerialNumberTests;

using AutoFixture.Xunit2;

using FluentAssertions;

using InventoryManagement.Core.ItemAggregate.ValueObjects;

using Xunit;

public class Equality
{
  [Theory]
  [AutoData]
  public void Equal_GivenMatchingValue(string serialNumber)
  {
    // Act.
    var obj1 = new SerialNumber(serialNumber);
    var obj2 = new SerialNumber(serialNumber);

    // Assert.
    obj1.Should().NotBeSameAs(obj2);
    obj1.Should().Be(obj2);
    obj2.Should().Be(obj1);
    obj1.Should().BeEquivalentTo(obj2);
    obj2.Should().BeEquivalentTo(obj1);
    (obj1 == obj2).Should().BeTrue();
    (obj1 != obj2).Should().BeFalse();

    (obj1.GetHashCode() == obj2.GetHashCode()).Should().BeTrue();
  }

  [Theory]
  [AutoData]
  public void UnEqualGivenMisMatchedData(string serial1, string serial2)
  {
    // Act.
    var obj1 = new SerialNumber(serial1);
    var obj2 = new SerialNumber(serial2);

    // Assert.
    obj1.Should().NotBeSameAs(obj2);
    obj1.Should().NotBe(obj2);
    obj2.Should().NotBe(obj1);
    obj2.Should().NotBeRankedEquallyTo(obj1);
    obj1.Should().NotBeRankedEquallyTo(obj2);
    (obj1 == obj2).Should().BeFalse();
    (obj1 != obj2).Should().BeTrue();

    (obj1.GetHashCode() == obj2.GetHashCode()).Should().BeFalse();
  }
}
