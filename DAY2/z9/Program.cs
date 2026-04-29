using System;
using System.Text;

namespace z9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            bool isEmpty = sb.Length == 0;
            Console.WriteLine(isEmpty ? "Пустой" : "Не пустой");
        }
    }
}
