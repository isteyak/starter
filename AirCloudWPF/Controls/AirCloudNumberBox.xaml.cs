using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace AirCloudWPF
{
    /// <summary>
    /// Interaction logic for AirCloudNumberBox.xaml
    /// TODO: Handle binding errors like 'FormatException'
    /// </summary>
    public partial class AirCloudNumberBox : UserControl
    {
        /// <summary>
        /// The value property
        /// </summary>
        public readonly static DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value",
            typeof(string),
            typeof(AirCloudNumberBox),
            new FrameworkPropertyMetadata("-", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// The box size property
        /// </summary>
        public readonly static DependencyProperty BoxSizeProperty =
            DependencyProperty.RegisterAttached("BoxSize", typeof(ButtonSize), typeof(AirCloudNumberBox), new PropertyMetadata(ButtonSize.Auto, SizeChangedCallback));

        /// <summary>
        /// The minimum error height property
        /// </summary>
        public readonly static DependencyProperty ErrorHeightProperty =
            DependencyProperty.RegisterAttached("ErrorHeight", typeof(double), typeof(AirCloudNumberBox), new PropertyMetadata(Convert.ToDouble("12")));

        /// <summary>
        /// The header property
        /// </summary>
        public readonly static DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header",
            typeof(string),
            typeof(AirCloudNumberBox),
            new PropertyMetadata(string.Empty));

        /// <summary>
        /// The header property
        /// </summary>
        public readonly static DependencyProperty HeaderSizeProperty = DependencyProperty.Register(
            "HeaderSize",
            typeof(double),
            typeof(AirCloudNumberBox),
            new PropertyMetadata(double.Parse("12")));

        /// <summary>
        /// The header property
        /// </summary>
        public readonly static DependencyProperty HeaderBrushProperty = DependencyProperty.Register(
            "HeaderBrush",
            typeof(SolidColorBrush),
            typeof(AirCloudNumberBox),
            new PropertyMetadata(Brushes.Black));

        /// <summary>
        /// The command parameter property
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(AirCloudNumberBox), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// The header property
        /// </summary>
        //// public readonly static DependencyProperty ErrorBrushProperty = DependencyProperty.Register(
        ////    "ErrorBrush",
        ////    typeof(SolidColorBrush),
        ////    typeof(AirCloudNumberBox),
        ////    new PropertyMetadata(Brushes.Tomato));

        /// <summary>
        /// The has error property
        /// </summary>
        public readonly static DependencyProperty HasErrorProperty = DependencyProperty.Register(
            "HasError",
            typeof(bool),
            typeof(AirCloudNumberBox),
            new PropertyMetadata(false));

        /// <summary>
        /// The unit property
        /// </summary>
        public readonly static DependencyProperty UnitProperty = DependencyProperty.Register(
            "Unit",
            typeof(string),
            typeof(AirCloudNumberBox),
            new PropertyMetadata(string.Empty));

        /// <summary>
        /// The error message property key
        /// </summary>
        public readonly static DependencyProperty ErrorMessageProperty = DependencyProperty.Register(
            "ErrorMessage",
            typeof(string),
            typeof(AirCloudNumberBox),
            new PropertyMetadata(string.Empty, ErrorMessagePropertyCallBack));

        /// <summary>
        /// The value change property
        /// </summary>
        public readonly static DependencyProperty ValueChangeProperty =
            DependencyProperty.Register(
                "ValueChange",
                typeof(ICommand),
                typeof(AirCloudNumberBox),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        //// /// <summary>
        //// /// The has error property
        //// /// </summary>
        //// public readonly static DependencyProperty HasErrorProperty = HasErrorPropertyKey.DependencyProperty;

        //// /// <summary>
        //// /// The error message property
        //// /// </summary>
        //// public readonly static DependencyProperty ErrorMessageProperty = ErrorMessagePropertyKey.DependencyProperty;

        /// <summary>
        /// The step property
        /// </summary>
        public readonly static DependencyProperty StepProperty = DependencyProperty.Register(
            "Step",
            typeof(decimal),
            typeof(AirCloudNumberBox),
            new PropertyMetadata(new decimal(0.1)));

        /// <summary>
        /// The decimals property
        /// </summary>
        public readonly static DependencyProperty DecimalsProperty = DependencyProperty.Register(
            "Decimals",
            typeof(int),
            typeof(AirCloudNumberBox),
            new PropertyMetadata(2));

        /// <summary>
        /// The minimum value property
        /// </summary>
        public readonly static DependencyProperty MinValueProperty = DependencyProperty.Register(
            "MinValue",
            typeof(decimal),
            typeof(AirCloudNumberBox),
            new PropertyMetadata(decimal.MinValue));

        /// <summary>
        /// The maximum value property
        /// </summary>
        public readonly static DependencyProperty MaxValueProperty = DependencyProperty.Register(
            "MaxValue",
            typeof(decimal),
            typeof(AirCloudNumberBox),
            new PropertyMetadata(decimal.MaxValue));

        /// <summary>
        /// The show box only property
        /// </summary>
        public readonly static DependencyProperty ShowBoxOnlyProperty = 
            DependencyProperty.RegisterAttached("ShowBoxOnly", typeof(bool), typeof(AirCloudNumberBox), new PropertyMetadata(false, HandleShowOnlyBox));

        /// <summary>
        /// The digits only property
        /// </summary>
        public readonly static DependencyProperty DigitsOnlyProperty =
            DependencyProperty.RegisterAttached("DigitsOnly", typeof(bool), typeof(AirCloudNumberBox), new PropertyMetadata(false));

        public readonly static DependencyProperty BindWhileInputProperty =
            DependencyProperty.RegisterAttached("BindWhileInput", typeof(bool), typeof(AirCloudNumberBox), new PropertyMetadata(false, HandleBindingOnNumberBox));

        /// <summary>
        /// The binding delay property
        /// </summary>
        public readonly static DependencyProperty BindingDelayProperty =
            DependencyProperty.RegisterAttached("BindingDelay", typeof(int), typeof(AirCloudNumberBox), new PropertyMetadata(1000));

        /// <summary>
        /// The digits regex
        /// </summary>
        private readonly Regex digitsRegex;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirCloudNumberBox"/> class.
        /// </summary>
        public AirCloudNumberBox()
        { 
            this.InitializeComponent();
            this.digitsRegex = new Regex(@"^-?[0-9]\d*(\.\d+)?$");           
            this.NumberBox.SetBinding(TextBox.TextProperty, new Binding("Value")
            {
                ElementName = "NumericControl",
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger = UpdateSourceTrigger.LostFocus,
                //// Delay = this.BindingDelay
            });

            this.ValueChanged += this.AirCloudNumberBox_ValueChanged;
            this.PreviewKeyDown += this.AirCloudNumberBox_PreviewKeyDown;
        }

        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        public event EventHandler ValueChanged;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value
        {
            get 
            {
                return GetValue(ValueProperty).ToString();
            }

            set
            {
                if (Convert.ToDecimal(value) < this.MinValue)
                {
                    value = this.MinValue.ToString();
                }

                if (Convert.ToDecimal(value) > this.MaxValue)
                {
                    value = this.MaxValue.ToString();
                }

                this.SetValue(ValueProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the step.
        /// </summary>
        /// <value>
        /// The step.
        /// </value>
        public decimal Step
        {
            get 
            { 
                return (decimal)GetValue(StepProperty); 
            }

            set
            {
                this.SetValue(StepProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the decimals.
        /// </summary>
        /// <value>
        /// The decimals.
        /// </value>
        public int Decimals
        {
            get 
            { 
                return (int)GetValue(DecimalsProperty); 
            }

            set
            {
                this.SetValue(DecimalsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>
        /// The minimum value.
        /// </value>
        public decimal MinValue
        {
            get 
            { 
                return (decimal)GetValue(MinValueProperty); 
            }

            set
            {
                if (value > this.MaxValue)
                {
                    this.MaxValue = value;
                }

                this.SetValue(MinValueProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        public decimal MaxValue
        {
            get 
            { 
                return (decimal)GetValue(MaxValueProperty); 
            }

            set
            {
                if (value < this.MinValue)
                {
                    value = this.MinValue;
                }

                this.SetValue(MaxValueProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has error; otherwise, <c>false</c>.
        /// </value>
        public bool HasError
        {
            get => (bool)this.GetValue(HasErrorProperty);

            set => this.SetValue(HasErrorProperty, value);
        }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>
        /// The header.
        /// </value>
        public string Header
        {
            get => (string)this.GetValue(HeaderProperty);

            set => this.SetValue(HeaderProperty, value);
        }

        /// <summary>
        /// Gets or sets the size of the header.
        /// </summary>
        /// <value>
        /// The size of the header.
        /// </value>
        public double HeaderSize
        {
            get => (double)this.GetValue(HeaderSizeProperty);

            set => this.SetValue(HeaderSizeProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [bind while input].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [bind while input]; otherwise, <c>false</c>.
        /// </value>
        public bool BindWhileInput
        {
            get => (bool)this.GetValue(BindWhileInputProperty);
            set => this.SetValue(BindWhileInputProperty, value);
        }

        /// <summary>
        /// Gets or sets the header brush.
        /// </summary>
        /// <value>
        /// The header brush.
        /// </value>
        public SolidColorBrush HeaderBrush
        {
            get => (SolidColorBrush)this.GetValue(HeaderBrushProperty);

            set => this.SetValue(HeaderBrushProperty, value);
        }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>
        /// The unit.
        /// </value>
        public string Unit
        {
            get => (string)this.GetValue(UnitProperty);
            set => this.SetValue(UnitProperty, value);
        }

        /// <summary>
        /// Gets or sets the error brush.
        /// </summary>
        /// <value>
        /// The error brush.
        /// </value>
        //// public SolidColorBrush ErrorBrush
        //// {
        ////    get => (SolidColorBrush)this.GetValue(ErrorBrushProperty);

        ////    set => this.SetValue(ErrorBrushProperty, value);
        //// }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage
        {
            get => (string)this.GetValue(ErrorMessageProperty);

            set => this.SetValue(ErrorMessageProperty, value);
        }

        /// <summary>
        /// Gets or sets the size of the box.
        /// </summary>
        /// <value>
        /// The size of the box.
        /// </value>
        public ButtonSize BoxSize
        {
            get => (ButtonSize)this.GetValue(BoxSizeProperty);

            set => this.SetValue(BoxSizeProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show box only].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show box only]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowBoxOnly
        {
            get => (bool)this.GetValue(ShowBoxOnlyProperty);
            set => this.SetValue(ShowBoxOnlyProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [digits only].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [digits]; otherwise, <c>false</c>.
        /// </value>
        public bool DigitsOnly
        {
            get => (bool)this.GetValue(DigitsOnlyProperty);
            set => this.SetValue(DigitsOnlyProperty, value);
        }

        /// <summary>
        /// Gets or sets the binding delay.
        /// </summary>
        /// <value>
        /// The binding delay.
        /// </value>
        public int BindingDelay
        {
            get => (int)this.GetValue(BindingDelayProperty);
            set => this.SetValue(BindingDelayProperty, value);
        }

        /// <summary>
        /// Gets or sets the height of the error.
        /// </summary>
        /// <value>
        /// The height of the error.
        /// </value>
        public double ErrorHeight
        {
            get => (double)this.GetValue(ErrorHeightProperty);

            set => this.SetValue(ErrorHeightProperty, value);
        }

        /// <summary>
        /// Gets or sets the value change.
        /// </summary>
        /// <value>
        /// The value change.
        /// </value>
        public ICommand ValueChange
        {
            get => (ICommand)this.GetValue(ValueChangeProperty);
            set => this.SetValue(ValueChangeProperty, value);
        }

        /// <summary>
        /// Gets or sets the command parameter.
        /// </summary>
        /// <value>
        /// The command parameter.
        /// </value>
        public object CommandParameter
        {
            get => (object)this.GetValue(CommandParameterProperty);
            set => this.SetValue(CommandParameterProperty, value);
        }

        /// <summary>
        /// Sizes the changed callback.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void SizeChangedCallback(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var newValue = e.NewValue != null && e.NewValue is ButtonSize;
            var airCloudNumberBox = obj as AirCloudNumberBox;
            if (airCloudNumberBox != null && newValue)
            {
                var size = (ButtonSize)e.NewValue;
                switch (size)
                {
                    case ButtonSize.Large:
                        airCloudNumberBox.NumericBoxBorder.Height = 48;
                        airCloudNumberBox.Up.Margin = new Thickness(0, 2, 0, 0);
                        airCloudNumberBox.Down.Margin = new Thickness(0, 0, 0, 2);
                        airCloudNumberBox.HeaderSize = 14;
                        break;
                    case ButtonSize.Medium:
                        airCloudNumberBox.NumericBoxBorder.Height = 42;
                        airCloudNumberBox.Up.Margin = new Thickness(0, 0, 0, 0);
                        airCloudNumberBox.Down.Margin = new Thickness(0, 0, 0, 0);
                        airCloudNumberBox.HeaderSize = 12;
                        break;
                    case ButtonSize.Small:
                    case ButtonSize.Auto:
                    default:
                        airCloudNumberBox.NumericBoxBorder.Height = 32;
                        airCloudNumberBox.Up.Margin = new Thickness(0, 0, 0, 0);
                        airCloudNumberBox.Down.Margin = new Thickness(0, 0, 0, 0);
                        airCloudNumberBox.HeaderSize = 12;
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the show only box.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void HandleShowOnlyBox(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var airCloudNumberBox = d as AirCloudNumberBox;
            if (airCloudNumberBox != null && e.NewValue is bool && (bool)e.NewValue)
            {
                airCloudNumberBox.HeaderText.Visibility = Visibility.Collapsed;
                airCloudNumberBox.Error.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Handles the binding on number box.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="dpCe">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void HandleBindingOnNumberBox(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dpCe)
        {
            var airCloudNumberBox = dependencyObject as AirCloudNumberBox;
            if (airCloudNumberBox != null && dpCe.NewValue is bool && (bool)dpCe.NewValue)
            {
                BindingOperations.ClearBinding(airCloudNumberBox.NumberBox, TextBox.TextProperty);
                airCloudNumberBox.NumberBox.SetBinding(TextBox.TextProperty, new Binding("Value")
                {
                    ElementName = "NumericControl",
                    Mode = BindingMode.TwoWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                    Delay = airCloudNumberBox.BindingDelay
                });
            }
        }

        /// <summary>
        /// Errors the message property call back.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void ErrorMessagePropertyCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var airCloudNumberBox = d as AirCloudNumberBox;
            if (airCloudNumberBox != null)
            {
                airCloudNumberBox.HasError = e.NewValue?.ToString().Length > 0;
            }
        }

        /// <summary>
        /// Handles the Click event of the Down control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Down_Click(object sender, RoutedEventArgs e)
        {
            var value = this.Value == "-" || this.Value == "" ? 0 : Convert.ToDecimal(this.Value);
            value -= this.Step;
            this.Value = value.ToString();
        }

        /// <summary>
        /// Handles the Click event of the Up control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Up_Click(object sender, RoutedEventArgs e)
        {
            var value = this.Value == "-" || this.Value == "" ? 0 : Convert.ToDecimal(this.Value);
            value += this.Step;
            this.Value = value.ToString();
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        private void Validate()
        {
            if (this.MinValue > this.MaxValue) { this.MinValue = this.MaxValue; }
            if (this.MaxValue < this.MinValue) { this.MaxValue = this.MinValue; }
            if (Convert.ToDecimal(this.Value) < this.MinValue) { this.Value = this.MinValue.ToString(); }
            if (Convert.ToDecimal(this.Value) > this.MaxValue) { this.Value = this.MaxValue.ToString(); }

            this.Value = decimal.Round(Convert.ToDecimal(this.Value), this.Decimals).ToString();
        }

        /// <summary>
        /// Handles the ValueChanged event of the AirCloudNumberBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AirCloudNumberBox_ValueChanged(object sender, EventArgs e) { }

        /// <summary>
        /// Handles the TextChanged event of the NumberBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void NumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //// this.HasError = !(double.TryParse(this.NumberBox.Text, out _) && this.Value >= this.MinValue && this.Value <= this.MaxValue);
            this.NumberBox.SelectionStart = this.NumberBox.Text.Length;
            this.NumberBox.SelectionLength = 0;
            //// this.ValueChange?.Execute(this.CommandParameter);
            //// this.ErrorMessage = this.HasError ? $"Value should be between {this.MinValue} and {this.MaxValue}" : string.Empty;
            //// this.HeaderText.Foreground = this.HasError ? this.ErrorBrush : this.HeaderBrush;
            //// this.NumericBoxBorder.BorderBrush = this.HasError ? this.ErrorBrush : this.BorderBrush;
        }

        /// <summary>
        /// Handles the PreviewKeyDown event of the AirCloudNumberBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void AirCloudNumberBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Down:
                    this.Down_Click(sender, e);
                    break;
                case Key.Up:
                    this.Up_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the PreviewTextInput event of the NumberBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextCompositionEventArgs"/> instance containing the event data.</param>
        private void NumberBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (this.DigitsOnly)
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            else
            {   
                if (e.Text == ".")
                {
                    e.Handled = this.NumberBox.Text.Count(x => x == '.') == 1;
                }
                else if(e.Text == "-")
                {
                    e.Handled = this.NumberBox.Text.Count(x => x == '-') == 1;
                }
                else
                {
                    Regex regex = new Regex("[^0-9]+");
                    e.Handled = regex.IsMatch(e.Text);
                }
            }
        }

        /// <summary>
        /// Handles the LostFocus event of the NumberBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void NumberBox_LostFocus(object sender, RoutedEventArgs e)
        {
            this.NumberBox.ScrollToHome();
        }

        /// <summary>
        /// Handles the GotFocus event of the NumericControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void NumericControl_GotFocus(object sender, RoutedEventArgs e)
        {
            this.NumberBox.Focus();
        }

        /// <summary>
        /// Checks if the text is allowed
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>TRUE if its allowed</returns>
        private bool IsTextAllowed(string text)
        {
            return !this.digitsRegex.IsMatch(text);
        }

        /// <summary>
        /// Handles the paste event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {

        }
    }
}
