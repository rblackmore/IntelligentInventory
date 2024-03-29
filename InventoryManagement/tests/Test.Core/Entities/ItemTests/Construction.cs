﻿namespace Test.Core.Entities.ItemTests;

using System;
using System.ComponentModel.DataAnnotations;

using AutoFixture;
using AutoFixture.Xunit2;

using FluentAssertions;

using InventoryManagement.Core.ItemAggregate;
using InventoryManagement.Core.ItemAggregate.ValueObjects;
using InventoryManagement.Core.ProductAggregate.ValueObjects;

using Xunit;

public class Construction
{
  private readonly Fixture fixture;

  private readonly ItemId itemId;
  private readonly SerialNumber serialNumber;
  private readonly ProductId productId;
  private readonly DateCode dateCode;

  public Construction()
  {
    this.fixture = new Fixture();
    this.itemId = this.fixture.Create<ItemId>();
    this.serialNumber = this.fixture.Create<SerialNumber>();
    this.productId = this.fixture.Create<ProductId>();
    this.dateCode = this.fixture.Create<DateCode>();
  }

  [Theory]
  [AutoData]
  public void CreateSuccess_WithCorrectlyAssignedValue(
    ItemId itemId,
    SerialNumber serialNumber,
    ProductId productId,
    DateCode dateCode)
  {
    // Act.
    var item = new Item(itemId, serialNumber, productId, dateCode);

    // Assert.
    item.Id.Should().Be(itemId);
    item.SerialNumber.Should().Be(serialNumber);
    item.Product_Id.Should().Be(productId);
    item.DateCode.Should().Be(dateCode);
  }

  [Fact]
  public void AssignsDateCodeNone_When_DateCodeIsOmitted()
  {
    var item = new Item(itemId, serialNumber, productId);

    item.DateCode.Should().Be(DateCode.None);
  }

  [Theory]
  [AutoData]
  public void Throws_ArgumentException_When_PassedInvalidProductId([Range(-10, 0)] int invalidProductId)
  {
    // Arrange.

    // Act.
    var create = () => new Item(
        itemId,
        serialNumber,
        ProductId.From(invalidProductId),
        dateCode);

    // Assert.
    create.Should().Throw<ArgumentException>();
  }

  [Fact]
  public void Throws_ArgumentNullException_When_SerialNumberIsNull()
  {
    // Arrange
    var create = () => new Item(
      itemId,
      null!,
      productId,
      dateCode);

    create.Should().Throw<ArgumentNullException>();
  }
}
