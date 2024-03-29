﻿namespace InventoryManagement.Infrastructure.Data.Config;

using InventoryManagement.Core.ProductAggregate;
using InventoryManagement.Core.ProductAggregate.Enums;
using InventoryManagement.Core.ProductAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> builder)
  {
    builder.ToTable("Products").HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .ValueGeneratedOnAdd()
      .HasConversion(
        v => v.Value,
        v => ProductId.From(v))
      .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

    builder.OwnsOne(x => x.ProductCode, x =>
    {
      x.Property(p => p.Value)
        .HasColumnName(nameof(Product.ProductCode))
        .HasMaxLength(50);
    });

    builder.OwnsOne(x => x.Frequency, x =>
    {
      x.Property(x => x.Value)
        .HasColumnName("Frequency")
        .IsRequired();

      x.Property(x => x.Name)
      .HasColumnName("Frequency_Name");

      x.Property(x => x.Description)
      .HasColumnName("Frequency_Description");
    });

    builder.HasMany(x => x.Items)
      .WithOne()
      .HasForeignKey(x => x.Product_Id);

    builder.HasMany(x => x.Categories)
      .WithMany("Products");
  }
}
