using System;
using System.Linq;

interface ICargoShip { void LoadCargo(); }
interface IPassengerShip { void BoardPassengers(); }

abstract class Spacecraft { public string Name { get; set; } }

class Freighter : Spacecraft, ICargoShip
{
    public Freighter(string name) => Name = name;
    public void LoadCargo() => Console.WriteLine($"{Name}: Груз загружен");
}

class Shuttle : Spacecraft, IPassengerShip
{
    public Shuttle(string name) => Name = name;
    public void BoardPassengers() => Console.WriteLine($"{Name}: Пассажиры на борту");
}

class Program
{
    static void Main()
    {
        Spacecraft[] ships = { new Freighter("Грузовик-1"), new Shuttle("Челнок-1"), new Shuttle("Челнок-2") };

        var passengerShips = ships.OfType<IPassengerShip>();
        Console.WriteLine("Пассажирские корабли:");
        foreach (var ship in passengerShips) ship.BoardPassengers();
    }
}