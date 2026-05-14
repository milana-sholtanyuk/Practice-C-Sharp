using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using LibraryApp.Models;

namespace LibraryApp.Data
{
    public class BookRepository
    {
        private readonly string _filePath;
        private List<BookModel> _books;

        public BookRepository()
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LibraryApp");
            Directory.CreateDirectory(folder);
            _filePath = Path.Combine(folder, "books.json");
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _books = JsonSerializer.Deserialize<List<BookModel>>(json) ?? new List<BookModel>();
            }
            else
            {
                _books = GetDefaultBooks();
                SaveToFile();
            }
        }

        private void SaveToFile()
        {
            var json = JsonSerializer.Serialize(_books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        private List<BookModel> GetDefaultBooks()
        {
            return new List<BookModel>
            {
                new BookModel { Id = Guid.NewGuid().ToString(), Title = "Война и мир", Author = "Лев Толстой", Genre = "Роман", Year = 1869, IsAvailable = true },
                new BookModel { Id = Guid.NewGuid().ToString(), Title = "1984", Author = "Джордж Оруэлл", Genre = "Антиутопия", Year = 1949, IsAvailable = false },
                new BookModel { Id = Guid.NewGuid().ToString(), Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Genre = "Роман", Year = 1967, IsAvailable = true },
                new BookModel { Id = Guid.NewGuid().ToString(), Title = "Преступление и наказание", Author = "Фёдор Достоевский", Genre = "Роман", Year = 1866, IsAvailable = true }
            };
        }

        public async Task<List<BookModel>> GetAllAsync()
        {
            return await Task.Run(() => _books.ToList());
        }

        public async Task AddAsync(BookModel book)
        {
            await Task.Run(() =>
            {
                book.Id = Guid.NewGuid().ToString();
                _books.Add(book);
                SaveToFile();
            });
        }

        public async Task UpdateAsync(BookModel book)
        {
            await Task.Run(() =>
            {
                var existing = _books.FirstOrDefault(b => b.Id == book.Id);
                if (existing != null)
                {
                    existing.Title = book.Title;
                    existing.Author = book.Author;
                    existing.Genre = book.Genre;
                    existing.Year = book.Year;
                    SaveToFile();
                }
            });
        }

        public async Task DeleteAsync(string id)
        {
            await Task.Run(() =>
            {
                var book = _books.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    _books.Remove(book);
                    SaveToFile();
                }
            });
        }

        public async Task ToggleAvailabilityAsync(string id)
        {
            await Task.Run(() =>
            {
                var book = _books.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    book.IsAvailable = !book.IsAvailable;
                    SaveToFile();
                }
            });
        }

        public async Task<BookModel> GetByIdAsync(string id)
        {
            return await Task.Run(() => _books.FirstOrDefault(b => b.Id == id));
        }
    }
}