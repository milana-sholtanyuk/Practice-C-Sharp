using System;
using System.ComponentModel;

namespace LibraryApp.Models
{
    public class BookModel : INotifyPropertyChanged
    {
        private string _id;
        private string _title;
        private string _author;
        private string _genre;
        private int _year;
        private bool _isAvailable;

        public BookModel()
        {
            Id = Guid.NewGuid().ToString();
            Title = "";
            Author = "";
            Genre = "";
            Year = 0;
            IsAvailable = true;
        }

        public string Id
        {
            get => _id;
            set { _id = value ?? Guid.NewGuid().ToString(); OnPropertyChanged(); }
        }

        public string Title
        {
            get => _title ?? "";
            set { _title = value ?? ""; OnPropertyChanged(); }
        }

        public string Author
        {
            get => _author ?? "";
            set { _author = value ?? ""; OnPropertyChanged(); }
        }

        public string Genre
        {
            get => _genre ?? "";
            set { _genre = value ?? ""; OnPropertyChanged(); }
        }

        public int Year
        {
            get => _year;
            set { _year = value; OnPropertyChanged(); }
        }

        public bool IsAvailable
        {
            get => _isAvailable;
            set { _isAvailable = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}