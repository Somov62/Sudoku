using System;
using System.Globalization;
using Xamarin.Forms;

namespace Sudoku.UI.Converters
{
    public class CollectionViewFontSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value / 2 + 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
