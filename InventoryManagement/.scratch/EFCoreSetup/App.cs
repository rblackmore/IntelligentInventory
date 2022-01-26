namespace EFCoreSetup;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;
using ElectroCom.IntelligentInventory.InventoryManagement.Infrastructure.Data;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Spectre.Console;

public class App : IHostedService
{
  private readonly IServiceScopeFactory scopeFactory;

  public App(IServiceScopeFactory scopeFactory)
  {
    this.scopeFactory = Guard.Against.Null(scopeFactory, nameof(scopeFactory));
  }

  public async Task StartAsync(CancellationToken cancellationToken)
  {

    var services = this.scopeFactory.CreateScope().ServiceProvider;

    var repo = services.GetService<EFRepository<Manufacturer>>();

    if (repo is null)
      throw new ArgumentNullException(nameof(repo));

    AnsiConsole.MarkupLine($"[green]Count:[/][blue]{await repo.CountAsync()}[/]");
    AnsiConsole.MarkupLine($"[green]Any:[/][blue]{await repo.AnyAsync()}[/]");

    var man = await repo.GetByIdAsync(1);

    if (man is null)
      throw new NullReferenceException("No Manufactuer with ID: 1");

    AnsiConsole.MarkupLine($"[yellow]ID: [/][blue]{man.Id}[/]");
    AnsiConsole.MarkupLine($"[yellow]Name: [/][blue]{man.Name}[/]");
    AnsiConsole.MarkupLine($"[yellow]Description: [/][blue]{man.Description}[/]");
    AnsiConsole.MarkupLine($"[yellow]Product Count: [/][blue]{man.Products.Count()}[/]");


  }

  public Task StopAsync(CancellationToken cancellationToken)
  {
    AnsiConsole.MarkupLine("[red]Bye bye!!![/]");
    return Task.CompletedTask;
  }
}
