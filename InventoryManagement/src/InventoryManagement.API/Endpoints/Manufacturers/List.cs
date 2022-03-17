namespace InventoryManagement.API.Endpoints.Manufacturers;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.ManufacturerAggregate;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class List : EndpointBaseAsync
  .WithoutRequest
  .WithActionResult<List<ListManufacturerDTO>>
{
  private readonly IReadRepository<Manufacturer> repository;

  public List(IReadRepository<Manufacturer> repository)
  {
    this.repository = Guard.Against.Null(repository, nameof(repository));
  }

  [HttpGet("api/manufacturers")]
  [SwaggerOperation(
  Summary = "List Manufacturers",
  Description = "Gets a list of all Manufacturers",
  OperationId = "Manufactuers.List",
  Tags = new[] { "ManufacturerEndpoints" })]
  public override async Task<ActionResult<List<ListManufacturerDTO>>> HandleAsync(
    CancellationToken cancellationToken = default)
  {
    var entities = await this.repository.ListAsync(cancellationToken);

    var response = entities
      .Select(e => new ListManufacturerDTO(e.Id.Value, e.Name, e.Description));

    return this.Ok(response.ToList());
  }
}

public record ListManufacturerDTO(int Id, string Name, string Description);
