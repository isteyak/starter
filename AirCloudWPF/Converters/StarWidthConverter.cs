using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace AirCloudWPF
{
    public class StarWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var listview = value as ListView;
            double width = listview.ActualWidth;
            var listBox = listview.GetChildOfType<ListBox>();
            //// width = listBox.ActualWidth;
            GridView gridView = listview.View as GridView;
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                if (!double.IsNaN(gridView.Columns[i].ActualWidth))
                {
                    width -= gridView.Columns[i].ActualWidth;
                }
            }

            return width - 5;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
