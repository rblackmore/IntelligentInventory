namespace ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

using ElectroCom.IntelligentInventory.SharedKernel.BaseClasses;

public interface IHandle<TEvent>
  where TEvent : DomainEvent
{
  Task HandleAsync(TEvent eventArgs);
}
