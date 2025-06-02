using BookTracker.Models;
using BookTracker.Services;
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
    /// Interaction logic for MainWindow1.xaml
    /// </summary>
    public partial class MainWindow1 : Window
    {

        public MainWindow1()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new DialogService());
        }

        private void BooksList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (BooksList.SelectedItem is Book selectedBook)
            {
                // Доступ до DataContext (твоя MainViewModel)
                var vm = DataContext as MainViewModel;
                if (vm != null && vm.EditBookCommand.CanExecute(selectedBook))
                {
                    // Виклик команди з параметром
                    vm.EditBookCommand.Execute(selectedBook);
                }
            }
        }
    }
}
