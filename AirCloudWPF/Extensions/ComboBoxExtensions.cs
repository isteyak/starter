using System;
using System.Windows;
using System.Windows.Media;

namespace AirCloudWPF
{
    public class ComboBoxExtensions
    {
        /// <summary>
        /// The box size property
        /// </summary>
        public static readonly DependencyProperty BoxSizeProperty =
            DependencyProperty.RegisterAttached("BoxSize", typeof(ButtonSize), typeof(ComboBoxExtensions), new PropertyMetadata(ButtonSize.Large));

        /// <summary>
        /// The place holder property
        /// </summary>
        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.RegisterAttached("PlaceHolder", typeof(string), typeof(ComboBoxExtensions), new PropertyMetadata("Select"));

        /// <summary>
        /// The header size property
        /// </summary>
        public static readonly DependencyProperty HeaderSizeProperty =
            DependencyProperty.RegisterAttached("HeaderSize", typeof(double), typeof(ComboBoxExtensions), new FrameworkPropertyMetadata(12.0, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// The header foreground brush property
        /// </summary>
        public static readonly DependencyProperty HeaderForegroundBrushProperty =
            DependencyProperty.RegisterAttached("HeaderForegroundBrush", typeof(SolidColorBrush), typeof(ComboBoxExtensions), new FrameworkPropertyMetadata(new BrushConverter().ConvertFromString("#FF151515") as SolidColorBrush, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// The error text property
        /// </summary>
        public static readonly DependencyProperty ErrorTextProperty =
            DependencyProperty.RegisterAttached("ErrorText", typeof(string), typeof(ComboBoxExtensions), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// The minimum error height property
        /// </summary>
        public readonly static DependencyProperty ErrorHeightProperty =
            DependencyProperty.RegisterAttached("ErrorHeight", typeof(double), typeof(ComboBoxExtensions), new PropertyMetadata(Convert.ToDouble("12")));
        
        /// <summary>
        /// The header property
        /// </summary>
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.RegisterAttached("Header", typeof(string), typeof(ComboBoxExtensions), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// The text property
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.RegisterAttached("Text", typeof(string), typeof(ComboBoxExtensions), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Gets the place holder.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static string GetPlaceHolder(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(PlaceHolderProperty);
        }

        /// <summary>
        /// Sets the place holder.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="placeHolder">The place holder.</param>
        public static void SetPlaceHolder(DependencyObject dependencyObject, string placeHolder)
        {
            dependencyObject.SetValue(PlaceHolderProperty, placeHolder);
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
        }/// <summary>
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
        /// Sets the height of the error.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetErrorHeight(DependencyObject element, double value)
        {
            element.SetValue(ErrorHeightProperty, value);
        }

        /// <summary>
        /// Gets the height of the error.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static double GetErrorHeight(DependencyObject element)
        {
            return (double)element.GetValue(ErrorHeightProperty);
        }

        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetText(DependencyObject element, string value)
        {
            element.SetValue(TextProperty, value);
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static string GetText(DependencyObject element)
        {
            return (string)element.GetValue(TextProperty);
        }
    }
}
