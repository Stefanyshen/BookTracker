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
        private string titleInput = string.Empty;
        private string authorInput = string.Empty;
        private string genreInput = string.Empty;
        private Book? selectedBook;

        private string statusFilter = "Всі";
        private int? minRateFilter = null;

        public ICollectionView FilteredBooks { get; }
        public ObservableCollection<Book> Books => bookService.Books;
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
        public ICommand MarkAsReadCommand { get; }
        public ICommand RemoveBookCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }

        public MainViewModel(IDialogService dialogService)
        {
            FilteredBooks = CollectionViewSource.GetDefaultView(bookService.Books);
            FilteredBooks.Filter = FilterBooks;
            this.dialogService = dialogService;
            ShowAddBookCommand = new RelayCommand(_ => ShowAddBook());
            MarkAsReadCommand = new RelayCommand(_ => MarkAsRead(), _ => SelectedBook != null);
            RemoveBookCommand = new RelayCommand(_ => RemoveBook(), _ => SelectedBook != null);
            SaveCommand = new RelayCommand(_ => bookService.SaveToFile(filePath));
            LoadCommand = new RelayCommand(_ => bookService.LoadFromFile(filePath));
        }

        private void ShowAddBook()
        {
            var book = dialogService.ShowAddBookDialog();
            if (book != null) bookService.AddBook(book);
        }

        private void MarkAsRead()
        {
            if (SelectedBook != null)
            {
                var result = dialogService.ShowReviewDialog();

                if (result is (int rating, string review))
                {
                    SelectedBook.Rate = rating;
                    SelectedBook.Review = review;
                    bookService.MarkAsRead(SelectedBook);
                }
            }
        }

        private void RemoveBook()
        {
            if (SelectedBook != null)
                bookService.RemoveBook(SelectedBook);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        private bool FilterBooks(object obj)
        {
            if (obj is not Book book) 
                return false;
            if ((StatusFilter == "Прочитано" && !book.IsRead) || (StatusFilter == "Не прочитано" && book.IsRead))
                return false;
            if (minRateFilter.HasValue && (book.Rate ?? 0) < minRateFilter.Value) 
                return false;

            return true;
        }
    }
}
