using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Prism.Commands;

namespace AirCloudWPF
{
    public class AirCloudModal : Window
    {
        /// <summary>
        /// The background window
        /// </summary>
        private Window backgroundWindow;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirCloudModal"/> class.
        /// </summary>
        public AirCloudModal()
        {
            var dic = new ResourceDictionary() { Source = new Uri("pack://application:,,,/AirCloudWPF;component/Styles/Window.xaml") };
            this.Template = dic["AirCloudModal"] as ControlTemplate;
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth - 80;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight - 40;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.WindowStyle = WindowStyle.None;
            this.AllowsTransparency = true;
            this.ResizeMode = ResizeMode.NoResize;
            this.ShowInTaskbar = false;
            this.BackgroundWindow.Owner = Application.Current.Windows.OfType<Window>()?.FirstOrDefault(x => x.IsActive);
            this.BackgroundWindow.Show();
            this.Owner = this.backgroundWindow;
            this.MouseDownCommand = new DelegateCommand(() => this.DragMove());
            this.CloseCommand = new DelegateCommand(() => this.Close());
        }

        /// <summary>
        /// Gets or sets the mouse down command.
        /// </summary>
        /// <value>
        /// The mouse down command.
        /// </value>
        public ICommand MouseDownCommand { get; set; }

        /// <summary>
        /// Gets or sets the close command.
        /// </summary>
        /// <value>
        /// The close command.
        /// </value>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Gets the background window.
        /// </summary>
        /// <value>
        /// The background window.
        /// </value>
        protected Window BackgroundWindow
        {
            get
            {
                if(this.backgroundWindow == null)
                {
                    this.backgroundWindow = new Window()
                    {
                        WindowStyle = WindowStyle.None,
                        AllowsTransparency = true,
                        MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight,
                        MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth,
                        WindowState = WindowState.Maximized,
                        Background = Brushes.Black,
                        Opacity = 0.25,
                        IsHitTestVisible = false,
                        ShowInTaskbar = false,
                        WindowStartupLocation = WindowStartupLocation.CenterOwner,
                        Owner = Application.Current.MainWindow
                    };
                }

                return this.backgroundWindow;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Window.Closed" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if(this.BackgroundWindow.Owner != null)
            {
                this.backgroundWindow.Owner.Activate();
            }

            this.BackgroundWindow.Close();
        }
    }
}
