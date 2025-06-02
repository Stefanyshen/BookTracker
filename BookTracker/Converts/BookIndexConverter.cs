using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BookTracker.Converts
{
    public class BookIndexConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var book = values[0];
            if (book == null || values[1] is not IEnumerable items) return "";
            int index = 1;
            foreach (var item in items)
            {
                if (item == book)
                    return index.ToString();
                index++;
            }
            return "";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
