using BookTracker.Commands;
using BookTracker.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BookTracker.ViewModels
{
    public class AddBookViewModel : INotifyPropertyChanged
    {
        private string title = "";
        private string author = "";
        private string genre = "";
        private Status status = Status.Unread;

        public string Title 
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        public string Author
        {
            get => author;
            set
            {
                author = value;
                OnPropertyChanged();
            }
        }
        public string Genre
        {
            get => genre;
            set
            {
                genre = value;
                OnPropertyChanged();
            }
        }
        public Status Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }
        public Book? CreatedBook { get; private set; }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public event EventHandler? RequestClose;
        public AddBookViewModel()
        {
            SubmitCommand = new RelayCommand(_ => OnSubmit(), _ => CanSubmit());
            CancelCommand = new RelayCommand(_ => RequestClose?.Invoke(this, EventArgs.Empty));
        }

        private void OnSubmit()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        private bool CanSubmit()
        {
            return !string.IsNullOrWhiteSpace(Title)
                && !string.IsNullOrWhiteSpace(Author)
                && !string.IsNullOrWhiteSpace(Genre);
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? property = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
