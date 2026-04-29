using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new[] { "Hello", "World", "C#" };
            string search = "HELLO";
            bool contains = list.Any(item => item.Equals(search, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(contains ? "Содержится" : "Не содержится");
        }
    }
}
