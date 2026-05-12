using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using LibraryApp.Models;
using LibraryApp.Services;

namespace LibraryApp.ViewModels
{
    public class LibraryViewModel : INotifyPropertyChanged
    {
        private readonly LibraryService _service;
        private string _searchText;
        private string _filterAuthor;
        private string _filterGenre;
        private ObservableCollection<BookModel> _books;
        private bool _isLoading;
        private BookModel _selectedBook;

        public LibraryViewModel()
        {
            var storage = new DataStorageService();
            _service = new LibraryService(storage);
            _books = new ObservableCollection<BookModel>();

            LoadBooksCommand = new RelayCommand(async () => await LoadBooksAsync());
            AddBookCommand = new RelayCommand(OpenAddBookDialog);
            EditBookCommand = new RelayCommand(OpenEditBookDialog, () => SelectedBook != null);
            DeleteBookCommand = new RelayCommand(DeleteBook, () => SelectedBook != null);
            ToggleAvailabilityCommand = new RelayCommand(ToggleAvailability, () => SelectedBook != null);

            Task.Run(async () => await LoadBooksAsync());
        }

        public string SearchText
        {
            get => _searchText;
            set { _searchText = value; OnPropertyChanged(); Task.Run(async () => await LoadBooksAsync()); }
        }

        public string FilterAuthor
        {
            get => _filterAuthor;
            set { _filterAuthor = value; OnPropertyChanged(); Task.Run(async () => await LoadBooksAsync()); }
        }

        public string FilterGenre
        {
            get => _filterGenre;
            set { _filterGenre = value; OnPropertyChanged(); Task.Run(async () => await LoadBooksAsync()); }
        }

        public ObservableCollection<BookModel> Books
        {
            get => _books;
            set { _books = value; OnPropertyChanged(); }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        public BookModel SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged();
                ((RelayCommand)EditBookCommand).RaiseCanExecuteChanged();
                ((RelayCommand)DeleteBookCommand).RaiseCanExecuteChanged();
                ((RelayCommand)ToggleAvailabilityCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand LoadBooksCommand { get; }
        public ICommand AddBookCommand { get; }
        public ICommand EditBookCommand { get; }
        public ICommand DeleteBookCommand { get; }
        public ICommand ToggleAvailabilityCommand { get; }

        private async Task LoadBooksAsync()
        {
            IsLoading = true;
            var result = await _service.SearchBooksAsync(SearchText, FilterAuthor, FilterGenre);
            Books = result;
            IsLoading = false;
        }

        private void OpenAddBookDialog()
        {
            var dialog = new BookDialog();
            if (dialog.ShowDialog() == true)
            {
                _service.AddBook(dialog.Book);
                Task.Run(async () => await LoadBooksAsync());
            }
        }

        private void OpenEditBookDialog()
        {
            var dialog = new BookDialog(SelectedBook);
            if (dialog.ShowDialog() == true)
            {
                _service.UpdateBook(SelectedBook, dialog.Book);
                Task.Run(async () => await LoadBooksAsync());
            }
        }

        private void DeleteBook()
        {
            if (System.Windows.MessageBox.Show($"Удалить книгу \"{SelectedBook.Title}\"?", "Подтверждение",
                System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question) == System.Windows.MessageBoxResult.Yes)
            {
                _service.DeleteBook(SelectedBook);
                Task.Run(async () => await LoadBooksAsync());
            }
        }

        private void ToggleAvailability()
        {
            _service.ToggleBookAvailability(SelectedBook);
            Task.Run(async () => await LoadBooksAsync());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}