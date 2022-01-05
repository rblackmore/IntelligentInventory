namespace ElectroCom.IntelligentInventory.SharedKernel.UnitTests.ValueObjectTests;

using System;
using System.Collections.Generic;

using FluentAssertions;

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
    var obj1 = new CompareToTestValueObject("abcd", 1) as IComparable;
    var obj2 = new CompareToTestValueObject("abce", 2);

    // Act.
    var comparison = obj1.CompareTo(obj2);

    // Assert.
    comparison.Should().BeLessThan(0);
  }
}
