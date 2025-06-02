using BookTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookTracker.Views
{
    /// <summary>
    /// Interaction logic for BookDialogWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public Book? CreatedBook { get; private set; }

        public AddBookWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Зчитати поля (через data-binding або напряму з TextBox'ів)
            string title = TitleInput.Text;
            string author = AuthorInput.Text;
            string genre = GenreInput.Text;
            Status status = SetStatus();

            if (!string.IsNullOrWhiteSpace(title) || !string.IsNullOrWhiteSpace(author) || !string.IsNullOrWhiteSpace(genre))
            {
                CreatedBook = new Book(title, author, genre, status);

                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Всі обов'язкові поля мають бути заповнені!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private Status SetStatus()
        {
            string? status = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content as string;
            if (status is not null && status == "Unread") return Status.Unread;
            if (status is not null && status == "Reading") return Status.Reading;
            return Status.Finished;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }

}
