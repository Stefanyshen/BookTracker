using BookTracker.Commands;
using BookTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookTracker.ViewModels
{
    public class EditBookViewModel : INotifyPropertyChanged
    {
        private string title = "";
        private string author = "";
        private string genre = "";
        private Status status = Status.Unread;
        private int rate = 1;
        private string review = "";

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
        public int Rate
        {
            get => rate;
            set
            {
                rate = value;
                OnPropertyChanged();
            }
        }
        public string Review
        {
            get => review;
            set
            {
                review = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public event EventHandler? RequestClose;
        public EditBookViewModel(Book bookToEdit)
        {
            Title = bookToEdit.Title;
            Author = bookToEdit.Author;
            Genre = bookToEdit.Genre;
            Status = bookToEdit.Status;
            Rate = bookToEdit.Rate ?? 1;
            Review = bookToEdit.Review ?? "";
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
