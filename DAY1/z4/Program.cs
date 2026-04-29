using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите x: ");
        double x = double.Parse(Console.ReadLine());

        double y;

        if (x < 0.5)
        {
            y = (Math.Pow(Math.Log(x), 3) + x * x) / Math.Sqrt(x + 2);
        }
        else // x > 0.5 (по условию x не равен 0.5)
        {
            y = Math.Cos(x) + 2 * Math.Pow(Math.Sin(x), 2);
        }

        Console.WriteLine($"y = {y:F6}");
    }
}