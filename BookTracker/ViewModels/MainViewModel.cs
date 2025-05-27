using BookTracker.Commands;
using BookTracker.Models;
using BookTracker.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookTracker.ViewModels
{
    public class MainViewModel
    {
        private BookService bookService = new();
        public ObservableCollection<Book> Books => bookService.Books;

        private string titleInput = string.Empty;
        private string authorInput = string.Empty;
        private Book? selectedBook;
        private readonly string filePath = "books.json";

        public string TitleInput
        {
            get => titleInput;
            set
            {
                titleInput = value;
                OnPropertyChanged(nameof(TitleInput));
            }
        }
        public string AuthorInput
        {
            get => authorInput;
            set
            {
                authorInput = value;
                OnPropertyChanged(nameof(AuthorInput));
            }
        }
        public Book? SelectedBook
        {
            get => selectedBook;
            set
            {
                selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        public ICommand AddBookCommand { get; }
        public ICommand MarkAsReadCommand { get; }
        public ICommand RemoveBookCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }

        public MainViewModel()
        {
            AddBookCommand = new RelayCommand(_ => AddBook());
            MarkAsReadCommand = new RelayCommand(_ => MarkAsRead(), _ => SelectedBook != null);
            RemoveBookCommand = new RelayCommand(_ => RemoveBook(), _ => SelectedBook != null);
            SaveCommand = new RelayCommand(_ => bookService.SaveToFile(filePath));
            LoadCommand = new RelayCommand(_ => bookService.LoadFromFile(filePath));
        }

        private void AddBook()
        {
            if (!string.IsNullOrWhiteSpace(TitleInput) && !string.IsNullOrWhiteSpace(AuthorInput))
            {
                var book = new Book(TitleInput, AuthorInput);
                bookService.AddBook(book);
                TitleInput = "";
                AuthorInput = "";
            }
        }

        private void MarkAsRead()
        {
            if (SelectedBook != null)
                bookService.MarkAsRead(SelectedBook);
        }

        private void RemoveBook()
        {
            if (SelectedBook != null)
                bookService.RemoveBook(SelectedBook);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
