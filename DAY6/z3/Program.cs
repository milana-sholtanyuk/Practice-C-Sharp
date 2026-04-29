using System;

delegate void ItemMovedHandler(string itemName, string fromLocation, string toLocation);

class WarehouseMonitor
{
    public event ItemMovedHandler ItemMoved;

    public void MoveItem(string item, string from, string to)
    {
        Console.WriteLine($"\nПеремещение товара: {item} из {from} в {to}");
        ItemMoved?.Invoke(item, from, to);
    }
}

class InventorySystem
{
    public void UpdateInventory(string item, string from, string to)
    {
        Console.WriteLine($"  Инвентаризация: {item} теперь в {to}");
    }
}

class SecuritySystem
{
    public void CheckPermissions(string item, string from, string to)
    {
        Console.WriteLine($"  Безопасность: перемещение {item} разрешено");
    }
}

class Program
{
    static void Main()
    {
        WarehouseMonitor monitor = new WarehouseMonitor();
        InventorySystem inventory = new InventorySystem();
        SecuritySystem security = new SecuritySystem();

        monitor.ItemMoved += inventory.UpdateInventory;
        monitor.ItemMoved += security.CheckPermissions;

        monitor.MoveItem("Телефон", "Склад А", "Склад Б");
        monitor.MoveItem("Ноутбук", "Зона приёма", "Магазин");
    }
}