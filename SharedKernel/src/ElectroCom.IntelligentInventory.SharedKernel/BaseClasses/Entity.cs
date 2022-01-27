namespace ElectroCom.IntelligentInventory.SharedKernel;

using System.Collections.Generic;

using ElectroCom.IntelligentInventory.SharedKernel.BaseClasses;

public abstract class Entity<Tid> : IEntity
{
  private int? cachedHashCode;

  public Entity()
  {
  }

  protected Entity(Tid id)
  {
    this.Id = id;
  }

  public virtual Tid Id { get; protected set; }

  public List<DomainEvent> Events { get; } = new ();

  public static bool operator ==(Entity<Tid> a, Entity<Tid> b)
  {
    if (a is null && b is null)
      return true;

    if (a is null || b is null)
      return false;

    if (a.Id is null || b.Id is null)
      return false;

    return a.Equals(b);
  }

  public static bool operator !=(Entity<Tid> a, Entity<Tid> b)
  {
    return !(a == b);
  }

  public override bool Equals(object? obj)
  {
    if (obj is not Entity<Tid> other)
      return false;

    if (ReferenceEquals(this, other))
      return true;

    Type thisType = ValueObject.GetUnproxiedType(this);
    Type otherType = ValueObject.GetUnproxiedType(other);

    if (thisType != otherType)
      return false;

    if (IsIdNullOrDefault(this) || IsIdNullOrDefault(other))
      return false;

    return this.Id?.Equals(other.Id) ?? false;
  }

  public override int GetHashCode()
  {
    if (!this.cachedHashCode.HasValue)
    {
      this.cachedHashCode =
        (ValueObject.GetUnproxiedType(this).ToString() + this.Id).GetHashCode();
    }

    return this.cachedHashCode.Value;
  }

  private static bool IsIdNullOrDefault(Entity<Tid> entity)
  {
    return entity.Id is null || entity.Id.Equals(default(Tid));
  }
}
