using System;
using System.Globalization;
using System.Windows.Data;

namespace BookTracker.Converts
{
    public class StatusIsFinishedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value.ToString() == "Finished";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
