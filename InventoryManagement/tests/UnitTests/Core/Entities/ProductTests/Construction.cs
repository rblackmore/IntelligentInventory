namespace UnitTests.Core.Entities.ProductTests;

using System;
using System.ComponentModel.DataAnnotations;

using AutoFixture;
using AutoFixture.Xunit2;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;
using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.Enums;
using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using FluentAssertions;

using Xunit;

public class Construction
{
  //private readonly int productId = 7;
  //private readonly int manufacturerid = 9;
  //private readonly string description = "Fancy Product";
  //private readonly ProductCode productCode = new ("MRU102-USB");
  //private readonly Frequency frequency = Frequency.UHF;

  [Theory]
  [AutoData]
  public void CreateSuccess_AndAssignsValues(
    int productId,
    int manufacturerId,
    string description,
    ProductCode productCode)
  {
    // Arrange.
    var frequency = Frequency.UHF;

    // Act.
    var product = new Product(
      productId,
      manufacturerId,
      description,
      productCode,
      frequency);

    // Assert.
    product.Id.Should().Be(productId);
    product.Manufacturer_id.Should().Be(manufacturerId);
    product.Description.Should().Be(description);
    product.ProductCode.Should().Be(productCode);
    product.Frequency.Should().Be(frequency);
    product.Items.Should().NotBeNull();
    product.Categories.Should().NotBeNull();
  }

  [Theory]
  [AutoData]
  public void CreateSuccess_FrequencySetToNone_WhenNotProvided(
    int productId,
    int manufacturerId,
    string description,
    ProductCode productCode)
  {
    // Act.
    var product = new Product(
      productId,
      manufacturerId,
      description,
      productCode);

    // Assert.
    product.Id.Should().Be(productId);
    product.Manufacturer_id.Should().Be(manufacturerId);
    product.Description.Should().Be(description);
    product.ProductCode.Should().Be(productCode);
    product.Frequency.Should().Be(Frequency.None);
    product.Items.Should().NotBeNull();
    product.Categories.Should().NotBeNull();
  }

  [Theory]
  [AutoData]
  public void CreateSuccess_AndAssigns_ProductId_ManufacturerId(
    int productId,
    int manufacturerId)
  {
    // Act.
    var product = new Product(productId, manufacturerId);

    // Assert.
    product.Id.Should().Be(productId);
    product.Manufacturer_id.Should().Be(manufacturerId);
    product.Frequency.Should().Be(Frequency.None);
  }

  [Theory]
  [AutoData]
  public void Throws_ArgumentException_GivenManufacturerIdNegativeOrZero([Range(-10, 0)]int invalidManId)
  {
    // Arrange.
    var fixture = new Fixture();

    var productId = fixture.Create<int>();
    var description = fixture.Create<string>();
    var productCode = fixture.Create<ProductCode>();
    var frequency = Frequency.None;

    // Act.
    var createFull = () => new Product(
      productId,
      invalidManId,
      description,
      productCode,
      frequency);

    var createMinimum = () => new Product(
      productId,
      invalidManId);

    // Assert.
    createFull.Should().Throw<ArgumentException>();
    createMinimum.Should().Throw<ArgumentException>();
  }

  [Theory]
  [AutoData]
  public void Throws_ArgumentNullException_GivenNullValues(
    int productId,
    int manufacturerId,
    string description,
    ProductCode productCode)
  {
    //// Arrange.
    var frequency = Frequency.None;

    // Act.
    var createNullDescription = () =>
    new Product(
      productId,
      manufacturerId,
      null!,
      productCode,
      frequency);

    var createNullProductCode = () =>
    new Product(
      productId,
      manufacturerId,
      description,
      null!,
      frequency);

    // Assert.
    createNullDescription.Should().Throw<ArgumentNullException>();
    createNullProductCode.Should().Throw<ArgumentNullException>();
  }
}
