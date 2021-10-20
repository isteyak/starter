using AirCloudWPF.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace AirCloudWPF
{
    /// <summary>
    /// Container Control to be used in AirCloudTimeLine, Similar to a ListBoxItem
    /// </summary>
    class AirCloudTimeLineItem : ContentControl
    {
        private string _headerPath;
        private string _datePath;
        private string _detailsPath;

        public AirCloudTimeLineItem(string headerPath, string datePath, string detailsPath)
        {
            _headerPath = headerPath;
            _datePath = datePath;
            _detailsPath = detailsPath;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var cp = this.Template.FindName("Part_ContentPresenter", this) as ContentPresenter;
            cp.ApplyTemplate();

            var headerTb = cp.ContentTemplate.FindName("Part_Header", cp) as TextBlock;
            if (headerTb != null)
            { 
                //Means it is working with the default template.
                //User hasn't created his own Data Template

                headerTb.SetBinding(TextBlock.TextProperty, new Binding(_headerPath));

                var dateTb = cp.ContentTemplate.FindName("Part_Date", cp) as TextBlock;

                Run day = new Run();
                day.SetBinding(Run.TextProperty, new Binding(_datePath + ".Day"){ Mode=BindingMode.OneWay });

                Run superfix = new Run() { BaselineAlignment=BaselineAlignment.Superscript, FontSize=10 };
                superfix.SetBinding(Run.TextProperty, new Binding(_datePath) { Mode = BindingMode.OneWay, Converter = new DateToDaySuffixConverter() });

                Run monthYear = new Run();
                monthYear.SetBinding(Run.TextProperty, new Binding(_datePath) { Mode = BindingMode.OneWay, StringFormat = "{0: MMMM yyyy}" });

                dateTb.Inlines.Add(day);
                dateTb.Inlines.Add(superfix);
                dateTb.Inlines.Add(monthYear);

                var detailsList = cp.ContentTemplate.FindName("Part_Details", cp) as ItemsControl;
                detailsList.SetBinding(ItemsControl.ItemsSourceProperty, new Binding(_detailsPath));
            }
        }
    }
}
