using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Console.Write("N (N<10): ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("a b: ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int[,] m = new int[N, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    m[i, j] = r.Next(a, b + 1);

            Console.WriteLine("Матрица:");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(m[i, j] + "\t");
                Console.WriteLine();
            }

            double sumNeg = 0;
            int countNeg = 0;
            for (int i = 0; i < N; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < N; j++)
                {
                    if (m[i, j] < 0) { sumNeg += m[i, j]; countNeg++; }
                    rowSum += m[i, j];
                }
                Console.WriteLine($"Сумма строки {i + 1}: {rowSum}");
            }
            Console.WriteLine(countNeg > 0 ? $"Ср.ар. отрицательных: {sumNeg / countNeg:F2}" : "Нет отрицательных");
        }
    }
}
