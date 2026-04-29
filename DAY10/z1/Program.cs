using System;
using System.Collections.Generic;

class AchievementsManager
{
    private static AchievementsManager _instance;
    private List<string> _achievements = new List<string>();

    private AchievementsManager() { }

    public static AchievementsManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new AchievementsManager();
            return _instance;
        }
    }

    public void UnlockAchievement(string name)
    {
        if (!_achievements.Contains(name))
        {
            _achievements.Add(name);
            Console.WriteLine($"Достижение разблокировано: {name}");
        }
        else
        {
            Console.WriteLine($"Достижение уже есть: {name}");
        }
    }

    public List<string> GetAchievements() => new List<string>(_achievements);
}

class Program
{
    static void Main()
    {
        var manager = AchievementsManager.Instance;
        manager.UnlockAchievement("Победитель");
        manager.UnlockAchievement("Исследователь");
        manager.UnlockAchievement("Победитель"); 

        Console.WriteLine("\nВсе достижения:");
        foreach (var ach in manager.GetAchievements())
            Console.WriteLine($"- {ach}");
    }
}