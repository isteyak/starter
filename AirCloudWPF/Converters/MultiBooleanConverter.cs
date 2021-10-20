using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace AirCloudWPF
{
    public class MultiBooleanConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var result = false;
            if(values != null && values.Any())
            {
                result = values.All(x => x is bool && (bool)x);
            }

            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
