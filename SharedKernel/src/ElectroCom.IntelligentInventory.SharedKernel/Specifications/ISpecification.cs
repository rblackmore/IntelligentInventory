namespace ElectroCom.IntelligentInventory.SharedKernel.Specifications;

using System.Linq.Expressions;

public interface ISpecification<T>
{
  IEnumerable<Expression<Func<T, bool>>> WhereExpressions { get; }

  IQueryable<T> GetQuery(IQueryable<T> query);

  bool IsSatisfiedBy(T entity);
}
