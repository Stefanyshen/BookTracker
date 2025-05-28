using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTracker.Services
{
    public interface IDialogService
    {
        (int? rate, string? review)? ShowReviewDialog();
    }
}
