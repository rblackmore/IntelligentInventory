namespace IntelligentInventory.SharedKernel.Guards;

using Ardalis.GuardClauses;

public static class BasicGuards
{
  public static void AnyNullOrEmpty(this IGuardClause guardClause, string[] strings, string paramName)
  {
    for (var i = 0; i < strings.Length; i++)
    {
      var message = string
        .Format("Index {0} in {1} is Null or Empty", i, paramName);

      Guard.Against.NullOrEmpty(strings[i], paramName, message);
    }
  }

  public static void AnyNull(this IGuardClause guardClause, Array array, string paramName)
  {
    for (var i = 0; i < array.Length; i++)
    {
      var message = string
        .Format("Item in array cannot be null. Index: {0}. Parameter: {1}", i, paramName);

      Guard.Against.Null(array.GetValue(i), paramName, message);
    }
  }
}
