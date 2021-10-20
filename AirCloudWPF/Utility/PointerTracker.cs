using System.Windows;

namespace AirCloudWPF
{
    public static class PointerTracker
    {
        /// <summary>
        /// Gets the x.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static double GetX(DependencyObject obj)
        {
            return (double)obj.GetValue(XProperty);
        }

        /// <summary>
        /// Sets the x.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="value">The value.</param>
        private static void SetX(DependencyObject obj, double value)
        {
            obj.SetValue(XProperty, value);
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for X.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty XProperty =
            DependencyProperty.RegisterAttached("X", typeof(double), typeof(PointerTracker), new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Gets the y.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static double GetY(DependencyObject obj)
        {
            return (double)obj.GetValue(YProperty);
        }

        /// <summary>
        /// Sets the y.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="value">The value.</param>
        private static void SetY(DependencyObject obj, double value)
        {
            obj.SetValue(YProperty, value);
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Y.  This enables animation, styling, binding, etc...
        /// </summary>        
        public static readonly DependencyProperty YProperty =
            DependencyProperty.RegisterAttached("Y", typeof(double), typeof(PointerTracker), new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static Point GetPosition(DependencyObject obj)
        {
            return (Point)obj.GetValue(PositionProperty);
        }

        /// <summary>
        /// Sets the position.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="value">The value.</param>
        private static void SetPosition(DependencyObject obj, Point value)
        {
            obj.SetValue(PositionProperty, value);
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Position.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.RegisterAttached("Position", typeof(Point), typeof(PointerTracker), new FrameworkPropertyMetadata(new Point(0, 0), FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Gets the is enter.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static bool GetIsEnter(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnterProperty);
        }

        /// <summary>
        /// Sets the is enter.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private static void SetIsEnter(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnterProperty, value);
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for IsEnter.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IsEnterProperty =
            DependencyProperty.RegisterAttached("IsEnter", typeof(bool), typeof(PointerTracker), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Gets the root object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static UIElement GetRootObject(DependencyObject obj)
        {
            return (UIElement)obj.GetValue(RootObjectProperty);
        }

        /// <summary>
        /// Sets the root object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="value">The value.</param>
        private static void SetRootObject(DependencyObject obj, UIElement value)
        {
            obj.SetValue(RootObjectProperty, value);
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for RootObject.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty RootObjectProperty =
            DependencyProperty.RegisterAttached("RootObject", typeof(UIElement), typeof(PointerTracker), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Gets the enabled.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static bool GetEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnabledProperty);
        }

        /// <summary>
        /// Sets the enabled.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void SetEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(EnabledProperty, value);
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Enabled.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.RegisterAttached("Enabled", typeof(bool), typeof(PointerTracker), new PropertyMetadata(false, OnEnabledChanged));

        /// <summary>
        /// Called when [enabled changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = d as UIElement;
            var newValue = (bool)e.NewValue;
            var oldValue = (bool)e.OldValue;
            if (ctrl == null) return;

            if (oldValue && !newValue)
            {
                ctrl.MouseEnter -= Ctrl_MouseEnter;
                ctrl.PreviewMouseMove -= Ctrl_PreviewMouseMove;
                ctrl.MouseLeave -= Ctrl_MouseLeave;

                ctrl.ClearValue(PointerTracker.RootObjectProperty);
            }

            if (!oldValue && newValue)
            {
                ctrl.MouseEnter += Ctrl_MouseEnter;
                ctrl.PreviewMouseMove += Ctrl_PreviewMouseMove;
                ctrl.MouseLeave += Ctrl_MouseLeave;

                SetRootObject(ctrl, ctrl);
            }
        }

        /// <summary>
        /// Handles the MouseEnter event of the Ctrl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseEventArgs"/> instance containing the event data.</param>
        private static void Ctrl_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var ctrl = sender as UIElement;
            if (ctrl != null)
            {
                SetIsEnter(ctrl, true);
            }
        }

        /// <summary>
        /// Handles the PreviewMouseMove event of the Ctrl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseEventArgs"/> instance containing the event data.</param>
        private static void Ctrl_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var ctrl = sender as UIElement;
            if (ctrl != null && GetIsEnter(ctrl))
            {
                var pos = e.GetPosition(ctrl);

                SetX(ctrl, pos.X);
                SetY(ctrl, pos.Y);
                SetPosition(ctrl, pos);
            }
        }

        /// <summary>
        /// Handles the MouseLeave event of the Ctrl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseEventArgs"/> instance containing the event data.</param>
        private static void Ctrl_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var ctrl = sender as UIElement;
            if (ctrl != null)
            {
                SetIsEnter(ctrl, false);
            }
        }
    }
}
