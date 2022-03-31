namespace Test.Infrastructure;

using AutoFixture;

using InventoryManagement.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

public abstract class TestBase
{
  public TestBase(DbContextOptions<AppDbContext> options)
  {
    Options = options;

    Fixture = new Fixture();
  }

  protected DbContextOptions<AppDbContext> Options { get; set; }

  protected IFixture Fixture { get; set; }
}
