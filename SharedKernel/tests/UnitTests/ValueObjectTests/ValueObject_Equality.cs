﻿namespace UnitTests.ValueObjectTests;

using System.Collections.Generic;

using FluentAssertions;

using IntelligentInventory.SharedKernel.BaseClasses;

using Xunit;

public class ValueObject_Equality
{
  class EqualityTestValueObject : ValueObject
  {
    public EqualityTestValueObject(string name, int score)
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
  public void ReturnsTrueGivenMatchingData()
  {
    var obj1 = new EqualityTestValueObject("Grugg", 9001);
    var obj2 = new EqualityTestValueObject("Grugg", 9001);

    obj1.Should().NotBeSameAs(obj2);
    obj1.Should().Be(obj2);
    obj2.Should().Be(obj1);
    obj1.Should().BeEquivalentTo(obj2);
    obj2.Should().BeEquivalentTo(obj1);
    (obj1 == obj2).Should().BeTrue();
    (obj1 != obj2).Should().BeFalse();

    (obj1.GetHashCode() == obj2.GetHashCode()).Should().BeTrue();
  }

  [Fact]
  public void ReturnsFalseGivenMisMatchedData()
  {
    var obj1 = new EqualityTestValueObject("Grugg", 9001);
    var obj2 = new EqualityTestValueObject("Grugg", 9002);

    obj1.Should().NotBeSameAs(obj2);
    obj1.Should().NotBe(obj2);
    obj2.Should().NotBe(obj1);
    obj2.Should().NotBeRankedEquallyTo(obj1);
    obj1.Should().NotBeRankedEquallyTo(obj2);
    (obj1 == obj2).Should().BeFalse();
    (obj1 != obj2).Should().BeTrue();

    (obj1.GetHashCode() == obj2.GetHashCode()).Should().BeFalse();
  }
}
