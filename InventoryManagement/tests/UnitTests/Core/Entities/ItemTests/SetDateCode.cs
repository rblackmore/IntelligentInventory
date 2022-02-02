namespace UnitTests.Core.Entities.ItemTests;

using System;

using AutoFixture.Xunit2;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;
using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class SetDateCode
{

  [Theory]
  [AutoData]
  public void AssignsPropertyDateCode(Item item, DateCode dateCode)
  {
    // Act.
    item.SetDateCode(dateCode);

    // Assert
    item.DateCode.Should().Be(dateCode);
  }

  [Theory]
  [AutoData]
  public void Throws_ArgumentNullException_GivenNull(Item item)
  {
    var setDateCodeNull = () => item.SetDateCode(null!);

    setDateCodeNull.Should().Throw<ArgumentNullException>();
  }
}
