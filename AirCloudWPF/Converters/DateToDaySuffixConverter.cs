using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AirCloudWPF.Converters
{
    public class DateToDaySuffixConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
            {
                DateTime day = (DateTime)value;
                string suffix = "th";
                switch (day.Day)
                {
                    case 1:
                    case 21:
                    case 31:
                        suffix= "st";
                        break;
                    case 2:
                    case 22:
                        suffix= "nd";
                        break;
                    case 3:
                    case 23:
                        suffix = "rd";
                        break;
                }

                return suffix;// day.Day + suffix + " of " + String.Format("{0:MMMM yyyy}", day);
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
