using System;

class ExpiredProductException : Exception
{
    public ExpiredProductException() : base("Продукт просрочен") { }
    public ExpiredProductException(string message) : base(message) { }
    public ExpiredProductException(string message, Exception inner) : base(message, inner) { }
}

class Product
{
    public void CheckExpiration(DateTime expirationDate)
    {
        if (expirationDate < DateTime.Now)
            throw new ExpiredProductException($"Срок годности истёк {expirationDate:dd.MM.yyyy}");
        Console.WriteLine("Продукт годен");
    }
}

class Program
{
    static void Main()
    {
        Product product = new Product();
        try
        {
            product.CheckExpiration(new DateTime(2020, 1, 1));
        }
        catch (ExpiredProductException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}