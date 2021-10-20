using AirCloudWPF;
using System;
using System.Collections.Generic;
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

namespace TestApp
{
    /// <summary>
    /// Interaction logic for Controls.xaml
    /// </summary>
    public partial class Controls : UserControl
    {
        private readonly IModalWindowService modal;

        public Controls(IModalWindowService modal)
        {
            InitializeComponent();
            this.modal = modal;
            this.DataContext = new TestViewModel();
            this.Loaded += (s, e) => FocusManager.SetFocusedElement(this, this.NumericSpinner);
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.modal.Show("TC", "TestTitle");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var data = this.modal.GetParameters(nameof(Controls))["Show"];
        }
    }
}
