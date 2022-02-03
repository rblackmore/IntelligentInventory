namespace InventoryManagement.Infrastructure.Data.Config;

using InventoryManagement.Core.ManufacturerAggregate;
using InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
  public void Configure(EntityTypeBuilder<Item> builder)
  {
    builder.ToTable("Items");

    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .HasConversion(v => v.Value, v => ItemId.CreateFrom(v));

    builder.OwnsOne(x => x.DateCode, x =>
    {
      x.Property(x => x.Value).HasColumnName("DateCode");
    });

    builder.OwnsOne(x => x.SerialNumber, x =>
    {
      x.Property(x => x.Value).HasColumnName("Serial Number").IsRequired();
    });
  }
}
