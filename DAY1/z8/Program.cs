using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите A (-5..5): ");
        double A = double.Parse(Console.ReadLine());

        Console.Write("Введите N (1..10): ");
        int N = int.Parse(Console.ReadLine());

        double result = 1;
        for (int i = 1; i <= N; i++)
        {
            result *= A;
        }

        Console.WriteLine($"{A}^{N} = {result:F4}");
    }
}