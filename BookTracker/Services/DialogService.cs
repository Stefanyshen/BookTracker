using BookTracker.Models;
using BookTracker.ViewModels;
using BookTracker.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookTracker.Services
{
    public class DialogService : IDialogService
    {

        public Book? ShowAddBookDialog()
        {
            var window = new AddBookWindow();
            var viewModel = (AddBookViewModel)window.DataContext;

            bool? result = window.ShowDialog();
            if (result == true)
                return new Book(viewModel.Title, viewModel.Author, viewModel.Genre, viewModel.Status);
            return null;
        }
        public Book? ShowEditBookDialog(Book bookToEdit)
        {
            var window = new EditBookWindow(bookToEdit){ Owner = App.Current.MainWindow };
            var viewModel = (EditBookViewModel)window.DataContext;

            bool? result = window.ShowDialog();
            if (result == true) 
                return new Book(viewModel.Title, viewModel.Author, viewModel.Genre, viewModel.Status, viewModel.Rate, viewModel.Review);
            return null;
        }
    }
}
