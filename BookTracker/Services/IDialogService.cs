using BookTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTracker.Services
{
    public interface IDialogService
    {
        Book? ShowAddBookDialog();
        Book? ShowEditBookDialog(Book bookToEdit);
    }
}
