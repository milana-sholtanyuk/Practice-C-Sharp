using System;

class Program
{
    static void FindMinValue(in int[] array, out int minValue)
    {
        minValue = array[0];
        for (int i = 1; i < array.Length; i++)
            if (array[i] < minValue) minValue = array[i];
    }

    static void FindMinValue(in double[] array, out double minValue)
    {
        minValue = array[0];
        for (int i = 1; i < array.Length; i++)
            if (array[i] < minValue) minValue = array[i];
    }

    static void Main()
    {
        int[] intArray = { 5, 10, 1, 4 };
        FindMinValue(in intArray, out int minInt);
        Console.WriteLine($"Min int: {minInt}");

        double[] doubleArray = { 5.5, 2.1, 3.3 };
        FindMinValue(in doubleArray, out double minDouble);
        Console.WriteLine($"Min double: {minDouble}");
    }
}