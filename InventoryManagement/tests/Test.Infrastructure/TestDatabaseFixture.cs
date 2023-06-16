namespace Test.Infrastructure;

using System.Threading.Tasks;

using AutoFixture;

using InventoryManagement.Core.CategoryAggregate;
using InventoryManagement.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

using Test.Infrastructure.SpecimenBuilders;

public class TestDatabaseFixture
{
  private const string ConnectionString =
    "Server=localhost;Database=IntelligentInventory.Infrastructure.Tests;User Id=sa;Password=p@55w0rd;MultipleActiveresultSets=True";

  private static readonly object Locked = new();
  private static bool initialized;

  public TestDatabaseFixture()
  {
    lock (Locked)
    {
      if (initialized)
        return;

      using (var context = CreateContext())
      {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        SpecimenFixture.Customizations.Add(new CategorySpecimenBuilder());

        this.SeedAsync(context).GetAwaiter();
      }

      initialized = true;
    }
  }

  private async Task SeedAsync(AppDbContext context)
  {
    var categories = SpecimenFixture.CreateMany<Category>(10);

    context.Categories.AddRange(categories);

    await context.SaveChangesAsync();
  }

  public static Fixture SpecimenFixture { get; } = new Fixture();

  public AppDbContext CreateContext() =>
    new AppDbContext(
      new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlServer(ConnectionString)
        .Options,
      null!);
}
