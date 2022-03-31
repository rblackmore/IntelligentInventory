namespace UnitTests.Infrastructure.RepositoryTests;
using System.Linq;
using System.Threading.Tasks;

using AutoFixture;

using FluentAssertions;

using InventoryManagement.Core.CategoryAggregate;
using InventoryManagement.Core.CategoryAggregate.Specifications;
using InventoryManagement.Infrastructure.Data;

using UnitTests;

using Xunit;

public class CategoryRepositoryTest : IClassFixture<TestDatabaseFixture>
{
  public CategoryRepositoryTest(TestDatabaseFixture databaseFixture)
  {
    this.DatabaseFixture = databaseFixture;
  }

  public TestDatabaseFixture DatabaseFixture { get; }

  [Fact]
  public async Task GetCategoryById()
  {
    var context = this.DatabaseFixture.CreateContext();

    var repository = new EFRepository<Category>(context);

    var category = await repository.GetByIdAsync(1);

    category.Should().NotBeNull();
    category?.Id.Should().Be(1);
  }

  [Fact]
  public async Task GetAllCategories()
  {
    var context = this.DatabaseFixture.CreateContext();

    var repository = new EFRepository<Category>(context);

    var categories = await repository.ListAsync();

    Assert.Equal(10, categories.Count());
  }

  [Fact]
  public async Task AddCategory()
  {
    var context = this.DatabaseFixture.CreateContext();

    context.Database.BeginTransaction();

    var repository = new EFRepository<Category>(context);

    var newCategory = TestDatabaseFixture.SpecimenFixture.Create<Category>();

    await repository.AddAsync(newCategory);

    context.ChangeTracker.Clear();

    var category = context.Categories
      .Where(c => c.CategoryName.Name == newCategory.CategoryName.Name)
      .FirstOrDefault();

    category.Should().NotBeNull();

    category?.CategoryName.Should().Be(newCategory.CategoryName);
  }
}
