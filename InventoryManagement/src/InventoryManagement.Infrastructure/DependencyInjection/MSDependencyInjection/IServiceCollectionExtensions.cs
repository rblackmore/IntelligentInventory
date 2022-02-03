namespace InventoryManagement.Infrastructure.DependencyInjection.MSDependencyInjection;

using System.Reflection;

using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.StaffAggregate;
using InventoryManagement.Infrastructure.Data;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

public static class IServiceCollectionExtensions
{
  public static IServiceCollection AddIntelligentInventory(this IServiceCollection services)
  {
    services.AddMediatR(Assembly.GetAssembly(typeof(Staff))!);

    services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(EFRepository<>));
    services.AddScoped(typeof(EFRepository<>));

    return services;
  }
}
