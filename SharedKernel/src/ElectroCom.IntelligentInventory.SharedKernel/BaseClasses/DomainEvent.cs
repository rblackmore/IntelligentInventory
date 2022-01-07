namespace ElectroCom.IntelligentInventory.SharedKernel.BaseClasses;

using MediatR;

public abstract class DomainEvent : INotification
{
  public Guid EventId { get; } = Guid.NewGuid();

  public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.UtcNow;
}
