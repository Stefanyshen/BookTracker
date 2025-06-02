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
    /// Interaction logic for EditBookWindow.xaml
    /// </summary>
    public partial class EditBookWindow : Window
    {
        public Book? EditedBook { get; private set; }

        public EditBookWindow(Book bookToEdit)
        {
            InitializeComponent();

            // Попередньо заповнюємо поля
            TitleInput.Text = bookToEdit.Title;
            AuthorInput.Text = bookToEdit.Author;
            GenreInput.Text = bookToEdit.Genre;
            StatusComboBox.SelectedItem = StatusComboBox.Items
                .Cast<ComboBoxItem>()
                .FirstOrDefault(i => (string)i.Content == bookToEdit.Status.ToString());
            RateSlider.Value = bookToEdit.Rate ?? 1;
            ReviewInput.Text = bookToEdit.Review ?? "";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            // Зчитати значення з полів і створити новий/оновити Book
            EditedBook = new Book(
                TitleInput.Text,
                AuthorInput.Text,
                GenreInput.Text,
                Enum.TryParse(StatusComboBox.Text, out Status status) ? status : Status.Unread
            )
            {
                Rate = (status is Status.Finished) ? (int)RateSlider.Value : null,
                Review = ReviewInput.Text
            };

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
