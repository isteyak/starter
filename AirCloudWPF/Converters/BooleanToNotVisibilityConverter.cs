using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AirCloudWPF
{
    public class BooleanToNotVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = Visibility.Visible;
            var isTrue = value as bool?;
            if(isTrue != null && isTrue.Value)
            {
                visibility = Visibility.Collapsed;
            }

            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
