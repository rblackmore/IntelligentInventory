namespace UnitTests.Core.Entities.ItemTests.SerialNumberTests;

using System;

using AutoFixture.Xunit2;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class Construction
{
  [Theory]
  [AutoData]
  public void CreateSuccess_AssignsValidSerialNumber(string number)
  {
    var serialNumber = new SerialNumber(number);

    serialNumber.Value.Should().Be(number);
  }

  [Fact]
  public void Throws_ArgumentException_GivenEmptyString()
  {
    var create = () => new SerialNumber(String.Empty);

    create.Should().Throw<ArgumentException>();
  }

  [Fact]
  public void Throws_ArgumentNullException_GivenNull()
  {
    var create = () => new SerialNumber(null!);

    create.Should().Throw<ArgumentNullException>();
  }
}
