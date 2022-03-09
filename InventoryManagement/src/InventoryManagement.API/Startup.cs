namespace InventoryManagement.API;

using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Serilog;

/// <summary>
/// Extension methods for <see cref="WebApplicationBuilder"/> and <see cref="WebApplication"/>.
/// </summary>
public static class Startup
{
  /// <summary>
  /// Initializes app with services, logging and request pipline.
  /// </summary>
  /// <param name="args">Application Arguments.</param>
  /// <returns><see cref="WebApplication"/> ready for running.</returns>
  public static WebApplication InitializeApp(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    builder.ConfigureLogging();

    builder.ConfigureServices();

    var app = builder.Build();

    app.ConfigurePipline();

    return app;
  }

  private static WebApplicationBuilder ConfigureLogging(this WebApplicationBuilder builder)
  {
    builder.Logging.ClearProviders();

    builder.Host.UseSerilog((ctx, lc) =>
    {
      lc.ReadFrom.Configuration(ctx.Configuration);
    });

    return builder;
  }

  private static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
  {
    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

    // Configure Intelligent Inventory.
    builder.Services.AddIntelligentInventory(options =>
    {
      var connString = builder.Configuration.GetConnectionString("sqlServerConnection");
      var migrationAssembly = Assembly.GetExecutingAssembly();

      options.UseSqlServer(
        connString,
        sqlOptions => sqlOptions.MigrationsAssembly(migrationAssembly.FullName));

      if (builder.Environment.IsDevelopment())
        options.EnableSensitiveDataLogging();
    });

    return builder;
  }

  private static WebApplication ConfigurePipline(this WebApplication app)
  {
    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();

    app.UseRouting();
    app.UseAuthorization();
    app.UseAuthentication();
    app.MapControllers();

    if (app.Environment.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
      app.UseSwagger();
      app.UseSwaggerUI();
    }

    return app;
  }
}
