namespace InventoryManagement.API.Endpoints.Staff;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;

using IntelligentInventory.SharedKernel.Interfaces;

using InventoryManagement.Core.StaffAggregate;

using Microsoft.AspNetCore.Mvc;

using Serilog;

using Swashbuckle.AspNetCore.Annotations;

public class List : EndpointBaseAsync
  .WithoutRequest
  .WithActionResult<List<ListStaffDTO>>
{
  private readonly IReadRepository<Staff> repository;

  public List(IReadRepository<Staff> repository)
  {
    this.repository = Guard.Against.Null(repository, nameof(repository));
  }

  [HttpGet("api/staff")]
  [SwaggerOperation(
    Summary = "List Staff",
    Description = "Gets a list of all Staff Members",
    OperationId = "Staff.List",
    Tags = new[] { "StaffEndpoints" })]
  public override async Task<ActionResult<List<ListStaffDTO>>> HandleAsync(
    CancellationToken cancellationToken = default)
  {
    var entities = await this.repository.ListAsync(cancellationToken);

    var response = entities
      .Select(s => new ListStaffDTO(s.Id.Value, s.Name.FirstName, s.Name.LastName));

    return this.Ok(response.ToList());
  }
}

public record ListStaffDTO(Guid Id, string FirstName, string LastName);
