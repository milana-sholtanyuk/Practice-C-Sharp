using System;

interface ITaskScheduler { void Schedule(string taskName); }
interface IAlarmScheduler { void Schedule(string taskName); }

class Scheduler : ITaskScheduler, IAlarmScheduler
{
    void ITaskScheduler.Schedule(string taskName)
        => Console.WriteLine($"Задача добавлена в расписание: {taskName}");

    void IAlarmScheduler.Schedule(string taskName)
        => Console.WriteLine($"Будильник установлен: {taskName}");
}

class Program
{
    static void Main()
    {
        Scheduler scheduler = new Scheduler();

        ITaskScheduler taskScheduler = scheduler;
        taskScheduler.Schedule("Совещание в 10:00");

        IAlarmScheduler alarmScheduler = scheduler;
        alarmScheduler.Schedule("Проснуться в 7:00");
    }
}