using System.Reflection;

using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.StaffAggregate;
using InventoryManagement.Core.StaffAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIntelligentInventory(dbContextOptions =>
{
  var connString = builder.Configuration.GetConnectionString("DefaultConnection");
  var migrationAssembly = Assembly.GetExecutingAssembly();

  dbContextOptions.UseSqlServer(
    connString,
    sqlOptons => sqlOptons.MigrationsAssembly(migrationAssembly.FullName));
});

var app = builder.Build();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.MapPost("/staff", async (StaffDTO dto, IRepository<Staff> repo) =>
{
  var newEntity = new Staff(StaffId.Create(), new Name(dto.firstName, dto.lastName));

  var result = await repo.AddAsync(newEntity);

  return Results.Created($"/staff/{result.Id.Value}", new StaffDTO(result.Id.Value, result.Name.FirstName, result.Name.LastName));
});

app.MapGet("/staff", async (IReadRepository<Staff> repository) =>
{
  var staff = await repository.ListAsync();

  var dtos = staff.Select(e => new StaffDTO(e.Id.Value, e.Name.FirstName, e.Name.LastName));

  if (staff.Any())
    return Results.Ok(dtos);

  return Results.NotFound();
});

app.MapGet("/staff/{id}", async (Guid id, IReadRepository<Staff> repo) =>
{
  var staff = await repo.GetByIdAsync<StaffId>(StaffId.CreateFrom(id));

  if (staff is null)
    return Results.NotFound();

  return Results.Ok(new StaffDTO(staff.Id.Value, staff.Name.FirstName, staff.Name.LastName));
});

app.Run();

record StaffDTO(Guid id, string firstName, string lastName);
