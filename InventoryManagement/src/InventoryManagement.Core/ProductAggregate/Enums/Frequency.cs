namespace InventoryManagement.Core.ProductAggregate.Enums;

using Ardalis.GuardClauses;
using Ardalis.SmartEnum;

public class Frequency : SmartEnum<Frequency>
{
  public static readonly Frequency None = new(nameof(None), 0, string.Empty);
  public static readonly Frequency LF = new(nameof(LF), 1, "Low Frequency (125Khz or 134.2Khz)");
  public static readonly Frequency HF = new(nameof(HF), 2, "High Frequency (13.56Mhz)");
  public static readonly Frequency UHF = new(nameof(UHF), 4, "Ultra High Frequency (920-926Mhz)");
  public static readonly Frequency Dual = new(nameof(Dual), 8, "Dual Frequency HF and UHF");

  private Frequency(string name, int value, string description)
    : base(name, value)
  {
    Description = Guard.Against.Null(description, nameof(description));
  }

  private Frequency()
    : base(nameof(None), 0)
  {
    // EF Core.
  }

  public string Description { get; set; }
}
