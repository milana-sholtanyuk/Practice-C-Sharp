using System;
using System.Globalization;

static class DateTimeExtensions
{
    public static string GetRussianDayOfWeek(this DateTime date)
    {
        string[] days = { "Воскресенье", "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота" };
        return days[(int)date.DayOfWeek];
    }
}

class Program
{
    static void Main()
    {
        DateTime today = DateTime.Now;
        Console.WriteLine($"Сегодня: {today.GetRussianDayOfWeek()}");
    }
}