namespace InventoryManagement.MinimalAPI.Attributes;

using Microsoft.AspNetCore.Mvc.ModelBinding;

public class FromMultiSourceAttribute : Attribute, IBindingSourceMetadata
{
  public BindingSource BindingSource { get; } = CompositeBindingSource.Create(
    new [] { BindingSource.Path, BindingSource.Query },
    nameof(FromMultiSourceAttribute));
}
