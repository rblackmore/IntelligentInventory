namespace InventoryManagement.API.BaseEndpoints;

using Ardalis.ApiEndpoints;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Alternative BaseEndpointAsync class for use with multiple souce requests objects.
/// Can be use for up to 4 request objects.
/// </summary>
public static class MultiSourceEndpointBaseAsync
{
  public static class WithRequest<TRequest1, TRequest2>
  {
    public abstract class WithoutResult : EndpointBase
    {
      public abstract Task HandlAsync(TRequest1 request1, TRequest2 request2, CancellationToken cancellationToken = default);
    }

    public abstract class WithActionResult<TResponse> : EndpointBase
    {
      public abstract Task<ActionResult<TResponse>> HandleAsync(TRequest1 request1, TRequest2 request2, CancellationToken cancellationToken = default);
    }
  }

  public static class WithRequest<TRequest1, TRequest2, TRequest3>
  {
    public abstract class WithoutResult : EndpointBase
    {
      public abstract Task HandlAsync(TRequest1 request1, TRequest2 request2, TRequest3 request3, CancellationToken cancellationToken = default);
    }

    public abstract class WithActionResult<TResponse> : EndpointBase
    {
      public abstract Task<ActionResult<TResponse>> HandleAsync(TRequest1 request1, TRequest2 request2, TRequest3 request3, CancellationToken cancellationToken = default);
    }
  }

  public static class WithRequest<TRequest1, TRequest2, TRequest3, TRequest4>
  {
    public abstract class WithoutResult : EndpointBase
    {
      public abstract Task HandlAsync(TRequest1 request1, TRequest2 request2, TRequest3 request3, TRequest4 rquest4, CancellationToken cancellationToken = default);
    }

    public abstract class WithActionResult<TResponse> : EndpointBase
    {
      public abstract Task<ActionResult<TResponse>> HandleAsync(TRequest1 request1, TRequest2 request2, TRequest3 request3, TRequest4 rquest4, CancellationToken cancellationToken = default);
    }
  }
}
