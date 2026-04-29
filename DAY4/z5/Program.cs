using System;

abstract class Sport
{
    public abstract void Play();
    public virtual void DisplayRules()
    {
        Console.WriteLine("Общие правила спорта");
    }
}

sealed class Football : Sport
{
    public override void Play()
    {
        Console.WriteLine("Playing football");
    }

    public override void DisplayRules()
    {
        Console.WriteLine("Футбол: 11 игроков, нельзя руками, гол в ворота");
    }
}

sealed class Basketball : Sport
{
    public override void Play()
    {
        Console.WriteLine("Playing basketball");
    }

    public override void DisplayRules()
    {
        Console.WriteLine("Баскетбол: 5 игроков, забросить мяч в кольцо");
    }
}

class Program
{
    static void Main()
    {
        Sport[] sports = { new Football(), new Basketball() };

        foreach (var sport in sports)
        {
            sport.Play();
            sport.DisplayRules();
            Console.WriteLine();
        }
    }
}