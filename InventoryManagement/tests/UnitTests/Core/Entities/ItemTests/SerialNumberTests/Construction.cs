namespace UnitTests.Core.Entities.ItemTests.SerialNumberTests;

using System;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class Construction
{
  [Theory]
  [InlineData("ABCD")]
  [InlineData("1234")]
  [InlineData("AB12")]
  public void CreateSuccess_AssignsValidSerialNumber(string number)
  {
    var serialNumber = new SerialNumber(number);

    serialNumber.Value.Should().Be(number);
  }

  [Fact]
  public void Throws_ArgumentException_GivenEmptyString()
  {
    var create = () => new SerialNumber(null!);

    create.Should().Throw<ArgumentNullException>();
  }

  [Fact]
  public void Throws_ArgumentNullException_GivenNull()
  {
    var create = () => new SerialNumber(string.Empty);

    create.Should().Throw<ArgumentException>();
  }
}
