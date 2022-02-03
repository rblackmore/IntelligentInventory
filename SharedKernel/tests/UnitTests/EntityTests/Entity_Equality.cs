namespace UnitTests.EntityTests;

using FluentAssertions;

using IntelligentInventory.SharedKernel.BaseClasses;

using Xunit;

public class Entity_Equality
{
  class TestEntity : Entity<int>
  {
    public TestEntity(int id, string value)
      : base(id)
    {
      this.Value = value;
    }

    public string Value { get; set; }
  }

  [Fact]
  public void ReturnsTrueGivenSameId()
  {
    var entity1 = new TestEntity(1, "SomeData");
    var entity2 = new TestEntity(1, "SomeOtherData");

    entity1.Should().NotBeSameAs(entity2);

    entity1.Should().Be(entity2);
    entity2.Should().Be(entity1);

    (entity1 == entity2).Should().BeTrue();
    (entity2 != entity1).Should().BeFalse();

    (entity1.GetHashCode() == entity2.GetHashCode()).Should().BeTrue();

  }

  [Fact]
  public void ReturnsFalseGivenDifferingId()
  {
    var entity1 = new TestEntity(1, "SomeData");
    var entity2 = new TestEntity(2, "SomeOtherData");

    entity1.Should().NotBeSameAs(entity2);

    entity1.Should().NotBe(entity2);
    entity2.Should().NotBe(entity1);
    entity1.Should().NotBeEquivalentTo(entity2);
    entity2.Should().NotBeEquivalentTo(entity1);

    (entity1 == entity2).Should().BeFalse();
    (entity1 != entity2).Should().BeTrue();

    (entity1.GetHashCode() == entity2.GetHashCode()).Should().BeFalse();
  }

  [Fact]
  public void ReturnsTrueGivenSameReference()
  {
    var entity1 = new TestEntity(1, "SomeData");
    var entity2 = entity1;

    entity1.Should().BeSameAs(entity2);

    entity1.Should().Be(entity2);
    entity2.Should().Be(entity1);

    (entity1 == entity2).Should().BeTrue();
    (entity2 != entity1).Should().BeFalse();

    (entity1.GetHashCode() == entity2.GetHashCode()).Should().BeTrue();

  }
}
