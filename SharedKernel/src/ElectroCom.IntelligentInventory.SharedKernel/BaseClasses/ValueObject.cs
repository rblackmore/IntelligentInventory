namespace ElectroCom.IntelligentInventory.SharedKernel;

/// <summary>
/// See: https://enterprisecraftsmanship.com/posts/value-object-better-implementation/.
/// </summary>
public abstract class ValueObject : IComparable, IComparable<ValueObject>
{
  private int? cachedHashCode;

  public static bool operator ==(ValueObject a, ValueObject b)
  {
    if (a is null && b is null)
      return true;

    if (a is null || b is null)
      return false;

    return a.Equals(b);
  }

  public static bool operator !=(ValueObject a, ValueObject b)
  {
    return !(a == b);
  }

  public override bool Equals(object? obj)
  {
    if (obj is null)
      return false;

    if (GetUnproxiedType(obj) != GetUnproxiedType(this))
      return false;

    var valueObject = (ValueObject)obj;

    return this.GetEqualityComponents()
      .SequenceEqual(valueObject.GetEqualityComponents());
  }

  public override int GetHashCode()
  {
    if (!this.cachedHashCode.HasValue)
    {
      this.cachedHashCode = this.GetEqualityComponents()
        .Aggregate(1, (current, obj) =>
        {
          unchecked
          {
            return (current * 23) + (obj?.GetHashCode() ?? 0);
          }
        });
    }

    return this.cachedHashCode.Value;
  }

  /// <inheritdoc/>
  public int CompareTo(object? obj)
  {
    return this.CompareTo(obj as ValueObject);
  }

  /// <inheritdoc/>
  public int CompareTo(ValueObject? other)
  {
    if (other is null)
      return 1;

    Type thisType = GetUnproxiedType(this);
    Type otherType = GetUnproxiedType(other);

    if (thisType != otherType)
    {
      return string.Compare(
        thisType.ToString(),
        otherType.ToString(),
        StringComparison.Ordinal);
    }

    object[] components = this.GetEqualityComponents().ToArray();
    object[] otherComponents = other.GetEqualityComponents().ToArray();

    for (int i = 0; i < components.Length; i++)
    {
      int comparison = CompareComponents(components[i], otherComponents[i]);

      if (comparison != 0)
        return comparison;
    }

    return 0;
  }

  /// <summary>
  /// Implemented by sub classes to return all values used for equality comparisons.
  /// </summary>
  /// <returns>List of values to equate.</returns>
  protected abstract IEnumerable<object> GetEqualityComponents();

  /// <summary>
  /// Used to be get base type if using EF or NHibernate ORMs.
  /// </summary>
  /// <param name="obj">Object to get type of.</param>
  /// <returns>Type of the object.</returns>
  internal static Type GetUnproxiedType(object obj)
  {
    const string EFCoreProxyPrefix = "Castle.Proxies.";
    const string NHibernateProxyPostFix = "Proxy";

    Type type = obj.GetType();
    string typeString = type.ToString();

    var isProxied =
      typeString.StartsWith(EFCoreProxyPrefix) ||
      typeString.EndsWith(NHibernateProxyPostFix);

    if (isProxied && type.BaseType is not null)
      return type.BaseType;

    return type;
  }

  private static int CompareComponents(object obj1, object obj2)
  {
    if (obj1 is null && obj2 is null)
      return 0;

    if (obj1 is null)
      return -1;

    if (obj2 is null)
      return 1;

    if (obj1 is IComparable comparable1 && obj2 is IComparable comparable2)
      return comparable1.CompareTo(comparable2);

    return obj1.Equals(obj2) ? 0 : -1;
  }
}
