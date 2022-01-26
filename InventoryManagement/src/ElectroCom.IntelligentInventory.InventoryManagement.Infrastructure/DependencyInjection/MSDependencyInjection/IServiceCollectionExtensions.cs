namespace ElectroCom.IntelligentInventory.InventoryManagement.Infrastructure.DependencyInjection.MSDependencyInjection;

using System.Reflection;

using ElectroCom.IntelligentInventory.InventoryManagement.Core.StaffAggregate;
using ElectroCom.IntelligentInventory.InventoryManagement.Infrastructure.Data;
using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

public static class IServiceCollectionExtensions
{
  public static IServiceCollection AddIntelligentInventory(this IServiceCollection services)
  {
    services.AddMediatR(Assembly.GetAssembly(typeof(Staff)) !);

    services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(EFRepository<>));
    services.AddScoped(typeof(EFRepository<>));

    return services;
  }
}
