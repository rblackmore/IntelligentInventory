namespace ElectroCom.IntelligentInventory.SharedKernel.Specifications;

using System.Linq.Expressions;

public static class SpecificationExtensions
{
  public static ISpecification<T> Where<T>(this ISpecification<T> spec, Expression<Func<T,bool>> expression)
  {
    ((List<Expression<Func<T,bool>>>)spec.WhereExpressions).Add(expression);

    return spec;
  }
}
