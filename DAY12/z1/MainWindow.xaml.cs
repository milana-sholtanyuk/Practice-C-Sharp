using System.Windows;
using z1.ViewModels;

namespace z1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenBookButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = (MainViewModel)DataContext;
            if (vm.SelectedBook == null)
            {
                MessageBox.Show("Сначала выберите книгу из списка!", "Внимание",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show($"Вы открыли книгу:\n\n{vm.SelectedBook.Title}\n{vm.SelectedBook.Author}\n\n{vm.SelectedBook.Description}",
                "Открыть книгу", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}