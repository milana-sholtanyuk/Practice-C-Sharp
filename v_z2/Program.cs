using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите четырёхзначное число: ");
        int number = int.Parse(Console.ReadLine());

        if (number >= 1000 && number <= 9999)
        {
            int sum = number % 10 + number / 10 % 10 + number / 100 % 10 + number / 1000;
            Console.WriteLine($"Сумма цифр: {sum}");
        }
        else
        {
            Console.WriteLine("Ошибка: число должно быть четырёхзначным!");
        }
    }
}
