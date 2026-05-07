using System.Windows;

namespace LibraryApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Exit_Click(object sender, RoutedEventArgs e) => Close();

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция поиска книг", "Поиск", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}