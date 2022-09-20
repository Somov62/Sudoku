using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Sudoku.UI.Converters
{
    //For solving problem:
    //https://github.com/xamarin/Xamarin.Forms/issues/5942
    public class CollectionViewHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = (double)value / System.Convert.ToInt32(((Label)parameter).Text) - 1;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
