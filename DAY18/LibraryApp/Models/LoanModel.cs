using System;
using System.ComponentModel;

namespace LibraryApp.Models
{
    public class LoanModel : INotifyPropertyChanged
    {
        private string _id;
        private string _bookId;
        private string _readerName;
        private DateTime _loanDate;
        private DateTime? _returnDate;

        public LoanModel()
        {
            Id = Guid.NewGuid().ToString();
            LoanDate = DateTime.Now;
        }

        public string Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public string BookId
        {
            get => _bookId;
            set { _bookId = value; OnPropertyChanged(); }
        }

        public string ReaderName
        {
            get => _readerName ?? "";
            set { _readerName = value; OnPropertyChanged(); }
        }

        public DateTime LoanDate
        {
            get => _loanDate;
            set { _loanDate = value; OnPropertyChanged(); }
        }

        public DateTime? ReturnDate
        {
            get => _returnDate;
            set { _returnDate = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}