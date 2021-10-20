using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shell;

namespace AirCloudWPF
{
    /// <summary>
    /// Defines a custom window for airCloud Product line.
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    public class AirCloudWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirCloudWindow"/> class.
        /// </summary>
        public AirCloudWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AirCloudWindow), new FrameworkPropertyMetadata(typeof(AirCloudWindow)));
            WindowChrome.SetWindowChrome(this, new WindowChrome { CaptionHeight = 34 });
            var dic = new ResourceDictionary() { Source = new Uri("pack://application:,,,/AirCloudWPF;component/Styles/Window.xaml") };
            this.Template = dic["AirCloudWindow"] as ControlTemplate;
        }

        /// <summary>
        /// Occurs when the user selects a file name by either clicking the Open button of the <see cref="T:Microsoft.Win32.OpenFileDialog" /> or the Save button of the <see cref="T:Microsoft.Win32.SaveFileDialog" />.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
                      
            EnableBlur(this);
        }

        /// <summary>
        /// Enables the blur.
        /// </summary>
        /// <param name="window">The window.</param>
        internal static void EnableBlur(Window window)
        {
            if (window != null)
            {
                window.CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, (_, __) => SystemCommands.CloseWindow(window)));
                window.CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, (_, __) => SystemCommands.MinimizeWindow(window)));
                window.CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, (_, __) => SystemCommands.MaximizeWindow(window)));
                window.CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, (_, __) => SystemCommands.RestoreWindow(window)));

                void onContentRendered(object sender, EventArgs e)
                {
                    if (window.SizeToContent != SizeToContent.Manual)
                    {
                        window.InvalidateMeasure();
                    }

                    window.ContentRendered -= onContentRendered;
                }

                window.ContentRendered += onContentRendered;
            }
        }
    }
}
