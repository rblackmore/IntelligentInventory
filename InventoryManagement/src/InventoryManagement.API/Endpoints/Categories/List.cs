namespace InventoryManagement.API.Endpoints.Categories;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.CategoryAggregate;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class List : EndpointBaseAsync
  .WithoutRequest
  .WithActionResult<List<ListCategoryDTO>>
{
  private readonly IReadRepository<Category> repository;

  public List(IReadRepository<Category> repository)
  {
    this.repository = Guard.Against.Null(repository, nameof(repository));
  }

  [HttpGet("api/categories")]
  [SwaggerOperation(
  Summary = "List Categories",
  Description = "Gets a list of all Categories",
  OperationId = "Categories.List",
  Tags = new[] { "CategoryEndpoints" })]
  public override async Task<ActionResult<List<ListCategoryDTO>>> HandleAsync(
    CancellationToken cancellationToken = default)
  {
    var entities = await this.repository.ListAsync(cancellationToken);

    var response = entities
      .Select(e => new ListCategoryDTO(e.Id, e.CategoryName.Name));

    return this.Ok(response.ToList());
  }
}

public record ListCategoryDTO(int Id, string CategoryName);
