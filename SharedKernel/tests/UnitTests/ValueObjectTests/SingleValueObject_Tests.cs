namespace UnitTests.ValueObjectTests;

using System;

using AutoFixture.Xunit2;

using FluentAssertions;

using IntelligentInventory.SharedKernel.BaseClasses;

using Xunit;

internal class MyEntityId : SingleValueObject<Guid, MyEntityId>
{
  protected override void Validate()
  {
    if (this.Value == Guid.Empty)
      throw new ArgumentException("Empty id", nameof(this.Value));

    if (this.Value == default(Guid))
      throw new ArgumentException("Default id", nameof(this.Value));
  }

  public static MyEntityId Create()
  {
    return MyEntityId.From(Guid.NewGuid());
  }
}

public class SingleValueObject_Tests
{
  [Theory]
  [AutoData]
  public void Create_Success(Guid guid)
  {
    var id = MyEntityId.From(guid);

    id.Value.Should().Be(guid);
  }

  [Fact]
  public void Create_SuccessFromStatic()
  {
    var id = MyEntityId.Create();

    id.Value.Should().NotBe(Guid.Empty);
    id.Value.Should().NotBe(default(Guid));
  }

  [Fact]
  public void Throws_ArgumentException_WithEmptyGuid()
  {
    var id = Guid.Empty;

    var create = () => MyEntityId.From(id);

    create.Should().Throw<ArgumentException>();
  }

  [Fact]
  public void Throws_ArgumentException_WithDefaultGuid()
  {
    var id = default(Guid);

    var create = () => MyEntityId.From(id);

    create.Should().Throw<ArgumentException>();
  }
}
