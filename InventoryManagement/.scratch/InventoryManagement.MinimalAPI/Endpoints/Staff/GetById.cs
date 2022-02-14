namespace InventoryManagement.MinimalAPI.Endpoints.Staff;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.StaffAggregate;

using InventoryManagement.Core.StaffAggregate.ValueObjects;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class GetById : EndpointBaseAsync
  .WithRequest<Guid>
  .WithActionResult<GetByIdResult>
{
  private readonly IReadRepository<Staff> repository;

  public GetById(IReadRepository<Staff> repository)
  {
    this.repository = repository;
  }

  [HttpGet("staff/{id:guid}")]
  [SwaggerOperation(
    Summary = "Get Staff by Id",
    Description = "Get Staff by Id",
    OperationId = "Staff.GetById",
    Tags = new[] { "StaffEndpoint" })]
  public override async Task<ActionResult<GetByIdResult>> HandleAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
  {
    var staff = await this.repository.GetByIdAsync(StaffId.From(id), cancellationToken);

    if (staff is null)
      return this.NotFound();

    return this.Ok(GetByIdResult.FromDomain(staff));
  }
}

public class GetByIdResult
{
  public Guid id { get; set; }

  public string FirstName { get; set; }

  public string LastName { get; set; }

  public static GetByIdResult FromDomain(Staff staff)
  {
    return new GetByIdResult
    {
      id = staff.Id.Value,
      FirstName = staff.Name.FirstName,
      LastName = staff.Name.LastName,
    };
  }
}
