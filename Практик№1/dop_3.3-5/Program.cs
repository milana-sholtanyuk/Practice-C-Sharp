using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите число: ");
        int number = int.Parse(Console.ReadLine());

        int result = 0;
        int multiplier = 1;

        while (number > 0)
        {
            int digit = number % 10;
            if (digit % 2 != 0) // нечётная цифра
            {
                result = result + digit * multiplier;
                multiplier *= 10;
            }
            number /= 10;
        }

        Console.WriteLine($"Результат: {result}");
    }
}