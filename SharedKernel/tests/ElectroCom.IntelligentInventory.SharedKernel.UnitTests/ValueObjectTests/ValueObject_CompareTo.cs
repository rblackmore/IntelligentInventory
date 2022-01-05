namespace ElectroCom.IntelligentInventory.SharedKernel.UnitTests.ValueObjectTests;

using System.Collections.Generic;

using Xunit;

public class ValueObject_CompareTo
{
  class CompareToTestValueObject : ValueObject
  {
    public CompareToTestValueObject(string name, int score)
    {
      this.Name = name;
      this.Score = score;
    }

    public string Name { get; set; }

    public int Score { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return this.Name;
      yield return this.Score;
    }
  }

  [Fact]
  public void CompareToObject_ReturnsLessThanZero()
  {
    // Arrange.

    // Act.

    // Assert.
  }
}
