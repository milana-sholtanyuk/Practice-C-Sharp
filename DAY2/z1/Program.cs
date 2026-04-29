using System;

namespace z1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] arr = { -1.5, 2.3, -4.7, 0, -0.5, 3 };
            double? min = null;
            foreach (double x in arr)
                if (x < 0 && (min == null || x < min))
                    min = x;
            Console.WriteLine(min.HasValue ? $"Минимальный отрицательный: {min}" : "Нет отрицательных");
        }
    }
}
