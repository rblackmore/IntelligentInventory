namespace UnitTests.Core.Entities.ItemTests.DateCodeTests;

using System;

using AutoFixture.Xunit2;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class Construction
{
  [Theory]
  [AutoData]
  public void CreateSuccess_ValueAssigned(string dateCodeValue)
  {
    var dateCode = new DateCode(dateCodeValue);

    dateCode.Value.Should().Be(dateCodeValue);
  }

  [Fact]
  public void Throws_ArgumentNullException_GivenNull()
  {
    var create = () => new DateCode(null!);

    create.Should().Throw<ArgumentNullException>();
  }
}
