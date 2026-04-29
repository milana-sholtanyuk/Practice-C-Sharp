using System;

class Program
{
    static void Main()
    {
        Console.Write("x = ");
        double x = double.Parse(Console.ReadLine());

        Console.Write("y = ");
        int y = int.Parse(Console.ReadLine());

        double result = x / y;
        double rounded = Math.Round(result, 4);

        Console.WriteLine($"округляемый с точностью до 4 знаков результат: {x}/{y}={rounded}");
        Console.WriteLine("Для продолжения нажмите любую клавишу");
        Console.ReadKey();
    }
}