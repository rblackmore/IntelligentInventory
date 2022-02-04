namespace UnitTests.Core.AutoFixtureCustomizations.SpecimentBuilders;

using System;
using System.Reflection;

using AutoFixture.Kernel;

using InventoryManagement.Core.CategoryAggregate.ValueObjects;

internal class CategoryNameSpecimenBuilder : ISpecimenBuilder
{
  public object Create(object request, ISpecimenContext context)
  {
    if (request as Type != typeof(CategoryName))
      return new NoSpecimen();

    return new CategoryName("CatName");
  }
}
