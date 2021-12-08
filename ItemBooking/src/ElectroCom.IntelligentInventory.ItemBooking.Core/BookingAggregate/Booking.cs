namespace ElectroCom.IntelligentInventory.ItemBooking.Core.BookingAggregate;

using Ardalis.GuardClauses;

using ElectroCom.IntelligentInventory.ItemBooking.Core.ItemAggregate;
using ElectroCom.IntelligentInventory.SharedKernel;
using ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

public class Booking : Entity<BookingId>, IAggregateRoot
{
  public Booking(BookingId id, int staffId, SerialNumber itemId)
    : base(id)
  {
    this.StaffId = Guard.Against.Default(staffId, nameof(staffId));
    this.ItemId = itemId;
  }

  public int StaffId { get; private set; }

  public SerialNumber ItemId { get; private set; }

  public BookingDateTime BookingDateTime { get; private set; }

  public string Note { get; set; }

  public void Return(DateTime inDate)
  {
    this.BookingDateTime = this.BookingDateTime.NewInDate(inDate);
  }
}
