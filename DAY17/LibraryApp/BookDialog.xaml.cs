using System.Windows;
using LibraryApp.Models;

namespace LibraryApp
{
    public partial class BookDialog : Window
    {
        public BookModel Book { get; private set; }

        public BookDialog(BookModel book = null)
        {
            InitializeComponent();
            if (book != null)
            {
                TitleBox.Text = book.Title;
                AuthorBox.Text = book.Author;
                GenreBox.Text = book.Genre;
                YearBox.Text = book.Year.ToString();
            }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleBox.Text))
            {
                MessageBox.Show("Введите название книги");
                return;
            }

            Book = new BookModel
            {
                Title = TitleBox.Text.Trim(),
                Author = AuthorBox.Text.Trim(),
                Genre = GenreBox.Text.Trim(),
                Year = int.TryParse(YearBox.Text, out int y) ? y : 0,
                IsAvailable = true
            };
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}