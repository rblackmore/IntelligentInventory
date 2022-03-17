namespace InventoryManagement.API.Endpoints.Manufacturers;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.API.BaseEndpoints;
using InventoryManagement.Core.ManufacturerAggregate;
using InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class Update : MultiSourceEndpointBaseAsync
  .WithRequest<int, UpdateManufacturerRequestDTO>
  .WithActionResult<UpdateManufacturerResponseDTO>
{
  private readonly IRepository<Manufacturer> repository;

  public Update(IRepository<Manufacturer> repository)
  {
    this.repository = Guard.Against.Null(repository, nameof(repository));
  }

  [HttpPut("api/manufactuers/{id:int}")]
  [SwaggerOperation(
    Summary = "Update Manufacturer",
    Description = "Update Manufacturer Details",
    OperationId = "Manufacturer.Update",
    Tags = new[] { "ManufacturerEndpoints" })]
  public override async Task<ActionResult<UpdateManufacturerResponseDTO>> HandleAsync(
    [FromRoute] int id,
    [FromBody] UpdateManufacturerRequestDTO requestDTO,
    CancellationToken cancellationToken = default)
  {
    var entity = await this.repository.GetByIdAsync(ManufacturerId.From(id));

    if (entity is null)
      return this.NotFound();

    entity.Name = requestDTO.Name;
    entity.Description = requestDTO.Description;

    await this.repository.UpdateAsync(entity, cancellationToken);

    var response = new UpdateManufacturerResponseDTO(entity.Id.Value, entity.Name, entity.Description);

    return this.Ok(response);
  }
}

public record UpdateManufacturerRequestDTO(string Name, string Description);

public record UpdateManufacturerResponseDTO(int Id, string Name, string Description);
