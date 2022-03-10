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

public class Delete : EndpointBaseAsync
  .WithRequest<Guid>
  .WithActionResult
{
  private readonly IRepository<Staff> repository;

  public Delete(IRepository<Staff> repository)
  {
    this.repository = repository;
  }

  [HttpDelete("api/staff/{id:guid}")]
  [SwaggerOperation(
    Summary = "Delete Staff",
    Description = "Delete Staff Member",
    OperationId = "Staff.Delete",
    Tags = new[] { "StaffEndpoints" })]
  public override async Task<ActionResult> HandleAsync(
    Guid id,
    CancellationToken cancellationToken = default)
  {
    var entity = await this.repository.GetByIdAsync(StaffId.From(id));

    if (entity is null)
      return this.NotFound();

    await this.repository.DeleteAsync(entity);

    return this.NoContent();
  }
}
