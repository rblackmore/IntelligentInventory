namespace InventoryManagement.MinimalAPI.Endpoints.Staff;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.StaffAggregate;
using InventoryManagement.Core.StaffAggregate.ValueObjects;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class Create : EndpointBaseAsync
  .WithRequest<CreateRequest>
  .WithActionResult<CreateResponse>
{
  private readonly IRepository<Staff> repository;

  public Create(IRepository<Staff> repository)
  {
    this.repository = repository;
  }

  [HttpPost("staff")]
  [SwaggerOperation(
    Summary = "Create New Staff",
    Description = "Create New Staff",
    OperationId = "Staff.Create",
    Tags = new[] { "StaffEndpoint" })]
  public override async Task<ActionResult<CreateResponse>> HandleAsync(CreateRequest request, CancellationToken cancellationToken = default)
  {
    var staff = request.ToDomain();

    await this.repository.AddAsync(staff);

    return this.Created(staff.Id.Value.ToString(), CreateResponse.FromDomain(staff));
  }
}

public class CreateResponse
{
  public Guid id { get; set; }

  public string FirstName { get; set; }

  public string LastName { get; set; }

  public static CreateResponse FromDomain(Staff staff)
  {
    return new CreateResponse
    {
      id = staff.Id.Value,
      FirstName = staff.Name.FirstName,
      LastName = staff.Name.LastName,
    };
  }
}

public class CreateRequest
{
  public string FirstName { get; set; }

  public string LastName { get; set; }

  internal Staff ToDomain()
  {
    return new Staff(new Name(this.FirstName, this.LastName));
  }

  public static CreateRequest FromDomain(Staff staff)
  {
    return new CreateRequest
    {
      FirstName = staff.Name.FirstName,
      LastName = staff.Name.LastName,
    };
  }
}
