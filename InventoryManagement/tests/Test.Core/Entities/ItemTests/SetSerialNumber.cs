namespace Test.Core.Entities.ItemTests;

using System;

using AutoFixture.Xunit2;

using FluentAssertions;

using InventoryManagement.Core.ItemAggregate;
using InventoryManagement.Core.ItemAggregate.ValueObjects;

using Xunit;

public class SetSerialNumber
{
  [Theory]
  [AutoData]
  public void AssignsPropertySerialNumber(Item item, SerialNumber serialNumber)
  {
    item.SetSerialNumber(serialNumber);

    item.SerialNumber.Should().Be(serialNumber);
  }

  [Theory]
  [AutoData]
  public void Throws_ArgumentNullException_GivenNull(Item item)
  {
    var setSerialNumber = () => item.SetSerialNumber(null!);

    setSerialNumber.Should().Throw<ArgumentNullException>();
  }
}
