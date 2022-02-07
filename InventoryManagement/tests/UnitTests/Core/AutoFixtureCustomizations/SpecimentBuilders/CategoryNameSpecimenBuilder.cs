namespace UnitTests.Core.AutoFixtureCustomizations.SpecimentBuilders;

using System;
using System.Reflection;

using AutoFixture.Kernel;

using InventoryManagement.Core.CategoryAggregate.ValueObjects;

/// <summary>
/// Specimen Builder for <see cref="CategoryName"/> name parameter.
/// Produces random string with lenth 3-20 (inclusive) characters.
/// </summary>
internal class CategoryNameSpecimenBuilder : ISpecimenBuilder
{
  public object Create(object request, ISpecimenContext context)
  {
    if (request is not ParameterInfo pi)
      return new NoSpecimen();

    if (pi.Member.DeclaringType != typeof(CategoryName))
      return new NoSpecimen();

    if (pi.ParameterType != typeof(string))
      return new NoSpecimen();

    if (pi.Name != "name")
      return new NoSpecimen();

    var length = new Random().Next(3, 21);

    var ret = Guid.NewGuid().ToString()[..length];

    return ret;
  }
}
