namespace InventoryManagement.API.Endpoints.Manufacturers;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.ManufacturerAggregate;
using InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class Delete : EndpointBaseAsync
  .WithRequest<int>
  .WithActionResult
{

  private readonly IRepository<Manufacturer> repository;

  public Delete(IRepository<Manufacturer> repository)
  {
    this.repository = Guard.Against.Null(repository, nameof(repository));
  }

  [HttpDelete("api/manufactuers/{id:int}")]
  [SwaggerOperation(
    Summary = "Delete Manufacturer by Id(int)",
    Description = "Delete Manufactuer by Id (int)",
    OperationId = "Manufacturer.Delete",
    Tags = new[] { "ManufacturerEndpoints" })]
  public override async Task<ActionResult> HandleAsync(
    int id,
    CancellationToken cancellationToken = default)
  {
    var entity = await this.repository.GetByIdAsync(ManufacturerId.From(id), cancellationToken);

    if (entity is null)
      return this.NotFound();

    await this.repository.DeleteAsync(entity, cancellationToken);

    return this.NoContent();
  }
}
