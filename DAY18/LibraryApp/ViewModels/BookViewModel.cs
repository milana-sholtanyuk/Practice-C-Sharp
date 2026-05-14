using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using LibraryApp.Commands;
using LibraryApp.Data;
using LibraryApp.Models;
using LibraryApp.Views;

namespace LibraryApp.ViewModels
{
    public class BookViewModel : BaseViewModel
    {
        private readonly BookRepository _repository;
        private ObservableCollection<BookModel> _items;
        private BookModel _selectedItem;
        private string _searchText;
        private string _filterAuthor;
        private string _filterGenre;
        private bool _isLoading;

        public BookViewModel()
        {
            _repository = new BookRepository();
            _items = new ObservableCollection<BookModel>();

            LoadCommand = new AsyncRelayCommand(async () => await LoadBooksAsync());
            AddCommand = new AsyncRelayCommand(async () => await AddBookAsync());
            EditCommand = new AsyncRelayCommand(async () => await EditBookAsync(), () => SelectedItem != null);
            DeleteCommand = new AsyncRelayCommand(async () => await DeleteBookAsync(), () => SelectedItem != null);
            BorrowCommand = new AsyncRelayCommand(async () => await BorrowBookAsync(), () => SelectedItem != null && SelectedItem.IsAvailable);
            ReturnCommand = new AsyncRelayCommand(async () => await ReturnBookAsync(), () => SelectedItem != null && !SelectedItem.IsAvailable);

            Task.Run(async () => await LoadBooksAsync());
        }

        public ObservableCollection<BookModel> Items
        {
            get => _items;
            set { _items = value; OnPropertyChanged(); }
        }

        public BookModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                ((AsyncRelayCommand)EditCommand).RaiseCanExecuteChanged();
                ((AsyncRelayCommand)DeleteCommand).RaiseCanExecuteChanged();
                ((AsyncRelayCommand)BorrowCommand).RaiseCanExecuteChanged();
                ((AsyncRelayCommand)ReturnCommand).RaiseCanExecuteChanged();
            }
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

        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        public ICommand LoadCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand BorrowCommand { get; }
        public ICommand ReturnCommand { get; }

        private async Task LoadBooksAsync()
        {
            IsLoading = true;
            var allBooks = await _repository.GetAllAsync();

            var filtered = allBooks.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                var search = SearchText.ToLower();
                filtered = filtered.Where(b =>
                    b.Title.ToLower().Contains(search) ||
                    b.Author.ToLower().Contains(search) ||
                    b.Genre.ToLower().Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(FilterAuthor))
            {
                filtered = filtered.Where(b => b.Author.ToLower().Contains(FilterAuthor.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(FilterGenre))
            {
                filtered = filtered.Where(b => b.Genre.ToLower().Contains(FilterGenre.ToLower()));
            }

            Items.Clear();
            foreach (var book in filtered)
            {
                Items.Add(book);
            }
            IsLoading = false;
        }

        private async Task AddBookAsync()
        {
            var dialog = new BookDialogWindow();
            if (dialog.ShowDialog() == true)
            {
                await _repository.AddAsync(dialog.Book);
                await LoadBooksAsync();
                MessageBox.Show("Книга успешно добавлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private async Task EditBookAsync()
        {
            var dialog = new BookDialogWindow(SelectedItem);
            if (dialog.ShowDialog() == true)
            {
                await _repository.UpdateAsync(dialog.Book);
                await LoadBooksAsync();
                MessageBox.Show("Книга успешно обновлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private async Task DeleteBookAsync()
        {
            var result = MessageBox.Show($"Удалить книгу \"{SelectedItem.Title}\"?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                await _repository.DeleteAsync(SelectedItem.Id);
                await LoadBooksAsync();
                MessageBox.Show("Книга удалена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private async Task BorrowBookAsync()
        {
            var result = MessageBox.Show($"Выдать книгу \"{SelectedItem.Title}\"?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                await _repository.ToggleAvailabilityAsync(SelectedItem.Id);
                await LoadBooksAsync();
                MessageBox.Show("Книга выдана!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private async Task ReturnBookAsync()
        {
            var result = MessageBox.Show($"Принять возврат книги \"{SelectedItem.Title}\"?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                await _repository.ToggleAvailabilityAsync(SelectedItem.Id);
                await LoadBooksAsync();
                MessageBox.Show("Книга возвращена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}