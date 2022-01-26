namespace ElectroCom.IntelligentInventory.InventoryManagement.Infrastructure.Data.Config;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> builder)
  {
    builder.ToTable("Products").HasKey(x => x.Id);

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
