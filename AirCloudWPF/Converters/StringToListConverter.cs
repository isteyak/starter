using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

namespace AirCloudWPF
{
    public class StringToListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IList<string> data = new ObservableCollection<string>();
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                foreach(var item in value.ToString().Split(','))
                {
                    data.Add(item);
                }
            }

            return data;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
