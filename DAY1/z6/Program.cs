using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите номер спортсмена (1-9): ");
        int number = int.Parse(Console.ReadLine());

        string sport;

        switch (number)
        {
            case 1:
            case 2:
            case 9:
                sport = "баскетбол";
                break;
            case 3:
            case 4:
            case 5:
                sport = "бег";
                break;
            case 6:
            case 7:
            case 8:
                sport = "штанга";
                break;
            default:
                sport = "некорректный номер";
                break;
        }

        Console.WriteLine($"Спортсмен под номером {number} занимается: {sport}");
    }
}