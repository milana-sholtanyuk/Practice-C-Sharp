using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "hello world";
            int uniqueCount = s.Distinct().Count();
            Console.WriteLine($"Уникальных символов: {uniqueCount}");
        }
    }
}
