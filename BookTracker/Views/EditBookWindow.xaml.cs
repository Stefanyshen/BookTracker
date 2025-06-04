using BookTracker.Models;
using BookTracker.ViewModels;
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

            DataContext = new EditBookViewModel(bookToEdit);
            var viewModel = (EditBookViewModel)DataContext;
            viewModel.RequestClose += (_, _) =>
            {
                // Повертаємо результат якщо це Submit, інакше просто закриваємо
                if (viewModel.SubmitCommand.CanExecute(null))
                    DialogResult = true;
                else
                    DialogResult = false;
                Close();
            };
        }
    }
}
