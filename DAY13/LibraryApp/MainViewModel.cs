using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace LibraryApp
{
    public class MainViewModel
    {
        public ObservableCollection<Book> Books { get; set; }
        private Book _selectedBook;
        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand AddBookCommand { get; }
        public ICommand EditBookCommand { get; }
        public ICommand DeleteBookCommand { get; }

        public MainViewModel()
        {
            Books = new ObservableCollection<Book>();
            Books.Add(new Book { Title = "Война и мир", Author = "Лев Толстой", Genre = "Роман", Year = 1869 });
            Books.Add(new Book { Title = "1984", Author = "Джордж Оруэлл", Genre = "Антиутопия", Year = 1949 });
            Books.Add(new Book { Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Genre = "Роман", Year = 1967 });

            AddBookCommand = new RelayCommand(AddBook);
            EditBookCommand = new RelayCommand(EditBook, () => SelectedBook != null);
            DeleteBookCommand = new RelayCommand(DeleteBook, () => SelectedBook != null);
        }

        private void AddBook()
        {
            var dialog = new BookDialog();
            if (dialog.ShowDialog() == true)
                Books.Add(dialog.Book);
        }

        private void EditBook()
        {
            var dialog = new BookDialog(SelectedBook);
            if (dialog.ShowDialog() == true)
            {
                var index = Books.IndexOf(SelectedBook);
                Books[index] = dialog.Book;
            }
        }

        private void DeleteBook()
        {
            if (MessageBox.Show($"Удалить книгу \"{SelectedBook.Title}\"?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Books.Remove(SelectedBook);
            }
        }
    }
}