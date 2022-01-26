namespace ElectroCom.IntelligentInventory.InventoryManagement.Infrastructure.Data;

using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.CategoryAggregate;
using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;
using ElectroCom.IntelligentInventory.InventoryManagement.Core.StaffAggregate;
using ElectroCom.IntelligentInventory.SharedKernel.BaseClasses;

using MediatR;

using Microsoft.EntityFrameworkCore;

public sealed class AppDbContext : DbContext
{
  private readonly IMediator mediator;

  public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator)
    : base(options)
  {
    this.mediator = mediator;
  }

  public DbSet<Staff> Staff { get; set; }

  public DbSet<Category> Categories { get; set; }

  public DbSet<Manufacturer> Manufacturers { get; set; }

  public DbSet<Product> Products { get; set; }

  public DbSet<Item> Items { get; set; }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    int result = await base.SaveChangesAsync(cancellationToken);

    if (this.mediator is null)
      return result;

    // Handle Domain Events.
    var entitiesWithEvents = this.ChangeTracker
      .Entries()
      .Select(e => e.Entity as BaseEntity)
      .Where(e => e?.Events != null && e.Events.Any())
      .ToArray();

    foreach (var entity in entitiesWithEvents)
    {
      if (entity is null)
        continue;

      var events = entity.Events.ToArray();
      entity.Events.Clear();

      foreach (var domainEvent in events)
      {
        await this.mediator.Publish(domainEvent).ConfigureAwait(false);
      }
    }

    return result;
  }

  public override int SaveChanges()
  {
    return this.SaveChangesAsync().GetAwaiter().GetResult();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    modelBuilder.Ignore<DomainEvent>();
  }
}
