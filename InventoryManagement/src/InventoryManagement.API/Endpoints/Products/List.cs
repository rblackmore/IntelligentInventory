namespace InventoryManagement.API.Endpoints.Products;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.ProductAggregate;
using InventoryManagement.Core.ProductAggregate.Specifications;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class List : EndpointBaseAsync
  .WithRequest<ProductListRequestDTO>
  .WithActionResult<List<ProductListResponseDTO>>
{
  private readonly IReadRepository<Product> repository;

  public List(IReadRepository<Product> repository)
  {
    this.repository = Guard.Against.Null(repository, nameof(repository));
  }

  [HttpGet("api/products")]
  [SwaggerOperation(
    Summary = "Get All Products",
    Description = "Get All Products Paginated",
    OperationId = "Products.List",
    Tags = new[] { "ProductEndpoints" })]
  public override async Task<ActionResult<List<ProductListResponseDTO>>> HandleAsync(
    [FromQuery] ProductListRequestDTO request,
    CancellationToken cancellationToken = default)
  {
    var entityCount = await this.repository.CountAsync(cancellationToken);

    var pageCount = (int)Math.Ceiling((double)(entityCount / request.PageSize)) + 1;

    var pageNo = request.PageNo > pageCount ? pageCount
                 : request.PageNo < 1 ? 1
                 : request.PageNo;

    var pageSize = request.PageSize;

    var spec = new GetProductListPaginatedSpec(pageNo, pageSize);

    var entities = await this.repository.ListAsync(spec, cancellationToken);

    var response = entities
      .Select(e =>
      new ProductListResponseDTO(
        e.Id.Value,
        e.Manufacturer_id.Value,
        e.ProductCode.Value,
        e.Description,
        e.Frequency.Name,
        e.Categories.Select(c => c.CategoryName.Name)));

    return this.Ok(response.ToList());
  }
}

public record ProductListRequestDTO(
  [FromQuery(Name = "pageNo")] int PageNo = 1,
  [FromQuery(Name = "pageSize")] int PageSize = 5);

public record ProductListResponseDTO(
  int Id,
  int ManufacturerId,
  string ProductCode,
  string Description,
  string Frequency,
  IEnumerable<string> Categories);
