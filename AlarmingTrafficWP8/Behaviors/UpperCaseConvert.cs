using System;
using System.Globalization;
using System.Windows.Data;

namespace AlarmingTrafficWP8.Behaviors
{
    public class UpperCaseConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value != null) ? value.ToString().ToUpper():String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value != null) ? value.ToString().ToUpper():String.Empty;            
        }
    }

    public class SelectPositionConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString().Length;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }


}
