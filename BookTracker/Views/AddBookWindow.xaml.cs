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
            string title = TitleInput.Text.Trim();
            string author = AuthorInput.Text.Trim();
            string genre = GenreInput.Text.Trim();
            string status = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content as string ?? "unread";

            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(author))
            {
                CreatedBook = new Book(title, author)
                {
                    // Якщо у Book є Genre, Status - додати їх сюди
                    // Genre = genre,
                    // Status = status,
                };
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Всі обов'язкові поля мають бути заповнені!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }

}
