using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace AirCloudWPF
{
    /// <summary>
    /// Defines button extensions.
    /// </summary>
    public class ButtonExtensions : DependencyObject
    {
        /// <summary>
        /// The button type property.
        /// </summary>
        public static readonly DependencyProperty ButtonTypeProperty =
            DependencyProperty.RegisterAttached("ButtonType", typeof(ButtonType), typeof(ButtonExtensions), new PropertyMetadata(ButtonType.Primary));

        /// <summary>
        /// The button size property
        /// </summary>
        public static readonly DependencyProperty ButtonSizeProperty =
            DependencyProperty.RegisterAttached("ButtonSize", typeof(ButtonSize), typeof(ButtonExtensions), new PropertyMetadata(ButtonSize.Large));

        /// <summary>
        /// The button text property
        /// </summary>
        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.RegisterAttached("ButtonText", typeof(string), typeof(ButtonExtensions), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The notification property
        /// </summary>
        public static readonly DependencyProperty HasUpdateProperty =
            DependencyProperty.RegisterAttached("HasUpdate", typeof(bool), typeof(ButtonExtensions), new PropertyMetadata(false));

        /// <summary>
        /// The ribbon content property
        /// </summary>
        public static readonly DependencyProperty RibbonContentProperty =
            DependencyProperty.RegisterAttached("RibbonContent", typeof(object), typeof(ButtonExtensions), new PropertyMetadata(null));

        /// <summary>
        /// The icon property
        /// </summary>
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(string), typeof(ButtonExtensions), new PropertyMetadata(null));

        /// <summary>
        /// The icon color property
        /// </summary>
        public static readonly DependencyProperty IconColorProperty =
            DependencyProperty.RegisterAttached("IconColor", typeof(SolidColorBrush), typeof(ButtonExtensions), new PropertyMetadata(default(SolidColorBrush)));

        /// <summary>
        /// The error count property
        /// </summary>
        public static readonly DependencyProperty ErrorCountProperty =
            DependencyProperty.RegisterAttached("ErrorCount", typeof(int), typeof(ButtonExtensions), new PropertyMetadata(default(int)));

        /// <summary>
        /// The icon position property
        /// </summary>
        public static readonly DependencyProperty IconPositionProperty =
            DependencyProperty.RegisterAttached("IconPosition", typeof(IconPosition), typeof(ButtonExtensions), new PropertyMetadata(IconPosition.Right));

        /// <summary>
        /// The count property
        /// </summary>
        public static readonly DependencyProperty CountProperty =
            DependencyProperty.RegisterAttached("Count", typeof(int), typeof(ButtonExtensions), new PropertyMetadata(0));

        /// <summary>
        /// The count visibility property
        /// </summary>
        public static readonly DependencyProperty CountVisibilityProperty =
            DependencyProperty.RegisterAttached("CountVisibility", typeof(bool), typeof(ButtonExtensions), new PropertyMetadata(false));

        /// <summary>
        /// The enabled property
        /// </summary>
        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.RegisterAttached("Enabled", typeof(bool), typeof(ButtonExtensions), new PropertyMetadata(true));

        /// <summary>
        /// The command property
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(ButtonExtensions), new PropertyMetadata(default(ICommand)));

        /// <summary>
        /// The command parameter property
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(ButtonExtensions), new PropertyMetadata(default(object)));

        /// <summary>
        /// The CheckBox background property
        /// </summary>
        public static readonly DependencyProperty CheckBoxBackgroundProperty =
            DependencyProperty.RegisterAttached("CheckBoxBackground", typeof(SolidColorBrush), typeof(ButtonExtensions), new FrameworkPropertyMetadata(Brushes.Transparent, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static ICommand GetCommand(DependencyObject dependencyObject)
        {
            return (ICommand)dependencyObject.GetValue(CommandProperty);
        }

        /// <summary>
        /// Sets the command.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="command">The command.</param>
        public static void SetCommand(DependencyObject dependencyObject, ICommand command)
        {
            dependencyObject.SetValue(CommandProperty, command);
        }

        /// <summary>
        /// Gets the command parameter.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static object GetCommandParameter(DependencyObject dependencyObject)
        {
            return dependencyObject.GetValue(CommandParameterProperty);
        }

        /// <summary>
        /// Sets the command parameter.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="commandParameter">The command parameter.</param>
        public static void SetCommandParameter(DependencyObject dependencyObject, object commandParameter)
        {
            dependencyObject.SetValue(CommandParameterProperty, commandParameter);
        }

        /// <summary>
        /// Gets the count visibility.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static bool GetCountVisibility(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(CountVisibilityProperty);
        }

        /// <summary>
        /// Sets the count visibility.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="countVisibility">if set to <c>true</c> [count visibility].</param>
        public static void SetCountVisibility(DependencyObject dependencyObject, bool countVisibility)
        {
            dependencyObject.SetValue(CountVisibilityProperty, countVisibility);
        }

        /// <summary>
        /// Gets the enabled.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static bool GetEnabled(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(EnabledProperty);
        }

        /// <summary>
        /// Sets the enabled.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        public static void SetEnabled(DependencyObject dependencyObject, bool enabled)
        {
            dependencyObject.SetValue(EnabledProperty, enabled);
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static int GetCount(DependencyObject dependencyObject)
        {
            return (int)dependencyObject.GetValue(CountProperty);
        }

        /// <summary>
        /// Sets the count.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="count">The count.</param>
        public static void SetCount(DependencyObject dependencyObject, int count)
        {
            dependencyObject.SetValue(CountProperty, count);
        }

        /// <summary>
        /// Gets the icon position.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static IconPosition GetIconPosition(DependencyObject dependencyObject)
        {
            return (IconPosition)dependencyObject.GetValue(IconPositionProperty);
        }

        /// <summary>
        /// Sets the icon position.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="iconPosition">The icon position.</param>
        public static void SetIconPosition(DependencyObject dependencyObject, IconPosition iconPosition)
        {
            dependencyObject.SetValue(IconPositionProperty, iconPosition);
        }

        /// <summary>
        /// Gets the error count.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static int GetErrorCount(DependencyObject dependencyObject)
        {
            return (int)dependencyObject.GetValue(ErrorCountProperty);
        }

        /// <summary>
        /// Sets the error count.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="errorCount">The error count.</param>
        public static void SetErrorCount(DependencyObject dependencyObject, int errorCount)
        {
            dependencyObject.SetValue(ErrorCountProperty, errorCount);
        }

        /// <summary>
        /// Gets the color of the icon.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static SolidColorBrush GetIconColor(DependencyObject dependencyObject)
        {
            return (SolidColorBrush)dependencyObject.GetValue(IconColorProperty);
        }

        /// <summary>
        /// Sets the color of the icon.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="solidColorBrush">The solid color brush.</param>
        public static void SetIconColor(DependencyObject dependencyObject, SolidColorBrush solidColorBrush)
        {
            dependencyObject.SetValue(IconColorProperty, solidColorBrush);
        }

        /// <summary>
        /// Gets the icon.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static string GetIcon(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(IconProperty);
        }

        /// <summary>
        /// Sets the icon.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="icon">The icon.</param>
        public static void SetIcon(DependencyObject dependencyObject, string icon)
        {
            dependencyObject.SetValue(IconProperty, icon);
        }

        /// <summary>
        /// Gets the content of the ribbon.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static object GetRibbonContent(DependencyObject dependencyObject)
        {
            return (object)dependencyObject.GetValue(RibbonContentProperty);
        }

        /// <summary>
        /// Sets the content of the ribbon.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="content">The content.</param>
        public static void SetRibbonContent(DependencyObject dependencyObject, object content)
        {
            dependencyObject.SetValue(RibbonContentProperty, content);
        }

        /// <summary>
        /// Gets the type of the button.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static ButtonType GetButtonType(DependencyObject dependencyObject)
        {
            return (ButtonType)dependencyObject.GetValue(ButtonTypeProperty);
        }

        /// <summary>
        /// Sets the type of the button.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="buttonType">Type of the button.</param>
        public static void SetButtonType(DependencyObject dependencyObject, ButtonType buttonType)
        {
            dependencyObject.SetValue(ButtonTypeProperty, buttonType);
        }

        /// <summary>
        /// Gets the size of the button.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static ButtonSize GetButtonSize(DependencyObject dependencyObject)
        {
            return (ButtonSize)dependencyObject.GetValue(ButtonSizeProperty);
        }

        /// <summary>
        /// Sets the size of the button.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="buttonSize">Size of the button.</param>
        public static void SetButtonSize(DependencyObject dependencyObject, ButtonSize buttonSize)
        {
            dependencyObject.SetValue(ButtonSizeProperty, buttonSize);
        }

        /// <summary>
        /// Gets the button text.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns>The button text</returns>
        public static string GetButtonText(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(ButtonTextProperty);
        }

        /// <summary>
        /// Sets the button text.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="buttonText">The button text.</param>
        public static void SetButtonText(DependencyObject dependencyObject, string buttonText)
        {
            dependencyObject.SetValue(ButtonTextProperty, buttonText);
        }

        /// <summary>
        /// Gets the button text.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns>The button text</returns>
        public static bool GetHasUpdate(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(HasUpdateProperty);
        }

        /// <summary>
        /// Sets the button text.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="buttonText">The button text.</param>
        public static void SetHasUpdate(DependencyObject dependencyObject, bool notification)
        {
            dependencyObject.SetValue(HasUpdateProperty, notification);
        }

        /// <summary>
        /// Sets the CheckBox background.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetCheckBoxBackground(DependencyObject element, SolidColorBrush value)
        {
            element.SetValue(CheckBoxBackgroundProperty, value);
        }

        /// <summary>
        /// Gets the CheckBox background.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static SolidColorBrush GetCheckBoxBackground(DependencyObject element)
        {
            return (SolidColorBrush)element.GetValue(CheckBoxBackgroundProperty);
        }
    }
}
