using Sudoku.PageModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Sudoku.UI.Converters
{
    public class NumbersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return false;
            var container = parameter as CollectionView;
            var context = container.BindingContext as SudokuPageModel;
            if (value.ToString() == "X" && context.SelectedNumber == 0) return true;
            return value.ToString() == context.SelectedNumber.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

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
