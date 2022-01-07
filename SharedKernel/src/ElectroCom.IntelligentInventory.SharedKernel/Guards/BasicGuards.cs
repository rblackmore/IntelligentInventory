namespace ElectroCom.IntelligentInventory.SharedKernel.Guards;

using Ardalis.GuardClauses;

public static class BasicGuards
{
  public static void AnyNullOrEmpty(this IGuardClause guardClause, string[] strings, string paramName)
  {
    for (int i = 0; i < strings.Length; i++)
    {
      Guard.Against.NullOrEmpty(strings[i], paramName, string.Format("Index {0} in {1} is Null or Empty", i, paramName));
    }
  }

  public static void AnyNull(this IGuardClause guardClause, Array array, string paramName)
  {
    for (int i = 0; i < array.Length; i++)
    {
      Guard.Against.Null(array.GetValue(i), paramName, string.Format("Item in array cannot be null. Index: {0}. Parameter: {1}", i, paramName));
    }
  }
}
