namespace InventoryManagement.MinimalAPI.Attributes;

using Microsoft.AspNetCore.Mvc.ModelBinding;

/// <summary>
/// Attribute that allows a composite object to provide data from multiple HTTP Sources.
/// Eg. [FromQuery] and [FromBody].
/// </summary>
public class FromMultiSourceAttribute : Attribute, IBindingSourceMetadata
{
  public BindingSource BindingSource { get; } = CompositeBindingSource.Create(
    new[] { BindingSource.Path, BindingSource.Query },
    nameof(FromMultiSourceAttribute));
}
