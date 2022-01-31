namespace UnitTests.Core.Entities.ProductTests;

using System;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;
using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.Enums;
using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class Construction
{
  private readonly int productId = 7;
  private readonly int manufacturerid = 9;
  private readonly string description = "Fancy Product";
  private readonly ProductCode productCode = new("MRU102-USB");
  private readonly Frequency frequency = Frequency.UHF;

  [Fact]
  public void CreateSuccess_AndAssignsValues()
  {
    // Act.
    var product = new Product(
      this.productId,
      this.manufacturerid,
      this.description,
      this.productCode,
      this.frequency);

    // Assert.
    product.Id.Should().Be(this.productId);
    product.Manufacturer_id.Should().Be(this.manufacturerid);
    product.Description.Should().Be(this.description);
    product.ProductCode.Should().Be(this.productCode);
    product.Frequency.Should().Be(this.frequency);
    product.Items.Should().NotBeNull();
    product.Categories.Should().NotBeNull();
  }

  [Fact]
  public void CreateSuccess_FrequencySetToNone_WhenNotProvided()
  {
    // Act.
    var product = new Product(
      this.productId,
      this.manufacturerid,
      this.description,
      this.productCode);

    // Assert.
    product.Id.Should().Be(this.productId);
    product.Manufacturer_id.Should().Be(this.manufacturerid);
    product.Description.Should().Be(this.description);
    product.ProductCode.Should().Be(this.productCode);
    product.Frequency.Should().Be(Frequency.None);
    product.Items.Should().NotBeNull();
    product.Categories.Should().NotBeNull();
  }

  [Fact]
  public void CreateSuccess_AndAssigns_ProductId_ManufacturerId()
  {
    // Act.
    var product = new Product(this.productId, this.manufacturerid);

    // Assert.
    product.Id.Should().Be(this.productId);
    product.Manufacturer_id.Should().Be(this.manufacturerid);
    product.Frequency.Should().Be(Frequency.None);
  }

  [Theory]
  [InlineData(-1)]
  [InlineData(0)]
  public void Throws_ArgumentException_GivenManufacturerIdNegativeOrZero(int invalidManId)
  {
    // Act.
    var createFull = () => new Product(
      this.productId,
      invalidManId,
      this.description,
      this.productCode,
      this.frequency);

    var createMinimum = () => new Product(this.productId, invalidManId);

    // Assert.
    createFull.Should().Throw<ArgumentException>();
    createMinimum.Should().Throw<ArgumentException>();
  }

  [Fact]
  public void Throws_ArgumentNullException_GivenNullValues()
  {
    // Act.
    var createNullDescription = () =>
    new Product(
      this.productId,
      this.manufacturerid,
      null!,
      this.productCode,
      this.frequency);

    var createNullProductCode = () =>
    new Product(
      this.productId,
      this.manufacturerid,
      this.description,
      null!,
      this.frequency);

    // Assert.
    createNullDescription.Should().Throw<ArgumentNullException>();
    createNullProductCode.Should().Throw<ArgumentNullException>();
  }
}
