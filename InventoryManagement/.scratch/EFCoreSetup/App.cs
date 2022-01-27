namespace EFCoreSetup;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.GuardClauses;

using EFCoreSetup.Menu;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;
using ElectroCom.IntelligentInventory.InventoryManagement.Infrastructure.Data;
using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

using IGE.SimpleConsole;
using IGE.SimpleConsole.Menu;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Spectre.Console;

public class App : IHostedService
{
  private readonly IServiceScopeFactory scopeFactory;
  private readonly IHostApplicationLifetime lifeTime;

  public App(IServiceScopeFactory scopeFactory, IHostApplicationLifetime lifeTime)
  {
    this.scopeFactory = Guard.Against.Null(scopeFactory, nameof(scopeFactory));
    this.lifeTime = lifeTime;
  }

  public async Task StartAsync(CancellationToken cancellationToken)
  {
    var isRunning = true;

    var prompt = new SelectionPrompt<MenuOption>();

    prompt.AddChoice(new MenuOption("List All Manufacturers", () => this.ViewAllManufacturers(cancellationToken)));
    prompt.AddChoice(new MenuOption("Add Manufacturer", () => this.AddNewManufacturer(cancellationToken)));
    prompt.AddChoice(new MenuOption("Remove Manufacturer", () => this.RemoveManufacturer(cancellationToken)));
    prompt.AddChoice(new MenuOption("Exit",
      () =>
      {
        isRunning = false;
        this.lifeTime.StopApplication();
        return Task.CompletedTask;
      }
      ));

    while (isRunning)
    {
      AnsiConsole.Clear();
      var choice = await prompt.ShowAsync(AnsiConsole.Console, cancellationToken);

      await choice.CallBack.Invoke();

      if (isRunning)
        SimpleMessage.AnyKeyToContinue();
    }
  }

  private async Task RemoveManufacturer(CancellationToken cancellationToken)
  {
    using var scope = this.scopeFactory.CreateScope();

    var services = scope.ServiceProvider;

    var repo = services.GetService<IRepository<Manufacturer>>();

    if (repo is null)
      throw new ArgumentNullException(nameof(repo));

    var prompt = new SelectionPrompt<Manufacturer>();

    prompt.UseConverter(c => c.Name);

    foreach (var man in await repo.ListAsync(cancellationToken))
    {
      prompt.AddChoice(man);
    }

    var selection = await prompt.ShowAsync(AnsiConsole.Console, cancellationToken);

    await repo.DeleteAsync(selection);
  }

  private async Task AddNewManufacturer(CancellationToken cancellationToken)
  {
    using var scope = this.scopeFactory.CreateScope();

    var services = scope.ServiceProvider;

    var repo = services.GetService<IRepository<Manufacturer>>();

    if (repo is null)
      throw new ArgumentNullException(nameof(repo));

    var name = AnsiConsole.Ask<string>("Name: ");
    var description = AnsiConsole.Ask<string>("Description: ");

    var man = new Manufacturer(name, description);

    await repo.AddAsync(man);
  }

  private async Task ViewAllManufacturers(CancellationToken cancellationToken)
  {
    var services = this.scopeFactory.CreateScope().ServiceProvider;

    var repo = services.GetService<IReadRepository<Manufacturer>>();

    if (repo is null)
      throw new ArgumentNullException(nameof(repo));

    AnsiConsole.MarkupLine($"[green]Count:[/][blue]{await repo.CountAsync(cancellationToken)}[/]");
    AnsiConsole.MarkupLine($"[green]Any:[/][blue]{await repo.AnyAsync(cancellationToken)}[/]");

    var table = new Table();

    table.Title("Manufacturers");

    table.AddColumns("ID", "Name", "Description");

    var mans = await repo.ListAsync(cancellationToken);

    foreach (var manufacturer in mans)
    {
      table.AddRow(manufacturer.Id.ToString(), manufacturer.Name, manufacturer.Description);
    }

    AnsiConsole.Write(table);
  }


  public Task StopAsync(CancellationToken cancellationToken)
  {
    AnsiConsole.MarkupLine("[red]Bye bye!!![/]");
    return Task.CompletedTask;
  }
}
