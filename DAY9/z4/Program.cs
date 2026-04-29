using System;
using System.IO;

class FolderSyncWatcher
{
    private FileSystemWatcher _watcher;
    private string _sourceFolder;
    private string _targetFolder;

    public FolderSyncWatcher(string sourceFolder, string targetFolder)
    {
        _sourceFolder = sourceFolder;
        _targetFolder = targetFolder;
        Directory.CreateDirectory(targetFolder);

        _watcher = new FileSystemWatcher(sourceFolder);
        _watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
        _watcher.Created += OnChanged;
        _watcher.Changed += OnChanged;
        _watcher.Renamed += OnRenamed;
        _watcher.Deleted += OnDeleted;
        _watcher.EnableRaisingEvents = true;
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        string dest = Path.Combine(_targetFolder, Path.GetFileName(e.FullPath));
        File.Copy(e.FullPath, dest, true);
        Console.WriteLine($"[Синхронизация] {e.Name} → {dest}");
    }

    private void OnRenamed(object sender, RenamedEventArgs e)
    {
        string destOld = Path.Combine(_targetFolder, Path.GetFileName(e.OldFullPath));
        string destNew = Path.Combine(_targetFolder, Path.GetFileName(e.FullPath));
        if (File.Exists(destOld)) File.Move(destOld, destNew);
        Console.WriteLine($"[Переименован] {e.OldName} → {e.Name}");
    }

    private void OnDeleted(object sender, FileSystemEventArgs e)
    {
        string dest = Path.Combine(_targetFolder, Path.GetFileName(e.FullPath));
        if (File.Exists(dest)) File.Delete(dest);
        Console.WriteLine($"[Удалён] {e.Name}");
    }

    public void Stop() => _watcher.EnableRaisingEvents = false;
}

class Program
{
    static void Main()
    {
        string folderA = @"C:\Sync\FolderA";
        string folderB = @"C:\Sync\FolderB";
        Directory.CreateDirectory(folderA);
        Directory.CreateDirectory(folderB);

        var watcher = new FolderSyncWatcher(folderA, folderB);
        Console.WriteLine($"Синхронизация {folderA} → {folderB}");
        Console.WriteLine("Нажмите Enter для выхода...");
        Console.ReadLine();
        watcher.Stop();
    }
}