namespace ElectroCom.IntelligentInventory.ItemBooking.Core.BookingAggregate;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel;

public class BookingId : ValueObject
{
  private BookingId(Guid value)
  {
    this.Value = Guard.Against.Default(value, nameof(value));
  }

  public Guid Value { get; private set; }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return this.Value;
  }

  public static BookingId Create()
  {
    return new BookingId(Guid.NewGuid());
  }

  public static BookingId CreateFrom(Guid guid)
  {
    return new BookingId(guid);
  }
}
