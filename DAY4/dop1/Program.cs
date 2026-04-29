using System;

class Program
{
    static double AreaOfTriangle(double xA, double yA, double xB, double yB, double xC, double yC)
    {
        return Math.Abs((xB - xA) * (yC - yA) - (xC - xA) * (yB - yA)) / 2;
    }

    static void Main()
    {
       
        double xA = 0, yA = 0;
        double xB = 4, yB = 0;
        double xC = 0, yC = 3;
        double xD = 4, yD = 3;

        double areaABC = AreaOfTriangle(xA, yA, xB, yB, xC, yC);
        double areaABD = AreaOfTriangle(xA, yA, xB, yB, xD, yD);
        double areaACD = AreaOfTriangle(xA, yA, xC, yC, xD, yD);

        Console.WriteLine($"Площадь ABC: {areaABC:F2}");
        Console.WriteLine($"Площадь ABD: {areaABD:F2}");
        Console.WriteLine($"Площадь ACD: {areaACD:F2}");
    }
}