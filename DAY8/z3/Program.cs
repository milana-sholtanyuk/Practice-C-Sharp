using System;
using System.Collections.Generic;

// Обобщённый интерфейс
interface IStack<T>
{
    void Push(T item);
    T Pop();
    T Peek();
    int Count { get; }  // ← Добавляем свойство Count в интерфейс
}

// Реализация
class SimpleStack<T> : IStack<T>
{
    private Stack<T> stack = new Stack<T>();

    public void Push(T item) => stack.Push(item);
    public T Pop() => stack.Pop();
    public T Peek() => stack.Peek();
    public int Count => stack.Count;  // ← Реализуем Count
}

// Класс-менеджер
class StackManager<T>
{
    private IStack<T> stack;

    public StackManager(IStack<T> stack) => this.stack = stack;

    public void PrintStack()
    {
        Console.Write("Стек: ");
        var list = new List<T>();
        var temp = new SimpleStack<T>();

        // Используем свойство Count интерфейса
        while (stack.Count > 0)
        {
            var item = stack.Pop();
            list.Add(item);
            temp.Push(item);
        }
        // Восстанавливаем стек
        while (temp.Count > 0)
            stack.Push(temp.Pop());

        Console.WriteLine(list.Count == 0 ? "пуст" : string.Join(", ", list));
    }

    public bool IsEmpty() => stack.Count == 0;

    public void Push(T item) => stack.Push(item);
    public T Pop() => stack.Pop();
}

class Program
{
    static void Main()
    {
        var stack = new SimpleStack<int>();
        var manager = new StackManager<int>(stack);

        manager.Push(10);
        manager.Push(20);
        manager.Push(30);

        manager.PrintStack();
        Console.WriteLine($"IsEmpty: {manager.IsEmpty()}");
        Console.WriteLine($"Pop: {manager.Pop()}");
        manager.PrintStack();
        Console.WriteLine($"Peek: {stack.Peek()}");
    }
}