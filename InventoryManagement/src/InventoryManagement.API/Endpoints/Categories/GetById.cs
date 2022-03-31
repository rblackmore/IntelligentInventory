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

public class GetById : EndpointBaseAsync
  .WithRequest<int>
  .WithActionResult<GetCategoryByIdResponseDTO>
{
  private readonly IReadRepository<Category> repository;

  public GetById(IReadRepository<Category> repository)
  {
    this.repository = Guard.Against.Null(repository, nameof(repository));
  }

  [HttpGet("api/categories/{id:int}")]
  [SwaggerOperation(
    Summary = "Get Category By Id (int)",
    Description = "Gets a Category by Id",
    OperationId = "Categories.GetById",
    Tags = new[] { "CategoryEndpoints" })]
  public override async Task<ActionResult<GetCategoryByIdResponseDTO>> HandleAsync(
    int id,
    CancellationToken cancellationToken = default)
  {
    var entity = await this.repository.GetByIdAsync(id, cancellationToken);

    if (entity is null)
      return this.NotFound();

    var response = new GetCategoryByIdResponseDTO(
      entity.Id,
      entity.CategoryName.Name);

    return this.Ok(response);
  }
}

public record GetCategoryByIdResponseDTO(int Id, string CategoryName);
