namespace InventoryManagement.Infrastructure.Data.Config;

using InventoryManagement.Core.ManufacturerAggregate;
using InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> builder)
  {
    builder.ToTable("Products").HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .HasConversion(v => v.Value, v => ProductId.From(v));

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
    });

    builder.HasMany(x => x.Items)
      .WithOne()
      .HasForeignKey(x => x.Product_Id);

    builder.HasMany(x => x.Categories)
      .WithMany("Products");
  }
}
