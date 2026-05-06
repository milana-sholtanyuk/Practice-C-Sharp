using z1.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace z1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Book> _allBooks;
        private ObservableCollection<Book> _filteredBooks;
        private string _searchText;
        private Book _selectedBook;

        public MainViewModel()
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            _allBooks = new ObservableCollection<Book>
            {
                new Book { Title = "Война и мир", Author = "Лев Толстой", Genre = "Роман", Year = 1869, Description = "Эпическое произведение о русском обществе в эпоху Наполеоновских войн." },
                new Book { Title = "Преступление и наказание", Author = "Фёдор Достоевский", Genre = "Роман", Year = 1866, Description = "Психологический роман о студенте Раскольникове." },
                new Book { Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Genre = "Фэнтези", Year = 1967, Description = "Мистический роман о визите дьявола в Москву." },
                new Book { Title = "1984", Author = "Джордж Оруэлл", Genre = "Антиутопия", Year = 1949, Description = "Тоталитарное общество и Большой Брат." },
                new Book { Title = "Гарри Поттер и философский камень", Author = "Дж.К. Роулинг", Genre = "Фэнтези", Year = 1997, Description = "Мальчик-волшебник поступает в Хогвартс." },
                new Book { Title = "Три товарища", Author = "Эрих Мария Ремарк", Genre = "Роман", Year = 1936, Description = "О дружбе и любви в послевоенной Германии." }
            };
            FilteredBooks = new ObservableCollection<Book>(_allBooks);
        }

        public ObservableCollection<Book> FilteredBooks
        {
            get => _filteredBooks;
            set { _filteredBooks = value; OnPropertyChanged(); }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                ApplyFilter();
            }
        }

        public Book SelectedBook
        {
            get => _selectedBook;
            set { _selectedBook = value; OnPropertyChanged(); }
        }

        private void ApplyFilter()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredBooks = new ObservableCollection<Book>(_allBooks);
                return;
            }
            var searchLower = SearchText.ToLower();
            var filtered = _allBooks.Where(b =>
                b.Title.ToLower().Contains(searchLower) ||
                b.Author.ToLower().Contains(searchLower) ||
                b.Genre.ToLower().Contains(searchLower)).ToList();

            FilteredBooks = new ObservableCollection<Book>(filtered);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}