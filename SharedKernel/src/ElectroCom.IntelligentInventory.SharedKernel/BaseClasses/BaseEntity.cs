namespace ElectroCom.IntelligentInventory.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class BaseEntity
{
  public List<DomainEvent> Events { get; } = new ();
}
