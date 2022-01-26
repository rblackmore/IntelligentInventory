namespace EFCoreSetup;

using ElectroCom.IntelligentInventory.InventoryManagement.Infrastructure.Data;
using ElectroCom.IntelligentInventory.InventoryManagement.Infrastructure.DependencyInjection.MSDependencyInjection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class Program
{
  public static async Task Main(string[] args)
  {
    await CreateHostBuilder(args).Build().RunAsync();
  }

  private static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
      .ConfigureServices(services =>
      {
        services.AddHostedService<App>();

        services.AddIntelligentInventory();

        services.AddDbContext<AppDbContext>(options =>
        {
          //options.UseSqlServer(
          //  @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IntelligentInventoryScratch;",
          //  b => b.MigrationsAssembly("EFCoreSetup"));

          options.UseSqlite(
            @"Data Source=D:/Databases/IntelligentInventoryScratch.db;",
            b => b.MigrationsAssembly("EFCoreSetup"));

          options.EnableSensitiveDataLogging();
        });
      });
}
