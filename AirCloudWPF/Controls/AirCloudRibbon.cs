using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace AirCloudWPF
{
    /// <summary>
    /// Defines a ribbon class for airCloud product line
    /// </summary>
    public class AirCloudRibbon : UserControl
    {
        /// <summary>
        /// The button type property.
        /// </summary>
        public static readonly DependencyProperty RibbonTypeProperty =
            DependencyProperty.RegisterAttached("RibbonType", typeof(RibbonType), typeof(AirCloudRibbon), new PropertyMetadata(RibbonType.Information));

        /// <summary>
        /// The is active property
        /// </summary>
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(AirCloudRibbon), new PropertyMetadata(false, OnIsActiveChanged));

        /// <summary>
        /// The automatic hide property
        /// </summary>
        public static readonly DependencyProperty AutoHideProperty =
            DependencyProperty.Register("AutoHide", typeof(bool), typeof(AirCloudRibbon), new PropertyMetadata(false));

        /// <summary>
        /// The time out property
        /// </summary>
        public static readonly DependencyProperty TimeOutProperty =
            DependencyProperty.Register("TimeOut", typeof(double?), typeof(AirCloudRibbon), new PropertyMetadata(DEFAULT_TIME_OUT));

        /// <summary>
        /// The default time out
        /// </summary>
        private const double DEFAULT_TIME_OUT = 10;

        /// <summary>
        /// The dispatcher timer
        /// </summary>
        private DispatcherTimer dispatcherTimer;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirCloudRibbon"/> class.
        /// </summary>
        public AirCloudRibbon()
        {
            var dic = new ResourceDictionary() { Source = new Uri("pack://application:,,,/AirCloudWPF;component/Styles/Controls.xaml") };
            this.Template = dic["AirCloudRibbon"] as ControlTemplate;
            this.Loaded += this.AirCloudRibbon_Loaded;
            this.Visibility = Visibility.Collapsed;
            this.dispatcherTimer = new DispatcherTimer();
            this.dispatcherTimer.Interval = TimeSpan.FromSeconds(this.TimeOut != null && this.TimeOut > 0 ? this.TimeOut.Value : DEFAULT_TIME_OUT);
            this.dispatcherTimer.Tick += this.DispatcherTimer_Tick;
        }

        /// <summary>
        /// Gets the type of the ribbon.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns>The ribbon type</returns>
        public static RibbonType GetRibbonType(DependencyObject dependencyObject)
        {
            return (RibbonType)dependencyObject.GetValue(RibbonTypeProperty);
        }

        /// <summary>
        /// Sets the type of the ribbon.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="ribbonType">Type of the ribbon.</param>
        public static void SetRibbonType(DependencyObject dependencyObject, RibbonType ribbonType)
        {
            dependencyObject.SetValue(RibbonTypeProperty, ribbonType);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic hide].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [automatic hide]; otherwise, <c>false</c>.
        /// </value>
        public bool AutoHide
        {
            get => (bool)this.GetValue(AutoHideProperty);

            set => this.SetValue(AutoHideProperty, value);
        }

        /// <summary>
        /// Gets or sets the time out.
        /// </summary>
        /// <value>
        /// The time out.
        /// </value>
        public double? TimeOut
        {
            get => (double?)this.GetValue(TimeOutProperty);

            set => this.SetValue(TimeOutProperty, value);
        }

        private static void OnIsActiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var airCloudRibbon = d as AirCloudRibbon;
            if (airCloudRibbon != null)
            {
                airCloudRibbon.Visibility = (bool)e.NewValue ? Visibility.Visible : Visibility.Collapsed;

                if ((bool)e.NewValue && airCloudRibbon.AutoHide)
                {
                    airCloudRibbon.dispatcherTimer?.Start();
                }
            }
        }

        /// <summary>
        /// Handles the Loaded event of the AirCloudRibbon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AirCloudRibbon_Loaded(object sender, RoutedEventArgs e)
        {
            var closeButton = this.GetChildOfType<Button>(); ;
            if (closeButton != null)
            {
                closeButton.Click += (s, ce) =>
                {
                    this.dispatcherTimer?.Stop();
                    this.IsActive = false;
                };
            }
        }

        /// <summary>
        /// Handles the Tick event of the DispatcherTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            this.dispatcherTimer = sender as DispatcherTimer;
            this.dispatcherTimer?.Stop();
            this.IsActive = false;
        }
    }
}
