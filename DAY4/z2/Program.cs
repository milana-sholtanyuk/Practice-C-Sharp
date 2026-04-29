using System;

class Program
{
    static void Mean(double X, double Y, out double AMean, out double GMean)
    {
        AMean = (X + Y) / 2;
        GMean = Math.Sqrt(X * Y);
    }

    static void Main()
    {
        double A = 4, B = 9, C = 16, D = 25;
        double am, gm;

        Mean(A, B, out am, out gm);
        Console.WriteLine($"A,B: AMean={am:F2}, GMean={gm:F2}");

        Mean(A, C, out am, out gm);
        Console.WriteLine($"A,C: AMean={am:F2}, GMean={gm:F2}");

        Mean(A, D, out am, out gm);
        Console.WriteLine($"A,D: AMean={am:F2}, GMean={gm:F2}");
    }
}