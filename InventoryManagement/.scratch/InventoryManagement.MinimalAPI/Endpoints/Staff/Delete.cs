namespace InventoryManagement.MinimalAPI.Endpoints.Staff;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.StaffAggregate;
using InventoryManagement.Core.StaffAggregate.ValueObjects;

using Microsoft.AspNetCore.Mvc;

public class Delete : EndpointBaseAsync
  .WithRequest<Guid>
  .WithActionResult
{
  private readonly IRepository<Staff> repository;

  public Delete(IRepository<Staff> repository)
  {
    this.repository = repository;
  }

  [HttpDelete("staff/{id}")]
  public override async Task<ActionResult> HandleAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
  {
    var staff = await this.repository.GetByIdAsync(StaffId.From(id), cancellationToken);

    if (staff is null)
      return NotFound();

    await this.repository.DeleteAsync(staff);

    return NoContent();
  }
}
