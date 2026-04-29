using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите первое число: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Введите второе число: ");
        double b = double.Parse(Console.ReadLine());

        double absA = Math.Abs(a);
        double absB = Math.Abs(b);

        double arithmetic = (absA + absB) / 2;
        double geometric = Math.Sqrt(absA * absB);

        Console.WriteLine($"Среднее арифметическое модулей: {arithmetic:F4}");
        Console.WriteLine($"Среднее геометрическое модулей: {geometric:F4}");
    }
}