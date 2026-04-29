using System;

class Program
{
    static string SendMessage(string message)
    {
        return $"Message sent: {message}";
    }

    static string SendMessage(string message, string recipient)
    {
        return $"Message sent to {recipient}: {message}";
    }

    static void Main()
    {
        Console.WriteLine(SendMessage("Hello"));
        Console.WriteLine(SendMessage("Hello", "Alice"));
    }
}