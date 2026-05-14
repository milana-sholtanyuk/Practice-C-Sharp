using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Models;

namespace LibraryApp.Services
{
    public class LibraryService
    {
        private readonly DataStorageService _storage;
        public ObservableCollection<BookModel> Books { get; private set; }

        public LibraryService(DataStorageService storage)
        {
            _storage = storage;
            var loaded = _storage.LoadBooks();
            Books = new ObservableCollection<BookModel>(loaded);
        }

        private void SaveData()
        {
            _storage.SaveBooks(Books.ToList());
        }

        public async Task<ObservableCollection<BookModel>> SearchBooksAsync(string searchText, string filterAuthor, string filterGenre)
        {
            await Task.Delay(1500);

            var query = Books.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query = query.Where(b =>
                    (b.Title ?? "").ToLower().Contains(searchText.ToLower()) ||
                    (b.Author ?? "").ToLower().Contains(searchText.ToLower()) ||
                    (b.Genre ?? "").ToLower().Contains(searchText.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(filterAuthor))
            {
                query = query.Where(b => (b.Author ?? "").ToLower().Contains(filterAuthor.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(filterGenre))
            {
                query = query.Where(b => (b.Genre ?? "").ToLower().Contains(filterGenre.ToLower()));
            }

            return new ObservableCollection<BookModel>(query.ToList());
        }

        public void AddBook(BookModel book)
        {
            book.IsNewlyAdded = true;
            Books.Add(book);
            SaveData();

            // Сбросить флаг через 3 секунды
            Task.Run(async () =>
            {
                await Task.Delay(3000);
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    book.IsNewlyAdded = false;
                });
            });
        }

        public void UpdateBook(BookModel oldBook, BookModel newBook)
        {
            var index = Books.IndexOf(oldBook);
            if (index >= 0)
            {
                Books[index] = newBook;
                SaveData();
            }
        }

        public void DeleteBook(BookModel book)
        {
            Books.Remove(book);
            SaveData();
        }

        public void ToggleBookAvailability(BookModel book)
        {
            book.IsAvailable = !book.IsAvailable;
            SaveData();
        }
    }
}