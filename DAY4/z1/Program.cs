using System;

class Program
{
    static int SumOfDigits(int n)
    {
        n = Math.Abs(n);
        int sum = 0;
        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }
        return sum;
    }

    static void Main()
    {
        Console.WriteLine(SumOfDigits(12345)); 
        Console.WriteLine(SumOfDigits(-987)); 
    }
}