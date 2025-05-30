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
        //private string genre;
        private int? rate;
        private string review;
        private bool isRead;

        public Book() { } // для серіалізації

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            //Genre = genre;
            IsRead = false;
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
        //public string Genre
        //{
        //    get => genre;
        //    set 
        //    {
        //        genre = value;
        //        OnPropertyChanged(nameof(Genre));
        //    }
        //}
        public int? Rate 
        {
            get => rate;
            set
            {
                if (value > 0 && value <= 10)
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
        public bool IsRead 
        {
            get => isRead;
            set
            {
                isRead = value;
                OnPropertyChanged(nameof(IsRead));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
