namespace InventoryManagement.API.Endpoints.Categories;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.CategoryAggregate;
using InventoryManagement.Core.CategoryAggregate.ValueObjects;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class Update : EndpointBaseAsync
  .WithRequest<UpdateCategoryDTO>
  .WithActionResult<UpdateCategoryDTO>
{
  private readonly IRepository<Category> repository;

  public Update(IRepository<Category> repository)
  {
    this.repository = repository;
  }
  [HttpPut("api/categories")]
  [SwaggerOperation(
  Summary = "Update Category",
  Description = "Update Existing Category",
  OperationId = "Categories.Update",
  Tags = new[] { "CategoryEndpoints" })]
  public override async Task<ActionResult<UpdateCategoryDTO>> HandleAsync(
    UpdateCategoryDTO request,
    CancellationToken cancellationToken = default)
  {
    var entity = await this.repository.GetByIdAsync(CategoryId.From(request.Id));

    if (entity is null)
      return this.NotFound();

    entity.CategoryName = new CategoryName(request.CategoryName);

    var response = new UpdateCategoryDTO(
      entity.Id.Value,
      entity.CategoryName.Name);

    return this.Ok(response);
  }
}

public record UpdateCategoryDTO(int Id, string CategoryName);
