namespace ElectroCom.IntelligentInventory.SharedKernel.Interfaces;

using ElectroCom.IntelligentInventory.SharedKernel.BaseClasses;
using System.Collections.Generic;

public interface IEntity
{
  List<DomainEvent> Events { get; }
}
