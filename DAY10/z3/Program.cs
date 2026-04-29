using System;
using System.Collections.Generic;

interface IUserObserver
{
    void Update(string friendName, bool isOnline);
}

class Messenger
{
    private Dictionary<string, List<IUserObserver>> _observers = new Dictionary<string, List<IUserObserver>>();
    private Dictionary<string, bool> _statuses = new Dictionary<string, bool>();

    public void RegisterUser(string userName)
    {
        if (!_observers.ContainsKey(userName))
        {
            _observers[userName] = new List<IUserObserver>();
            _statuses[userName] = false;
        }
    }

    public void Subscribe(string userName, IUserObserver observer)
    {
        if (_observers.ContainsKey(userName))
            _observers[userName].Add(observer);
    }

    public void SetOnline(string userName)
    {
        if (_statuses.ContainsKey(userName))
        {
            _statuses[userName] = true;
            Notify(userName, true);
        }
    }

    public void SetOffline(string userName)
    {
        if (_statuses.ContainsKey(userName))
        {
            _statuses[userName] = false;
            Notify(userName, false);
        }
    }

    private void Notify(string userName, bool isOnline)
    {
        if (_observers.ContainsKey(userName))
        {
            foreach (var observer in _observers[userName])
                observer.Update(userName, isOnline);
        }
    }
}

class User : IUserObserver
{
    public string Name { get; set; }

    public User(string name) => Name = name;

    public void Update(string friendName, bool isOnline)
    {
        string status = isOnline ? "онлайн" : "офлайн";
        Console.WriteLine($"{Name}: {friendName} теперь {status}!");
    }
}

class Program
{
    static void Main()
    {
        var messenger = new Messenger();

        messenger.RegisterUser("Анна");
        messenger.RegisterUser("Борис");
        messenger.RegisterUser("Вика");

        var userAnna = new User("Анна");
        var userBoris = new User("Борис");
        var userVika = new User("Вика");

        messenger.Subscribe("Анна", userBoris); 
        messenger.Subscribe("Анна", userVika);  
        messenger.Subscribe("Борис", userAnna);  

        messenger.SetOnline("Анна");
        messenger.SetOnline("Борис");
        messenger.SetOffline("Анна");
    }
}