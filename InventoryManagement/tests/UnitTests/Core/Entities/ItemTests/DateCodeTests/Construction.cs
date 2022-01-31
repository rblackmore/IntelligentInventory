namespace UnitTests.Core.Entities.ItemTests.DateCodeTests;

using System;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class Construction
{
  private string dateCodeString = "2319";

  [Fact]
  public void CreateSuccess_ValueAssigned()
  {
    var dateCode = new DateCode(this.dateCodeString);

    dateCode.Value.Should().Be(this.dateCodeString);
  }

  [Fact]
  public void Throws_ArgumentNullException_GivenNull()
  {
    var create = () => new DateCode(null!);

    create.Should().Throw<ArgumentNullException>();
  }
}
