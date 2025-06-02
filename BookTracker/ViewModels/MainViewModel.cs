using BookTracker.Commands;
using BookTracker.Models;
using BookTracker.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace BookTracker.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly string filePath = "books.json";
        private readonly IDialogService dialogService;
        private readonly BookService bookService = new();
        private Book? selectedBook;

        private string statusFilter = "Всі";
        private int? minRateFilter = null;

        public ICollectionView FilteredBooks { get; }
        public ObservableCollection<Book> Books => bookService.Books;
        public Book? SelectedBook
        {
            get => selectedBook;
            set
            {
                selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }
        public string StatusFilter
        {
            get => statusFilter;
            set
            {
                statusFilter = value;
                OnPropertyChanged(nameof(StatusFilter));
                FilteredBooks.Refresh();
            }
        }
        public int? MinRateFilter
        {
            get => minRateFilter;
            set
            {
                minRateFilter = value;
                OnPropertyChanged(nameof(MinRateFilter));
                FilteredBooks.Refresh();
            }
        }

        public ICommand ShowAddBookCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand ShowAllBooksCommand { get; }
        public ICommand ShowReadBooksCommand { get; }
        public ICommand RemoveBookCommand { get; }

        public MainViewModel(IDialogService dialogService)
        {
            FilteredBooks = CollectionViewSource.GetDefaultView(bookService.Books);
            this.dialogService = dialogService;
            ShowAddBookCommand = new RelayCommand(_ => ShowAddBook());
            RemoveBookCommand = new RelayCommand(_ => RemoveBook());
            SaveCommand = new RelayCommand(_ => bookService.SaveToFile(filePath));
            ShowAllBooksCommand = new RelayCommand(_ => ShowAllBooks());
            ShowReadBooksCommand = new RelayCommand(_ => ShowReadBooks());
            FilteredBooks = CollectionViewSource.GetDefaultView(bookService.Books);
            FilteredBooks.Filter = FilterBooks;

            bookService.LoadFromFile(filePath);
        }

        private void ShowAddBook()
        {
            var book = dialogService.ShowAddBookDialog();
            if (book != null)
            {
                bookService.AddBook(book);
                bookService.SaveToFile(filePath);
            }
        }

        public void ShowAllBooks()
        {
            StatusFilter = "Всі";
            FilteredBooks.Refresh();
        }
        public void ShowReadBooks()
        {
            StatusFilter = "Прочитано";
            FilteredBooks.Refresh();
        }

        private void RemoveBook()
        {
            if (SelectedBook != null)
            {
                bookService.RemoveBook(SelectedBook);
                bookService.SaveToFile(filePath);
            }
        }

        private bool FilterBooks(object obj)
        {
            if (obj is not Book book) return false;
            if (StatusFilter == "Прочитано" && book.Status != Status.Finished) return false;
            if (StatusFilter == "Всі") return true;
            // ...інші фільтри
            return true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
