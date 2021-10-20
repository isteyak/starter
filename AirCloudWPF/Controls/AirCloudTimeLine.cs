using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirCloudWPF
{
    /// <summary>
    /// Time Line Control to display a series of events.
    /// </summary>
    public class AirCloudTimeLine : ItemsControl
    {
        static AirCloudTimeLine()
        {

        }

        public AirCloudTimeLine()
        {
            Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/AirCloudWPF;component/Styles/Timeline.xaml") };
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription(DatePath, Direction));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new AirCloudTimeLineItem(HeaderPath, DatePath, DetailsPath);
        }

        public string HeaderPath
        {
            get { return (string)GetValue(HeaderPathProperty); }
            set { SetValue(HeaderPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderPathProperty =
            DependencyProperty.Register("HeaderPath", typeof(string), typeof(AirCloudTimeLine), new PropertyMetadata("Header"));

        public string DatePath
        {
            get { return (string)GetValue(DatePathProperty); }
            set { SetValue(DatePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DatePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DatePathProperty =
            DependencyProperty.Register("DatePath", typeof(string), typeof(AirCloudTimeLine), new PropertyMetadata("Date"));

        public string DetailsPath
        {
            get { return (string)GetValue(DetailsPathProperty); }
            set { SetValue(DetailsPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DetailsPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DetailsPathProperty =
            DependencyProperty.Register("DetailsPath", typeof(string), typeof(AirCloudTimeLine), new PropertyMetadata("Details"));


        public ListSortDirection Direction
        {
            get { return (ListSortDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Direction.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(ListSortDirection), typeof(AirCloudTimeLine), new PropertyMetadata(ListSortDirection.Descending));




    }
}
