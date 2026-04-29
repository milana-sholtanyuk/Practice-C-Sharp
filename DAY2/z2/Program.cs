using System;
using System.Linq;

namespace z2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] a = { 3, 6, 9, 12, 15, 18, 30 };
            int count = a.Count(x => x % 3 == 0 && x % 5 != 0);
            Console.WriteLine($"Кратных 3 и не 5: {count}");

            Array.Sort(a);
            Console.WriteLine("Отсортировано: " + string.Join(" ", a));

            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());
            int index = Array.BinarySearch(a, k);
            Console.WriteLine(index >= 0 ? $"Найден на позиции {index}" : "Не найден");
        }
    }
}
