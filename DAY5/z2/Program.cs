using System;
using System.Linq;

// Композиция (принадлежит клубу)
class GymEquipment
{
    public string Name { get; set; }
    public GymEquipment(string name) => Name = name;
    public void Use() => Console.WriteLine($"Тренажёр {Name} используется");
}

// Агрегация (тренеры могут работать в разных клубах)
class Trainer
{
    public string Name { get; set; }
    public Trainer(string name) => Name = name;
    public void Train() => Console.WriteLine($"Тренер {Name} тренирует");
}

// Ассоциация (клиенты с абонементом)
class Membership
{
    public string ClientName { get; set; }
    public Membership(string name) => ClientName = name;
    public void Workout() => Console.WriteLine($"Клиент {ClientName} занимается");
}

class Gym
{
    public string Name { get; set; }
    public Trainer[] Trainers { get; set; }        // Агрегация
    public GymEquipment Equipment { get; set; }    // Композиция
    public Membership[] Members { get; set; }      // Ассоциация

    public Gym(string name, Trainer[] trainers, string equipmentName, Membership[] members)
    {
        Name = name;
        Trainers = trainers;
        Equipment = new GymEquipment(equipmentName);
        Members = members;
    }

    public void TrainClients()
    {
        Console.WriteLine($"\nФитнес-клуб {Name}:");
        Equipment.Use();
        foreach (var trainer in Trainers) trainer.Train();
        foreach (var member in Members) member.Workout();
    }
}

class Program
{
    static void Main()
    {
        Trainer[] trainers = { new Trainer("Анна"), new Trainer("Борис") };
        Membership[] members = { new Membership("Вика"), new Membership("Глеб") };

        Gym[] gyms =
        {
            new Gym("СпортЛайф", trainers, "Беговая дорожка", members),
            new Gym("ФитнесХаус", new[] { new Trainer("Игорь") }, "Велотренажёр", new[] { new Membership("Даша") })
        };

        foreach (var gym in gyms) gym.TrainClients();
    }
}