namespace InventoryManagement.MinimalAPI.Endpoints.Staff;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.StaffAggregate;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

public class List : EndpointBaseAsync
  .WithoutRequest
  .WithResult<List<GetAllStaffDTO>>
{
  private readonly IReadRepository<Staff> repository;

  public List(IReadRepository<Staff> repository)
  {
    this.repository = repository;
  }

  [HttpGet("api/staff")]
  [SwaggerOperation(
    Summary = "Get all Staff",
    Description = "Get all Staff",
    OperationId = "Staff.GetAll",
    Tags = new[] { "StaffEndpoint" })]
  public override async Task<List<GetAllStaffDTO>> HandleAsync(CancellationToken cancellationToken = default)
  {
    var staff = await this.repository.ListAsync(cancellationToken);

    var response = staff.Select(s => GetAllStaffDTO.FromDomain(s));

    return response.ToList();
  }
}

public class GetAllStaffDTO
{
  public Guid Id { get; set; }

  public string FirstName { get; set; }

  public string LastName { get; set; }

  public static GetAllStaffDTO FromDomain(Staff staff)
  {
    return new GetAllStaffDTO
    {
      Id = staff.Id.Value,
      FirstName = staff.Name.FirstName,
      LastName = staff.Name.LastName,
    };
  }
}
