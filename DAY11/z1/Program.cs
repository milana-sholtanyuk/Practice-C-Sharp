using System;

interface IFuelType
{
    string GetEnergySource();
}

class Gasoline : IFuelType
{
    public string GetEnergySource() => "Бензин 🔥";
}

class Diesel : IFuelType
{
    public string GetEnergySource() => "Дизель 🛢️";
}

class Electric : IFuelType
{
    public string GetEnergySource() => "Электричество ⚡";
}

abstract class FuelFactory
{
    public abstract IFuelType CreateFuel();
}

class GasolineFactory : FuelFactory
{
    public override IFuelType CreateFuel() => new Gasoline();
}

class DieselFactory : FuelFactory
{
    public override IFuelType CreateFuel() => new Diesel();
}

class ElectricFactory : FuelFactory
{
    public override IFuelType CreateFuel() => new Electric();
}

class Program
{
    static void Main()
    {
        FuelFactory[] factories = { new GasolineFactory(), new DieselFactory(), new ElectricFactory() };

        foreach (var factory in factories)
        {
            IFuelType fuel = factory.CreateFuel();
            Console.WriteLine($"Топливо: {fuel.GetEnergySource()}");
        }
    }
}