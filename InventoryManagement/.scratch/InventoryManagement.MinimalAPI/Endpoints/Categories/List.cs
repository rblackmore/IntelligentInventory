namespace InventoryManagement.MinimalAPI.Endpoints.Categories;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.CategoryAggregate;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class List : EndpointBaseAsync
  .WithoutRequest
  .WithResult<List<CategoryDTO>>
{
  private readonly IReadRepository<Category> repository;

  public List(IReadRepository<Category> repository)
  {
    this.repository = repository;
  }

  [HttpGet("api/categories")]
  [SwaggerOperation(
  Summary = "Get Categories",
  Description = "Get List of Categories",
  OperationId = "Categories.List",
  Tags = new[] { "CategoryEndpoints" })]
  public override async Task<List<CategoryDTO>> HandleAsync(CancellationToken cancellationToken = default)
  {
    var categories = await this.repository.ListAsync(cancellationToken);

    var dtos = categories
      .Select(c => new CategoryDTO(c.Id.Value, c.CategoryName.Name));

    return dtos.ToList();
  }
}

public record CategoryDTO(int ID, string Name);
