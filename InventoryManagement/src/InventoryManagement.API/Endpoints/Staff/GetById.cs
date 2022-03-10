namespace InventoryManagement.API.Endpoints.Staff;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.StaffAggregate;
using InventoryManagement.Core.StaffAggregate.ValueObjects;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class GetById : EndpointBaseAsync
  .WithRequest<Guid>
  .WithActionResult<GetStaffByIdResponseDTO>
{
  private readonly IReadRepository<Staff> repository;

  public GetById(IReadRepository<Staff> repository)
  {
    this.repository = Guard.Against.Null(repository, nameof(repository));
  }

  [HttpGet("api/staff/{id:guid}")]
  [SwaggerOperation(
    Summary = "Staff By Id (guid)",
    Description = "Get Staff by Id (guid)",
    OperationId = "Staff.GetById",
    Tags = new[] { "StaffEndpoints" })]
  public override async Task<ActionResult<GetStaffByIdResponseDTO>> HandleAsync(
    Guid id,
    CancellationToken cancellationToken = default)
  {
    var entity = await this.repository
      .GetByIdAsync(StaffId.From(id), cancellationToken);

    if (entity is null)
      return this.NotFound();

    var dto = new GetStaffByIdResponseDTO(
      entity.Id.Value,
      entity.Name.FirstName,
      entity.Name.LastName);

    return this.Ok(dto);
  }
}

public record GetStaffByIdResponseDTO(
  Guid Id,
  string FirstName,
  string LastName);
