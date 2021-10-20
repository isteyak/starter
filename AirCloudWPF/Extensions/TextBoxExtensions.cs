using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AirCloudWPF
{
    /// <summary>
    /// Defines text box extensions.
    /// </summary>
    public class TextBoxExtensions : DependencyObject
    {
        /// <summary>
        /// The header property
        /// </summary>
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.RegisterAttached("Header", typeof(string), typeof(TextBoxExtensions), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// The header size property
        /// </summary>
        public static readonly DependencyProperty HeaderSizeProperty =
            DependencyProperty.RegisterAttached("HeaderSize", typeof(double), typeof(TextBoxExtensions), new FrameworkPropertyMetadata(12.0, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// The header foreground brush property
        /// </summary>
        public static readonly DependencyProperty HeaderForegroundBrushProperty =
            DependencyProperty.RegisterAttached("HeaderForegroundBrush", typeof(SolidColorBrush), typeof(TextBoxExtensions), new FrameworkPropertyMetadata(new BrushConverter().ConvertFromString("#FF151515") as SolidColorBrush, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// The placeholder text property
        /// </summary>
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.RegisterAttached("PlaceholderText", typeof(string), typeof(TextBoxExtensions), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// The error text property
        /// </summary>
        public static readonly DependencyProperty ErrorTextProperty =
            DependencyProperty.RegisterAttached("ErrorText", typeof(string), typeof(TextBoxExtensions), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// The placeholder foreground brush property
        /// </summary>
        public static readonly DependencyProperty PlaceholderForegroundBrushProperty =
            DependencyProperty.RegisterAttached("PlaceholderForegroundBrush", typeof(Brush), typeof(TextBoxExtensions), new FrameworkPropertyMetadata(Brushes.DimGray, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// The is edit property
        /// </summary>
        public static readonly DependencyProperty IsEditableProperty =
            DependencyProperty.RegisterAttached("IsEditable", typeof(bool), typeof(TextBoxExtensions), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// The select all on focus property
        /// </summary>
        public static readonly DependencyProperty SelectAllOnFocusProperty =
            DependencyProperty.RegisterAttached("SelectAllOnFocus", typeof(bool), typeof(TextBoxExtensions), new PropertyMetadata(false, SelectAllOnFocusChanged));

        /// <summary>
        /// The box size property
        /// </summary>
        public static readonly DependencyProperty BoxSizeProperty =
            DependencyProperty.RegisterAttached("BoxSize", typeof(ButtonSize), typeof(TextBoxExtensions), new PropertyMetadata(ButtonSize.Auto));

        /// <summary>
        /// The show error property
        /// </summary>
        public static readonly DependencyProperty ShowErrorProperty =
            DependencyProperty.RegisterAttached("ShowError", typeof(bool), typeof(TextBoxExtensions), new PropertyMetadata(false));

        /// <summary>
        /// The required property
        /// </summary>
        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.RegisterAttached("IsRequired", typeof(bool), typeof(TextBoxExtensions), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// The brand margin property
        /// </summary>
        public static readonly DependencyProperty PlaceHolderMarginProperty =
            DependencyProperty.RegisterAttached("PlaceHolderMargin", typeof(Thickness), typeof(TextBoxExtensions), new PropertyMetadata(new Thickness(16, 0, 0, 0)));

        /// <summary>
        /// Gets the brand margin.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static Thickness GetPlaceHolderMargin(DependencyObject dependencyObject)
        {
            return (Thickness)dependencyObject.GetValue(PlaceHolderMarginProperty);
        }

        /// <summary>
        /// Sets the brand margin.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="thickness">The thickness.</param>
        public static void SetPlaceHolderMargin(DependencyObject dependencyObject, Thickness thickness)
        {
            dependencyObject.SetValue(PlaceHolderMarginProperty, thickness);
        }

        /// <summary>
        /// Gets the show error.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static bool GetShowError(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(ShowErrorProperty);
        }

        /// <summary>
        /// Sets the show error.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="showError">if set to <c>true</c> [show error].</param>
        public static void SetShowError(DependencyObject dependencyObject, bool showError)
        {
            dependencyObject.SetValue(ShowErrorProperty, showError);
        }

        /// <summary>
        /// Gets the is required.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static bool GetIsRequired(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(IsRequiredProperty);
        }

        /// <summary>
        /// Sets the is required.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="isRequired">if set to <c>true</c> [is required].</param>
        /// <returns></returns>
        public static void SetIsRequired(DependencyObject dependencyObject, bool isRequired)
        {
            dependencyObject.SetValue(IsRequiredProperty, isRequired);
        }

        /// <summary>
        /// Gets the size of the box.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static ButtonSize GetBoxSize(DependencyObject dependencyObject)
        {
            return (ButtonSize)dependencyObject.GetValue(BoxSizeProperty);
        }

        /// <summary>
        /// Sets the size of the box.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="buttonSize">Size of the button.</param>
        public static void SetBoxSize(DependencyObject dependencyObject, ButtonSize buttonSize)
        {
            dependencyObject.SetValue(BoxSizeProperty, buttonSize);
        }

        /// <summary>
        /// Gets the select all on focus.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static bool GetSelectAllOnFocus(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(SelectAllOnFocusProperty);
        }

        /// <summary>
        /// Sets the select all on focus.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void SetSelectAllOnFocus(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(SelectAllOnFocusProperty, value);
        }

        /// <summary>
        /// Sets the is edit.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void SetIsEditable(DependencyObject element, bool value)
        {
            element.SetValue(IsEditableProperty, value);
        }

        /// <summary>
        /// Gets the is edit.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static bool GetIsEditable(DependencyObject element)
        {
            return (bool)element.GetValue(IsEditableProperty);
        }

        /// <summary>
        /// Sets the header.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetHeader(DependencyObject element, string value)
        {
            element.SetValue(HeaderProperty, value);
        }

        /// <summary>
        /// Gets the header.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static string GetHeader(DependencyObject element)
        {
            return (string)element.GetValue(HeaderProperty);
        }

        /// <summary>
        /// Sets the size of the header.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetHeaderSize(DependencyObject element, double value)
        {
            element.SetValue(HeaderSizeProperty, value);
        }

        /// <summary>
        /// Gets the size of the header.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static double GetHeaderSize(DependencyObject element)
        {
            return (double)element.GetValue(HeaderSizeProperty);
        }

        /// <summary>
        /// Sets the header foreground brush.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetHeaderForegroundBrush(DependencyObject element, SolidColorBrush value)
        {
            element.SetValue(HeaderForegroundBrushProperty, value);
        }

        /// <summary>
        /// Gets the header foreground brush.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static SolidColorBrush GetHeaderForegroundBrush(DependencyObject element)
        {
            return (SolidColorBrush)element.GetValue(HeaderForegroundBrushProperty);
        }

        /// <summary>
        /// Sets the placeholder text.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetPlaceholderText(DependencyObject element, string value)
        {
            element.SetValue(PlaceholderTextProperty, value);
        }

        /// <summary>
        /// Gets the error text.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static string GetErrorText(DependencyObject element)
        {
            return (string)element.GetValue(ErrorTextProperty);
        }

        /// <summary>
        /// Sets the error text.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetErrorText(DependencyObject element, string value)
        {
            element.SetValue(ErrorTextProperty, value);
        }

        /// <summary>
        /// Gets the placeholder text.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static string GetPlaceholderText(DependencyObject element)
        {
            return (string)element.GetValue(PlaceholderTextProperty);
        }

        /// <summary>
        /// Sets the placeholder foreground brush.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetPlaceholderForegroundBrush(DependencyObject element, Brush value)
        {
            element.SetValue(PlaceholderForegroundBrushProperty, value);
        }

        /// <summary>
        /// Gets the placeholder foreground brush.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static Brush GetPlaceholderForegroundBrush(DependencyObject element)
        {
            return (Brush)element.GetValue(PlaceholderForegroundBrushProperty);
        }

        /// <summary>
        /// Selects all on focus changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="NotImplementedException"></exception>
        private static void SelectAllOnFocusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as FrameworkElement;
            var newValue = e.NewValue is bool && (bool)e.NewValue;
            if(textBox != null && newValue)
            {
                textBox.GotFocus += OnTextBoxGotFocus;
                textBox.PreviewMouseDown += OnPreviewMouseDown;
            }
            else
            {
                textBox.GotFocus -= OnTextBoxGotFocus;
                textBox.PreviewMouseDown -= OnPreviewMouseDown;
            }
        }

        /// <summary>
        /// Called when [preview mouse down].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private static void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var textBox = sender as FrameworkElement;
            if(textBox != null && !textBox.IsKeyboardFocusWithin)
            {
                e.Handled = true;
                textBox.Focus();
            }
        }

        /// <summary>
        /// Called when [text box got focus].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private static void OnTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            var frameworkElement = e.OriginalSource as FrameworkElement;
            if(frameworkElement is TextBox)
            {
                (frameworkElement as TextBox).SelectAll();
            }

            if (frameworkElement is PasswordBox)
            {
                (frameworkElement as PasswordBox).SelectAll();
            }
        }
    }
}
