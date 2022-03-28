namespace InventoryManagement.API.Endpoints.Products;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using InventoryManagement.Core.ManufacturerAggregate.ValueObjects;
using InventoryManagement.Core.ProductAggregate;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class Create : EndpointBaseAsync
  .WithRequest<CreateProductRequestDTO>
  .WithActionResult<CreateProductResponseDTO>
{
  [HttpPost("api/products")]
  [SwaggerOperation(
    Summary = "Create Product",
    Description = "Create New Product",
    OperationId = "Products.Create",
    Tags = new[] { "ProductEndppoints" })]
  public override async Task<ActionResult<CreateProductResponseDTO>> HandleAsync(
    CreateProductRequestDTO request,
    CancellationToken cancellationToken = default)
  {
    // TODO: This.
    throw new NotImplementedException();
  }
}

public record CreateProductRequestDTO(
  int ManufacturerId,
  string ProductCode,
  string Description,
  string Frequency,
  IEnumerable<string> Categories);

public record CreateProductResponseDTO(
  int Id,
  int ManufacturerId,
  string ProductCode,
  string Description,
  string Frequency,
  IEnumerable<string> Categories);
