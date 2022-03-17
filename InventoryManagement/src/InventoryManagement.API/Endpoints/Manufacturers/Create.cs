namespace InventoryManagement.API.Endpoints.Manufacturers;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.ManufacturerAggregate;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class Create : EndpointBaseAsync
  .WithRequest<CreateManufacturerRequestDTO>
  .WithActionResult<CreateManufacturerResponseDTO>
{
  private readonly IRepository<Manufacturer> repository;

  public Create(IRepository<Manufacturer> repository)
  {
    this.repository = Guard.Against.Null(repository, nameof(repository));
  }

  [HttpPost("api/manufacturers")]
  [SwaggerOperation(
    Summary = "Create Manufacturer",
    Description = "Creates a Manufacturer",
    OperationId = "Manufactuers.Create",
    Tags = new[] { "ManufacturerEndpoints" })]
  public override async Task<ActionResult<CreateManufacturerResponseDTO>> HandleAsync(
    CreateManufacturerRequestDTO request,
    CancellationToken cancellationToken = default)
  {
    var newEntity = new Manufacturer(request.Name, request.Description);

    await this.repository.AddAsync(newEntity);

    var response = new CreateManufacturerResponseDTO(
      newEntity.Id.Value,
      newEntity.Name,
      newEntity.Description);

    return this.Created(response.Id.ToString(), response);
  }
}

public record CreateManufacturerRequestDTO(string Name, string Description);

public record CreateManufacturerResponseDTO(int Id, string Name, string Description);
