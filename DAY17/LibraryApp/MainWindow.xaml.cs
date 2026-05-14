using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using LibraryApp.Models;

namespace LibraryApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var fadeIn = Resources["FadeInAnimation"] as Storyboard;
            fadeIn?.Begin(MainGrid);

            var slideIn = Resources["SlideInFromLeft"] as Storyboard;
            slideIn?.Begin(BooksGrid);
        }

        private void Cell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var cell = sender as DataGridCell;
            if (cell?.DataContext is BookModel book)
            {
                ShowBookDescription(book);
            }
        }

        private void CloseDescription_Click(object sender, RoutedEventArgs e)
        {
            var fadeOut = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromMilliseconds(200)
            };
            fadeOut.Completed += (s, _) => DescriptionPanel.Visibility = Visibility.Collapsed;
            DescriptionPanel.BeginAnimation(UIElement.OpacityProperty, fadeOut);
        }

        private string GetBookDescription(BookModel book)
        {
            var descriptions = new System.Collections.Generic.Dictionary<string, string>
            {
                { "Война и мир", "Эпический роман о жизни русского общества в эпоху Наполеоновских войн." },
                { "1984", "Роман-антиутопия о тоталитарном режиме и Большом Брате." },
                { "Мастер и Маргарита", "Мистический роман о визите дьявола в Москву." },
                { "Преступление и наказание", "Психологический роман о студенте Раскольникове." }
            };
            return descriptions.ContainsKey(book.Title) ? descriptions[book.Title] : "Описание отсутствует.";
        }
        private void Row_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            if (row?.DataContext is BookModel book)
            {
                ShowBookDescription(book);
            }
        }

        private void ShowBookDescription(BookModel book)
        {
            DescriptionTitle.Text = $"{book.Title} — {book.Author} ({book.Year})";
            DescriptionText.Text = GetBookDescription(book);
            DescriptionPanel.Visibility = Visibility.Visible;

            var fadeIn = Resources["FadeInAnimation"] as Storyboard;
            fadeIn?.Begin(DescriptionPanel);
        }
    }
}