﻿namespace InventoryManagement.Infrastructure.Data.Config;

using InventoryManagement.Core.ManufacturerAggregate;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
{
  public void Configure(EntityTypeBuilder<Manufacturer> builder)
  {
    builder.ToTable("Manufacturers").HasKey(x => x.Id);

    builder.HasMany(x => x.Products)
      .WithOne()
      .HasForeignKey(x => x.Manufacturer_id);
  }
}