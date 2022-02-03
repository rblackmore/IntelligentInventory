namespace IntelligentInventory.SharedKernel.Interfaces;

using IntelligentInventory.SharedKernel.BaseClasses;

public interface IHandle<TEvent>
  where TEvent : DomainEvent
{
  Task HandleAsync(TEvent eventArgs);
}
