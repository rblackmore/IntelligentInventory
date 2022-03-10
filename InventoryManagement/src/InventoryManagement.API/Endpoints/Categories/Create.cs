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

public class Create : EndpointBaseAsync
  .WithRequest<CreateCategoryRequestDTO>
  .WithActionResult<CreateCategoryResponseDTO>
{
  private readonly IRepository<Category> repository;

  public Create(IRepository<Category> repository)
  {
    this.repository = Guard.Against.Null(repository, nameof(repository));
  }

  [HttpPost("api/categories")]
  [SwaggerOperation(
  Summary = "Create Category",
  Description = "Create a new Category",
  OperationId = "Categories.Create",
  Tags = new[] { "CategoryEndpoints" })]
  public override async Task<ActionResult<CreateCategoryResponseDTO>> HandleAsync(
    CreateCategoryRequestDTO request,
    CancellationToken cancellationToken = default)
  {
    var newEntity = new Category(new CategoryName(request.CategoryName));

    await this.repository.AddAsync(newEntity);

    var response = new CreateCategoryResponseDTO(
      newEntity.Id.Value,
      newEntity.CategoryName.Name);

    return this.Created(response.Id.ToString(), response);
  }
}

public record CreateCategoryRequestDTO(string CategoryName);

public record CreateCategoryResponseDTO(int Id, string CategoryName);
