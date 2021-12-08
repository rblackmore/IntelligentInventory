namespace ElectroCom.IntelligentInventory.ItemBooking.Core.BookingAggregate;

using System.Collections.Generic;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.SharedKernel;

public class BookingDateTime : ValueObject
{
  public BookingDateTime()
  {
  }

  public BookingDateTime(DateTime outDate)
  {
    this.OutDate = outDate;
  }

  public BookingDateTime(DateTime outDate, DateTime inDate)
  {
    Guard.Against.OutOfRange(outDate, nameof(outDate), outDate, inDate);
    this.OutDate = outDate;
    this.InDate = inDate;
  }

  public DateTime OutDate { get; private set; }

  public DateTime? InDate { get; private set; }

  public bool IsReturned => this.InDate.HasValue;

  public BookingDateTime NewInDate(DateTime inDate)
  {
    return new BookingDateTime(this.OutDate, inDate);
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return this.OutDate;
    yield return this.InDate ?? DateTime.MinValue;
  }
}
