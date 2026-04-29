using System;
using System.Collections.Generic;
using System.Linq;

class MyGraph<T>
{
    private Dictionary<T, List<T>> adj = new Dictionary<T, List<T>>();

    public void AddNode(T node)
    {
        if (!adj.ContainsKey(node)) adj[node] = new List<T>();
    }

    public void AddEdge(T from, T to)
    {
        AddNode(from);
        AddNode(to);
        adj[from].Add(to);
    }

    public void RemoveNode(T node)
    {
        if (!adj.ContainsKey(node)) return;
        adj.Remove(node);
        foreach (var key in adj.Keys.ToList())
            adj[key].RemoveAll(x => x.Equals(node));
    }

    public List<T> FindPath(T from, T to)
    {
        var queue = new Queue<List<T>>();
        queue.Enqueue(new List<T> { from });
        var visited = new HashSet<T>();

        while (queue.Count > 0)
        {
            var path = queue.Dequeue();
            var last = path.Last();

            if (last.Equals(to)) return path;

            if (!visited.Contains(last) && adj.ContainsKey(last))
            {
                visited.Add(last);
                foreach (var next in adj[last])
                {
                    var newPath = new List<T>(path) { next };
                    queue.Enqueue(newPath);
                }
            }
        }
        return null;
    }

    public void PrintGraph()
    {
        foreach (var node in adj)
            Console.WriteLine($"{node.Key} → {string.Join(", ", node.Value)}");
    }
}

class GraphProcessor<T>
{
    public void FindAndPrintPath(MyGraph<T> graph, T from, T to)
    {
        var path = graph.FindPath(from, to);
        if (path != null)
            Console.WriteLine($"Путь: {string.Join(" → ", path)}");
        else
            Console.WriteLine($"Путь от {from} до {to} не найден");
    }
}

class Program
{
    static void Main()
    {
        var graph = new MyGraph<string>();
        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");
        graph.AddEdge("B", "D");
        graph.AddEdge("C", "D");
        graph.AddEdge("D", "E");

        Console.WriteLine("Граф:");
        graph.PrintGraph();

        var processor = new GraphProcessor<string>();
        processor.FindAndPrintPath(graph, "A", "E");
        processor.FindAndPrintPath(graph, "A", "Z");
    }
}