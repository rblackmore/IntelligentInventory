namespace InventoryManagement.Infrastructure.Data.Config;

using InventoryManagement.Core.CategoryAggregate;
using InventoryManagement.Core.CategoryAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
  public void Configure(EntityTypeBuilder<Category> builder)
  {
    builder.ToTable("Categories").HasKey(c => c.Id);

    builder.Property(x => x.Id)
      .ValueGeneratedOnAdd()
      .HasConversion(
      v => v.Value,
      v => CategoryId.From(v));

    builder.OwnsOne(x => x.CategoryName, x =>
    {
      x.Property(x => x.Name)
        .HasColumnName(nameof(CategoryName.Name))
        .HasMaxLength(CategoryName.MAXIMUM)
        .IsRequired();

      x.HasIndex(x => x.Name)
        .IsUnique();
    });
  }
}
