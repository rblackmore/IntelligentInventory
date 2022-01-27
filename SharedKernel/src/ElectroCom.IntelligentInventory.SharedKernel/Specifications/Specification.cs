namespace ElectroCom.IntelligentInventory.SharedKernel.Specifications;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public abstract class Specification<T> : ISpecification<T>
{
  public IEnumerable<Expression<Func<T, bool>>> WhereExpressions { get; } = new List<Expression<Func<T,bool>>>();

  public IQueryable<T> GetQuery(IQueryable<T> query)
  {
    foreach (var expression in this.WhereExpressions)
    {
      query = query.Where(expression);
    }

    return query;
  }

  public bool IsSatisfiedBy(T entity)
  {
    foreach (var expression in this.WhereExpressions)
    {
      var pred = expression.Compile();

      if (pred(entity) == false) return false;
    }

    return true;
  }
}
