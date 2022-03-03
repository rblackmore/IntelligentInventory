using System.Reflection;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure Services.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Configure Intelligent Inventory.
builder.Services.AddIntelligentInventory(options =>
{
  var connString = builder.Configuration.GetConnectionString("DefaultConnection");
  var migrationAssembly = Assembly.GetExecutingAssembly();

  options.UseSqlServer(
    connString,
    sqlOptions => sqlOptions.MigrationsAssembly(migrationAssembly.FullName));
});

var app = builder.Build();

// Configure App.
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

app.Run();
