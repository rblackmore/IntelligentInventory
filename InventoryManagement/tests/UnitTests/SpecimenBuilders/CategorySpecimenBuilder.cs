namespace UnitTests.SpecimenBuilders;
using System;

using AutoFixture;
using AutoFixture.Kernel;

using InventoryManagement.Core.CategoryAggregate;
using InventoryManagement.Core.CategoryAggregate.ValueObjects;

public class CategorySpecimenBuilder : ISpecimenBuilder
{
  public object Create(object request, ISpecimenContext context)
  {
    var type = request as Type;

    if (type is null)
      return new NoSpecimen();

    if (type != typeof(Category))
      return new NoSpecimen();

    return new Category(
      new CategoryName(
        context.Create<string>()[..5]));
  }
}
