namespace UnitTests.Infrastructure;

using AutoFixture;

using InventoryManagement.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

public abstract class TestBase
{
  public TestBase(DbContextOptions<AppDbContext> options)
  {
    this.Options = options;

    this.Fixture = new Fixture();
  }

  protected DbContextOptions<AppDbContext> Options { get; set; }

  protected IFixture Fixture { get; set; }
}
