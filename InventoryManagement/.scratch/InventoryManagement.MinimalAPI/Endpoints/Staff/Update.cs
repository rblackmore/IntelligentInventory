namespace InventoryManagement.MinimalAPI.Endpoints.Staff;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.StaffAggregate;
using InventoryManagement.Core.StaffAggregate.ValueObjects;
using InventoryManagement.MinimalAPI.Attributes;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class Update : EndpointBaseAsync
  .WithRequest<UpdateRequest>
  .WithActionResult<UpdateResponse>
{
  private readonly IRepository<Staff> repository;

  public Update(IRepository<Staff> repository)
  {
    this.repository = repository;
  }

  [HttpPut("api/staff/{id:guid}")]
  [SwaggerOperation(
    Summary = "Update Staff",
    Description = "Update Staff",
    OperationId = "Staff.Update",
    Tags = new[] { "StaffEndpoint" })]
  public override async Task<ActionResult<UpdateResponse>> HandleAsync([FromMultiSource] UpdateRequest request, CancellationToken cancellationToken = default)
  {
    var staff = await this.repository.GetByIdAsync(StaffId.From(request.id));

    if (staff is null)
      return NotFound();

    staff.Name = new Name(request.UpdateStaff.FirstName, request.UpdateStaff.LastName);

    await this.repository.SaveChangesAsync();

    return Ok(UpdateResponse.FromDomain(staff));
  }
}

public class UpdateRequest
{
  [FromRoute(Name = "id")] public Guid id { get; init; }

  [FromBody] public StaffDTO UpdateStaff { get; set; } = default!;
}

public class UpdateResponse
{
  public Guid id { get; set; }

  public string FirstName { get; set; }

  public string LastName { get; set; }

  public static UpdateResponse FromDomain(Staff staff)
  {
    return new UpdateResponse
    {
      id = staff.Id.Value,
      FirstName = staff.Name.FirstName,
      LastName = staff.Name.LastName,
    };
  }
}

public class StaffDTO
{
  public string FirstName { get; set; }

  public string LastName { get; set; }

  public static StaffDTO FromDomain(Staff staff)
  {
    return new StaffDTO
    {
      FirstName = staff.Name.FirstName,
      LastName = staff.Name.LastName,
    };
  }
}
