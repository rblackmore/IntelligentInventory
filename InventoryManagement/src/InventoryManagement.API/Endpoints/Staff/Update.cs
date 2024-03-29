﻿namespace InventoryManagement.API.Endpoints.Staff;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.API.BaseEndpoints;
using InventoryManagement.Core.StaffAggregate;
using InventoryManagement.Core.StaffAggregate.ValueObjects;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class Update : MultiSourceEndpointBaseAsync
  .WithRequest<Guid, UpdateStaffRequestDTO>
  .WithActionResult<UpdateStaffResponsefDTO>
{
  private readonly IRepository<Staff> repository;

  public Update(IRepository<Staff> repository)
  {
    this.repository = Guard.Against.Null(repository, nameof(repository));
  }

  [HttpPut("api/staff/{id:guid}")]
  [SwaggerOperation(
  Summary = "Update Staff",
  Description = "Update Existing Staff Member",
  OperationId = "Staff.Update",
  Tags = new[] { "StaffEndpoints" })]
  public override async Task<ActionResult<UpdateStaffResponsefDTO>> HandleAsync(
    [FromRoute] Guid id,
    [FromBody] UpdateStaffRequestDTO requestDTO,
    CancellationToken cancellationToken = default)
  {
    var entity = await this.repository.GetByIdAsync(StaffId.From(id));

    if (entity is null)
      return this.NotFound();

    entity.Name = new Name(requestDTO.FirstName, requestDTO.LastName);

    await this.repository.UpdateAsync(entity, cancellationToken);

    var response = new UpdateStaffResponsefDTO(
      entity.Id.Value,
      entity.Name.FirstName,
      entity.Name.LastName);

    return this.Ok(response);
  }
}

public record UpdateStaffRequestDTO(string FirstName, string LastName);
public record UpdateStaffResponsefDTO(Guid Id, string FirstName, string LastName);
