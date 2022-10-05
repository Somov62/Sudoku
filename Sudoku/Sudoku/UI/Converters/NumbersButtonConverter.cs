using System;
using System.Globalization;
using Xamarin.Forms;

namespace Sudoku.UI.Converters
{
    public class NumbersButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return false;
            if (((Button)parameter).Text == "X" && (int)value == 0) return true;
            return ((Button)parameter).Text == value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
