namespace InventoryManagement.API.Endpoints.Manufacturers;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.ManufacturerAggregate;
using InventoryManagement.Core.ManufacturerAggregate.Specifications;
using InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class GetById : EndpointBaseAsync
  .WithRequest<int>
  .WithActionResult<GetManufactuerByIdDTO>
{
  private readonly IReadRepository<Manufacturer> repository;

  public GetById(IReadRepository<Manufacturer> repository)
  {
    this.repository = Guard.Against.Null(repository, nameof(repository));
  }

  [HttpGet("api/manufactuers/{id:int}")]
  [SwaggerOperation(
    Summary = "Manufacturer By Id (int)",
    Description = "Get Manufactuer by Id (int)",
    OperationId = "Manufacturer.GetById",
    Tags = new[] { "ManufacturerEndpoints" })]
  public override async Task<ActionResult<GetManufactuerByIdDTO>> HandleAsync(
    int id,
    CancellationToken cancellationToken = default)
  {
    var spec = new ManufacturerByIdIncludeProductsSpec(ManufacturerId.From(id));

    var entity = await this.repository.GetBySpecAsync(spec);

    if (entity is null)
      return this.NotFound();

    var productDTOs = entity.Products.Select(p => new ProductDTO(p.Id.Value, p.Description, p.ProductCode.Value, p.Frequency.Name));

    var dto = new GetManufactuerByIdDTO(entity.Id.Value, entity.Name, entity.Description, productDTOs.AsEnumerable());

    return this.Ok(dto);
  }
}

public record GetManufactuerByIdDTO(int Id, string Name, string Description, IEnumerable<ProductDTO> Products);

public record ProductDTO(int ID, string Description, string ProductCode, string Frequency);
