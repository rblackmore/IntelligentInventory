namespace IntelligentInventory.SharedKernel.BaseClasses;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

public abstract class SingleValueObject<TValue, TThis> : ValueObject
  where TThis : SingleValueObject<TValue, TThis>, new()
{
  private static readonly Func<TThis> Factory;

  static SingleValueObject()
  {
    ConstructorInfo ctor = typeof(TThis)
        .GetTypeInfo()
        .DeclaredConstructors
        .First();

    var argsExp = new Expression[0];
    NewExpression newExp = Expression.New(ctor, argsExp);
    LambdaExpression lambda = Expression.Lambda(typeof(Func<TThis>), newExp);

    Factory = (Func<TThis>)lambda.Compile();
  }

  public TValue Value { get; protected set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return this.Value;
  }

  protected abstract void Validate();

  public static TThis From(TValue item)
  {
    TThis x = Factory();
    x.Value = item;
    x.Validate();

    return x;
  }
}
