using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите число от -999 до 999: ");
        int n = int.Parse(Console.ReadLine());

        string sign = n > 0 ? "положительное" : (n < 0 ? "отрицательное" : "нулевое");

        if (n == 0)
        {
            Console.WriteLine("нулевое число");
        }
        else
        {
            int absN = Math.Abs(n);
            string length = absN < 10 ? "однозначное" : (absN < 100 ? "двузначное" : "трёхзначное");
            Console.WriteLine($"{sign} {length} число");
        }
    }
}