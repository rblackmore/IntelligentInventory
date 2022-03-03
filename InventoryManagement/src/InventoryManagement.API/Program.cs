using InventoryManagement.API;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureLogging();

builder.ConfigureServices();

var app = builder.Build();

app.ConfigurePipline();

app.Run();
