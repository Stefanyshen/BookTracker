using BookTracker.Models;
using BookTracker.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookService bookService = new();
        private readonly string filePath = "books.json";
        public MainWindow()
        {
            InitializeComponent();
            DataContext = bookService;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleInput.Text;
            string author = AuthorInput.Text;

            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(author) 
                && title != "Title..." && author != "Author...")
            {
                var book = new Book(title, author);
                bookService.AddBook(book);

                TitleInput.Clear();
                AuthorInput.Clear();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksList.SelectedItem is Book selectedBook)
                bookService.RemoveBook(selectedBook);
        }

        private void MarkAsReadButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksList.SelectedItem is Book selectedBook)
                bookService.MarkAsRead(selectedBook);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) => bookService.SaveToFile(filePath);

        private void LoadButton_Click(object sender, RoutedEventArgs e) => bookService.LoadFromFile(filePath);
    }
}