using InventoryManagement.API;

using Serilog;

Log.Logger = new LoggerConfiguration()
  .MinimumLevel.Debug()
  .WriteTo.Console()
  .CreateLogger();

try
{
  Log.Debug("Startup Application");

  var app = Startup.InitializeApp(args);

  app.Run();
}
catch (Exception ex)
{
  //Log.Fatal(ex, "Unhandled Exception, something went Terribly Wrong");
}
finally
{
  Log.CloseAndFlush();
}
