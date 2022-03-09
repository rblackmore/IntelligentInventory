namespace InventoryManagement.API.Endpoints.Staff;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.StaffAggregate;

using Microsoft.AspNetCore.Mvc;

using Serilog;

using Swashbuckle.AspNetCore.Annotations;

public class List : EndpointBaseAsync
  .WithoutRequest
  .WithResult<List<StaffDTO>>
{
  private readonly IReadRepository<Staff> repository;

  public List(IReadRepository<Staff> repository)
  {
    this.repository = repository;
  }

  [HttpGet("api/staff")]
  [SwaggerOperation(
    Summary = "Staf List",
    Description = "Gets a list of all Staff Members",
    OperationId = "Staff.List",
    Tags = new[] { "StaffEndpoints "})]
  public override async Task<List<StaffDTO>> HandleAsync(CancellationToken ct = default)
  {
    var staffList = await this.repository.ListAsync(ct);

    var response = staffList.Select(s => new StaffDTO(s.Id.Value, s.Name.FirstName, s.Name.LastName));

    return response.ToList();
  }
}

public record StaffDTO(Guid Id, string FirstName, string LastName);
