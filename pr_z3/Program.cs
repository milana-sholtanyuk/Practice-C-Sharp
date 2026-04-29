using System;

class Program
{
    static void Main()
    {
        double x = 1;

        double y = Math.Sqrt(x) * Math.Sin(2 * x) + Math.Exp(-2 * x) * (x + Math.Log(Math.Sqrt(x)));

        Console.WriteLine($"x = {x}");
        Console.WriteLine($"y = {y:F10}");
    }
}