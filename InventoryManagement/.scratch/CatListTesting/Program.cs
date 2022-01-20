using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate;
using ElectroCom.IntelligentInventory.InventoryManagement.Core.ManufacturerAggregate.ValueObjects;

string categoryString = "Reader;Antenna;Cable";

var list = (CategoryList)categoryString;

var product = new Product(1, 1, "MRU102", new ProductCode("ID.ISC.MRU102-USB"));

product.Categories = (CategoryList)categoryString;

Console.WriteLine(product.Categories);

product.AddCategories(Category.Create("Power Supply"));

foreach (var cat in product.Categories)
{
  Console.WriteLine(cat.Value);
}
