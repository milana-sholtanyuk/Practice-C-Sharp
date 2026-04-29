using System;

class Program
{
    static void Main()
    {
        double A = 0;
        double B = Math.PI / 4;
        int M = 20;

        double H = (B - A) / M;

        Console.WriteLine("Табулирование функции F(x) = sin(x) - tg(x)");
        Console.WriteLine($"Отрезок: [{A}, {B:F4}], шаг: {H:F4}\n");
        Console.WriteLine("    x        F(x)");
        Console.WriteLine("------------------");

        double x = A;
        for (int i = 0; i <= M; i++)
        {
            double y = Math.Sin(x) - Math.Tan(x);
            Console.WriteLine($"{x:F4}    {y:F6}");
            x += H;
        }
    }
}