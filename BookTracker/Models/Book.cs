using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTracker.Models 
{
    public class Book : INotifyPropertyChanged
    {
        private string title;
        private string author;
        private string genre;
        private Status status;
        private int? rate;
        private string review;

        public Book() { } // для серіалізації

        public Book(string title, string author, string genre, Status status)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Status = status;
        }

        public Book(string title, string author, string genre, Status status, int? rate, string review)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Status = status;
            Rate = rate;
            Review = review;
        }

        public string Title 
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Author 
        { 
            get => author;
            set
            {
                author = value;
                OnPropertyChanged(nameof(Author));
            }
        }
        public string Genre
        {
            get => genre;
            set
            {
                genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }
        public int? Rate 
        {
            get => rate;
            set
            {
                if (value > 0 && value <= 10 || value is null)
                {
                    rate = value;
                    OnPropertyChanged(nameof(Rate));
                }
            }
        }
        public string Review 
        {
            get => review;
            set
            {
                review = value;
                OnPropertyChanged(nameof(Review));
            }
        }
        public Status Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
