using System;

abstract class SportEvent
{
    public abstract void StartEvent();
}

class Football : SportEvent
{
    public override void StartEvent() => Console.WriteLine("Футбольный матч начался!");
}

class Swimming : SportEvent
{
    public override void StartEvent() => Console.WriteLine("Заплыв начался!");
}

class Tennis : SportEvent
{
    public override void StartEvent() => Console.WriteLine("Теннисный матч начался!");
}

class Program
{
    static void Main()
    {
        SportEvent[] events = { new Football(), new Swimming(), new Tennis() };
        foreach (var e in events) e.StartEvent();
    }
}