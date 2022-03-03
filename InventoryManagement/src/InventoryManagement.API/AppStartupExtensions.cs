namespace InventoryManagement.API;

using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Serilog;

/// <summary>
/// Extension methods for <see cref="WebApplicationBuilder"/> and <see cref="WebApplication"/>.
/// </summary>
public static class AppStartupExtensions
{
  public static WebApplicationBuilder ConfigureLogging(this WebApplicationBuilder appBuilder)
  {
    // Configure Logging.
    appBuilder.Logging.ClearProviders();

    appBuilder.Host.UseSerilog((ctx, lc) =>
    {
      lc.ReadFrom.Configuration(ctx.Configuration);
    });

    return appBuilder;
  }

  public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder appBuilder)
  {
    // Configure Services.
    appBuilder.Services.AddControllers();

    appBuilder.Services.AddEndpointsApiExplorer();
    appBuilder.Services.AddSwaggerGen(options => options.EnableAnnotations());

    // Configure Intelligent Inventory.
    appBuilder.Services.AddIntelligentInventory(options =>
    {
      var connString = appBuilder.Configuration.GetConnectionString("DefaultConnection");
      var migrationAssembly = Assembly.GetExecutingAssembly();

      options.UseSqlServer(
        connString,
        sqlOptions => sqlOptions.MigrationsAssembly(migrationAssembly.FullName));
    });
    return appBuilder;
  }

  public static WebApplication ConfigurePipline(this WebApplication webApp)
  {
    // Configure Applicaiton Pipline
    webApp.UseSerilogRequestLogging();
    webApp.UseHttpsRedirection();

    webApp.UseRouting();
    webApp.UseAuthorization();
    webApp.UseAuthentication();
    webApp.MapControllers();

    if (webApp.Environment.IsDevelopment())
    {
      webApp.UseDeveloperExceptionPage();
      webApp.UseSwagger();
      webApp.UseSwaggerUI();
    }

    return webApp;
  }
}
