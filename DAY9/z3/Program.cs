using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public double Score { get; set; }
    public override string ToString() => $"{Name},{Score}";
}

class StudentFileReader
{
    private readonly string _path = @"C:\Temp\file.data";

    public List<Student> ReadStudents()
    {
        var students = new List<Student>();

        if (!File.Exists(_path))
        {
            Console.WriteLine($"Файл {_path} не найден! Создаю пример файла...");
            CreateSampleFile();
        }

        var lines = File.ReadAllLines(_path);
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var parts = line.Split(',');
            if (parts.Length == 2 && double.TryParse(parts[1], out double score))
            {
                students.Add(new Student { Name = parts[0].Trim(), Score = score });
            }
        }
        return students;
    }

    private void CreateSampleFile()
    {
        Directory.CreateDirectory(@"C:\Temp");
        var sample = new[]
        {
            "Иванов,85.5",
            "Петрова,92.3",
            "Сидоров,74.0",
            "Козлова,88.7"
        };
        File.WriteAllLines(_path, sample);
        Console.WriteLine("Создан пример файла file.data со студентами");
    }
}

class StudentProcessor
{
    public void AnalyzePerformance(List<Student> students)
    {
        if (students.Count == 0)
        {
            Console.WriteLine("Нет данных для анализа!");
            return;
        }

        double avg = students.Average(s => s.Score);
        var best = students.Where(s => s.Score > avg);

        Console.WriteLine($"\nСредний балл: {avg:F2}");
        Console.WriteLine($"Лучших студентов: {best.Count()}");
        foreach (var s in best)
            Console.WriteLine($"  {s.Name} – {s.Score}");
    }
}

class Program
{
    static void Main()
    {
        var reader = new StudentFileReader();
        var students = reader.ReadStudents();

        var processor = new StudentProcessor();
        processor.AnalyzePerformance(students);
    }
}