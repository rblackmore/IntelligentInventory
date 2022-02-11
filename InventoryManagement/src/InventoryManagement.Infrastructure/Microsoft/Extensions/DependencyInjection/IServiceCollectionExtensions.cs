namespace Microsoft.Extensions.DependencyInjection;

using System.Reflection;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.StaffAggregate;
using InventoryManagement.Infrastructure.Data;

using MediatR;

using Microsoft.EntityFrameworkCore;

public static class IServiceCollectionExtensions
{
  public static IServiceCollection AddIntelligentInventory(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsBuilder)
  {
    Guard.Against.Null(optionsBuilder);

    var coreAssembly = Assembly.GetAssembly(typeof(Staff));

    services.AddDbContext<AppDbContext>(optionsBuilder);

    services.AddMediatR(coreAssembly!);

    services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(EFRepository<>));
    services.AddScoped(typeof(EFRepository<>));

    return services;
  }
}
