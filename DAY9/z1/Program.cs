using System;
using System.IO;
using System.Linq;

class FileManager
{
    public void CreateFile(string path, string content) => File.WriteAllText(path, content);
    public void DeleteFile(string path) { if (File.Exists(path)) File.Delete(path); }
    public void CopyFile(string source, string dest) => File.Copy(source, dest, true);
    public void MoveFile(string source, string dest) => File.Move(source, dest);
    public void RenameFile(string oldPath, string newPath) => File.Move(oldPath, newPath);
    public void SetReadOnly(string path) => new FileInfo(path).IsReadOnly = true;
    public bool Exists(string path) => File.Exists(path);
    public void DeleteByPattern(string dir, string pattern) => Directory.GetFiles(dir, pattern).ToList().ForEach(File.Delete);
    public string[] ListFiles(string dir) => Directory.GetFiles(dir);
}

class FileInfoProvider
{
    public void PrintInfo(string path)
    {
        var fi = new FileInfo(path);
        Console.WriteLine($"Размер: {fi.Length} байт");
        Console.WriteLine($"Создан: {fi.CreationTime}");
        Console.WriteLine($"Изменён: {fi.LastWriteTime}");
        Console.WriteLine($"Чтение: {fi.IsReadOnly}");
    }

    public bool CompareSize(string file1, string file2) => new FileInfo(file1).Length == new FileInfo(file2).Length;
}

class Program
{
    static void Main()
    {
        string basePath = @"C:\Temp";
        Directory.CreateDirectory(basePath);
        string file1 = Path.Combine(basePath, "sholtanyuk.mo");
        string file2 = Path.Combine(basePath, "copy.mo");
        string file3 = Path.Combine(basePath, "moved.mo");

        var fm = new FileManager();
        var info = new FileInfoProvider();

        fm.CreateFile(file1, "Hello, Ivanov!");
        Console.WriteLine("Файл создан.");

        Console.WriteLine($"Файл существует: {fm.Exists(file1)}");

        info.PrintInfo(file1);

        fm.CopyFile(file1, file2);
        Console.WriteLine($"Копия существует: {fm.Exists(file2)}");

        fm.MoveFile(file2, file3);
        Console.WriteLine($"Файл перемещён в {file3}");

        string renamed = Path.Combine(basePath, "petrov.ii");
        fm.RenameFile(file1, renamed);

        fm.DeleteFile(Path.Combine(basePath, "notexist.ii"));

        fm.CreateFile(Path.Combine(basePath, "temp.ii"), "delete me");
        fm.DeleteByPattern(basePath, "*.ii");
        Console.WriteLine("Все .ii удалены.");

        fm.CreateFile(Path.Combine(basePath, "test1.txt"), "");
        fm.CreateFile(Path.Combine(basePath, "test2.txt"), "");
        Console.WriteLine("Файлы в папке: " + string.Join(", ", fm.ListFiles(basePath).Select(Path.GetFileName)));

        string readOnlyFile = Path.Combine(basePath, "readonly.txt");
        fm.CreateFile(readOnlyFile, "readonly");
        fm.SetReadOnly(readOnlyFile);
        try { File.AppendAllText(readOnlyFile, "new"); }
        catch (UnauthorizedAccessException) { Console.WriteLine("Запись запрещена!"); }

        var fi = new FileInfo(readOnlyFile);
        Console.WriteLine($"Права на запись: {!fi.IsReadOnly}");
    }
}