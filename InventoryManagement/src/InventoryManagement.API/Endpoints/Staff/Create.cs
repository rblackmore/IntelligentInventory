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

public class Create : EndpointBaseAsync
  .WithRequest<CreateStaffRequestDTO>
  .WithActionResult<CreateStaffResponseDTO>
{
  private readonly IRepository<Staff> repository;

  public Create(IRepository<Staff> repository)
  {
    this.repository = Guard.Against.Null(repository, nameof(repository));
  }

  [HttpPost("api/staff")]
  [SwaggerOperation(
    Summary = "Create Staff",
    Description = "Create New Staff Member",
    OperationId = "Staff.Create",
    Tags = new[] { "StaffEndpoints" })]
  public override async Task<ActionResult<CreateStaffResponseDTO>> HandleAsync(
    CreateStaffRequestDTO request,
    CancellationToken cancellationToken = default)
  {
    var newEntity = new Staff(new Name(request.FirstName, request.LastName));

    await this.repository.AddAsync(newEntity);

    var response = new CreateStaffResponseDTO(
      newEntity.Id.Value,
      newEntity.Name.FirstName,
      newEntity.Name.LastName);

    return this.Created(response.Id.ToString(), response);
  }
}

public record CreateStaffRequestDTO(string FirstName, string LastName);

public record CreateStaffResponseDTO(Guid Id, string FirstName, string LastName);
