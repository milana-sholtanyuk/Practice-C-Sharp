using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите A: ");
        int A = int.Parse(Console.ReadLine());
        Console.Write("Введите B: ");
        int B = int.Parse(Console.ReadLine());

        Console.WriteLine("\n--- Способ 1: while ---");
        int i = A;
        while (i <= B)
        {
            if (i % 2 == 0 && i % 5 == 0)
                Console.Write(i + " ");
            i++;
        }

        Console.WriteLine("\n\n--- Способ 2: do while ---");
        i = A;
        do
        {
            if (i % 2 == 0 && i % 5 == 0)
                Console.Write(i + " ");
            i++;
        } while (i <= B);

        Console.WriteLine("\n\n--- Способ 3: for ---");
        for (i = A; i <= B; i++)
        {
            if (i % 2 == 0 && i % 5 == 0)
                Console.Write(i + " ");
        }

        Console.WriteLine();
    }
}