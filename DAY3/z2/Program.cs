using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

static class ArrayOperations
{
    
    public static void SortByAge(Person[] people)
    {
        Array.Sort(people, (p1, p2) => p1.Age.CompareTo(p2.Age));
    }

    
    public static Person[] FilterByAge(Person[] people, int minAge)
    {
        return people.Where(p => p.Age > minAge).ToArray();
    }

    
    public static double AverageAge(Person[] people)
    {
        return people.Average(p => p.Age);
    }

    
    public static Person[] GeneratePeople(int count)
    {
        Random rnd = new Random();
        string[] names = { "Анна", "Борис", "Вика", "Глеб", "Даша", "Егор", "Женя" };
        Person[] people = new Person[count];
        for (int i = 0; i < count; i++)
        {
            people[i] = new Person { Name = names[rnd.Next(names.Length)], Age = rnd.Next(18, 70) };
        }
        return people;
    }

    
    public static Dictionary<int, List<Person>> GroupByAge(Person[] people)
    {
        return people.GroupBy(p => p.Age).ToDictionary(g => g.Key, g => g.ToList());
    }
}

class Program
{
    static void Main()
    {
       
        Person[] people = ArrayOperations.GeneratePeople(10);

        Console.WriteLine("Исходный массив:");
        foreach (var p in people)
            Console.WriteLine($"{p.Name}, {p.Age} лет");

        
        ArrayOperations.SortByAge(people);
        Console.WriteLine("\nПосле сортировки по возрасту:");
        foreach (var p in people)
            Console.WriteLine($"{p.Name}, {p.Age} лет");

        
        var adults = ArrayOperations.FilterByAge(people, 25);
        Console.WriteLine($"\nСтарше 25 лет: {adults.Length} человек");

        
        Console.WriteLine($"\nСредний возраст: {ArrayOperations.AverageAge(people):F2}");

        
        var grouped = ArrayOperations.GroupByAge(people);
        Console.WriteLine("\nГруппировка по возрасту:");
        foreach (var group in grouped.OrderBy(g => g.Key))
        {
            Console.WriteLine($"Возраст {group.Key}: {string.Join(", ", group.Value.Select(p => p.Name))}");
        }
    }
}