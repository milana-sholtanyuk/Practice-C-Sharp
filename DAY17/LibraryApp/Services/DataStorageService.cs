using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using LibraryApp.Models;

namespace LibraryApp.Services
{
    public class DataStorageService
    {
        private readonly string _dataFolder;
        private readonly string _booksFile;

        public DataStorageService()
        {
            _dataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LibraryApp");
            Directory.CreateDirectory(_dataFolder);
            _booksFile = Path.Combine(_dataFolder, "library.json");
        }

        public List<BookModel> LoadBooks()
        {
            if (!File.Exists(_booksFile))
                return GetDefaultBooks();

            string json = File.ReadAllText(_booksFile);
            var books = JsonSerializer.Deserialize<List<BookModel>>(json);
            return books ?? GetDefaultBooks();
        }

        private List<BookModel> GetDefaultBooks()
        {
            return new List<BookModel>
            {
                new BookModel { Title = "Война и мир", Author = "Лев Толстой", Genre = "Роман", Year = 1869, IsAvailable = true },
                new BookModel { Title = "1984", Author = "Джордж Оруэлл", Genre = "Антиутопия", Year = 1949, IsAvailable = false },
                new BookModel { Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Genre = "Роман", Year = 1967, IsAvailable = true },
                new BookModel { Title = "Преступление и наказание", Author = "Фёдор Достоевский", Genre = "Роман", Year = 1866, IsAvailable = true }
            };
        }

        public void SaveBooks(List<BookModel> books)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(books, options);
            File.WriteAllText(_booksFile, json);
        }
    }
}