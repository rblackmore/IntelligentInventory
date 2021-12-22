namespace ElectroCom.IntelligentInventory.SharedKernel.BaseClasses;

using System.Collections.Generic;

using Ardalis.GuardClauses;

public abstract class SingleValueObject<T> : ValueObject
  where T : struct
{
  public SingleValueObject(T value)
  {
    this.Value = Guard.Against.Null(value, nameof(value));
  }

  public T Value { get; private set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return this.Value;
  }
}
