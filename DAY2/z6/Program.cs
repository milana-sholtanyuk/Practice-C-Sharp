using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "123.45.678";
            bool onlyDigitsAndDots = s.All(c => char.IsDigit(c) || c == '.');
            Console.WriteLine(onlyDigitsAndDots ? "Да" : "Нет");
        }
    }
}
