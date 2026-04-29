using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] jagged = { new[] { 1, 2 }, new[] { 3, 0 }, new[] { 2, 1 } };
            var sums = jagged.Select(row => row.Sum()).ToList();
            bool possible = sums.All(s => s == sums[0]);
            Console.WriteLine(possible ? "Можно" : "Нельзя");
        }
    }
}
