namespace InventoryManagement.MinimalAPI.Endpoints.Staff;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.StaffAggregate;

using Microsoft.AspNetCore.Mvc;

public class GetAllStaffResponse
{
  public Guid Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }

  public static GetAllStaffResponse FromDomain(Staff staff)
  {
    return new GetAllStaffResponse
    {
      Id = staff.Id.Value,
      FirstName = staff.Name.FirstName,
      LastName = staff.Name.LastName,
    };
  }
}


public class GetAll : EndpointBaseAsync
  .WithoutRequest
  .WithResult<List<GetAllStaffResponse>>
{
  private readonly IReadRepository<Staff> repository;

  public GetAll(IReadRepository<Staff> repository)
  {
    this.repository = repository;
  }

  [HttpGet("staff")]
  public override async Task<List<GetAllStaffResponse>> HandleAsync(CancellationToken cancellationToken = default)
  {
    var staff = await this.repository.ListAsync(cancellationToken);
    
    var response = staff.Select(s => GetAllStaffResponse.FromDomain(s));

    return response.ToList();
  }
}
