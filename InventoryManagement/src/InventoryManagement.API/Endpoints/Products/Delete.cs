namespace InventoryManagement.API.Endpoints.Products;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.ProductAggregate;
using InventoryManagement.Core.ProductAggregate.ValueObjects;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class Delete : EndpointBaseAsync
  .WithRequest<int>
  .WithActionResult
{
  private readonly IRepository<Product> repository;

  public Delete(IRepository<Product> repository)
  {
    this.repository = repository;
  }

  [HttpDelete("api/products/{id:int}")]
  [SwaggerOperation(
  Summary = "Delete Product",
  Description = "Delete Product by Id (int)",
  OperationId = "Products.Delete",
  Tags = new[] { "ProductEndpoints" })]
  public override async Task<ActionResult> HandleAsync(
    int id,
    CancellationToken cancellationToken = default)
  {
    var entity = await this.repository.GetByIdAsync(ProductId.From(id), cancellationToken);

    if (entity is null)
      return this.NotFound();

    await this.repository.DeleteAsync(entity, cancellationToken);

    return this.NoContent();
  }
}
