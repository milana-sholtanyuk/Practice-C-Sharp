using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[,] tickets = new int[20, 36];
            bool hasFree = false;

            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 36; j++)
                {
                    tickets[i, j] = r.Next(0, 2);
                    if (tickets[i, j] == 0) hasFree = true;
                }

            Console.WriteLine(hasFree ? "Свободные места есть" : "Свободных мест нет");
        }
    }
}
