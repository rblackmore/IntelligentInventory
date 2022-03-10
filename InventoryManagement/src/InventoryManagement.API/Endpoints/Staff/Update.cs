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

public class Update : EndpointBaseAsync
  .WithRequest<UpdateStaffDTO>
  .WithActionResult<UpdateStaffDTO>
{
  private readonly IRepository<Staff> repository;

  public Update(IRepository<Staff> repository)
  {
    this.repository = Guard.Against.Null(repository, nameof(repository));
  }

  [HttpPut("api/staff")]
  [SwaggerOperation(
  Summary = "Update Staff",
  Description = "Update Existing Staff Member",
  OperationId = "Staff.Update",
  Tags = new[] { "StaffEndpoints" })]
  public override async Task<ActionResult<UpdateStaffDTO>> HandleAsync(
    UpdateStaffDTO request,
    CancellationToken cancellationToken = default)
  {
    var entity = await this.repository.GetByIdAsync(StaffId.From(request.Id));

    if (entity is null)
      return this.NotFound();

    entity.Name = new Name(request.FirstName, request.LastName);

    await this.repository.UpdateAsync(entity, cancellationToken);

    var response = new UpdateStaffDTO(
      entity.Id.Value,
      entity.Name.FirstName,
      entity.Name.LastName);

    return this.Ok(response);
  }
}

public record UpdateStaffDTO(
  Guid Id,
  string FirstName,
  string LastName);
