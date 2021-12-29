﻿namespace UnitTests.Core.ItemAggregate.SerialNumberTests;

using AutoFixture;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;

using FluentAssertions;

using Xunit;

public class SerialNumber_Equality
{
  private readonly IFixture fixture = new Fixture();


  [Fact]
  public void EqualGivenMatchingData()
  {
    // Arrange.
    string serial = this.fixture.Create<string>();
    // Act.
    var obj1 = new SerialNumber(serial);
    var obj2 = new SerialNumber(serial);

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

  [Fact]
  public void UnEqualGivenMisMatchedData()
  {
    // Arrange.
    string serial1 = this.fixture.Create<string>();
    string serial2 = this.fixture.Create<string>();
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
