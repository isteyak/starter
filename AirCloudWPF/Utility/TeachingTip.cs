using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;

namespace AirCloudWPF
{
    public class TeachingTip
    {
        public static readonly DependencyProperty TemplateProperty =
            DependencyProperty.RegisterAttached("Template", typeof(ControlTemplate), typeof(TeachingTip), new PropertyMetadata(TemplateChanged));

        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.RegisterAttached("IsVisible", typeof(bool), typeof(TeachingTip), new PropertyMetadata(IsVisibleChanged));

        public static readonly DependencyProperty InternalAdornerProperty =
            DependencyProperty.RegisterAttached("InternalAdorner", typeof(AirCloudAdorner), typeof(TeachingTip));

        public static AirCloudAdorner GetInteranlAdorner(DependencyObject target)
        {
            return (AirCloudAdorner)target.GetValue(InternalAdornerProperty);
        }
        public static void SetInternalAdorner(DependencyObject target, AirCloudAdorner value)
        {
            target.SetValue(InternalAdornerProperty, value);
        }
        public static bool GetIsVisible(UIElement target)
        {
            return (bool)target.GetValue(IsVisibleProperty);
        }
        public static void SetIsVisible(UIElement target, bool value)
        {
            target.SetValue(IsVisibleProperty, value);
        }
        private static void IsVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpdateAdroner((UIElement)d, (bool)e.NewValue, GetTemplate((UIElement)d));
        }

        public static ControlTemplate GetTemplate(UIElement target)
        {
            return (ControlTemplate)target.GetValue(TemplateProperty);
        }
        public static void SetTemplate(UIElement target, ControlTemplate value)
        {
            target.SetValue(TemplateProperty, value);
        }
        private static void TemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpdateAdroner((UIElement)d, GetIsVisible((UIElement)d), (ControlTemplate)e.NewValue);
        }

        private static void UpdateAdroner(UIElement adorned)
        {
            UpdateAdroner(adorned, GetIsVisible(adorned), GetTemplate(adorned));
        }

        private static void UpdateAdroner(UIElement adorned, bool isVisible, ControlTemplate controlTemplate)
        {
            var layer = AdornerLayer.GetAdornerLayer(adorned);

            if (layer == null)
            {
                Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new Action<UIElement>((o) => UpdateAdroner(o)), adorned);
                return;                
            }

            var existingAdorner = GetInteranlAdorner(adorned);

            if (existingAdorner == null)
            {
                if (controlTemplate != null && isVisible)
                {
                    var newAdorner = new AirCloudAdorner(adorned);
                    newAdorner.Child = new Control() { Template = controlTemplate, Focusable = false, };
                    layer.Add(newAdorner);
                    SetInternalAdorner(adorned, newAdorner);
                }
            }
            else
            {
                if (controlTemplate != null && isVisible)
                {
                    Control ctrl = existingAdorner.Child;
                    ctrl.Template = controlTemplate;
                }
                else
                {
                    // hide
                    existingAdorner.Child = null;
                    layer.Remove(existingAdorner);
                    SetInternalAdorner(adorned, null);
                }
            }
        }
    }
}
