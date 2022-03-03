namespace InventoryManagement.MinimalAPI.Endpoints.Categories;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.CategoryAggregate;
using InventoryManagement.Core.CategoryAggregate.ValueObjects;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class Create : EndpointBaseAsync
  .WithRequest<CreateCategoryRequest>
  .WithResult<CreateCategoryResponse>
{
  private readonly IRepository<Category> repository;

  public Create(IRepository<Category> repository)
  {
    this.repository = repository;
  }
  [HttpPost("/api/categories")]
  [SwaggerOperation(
    Summary = "Create Category",
    Description = "Create and Add New Category",
    OperationId = "Categories.Create",
    Tags = new[] { "CategoryEndpoints" }
    )]
  public override async Task<CreateCategoryResponse> HandleAsync(
    CreateCategoryRequest request,
    CancellationToken cancellationToken = default)
  {
    var category = new Category(new CategoryName(request.CategoryName));

    await this.repository.AddAsync(category);

    return new CreateCategoryResponse(category.Id.Value, category.CategoryName.Name);
  }
}

public record CreateCategoryRequest(string CategoryName);

public record CreateCategoryResponse(int CategoryId, string CategoryName);
