namespace InventoryManagement.API.Endpoints.Categories;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.CategoryAggregate;
using InventoryManagement.Core.CategoryAggregate.ValueObjects;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class Delete : EndpointBaseAsync
  .WithRequest<int>
  .WithActionResult
{
  private readonly IRepository<Category> repository;

  public Delete(IRepository<Category> repository)
  {
    this.repository = Guard.Against.Null(repository, nameof(repository));
  }

  [HttpDelete("api/categories/{id:int}")]
  [SwaggerOperation(
    Summary = "Delete Category",
    Description = "Delete Category by Id (int)",
    OperationId = "Categories.Delete",
    Tags = new[] { "CategoryEndpoints" })]
  public override async Task<ActionResult> HandleAsync(
    int id,
    CancellationToken cancellationToken = default)
  {
    var entity = await this.repository.GetByIdAsync(CategoryId.From(id));

    if (entity is null)
      return this.NotFound();

    await this.repository.DeleteAsync(entity);

    return this.NoContent();
  }
}
