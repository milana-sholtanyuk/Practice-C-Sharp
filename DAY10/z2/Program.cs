using System;

class Car
{
    public string Type { get; set; }
    public string Engine { get; set; }
    public int Wheels { get; set; }
    public bool HasSunroof { get; set; }

    public void Show()
    {
        Console.WriteLine($"{Type}: {Engine}, {Wheels} колёс, Люк: {(HasSunroof ? "да" : "нет")}");
    }
}

interface ICarBuilder
{
    void SetEngine();
    void SetWheels();
    void SetSunroof();
    Car GetCar();
}

class SedanBuilder : ICarBuilder
{
    private Car _car = new Car();
    public SedanBuilder() => _car.Type = "Седан";
    public void SetEngine() => _car.Engine = "1.6 л";
    public void SetWheels() => _car.Wheels = 4;
    public void SetSunroof() => _car.HasSunroof = true;
    public Car GetCar() => _car;
}

class SUVBuilder : ICarBuilder
{
    private Car _car = new Car();
    public SUVBuilder() => _car.Type = "Внедорожник";
    public void SetEngine() => _car.Engine = "2.5 л";
    public void SetWheels() => _car.Wheels = 4;
    public void SetSunroof() => _car.HasSunroof = true;
    public Car GetCar() => _car;
}

class TruckBuilder : ICarBuilder
{
    private Car _car = new Car();
    public TruckBuilder() => _car.Type = "Грузовик";
    public void SetEngine() => _car.Engine = "4.0 л";
    public void SetWheels() => _car.Wheels = 6;
    public void SetSunroof() => _car.HasSunroof = false;
    public Car GetCar() => _car;
}

class CarDirector
{
    public Car Build(ICarBuilder builder)
    {
        builder.SetEngine();
        builder.SetWheels();
        builder.SetSunroof();
        return builder.GetCar();
    }
}

class Program
{
    static void Main()
    {
        var director = new CarDirector();

        Car sedan = director.Build(new SedanBuilder());
        Car suv = director.Build(new SUVBuilder());
        Car truck = director.Build(new TruckBuilder());

        sedan.Show();
        suv.Show();
        truck.Show();
    }
}