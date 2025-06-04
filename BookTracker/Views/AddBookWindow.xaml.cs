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
    /// Interaction logic for BookDialogWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();

            DataContext = new AddBookViewModel();
            var viewModel = (AddBookViewModel)DataContext;
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
