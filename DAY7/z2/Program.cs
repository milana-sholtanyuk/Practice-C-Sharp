using System;
using System.IO;

class ReportGenerationException : Exception
{
    public ReportGenerationException(string message, Exception inner) : base(message, inner) { }
}

class ReportGenerator
{
    public void GenerateReport()
    {
        throw new IOException("Недостаточно места на диске (D: заполнен)");
    }
}

class ReportManager
{
    public void CreateReport()
    {
        try
        {
            ReportGenerator generator = new ReportGenerator();
            generator.GenerateReport();
        }
        catch (IOException ex)
        {
            Console.WriteLine($"[ЛОГ] {DateTime.Now}: {ex.Message}");
            Console.WriteLine($"[ЛОГ] Стек вызовов: {ex.StackTrace}");
            throw new ReportGenerationException("Не удалось сгенерировать отчёт", ex);
        }
    }
}

class Program
{
    static void Main()
    {
        ReportManager manager = new ReportManager();
        try
        {
            manager.CreateReport();
        }
        catch (ReportGenerationException ex)
        {
            Console.WriteLine($"\nОшибка: {ex.Message}");
            Console.WriteLine($"Внутренняя ошибка: {ex.InnerException?.Message}");
        }
    }
}