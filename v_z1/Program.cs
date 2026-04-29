using System;

class Program
{
    static void Main()
    {
        double distance = 67;
        double consumption = 8.5;
        double pricePerLiter = 6.5;

        double totalCost = (distance * 2) * (consumption / 100) * pricePerLiter;

        Console.WriteLine($"Поездка на дачу и обратно обойдется в {totalCost:F2} руб.");
    }
}
