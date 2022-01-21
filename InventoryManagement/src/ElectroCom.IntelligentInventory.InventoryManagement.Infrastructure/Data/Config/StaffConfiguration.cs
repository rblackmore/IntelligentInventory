namespace ElectroCom.IntelligentInventory.InventoryManagement.Infrastructure.Data.Config;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.StaffAggregate;
using ElectroCom.IntelligentInventory.InventoryManagement.Core.StaffAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StaffConfiguration : IEntityTypeConfiguration<Staff>
{
  public void Configure(EntityTypeBuilder<Staff> builder)
  {
    builder.ToTable("Staff").HasKey(x => x.Id);
    builder.OwnsOne(x => x.Name, x =>
    {
      x.Property(p => p.FirstName).HasColumnName(nameof(Name.FirstName)).HasMaxLength(50);
      x.Property(p => p.LastName).HasColumnName(nameof(Name.LastName)).HasMaxLength(50);
    });
  }
}
