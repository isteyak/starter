using System;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace AirCloudWPF
{
    /// <summary>
    /// Header Reader and converter exclusively written for DataGrid customization. 
    /// Do not use this for other conversions.
    /// </summary>
    /// <seealso cref="System.Windows.Data.IMultiValueConverter" />
    public class HeaderReaderConverter : IMultiValueConverter
    {
        /// <summary>
        /// Converts source values to a value for the binding target. The data binding engine calls this method when it propagates the values from source bindings to the binding target.
        /// </summary>
        /// <param name="values">The array of values that the source bindings in the <see cref="T:System.Windows.Data.MultiBinding" /> produces. The value <see cref="F:System.Windows.DependencyProperty.UnsetValue" /> indicates that the source binding has no value to provide for conversion.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value.If the method returns <see langword="null" />, the valid <see langword="null" /> value is used.A return value of <see cref="T:System.Windows.DependencyProperty" />.<see cref="F:System.Windows.DependencyProperty.UnsetValue" /> indicates that the converter did not produce a value, and that the binding will use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue" /> if it is available, or else will use the default value.A return value of <see cref="T:System.Windows.Data.Binding" />.<see cref="F:System.Windows.Data.Binding.DoNothing" /> indicates that the binding does not transfer the value or use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue" /> or the default value.
        /// </returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            object convertedValue = null;
            if (values!= null && values.Any())
            {
                var columnHeader = values[0];
                if (columnHeader != null)
                {
                    var converterParameter = parameter?.ToString() ?? string.Empty;

                    var dataGrid = values[1] as DataGrid;
                    var dataGridColumn = dataGrid?.Columns.FirstOrDefault(x => x.Header != null && x.Header.Equals(columnHeader));
                    if (dataGridColumn != null)
                    {
                        var dataGridColumnHeader = dataGridColumn.GetDataGridColumnHeader(dataGrid);
                        switch (converterParameter)
                        {
                            case "C":
                                convertedValue = dataGrid.Columns.IndexOf(dataGridColumn); ;
                                break;
                            case "CS":
                                convertedValue = (object)GridExtensions.GetColumnSpan(dataGridColumnHeader);
                                break;
                            case "BT":

                                break;
                            default:
                                convertedValue = GridExtensions.GetHeader(dataGridColumnHeader);
                                break;
                        }
                    }
                }
            }

            return convertedValue;
        }

        /// <summary>
        /// Converts a binding target value to the source binding values.
        /// </summary>
        /// <param name="value">The value that the binding target produces.</param>
        /// <param name="targetTypes">The array of types to convert to. The array length indicates the number and types of values that are suggested for the method to return.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// An array of values that have been converted from the target value back to the source values.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
