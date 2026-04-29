using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите четырёхзначное число: ");
        int number = int.Parse(Console.ReadLine());

        if (number >= 1000 && number <= 9999)
        {
            int first = number / 1000;
            int last = number % 10;
            int middle = number / 10 % 100; // или (number % 1000) / 10

            int result = last * 1000 + middle * 10 + first;
            Console.WriteLine($"Результат: {result}");
        }
        else
        {
            Console.WriteLine("Ошибка: нужно четырёхзначное число!");
        }
    }
}