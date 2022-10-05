using System;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Sudoku.UI.Converters
{
    public class TimerValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int time = (int)value;
            int hours = time / 3600;
            int minutes = time / 60;
            int seconds = time % 60;
            StringBuilder result = new StringBuilder();
            if (hours > 0)
            {
                result.Append(hours.ToString());
                result.Append("h ");
            }

            if (minutes > 0)
            {
                result.Append(minutes.ToString());
                result.Append("m ");
            }

            if (seconds > 0)
            {
                result.Append(seconds.ToString());
                result.Append("s ");
            }

            return result.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
