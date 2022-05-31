namespace InventoryManagement.API.Endpoints.Products;

using System.Threading;
using System.Threading.Tasks;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.API.BaseEndpoints;
using InventoryManagement.Core.ManufacturerAggregate.ValueObjects;
using InventoryManagement.Core.ProductAggregate;
using InventoryManagement.Core.ProductAggregate.Enums;
using InventoryManagement.Core.ProductAggregate.ValueObjects;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class Update : MultiSourceEndpointBaseAsync
  .WithRequest<int, UpdateProductRequestDTO>
  .WithActionResult<UpdateProductResponseDTO>
{
  private readonly IRepository<Product> repository;

  public Update(IRepository<Product> repository)
  {
    this.repository = repository;
  }

  [HttpPut("api/products/{id:int}")]
  [SwaggerOperation(
    Summary = "Update Product",
    Description = "Update Existing Product",
    OperationId = "Products.Update",
    Tags = new[] { "ProductEndpoints" })]
  public override async Task<ActionResult<UpdateProductResponseDTO>> HandleAsync(
    [FromRoute] int id,
    [FromBody] UpdateProductRequestDTO requestDTO,
    CancellationToken cancellationToken = default)
  {
    var entity = await this.repository.GetByIdAsync(ProductId.From(id), cancellationToken);

    if (entity is null)
      return this.NotFound();

    var newEntity = new Product(
      entity.Id,
      ManufacturerId.From(requestDTO.ManufacturerId),
      requestDTO.Description,
      new ProductCode(requestDTO.ProductCode),
      Frequency.FromName(requestDTO.Frequency));

    await this.repository.UpdateAsync(newEntity, cancellationToken);

    var response = new UpdateProductResponseDTO(
      newEntity.Id.Value,
      newEntity.Manufacturer_id.Value,
      newEntity.Description,
      newEntity.ProductCode.Value,
      newEntity.Frequency.Name);

    return this.Ok(response);
  }
}

public record UpdateProductRequestDTO(
  int ManufacturerId,
  string Description,
  string ProductCode,
  string Frequency);

public record UpdateProductResponseDTO(
  int Id,
  int ManufacturerId,
  string Description,
  string ProductCode,
  string Frequency);
