namespace IntelligentInventory.SharedKernel.Interfaces;

using System.Collections.Generic;

using IntelligentInventory.SharedKernel.BaseClasses;

public interface IEntity
{
  List<DomainEvent> Events { get; }
}
