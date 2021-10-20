using System.Windows;

namespace AirCloudWPF
{
    /// <summary>
    /// Defines a class for windows extensions
    /// </summary>
    /// <seealso cref="DependencyObject" />
    public class WindowExtensions : DependencyObject
    {
        /// <summary>
        /// The user menu property
        /// </summary>
        public static readonly DependencyProperty UserMenuProperty =
            DependencyProperty.RegisterAttached("UserMenu", typeof(FrameworkElement), typeof(WindowExtensions), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// The side menu property
        /// </summary>
        public static readonly DependencyProperty SideMenuProperty =
            DependencyProperty.RegisterAttached("SideMenu", typeof(FrameworkElement), typeof(WindowExtensions), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// The side bar items property
        /// </summary>
        public static readonly DependencyProperty SideBarItemsProperty =
            DependencyProperty.RegisterAttached("SideBarItems", typeof(FrameworkElement), typeof(WindowExtensions), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// The project name property
        /// </summary>
        public static readonly DependencyProperty ProjectNameProperty =
            DependencyProperty.RegisterAttached("ProjectName", typeof(string), typeof(WindowExtensions), new PropertyMetadata(null));

        /// <summary>
        /// The brand property
        /// </summary>
        public static readonly DependencyProperty BrandProperty =
            DependencyProperty.RegisterAttached("Brand", typeof(string), typeof(WindowExtensions), new PropertyMetadata(null));

        /// <summary>
        /// The caption property
        /// </summary>
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.RegisterAttached("Caption", typeof(string), typeof(WindowExtensions), new PropertyMetadata(null));

        /// <summary>
        /// The brand margin property
        /// </summary>
        public static readonly DependencyProperty BrandMarginProperty =
            DependencyProperty.RegisterAttached("BrandMargin", typeof(Thickness), typeof(WindowExtensions), new PropertyMetadata(new Thickness(0, 0, 0, 0)));

        /// <summary>
        /// The menu visibility property
        /// </summary>
        public static readonly DependencyProperty MenuVisibilityProperty =
            DependencyProperty.RegisterAttached("MenuVisibility", typeof(bool), typeof(WindowExtensions), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Gets the menu visibility.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static bool GetMenuVisibility(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(MenuVisibilityProperty);
        }

        /// <summary>
        /// Sets the menu visibility.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="menuVisibility">if set to <c>true</c> [menu visibility].</param>
        public static void SetMenuVisibility(DependencyObject dependencyObject, bool menuVisibility)
        {
            dependencyObject.SetValue(MenuVisibilityProperty, menuVisibility);
        }

        /// <summary>
        /// Gets the brand margin.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static Thickness GetBrandMargin(DependencyObject dependencyObject)
        {
            return (Thickness)dependencyObject.GetValue(BrandMarginProperty);
        }

        /// <summary>
        /// Sets the brand margin.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="thickness">The thickness.</param>
        public static void SetBrandMargin(DependencyObject dependencyObject, Thickness thickness)
        {
            dependencyObject.SetValue(BrandMarginProperty, thickness);
        }

        /// <summary>
        /// Gets the user menu.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static FrameworkElement GetUserMenu(DependencyObject dependencyObject)
        {
            return (FrameworkElement)dependencyObject.GetValue(UserMenuProperty);
        }

        /// <summary>
        /// Sets the user menu.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="frameworkElement">The framework element.</param>
        public static void SetUserMenu(DependencyObject dependencyObject, FrameworkElement frameworkElement)
        {
            dependencyObject.SetValue(UserMenuProperty, frameworkElement);
        }

        /// <summary>
        /// Gets the side menu.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static FrameworkElement GetSideMenu(DependencyObject dependencyObject)
        {
            return (FrameworkElement)dependencyObject.GetValue(SideMenuProperty);
        }

        /// <summary>
        /// Sets the side menu.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="frameworkElement">The framework element.</param>
        public static void SetSideMenu(DependencyObject dependencyObject, FrameworkElement frameworkElement)
        {
            dependencyObject.SetValue(SideMenuProperty, frameworkElement);
        }

        /// <summary>
        /// Gets the side bar items.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static FrameworkElement GetSideBarItems(DependencyObject dependencyObject)
        {
            return (FrameworkElement)dependencyObject.GetValue(SideBarItemsProperty);
        }

        /// <summary>
        /// Sets the side bar items.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="frameworkElement">The framework element.</param>
        public static void SetSideBarItems(DependencyObject dependencyObject, FrameworkElement frameworkElement)
        {
            dependencyObject.SetValue(SideBarItemsProperty, frameworkElement);
        }

        /// <summary>
        /// Gets the name of the project.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static string GetProjectName(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(ProjectNameProperty);
        }

        /// <summary>
        /// Sets the name of the project.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="projectName">Name of the project.</param>
        public static void SetProjectName(DependencyObject dependencyObject, string projectName)
        {
            dependencyObject.SetValue(ProjectNameProperty, projectName);
        }

        /// <summary>
        /// Gets the brand.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static string GetBrand(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(BrandProperty);
        }

        /// <summary>
        /// Sets the brand.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="projectName">Name of the project.</param>
        public static void SetBrand(DependencyObject dependencyObject, string projectName)
        {
            dependencyObject.SetValue(BrandProperty, projectName);
        }

        /// <summary>
        /// Gets the caption.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static string GetCaption(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(CaptionProperty);
        }

        /// <summary>
        /// Sets the caption.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="projectName">Name of the project.</param>
        public static void SetCaption(DependencyObject dependencyObject, string projectName)
        {
            dependencyObject.SetValue(CaptionProperty, projectName);
        }
    }
}
