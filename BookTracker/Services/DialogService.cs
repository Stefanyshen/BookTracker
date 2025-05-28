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
        public (int? rate, string? review)? ShowReviewDialog()
        {
            var window = new ReviewWindow()
            {
                Owner = App.Current.MainWindow,
            };

            bool? result = window.ShowDialog();
            if (result == true)
                return (window.SelectedRating, window.ReviewText);

            return null;
        }
    }
}
