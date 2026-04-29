using System;

class ExcessLuggageException : Exception
{
    public int ExcessWeight { get; }
    public ExcessLuggageException(int weight)
        : base($"Превышение веса багажа! Ваш вес: {weight} кг (максимум 23 кг)")
    {
        ExcessWeight = weight;
    }
}

class LuggageChecker
{
    public void CheckWeight(int weight)
    {
        if (weight > 23)
            throw new ExcessLuggageException(weight);
        Console.WriteLine($"Вес {weight} кг — допущен к перелёту");
    }
}

class Program
{
    static void Main()
    {
        LuggageChecker checker = new LuggageChecker();

        try
        {
            checker.CheckWeight(25);
        }
        catch (ExcessLuggageException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.WriteLine($"Перевес: {ex.ExcessWeight - 23} кг");
        }
    }
}