namespace Test.Core.AutoFixtureCustomizations;

using AutoFixture;
using AutoFixture.Xunit2;

using Test.Core.AutoFixtureCustomizations.SpecimentBuilders;

public class CoreAutoDataAttribute : AutoDataAttribute
{
  public CoreAutoDataAttribute()
    : base(() =>
    {
      var fixture = new Fixture();
      fixture.Customizations.Add(new CategoryNameSpecimenBuilder());
      return fixture;
    })
  {
  }
}
