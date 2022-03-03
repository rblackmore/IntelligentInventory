namespace InventoryManagement.MinimalAPI;

using System.Reflection;

using Microsoft.EntityFrameworkCore;

public static class StartupExtensions
{
  public static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder webBuilder)
  {
    webBuilder.Services.AddControllers();
    webBuilder.Services.AddEndpointsApiExplorer();
    webBuilder.Services.AddSwaggerGen(options => options.EnableAnnotations());

    webBuilder.Services.AddIntelligentInventory(dbContextOptions =>
    {
      var connString = webBuilder.Configuration.GetConnectionString("DefaultConnection");
      var migrationAssembly = Assembly.GetExecutingAssembly();

      dbContextOptions.UseSqlServer(
        connString,
        sqlOptons => sqlOptons.MigrationsAssembly(migrationAssembly.FullName));
    });

    return webBuilder;
  }

  public static WebApplication ConfigureApp(this WebApplication webApp)
  {
    webApp.UseRouting();
    webApp.UseAuthorization();
    webApp.UseHttpsRedirection();
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
