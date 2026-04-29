using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Расчёт по двум формулам: z1 = cosα + cos2α + cos6α + cos7α");
        Console.WriteLine("           z2 = 4·cos(α/2)·cos(5α/2)·cos(4α)");
        Console.WriteLine(new string('-', 60));

        Console.Write("Введите угол α в градусах: ");
        double alphaDeg = double.Parse(Console.ReadLine());

      
        double alpha = alphaDeg * Math.PI / 180.0;

       
        double z1 = Math.Cos(alpha) + Math.Cos(2 * alpha) + Math.Cos(6 * alpha) + Math.Cos(7 * alpha);

      
        double z2 = 4 * Math.Cos(alpha / 2) * Math.Cos(5 * alpha / 2) * Math.Cos(4 * alpha);

        Console.WriteLine($"\nРезультаты:");
        Console.WriteLine($"z1 = {z1:F10}");
        Console.WriteLine($"z2 = {z2:F10}");

        
        double epsilon = 1e-10;
        if (Math.Abs(z1 - z2) < epsilon)
            Console.WriteLine("\nФормулы совпадают (в пределах погрешности).");
        else
            Console.WriteLine($"\nФормулы НЕ совпадают. Разница: {Math.Abs(z1 - z2):E}");
    }
}