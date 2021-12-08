namespace ElectroCom.IntelligentInventory.SharedKernel.UnitTests.EntityTests;

using FluentAssertions;

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
    entity1.Should().Equals(entity2);
    entity2.Should().Equals(entity1);
    (entity1 == entity2).Should().BeTrue();
    (entity2 != entity1).Should().BeFalse();
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
  }
}
