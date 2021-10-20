using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace AirCloudWPF
{
    public class AdornedPlaceholder : FrameworkElement
    {
        public Adorner Adorner
        {
            get
            {
                Visual current = this;
                while (current != null && !(current is Adorner))
                {
                    current = (Visual)VisualTreeHelper.GetParent(current);
                }

                return (Adorner)current;
            }
        }

        public FrameworkElement AdornedElement
        {
            get
            {
                return Adorner == null ? null : Adorner.AdornedElement as FrameworkElement;
            }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            var controlAdorner = Adorner as AirCloudAdorner;
            if (controlAdorner != null)
            {
                controlAdorner.Placeholder = this;
            }

            FrameworkElement e = AdornedElement;
            return new Size(e.ActualWidth, e.ActualHeight);
        }
    }
}