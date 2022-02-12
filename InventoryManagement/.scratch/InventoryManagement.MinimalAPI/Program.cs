﻿using System.Reflection;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.Run();