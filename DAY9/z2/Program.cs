using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Car
{
    public string Brand { get; set; }
    public int Year { get; set; }
    public override string ToString() => $"{Brand},{Year}";
}

class CarFileWriter
{
    private readonly string _path = "file.data";

    public void WriteFilteredCars(List<Car> cars, int minYear)
    {
        var filtered = cars.Where(c => c.Year > minYear);
        File.WriteAllLines(_path, filtered.Select(c => c.ToString()));
        Console.WriteLine($"Записано {filtered.Count()} автомобилей новее {minYear} года");
    }
}

class Program
{
    static void Main()
    {
        var cars = new List<Car>
        {
            new Car { Brand = "Toyota", Year = 2010 },
            new Car { Brand = "BMW", Year = 2015 },
            new Car { Brand = "Lada", Year = 2005 },
            new Car { Brand = "Tesla", Year = 2020 }
        };

        var writer = new CarFileWriter();
        writer.WriteFilteredCars(cars, 2010);
    }
}