namespace InventoryManagement.API.Endpoints.Categories;

using System.Threading;
using System.Threading.Tasks;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.API.BaseEndpoints;
using InventoryManagement.Core.CategoryAggregate;
using InventoryManagement.Core.CategoryAggregate.ValueObjects;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class Update : MultiSourceEndpointBaseAsync
  .WithRequest<int, UpdateCategoryRequestDTO>
  .WithActionResult<UpdateCategoryResponseDTO>
{
  private readonly IRepository<Category> repository;

  public Update(IRepository<Category> repository)
  {
    this.repository = repository;
  }

  [HttpPut("api/categories/{id:int}")]
  [SwaggerOperation(
  Summary = "Update Category",
  Description = "Update Existing Category",
  OperationId = "Categories.Update",
  Tags = new[] { "CategoryEndpoints" })]
  public override async Task<ActionResult<UpdateCategoryResponseDTO>> HandleAsync(
    int id,
    UpdateCategoryRequestDTO request,
    CancellationToken cancellationToken = default)
  {
    var entity = await this.repository.GetByIdAsync(CategoryId.From(id), cancellationToken);

    if (entity is null)
      return this.NotFound();

    entity.CategoryName = new CategoryName(request.CategoryName);

    await this.repository.UpdateAsync(entity, cancellationToken);

    var response = new UpdateCategoryResponseDTO(
      entity.Id.Value,
      entity.CategoryName.Name);

    return this.Ok(response);
  }
}

public record UpdateCategoryRequestDTO(string CategoryName);
public record UpdateCategoryResponseDTO(int Id, string CategoryName);
