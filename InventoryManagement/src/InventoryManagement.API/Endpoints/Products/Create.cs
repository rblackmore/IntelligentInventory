namespace InventoryManagement.API.Endpoints.Products;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.ManufacturerAggregate.ValueObjects;
using InventoryManagement.Core.ProductAggregate;
using InventoryManagement.Core.ProductAggregate.Enums;
using InventoryManagement.Core.ProductAggregate.ValueObjects;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class Create : EndpointBaseAsync
  .WithRequest<CreateProductRequestDTO>
  .WithActionResult<CreateProductResponseDTO>
{
  private readonly IRepository<Product> repository;

  public Create(IRepository<Product> repository)
  {
    this.repository = Guard.Against.Null(repository, nameof(repository));
  }

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
    var newEntity = new Product(
      ManufacturerId.From(request.ManufacturerId),
      request.Description,
      new ProductCode(request.ProductCode),
      Frequency.FromName(request.Frequency));

    await this.repository.AddAsync(newEntity);

    var response = new CreateProductResponseDTO(
      newEntity.Id.Value,
      newEntity.Manufacturer_id.Value,
      newEntity.ProductCode.Value,
      newEntity.Description,
      newEntity.Frequency.Name);

    return this.Created(response.Id.ToString(), response);
  }
}

public record CreateProductRequestDTO(
  int ManufacturerId,
  string Description,
  string ProductCode,
  string Frequency);

public record CreateProductResponseDTO(
  int Id,
  int ManufacturerId,
  string Description,
  string ProductCode,
  string Frequency);
