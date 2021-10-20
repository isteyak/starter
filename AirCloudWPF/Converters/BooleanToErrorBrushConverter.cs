using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace AirCloudWPF
{
    public class BooleanToErrorBrushConverter : IValueConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanToErrorBrushConverter"/> class.
        /// </summary>
        public BooleanToErrorBrushConverter()
        {
            this.DefaultBrush = Brushes.Gray;
            this.ErrorColorBrush = Brushes.Red;
        }

        /// <summary>
        /// Gets or sets the default brush.
        /// </summary>
        /// <value>
        /// The default brush.
        /// </value>
        public SolidColorBrush DefaultBrush { get; set; }

        /// <summary>
        /// Gets or sets the error color brush.
        /// </summary>
        /// <value>
        /// The error color brush.
        /// </value>
        public SolidColorBrush ErrorColorBrush { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var errorBrush = parameter != null ? parameter as SolidColorBrush : this.DefaultBrush;
            var isTrue = value as bool?;
            if (isTrue != null && isTrue.Value)
            {
                errorBrush = this.ErrorColorBrush;
            }

            return errorBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
