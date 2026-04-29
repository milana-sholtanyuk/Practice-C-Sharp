using System;
using System.Collections;

class InventoryItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public override string ToString() => $"[{Id}] {Name}: {Quantity} шт.";
}

class InventorySystem
{
    private Hashtable inventory = new Hashtable();

    public void Add(InventoryItem item) => inventory[item.Id] = item;
    public void Remove(int id) => inventory.Remove(id);
    public InventoryItem Find(int id) => inventory[id] as InventoryItem;
    public void UpdateQuantity(int id, int newQuantity)
    {
        var item = Find(id);
        if (item != null) item.Quantity = newQuantity;
    }

    public void PrintAll()
    {
        foreach (DictionaryEntry entry in inventory)
            Console.WriteLine(entry.Value);
    }

    public ArrayList GetLowStockItems(int threshold)
    {
        var result = new ArrayList();
        foreach (DictionaryEntry entry in inventory)
        {
            var item = (InventoryItem)entry.Value;
            if (item.Quantity < threshold) result.Add(item);
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        var system = new InventorySystem();
        system.Add(new InventoryItem { Id = 1, Name = "Молоток", Quantity = 10 });
        system.Add(new InventoryItem { Id = 2, Name = "Отвёртка", Quantity = 3 });
        system.Add(new InventoryItem { Id = 3, Name = "Дрель", Quantity = 1 });

        Console.WriteLine("Все товары:");
        system.PrintAll();

        Console.WriteLine("\nПоиск ID=2:");
        Console.WriteLine(system.Find(2));

        Console.WriteLine("\nТовары с количеством < 5:");
        var lowStock = system.GetLowStockItems(5);
        foreach (InventoryItem item in lowStock) Console.WriteLine(item);
    }
}