using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите трёхзначное число: ");
        int number = int.Parse(Console.ReadLine());

        if (number >= 100 && number <= 999)
        {
            int first = number / 100;
            int second = number / 10 % 10;
            int third = number % 10;

            if (first == second && second == third)
                Console.WriteLine("Все цифры одинаковые");
            else
                Console.WriteLine("Цифры не одинаковые");
        }
        else
        {
            Console.WriteLine("Ошибка: нужно трёхзначное число!");
        }
    }
}