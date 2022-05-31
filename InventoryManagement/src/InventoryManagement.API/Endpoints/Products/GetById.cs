namespace InventoryManagement.API.Endpoints.Products;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.ProductAggregate;
using InventoryManagement.Core.ProductAggregate.ValueObjects;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class GetById : EndpointBaseAsync
  .WithRequest<int>
  .WithActionResult<GetProductByIdResposneDTO>
{
  private readonly IReadRepository<Product> repository;

  public GetById(IReadRepository<Product> repository)
  {
    this.repository = Guard.Against.Null(repository, nameof(repository));
  }

  [HttpGet("api/products/{id:int}")]
  [SwaggerOperation(
  Summary = "Get Product By Id (int)",
  Description = "Gets a Product by Id",
  OperationId = "Products.GetById",
  Tags = new[] { "ProductEndpoints" })]
  public override async Task<ActionResult<GetProductByIdResposneDTO>> HandleAsync(
    int id,
    CancellationToken cancellationToken = default)
  {
    var entity = await this.repository.GetByIdAsync(ProductId.From(id), cancellationToken);

    if (entity is null)
      return this.NotFound();

    var response = new GetProductByIdResposneDTO(
      entity.Id.Value,
      entity.Manufacturer_id.Value,
      entity.Description,
      entity.ProductCode.Value,
      entity.Frequency.Value,
      entity.Frequency.Name);

    return this.Ok(response);
  }
}

public record GetProductByIdResposneDTO(
  int Id,
  int ManufacturerId,
  string Description,
  string ProductCode,
  int FrequencyValue,
  string Frequency);
