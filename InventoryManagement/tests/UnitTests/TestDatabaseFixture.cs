namespace UnitTests;

using AutoFixture;

using InventoryManagement.Core.CategoryAggregate;
using InventoryManagement.Core.ProductAggregate;
using InventoryManagement.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

using UnitTests.SpecimenBuilders;

public class TestDatabaseFixture
{
  private const string ConnectionString =
    "Server=localhost;Database=IntelligentInventory.Infrastructure.Tests;User Id=sa;Password=Passw0rd123";

  private static readonly object Locked = new();
  private static bool initialized;

  public TestDatabaseFixture()
  {
    lock (Locked)
    {
      if (initialized)
        return;

      using (var context = this.CreateContext())
      {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        SpecimenFixture.Customizations.Add(new CategorySpecimenBuilder());

        var categories = SpecimenFixture.CreateMany<Category>(10);

        context.Categories.AddRange(categories);

        context.SaveChanges();
      }

      initialized = true;
    }
  }

  public static Fixture SpecimenFixture { get; } = new Fixture();

  public AppDbContext CreateContext() =>
    new AppDbContext(
      new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlServer(ConnectionString)
        .Options,
      null!);
}
