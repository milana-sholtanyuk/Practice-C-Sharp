using System;

class Program
{
    static void HanoiTower(int n, char from, char to, char aux)
    {
        if (n == 1)
        {
            Console.WriteLine($"Переместить диск 1 с {from} на {to}");
            return;
        }
        HanoiTower(n - 1, from, aux, to);
        Console.WriteLine($"Переместить диск {n} с {from} на {to}");
        HanoiTower(n - 1, aux, to, from);
    }

    static void Main()
    {
        HanoiTower(3, 'A', 'C', 'B');
    }
}