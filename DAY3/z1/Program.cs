using System;

class A
{
    public int a;
    public int b;

    public A(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public double Method1()
    {
        return 2 - a;
    }

    public double Method2()
    {
        return Math.Sqrt(a);
    }
}

class Program
{
    static void Main()
    {
        A obj = new A(9, 5);
        Console.WriteLine($"a = {obj.a}, b = {obj.b}");
        Console.WriteLine($"2 - a = {obj.Method1()}");
        Console.WriteLine($"√a = {obj.Method2():F4}");
    }
}