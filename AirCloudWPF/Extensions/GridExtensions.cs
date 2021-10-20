using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AirCloudWPF
{
    public class GridExtensions
    {
        /// <summary>
        /// The button text property
        /// </summary>
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.RegisterAttached("Header", typeof(string), typeof(GridExtensions), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The hide right border property
        /// </summary>
        public static readonly DependencyProperty HideRightBorderProperty =
            DependencyProperty.RegisterAttached("HideRightBorder", typeof(bool), typeof(GridExtensions), new PropertyMetadata(false));

        /// <summary>
        /// The row span property
        /// </summary>
        public static readonly DependencyProperty RowSpanProperty =
            DependencyProperty.RegisterAttached("RowSpan", typeof(int), typeof(GridExtensions), new PropertyMetadata(1));

        /// <summary>
        /// The column span property
        /// </summary>
        public static readonly DependencyProperty ColumnSpanProperty =
            DependencyProperty.RegisterAttached("ColumnSpan", typeof(int), typeof(GridExtensions), new PropertyMetadata(1));

        /// <summary>
        /// Adds the specified number of Rows to RowDefinitions. 
        /// Default Height is Auto
        /// </summary>
        public static readonly DependencyProperty RowCountProperty =
            DependencyProperty.RegisterAttached("RowCount", typeof(int), typeof(GridExtensions), new PropertyMetadata(-1, RowCountChanged));

        /// <summary>
        /// Adds the specified number of Columns to ColumnDefinitions. 
        /// Default Width is Auto
        /// </summary>
        public static readonly DependencyProperty ColumnCountProperty =
            DependencyProperty.RegisterAttached("ColumnCount", typeof(int), typeof(GridExtensions), new PropertyMetadata(-1, ColumnCountChanged));

        /// <summary>
        /// Makes the specified Column's Width equal to Star. 
        /// Can set on multiple Columns
        /// </summary>
        public static readonly DependencyProperty StarColumnsProperty =
            DependencyProperty.RegisterAttached("StarColumns", typeof(string), typeof(GridExtensions), new PropertyMetadata(string.Empty, StarColumnsChanged));

        /// <summary>
        /// Makes the specified Row's Height equal to Star. 
        /// Can set on multiple Rows
        /// </summary>
        public static readonly DependencyProperty StarRowsProperty =
            DependencyProperty.RegisterAttached("StarRows", typeof(string), typeof(GridExtensions), new PropertyMetadata(string.Empty, StarRowsChanged));

        /// <summary>
        /// The refresh headers property
        /// </summary>
        public static readonly DependencyProperty RefreshHeadersProperty =
            DependencyProperty.RegisterAttached("RefreshHeaders", typeof(bool), typeof(GridExtensions), new PropertyMetadata(false, RefreshChanged));

        /// <summary>
        /// The command property
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(GridExtensions), new PropertyMetadata(default(ICommand)));

        /// <summary>
        /// The command parameter property
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(GridExtensions), new PropertyMetadata(default(object)));

        /// <summary>
        /// The show custom headers property
        /// </summary>
        public static readonly DependencyProperty ShowCustomHeadersProperty =
            DependencyProperty.RegisterAttached("ShowCustomHeaders", typeof(bool), typeof(GridExtensions), new PropertyMetadata(false));

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
        /// Gets the refresh headers.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns>The refresh headers</returns>
        public static bool GetRefreshHeaders(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(RefreshHeadersProperty);
        }

        /// <summary>
        /// Sets the refresh headers.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void SetRefreshHeaders(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(RefreshHeadersProperty, value);
        }

        /// <summary>
        /// Gets the row span.
        /// </summary>
        /// <param name="dependencyProperty">The dependency property.</param>
        /// <returns></returns>
        public static int GetRowSpan(DependencyObject dependencyProperty)
        {
            return (int)dependencyProperty.GetValue(RowSpanProperty);
        }

        /// <summary>
        /// Sets the row span.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="value">The value.</param>
        public static void SetRowSpan(DependencyObject dependencyObject, int value)
        {
            dependencyObject.SetValue(RowSpanProperty, value);
        }

        /// <summary>
        /// Gets the column span.
        /// </summary>
        /// <param name="dependencyProperty">The dependency property.</param>
        /// <returns></returns>
        public static int GetColumnSpan(DependencyObject dependencyProperty)
        {
            return dependencyProperty != null ? (int)dependencyProperty.GetValue(ColumnSpanProperty) : 1;
        }

        /// <summary>
        /// Sets the column span.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="value">The value.</param>
        public static void SetColumnSpan(DependencyObject dependencyObject, int value)
        {
            dependencyObject.SetValue(ColumnSpanProperty, value);
        }

        /// <summary>
        /// Gets the hide right border.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static bool GetHideRightBorder(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(HideRightBorderProperty);
        }

        /// <summary>
        /// Sets the hide right border.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void SetHideRightBorder(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(HideRightBorderProperty, value);
        }

        /// <summary>
        /// Gets the header.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns>The header</returns>
        public static string GetHeader(DependencyObject dependencyObject)
        {
            return dependencyObject != null ? (string)dependencyObject.GetValue(HeaderProperty) : string.Empty;
        }

        /// <summary>
        /// Sets the header.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="buttonText">The button text.</param>
        public static void SetHeader(DependencyObject dependencyObject, string buttonText)
        {
            dependencyObject.SetValue(HeaderProperty, buttonText);
        }

        /// <summary>
        /// Gets the show custom headers.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <returns></returns>
        public static bool GetShowCustomHeaders(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(ShowCustomHeadersProperty);
        }

        /// <summary>
        /// Sets the show custom headers.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void SetShowCustomHeaders(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(ShowCustomHeadersProperty, value);
        }

        /// <summary>
        /// Gets the row count
        /// </summary>
        /// <param name="obj">The dependency object</param>
        /// <returns>The row count</returns>
        public static int GetRowCount(DependencyObject obj)
        {
            return (int)obj.GetValue(RowCountProperty);
        }

        /// <summary>
        /// Sets the row count
        /// </summary>
        /// <param name="obj">The dependency object</param>
        /// <param name="value">The row count</param>
        public static void SetRowCount(DependencyObject obj, int value)
        {
            obj.SetValue(RowCountProperty, value);
        }

        /// <summary>
        /// Handles the row count change event
        /// </summary>
        /// <param name="obj">The dependency object</param>
        /// <param name="e">The dependency property change event arguments</param>
        // Change Event - Adds the Rows
        public static void RowCountChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid) || (int)e.NewValue < 0)
            {
                return;
            }

            Grid grid = (Grid)obj;
            grid.RowDefinitions.Clear();

            for (int i = 0; i < (int)e.NewValue; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            }

            SetStarRows(grid);
        }


        /// <summary>
        /// Gets the column count
        /// </summary>
        /// <param name="obj">The dependency object</param>
        /// <returns>The column count</returns>
        public static int GetColumnCount(DependencyObject obj)
        {
            return (int)obj.GetValue(ColumnCountProperty);
        }

        /// <summary>
        /// Sets the column count
        /// </summary>
        /// <param name="obj">The dependency object</param>
        /// <param name="value">The column count</param>
        public static void SetColumnCount(DependencyObject obj, int value)
        {
            obj.SetValue(ColumnCountProperty, value);
        }

        /// <summary>
        /// Handles the column count changes
        /// </summary>
        /// <param name="obj">The dependency object</param>
        /// <param name="e">The dependency property change event</param>
        public static void ColumnCountChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid) || (int)e.NewValue < 0)
            {
                return;
            }

            Grid grid = (Grid)obj;
            grid.ColumnDefinitions.Clear();

            for (int i = 0; i < (int)e.NewValue; i++)
            {
                grid.ColumnDefinitions.Add(
                    new ColumnDefinition() { Width = GridLength.Auto });
            }

            SetStarColumns(grid);
        }

        /// <summary>
        /// Gets the start rows
        /// </summary>
        /// <param name="obj">The dependency object</param>
        /// <returns>The start rows</returns>
        public static string GetStarRows(DependencyObject obj)
        {
            return (string)obj.GetValue(StarRowsProperty);
        }

        /// <summary>
        /// Sets the start rows
        /// </summary>
        /// <param name="obj">The dependency object</param>
        /// <param name="value">The start rows</param>
        public static void SetStarRows(DependencyObject obj, string value)
        {
            obj.SetValue(StarRowsProperty, value);
        }

        /// <summary>
        /// Sets the start rows. Makes the specific height to start
        /// </summary>
        /// <param name="obj">The dependency object</param>
        /// <param name="e">The dependency property change event</param>
        public static void StarRowsChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid) || string.IsNullOrEmpty(e.NewValue.ToString()))
            {
                return;
            }

            SetStarRows((Grid)obj);
        }

        /// <summary>
        /// Gets the start columns
        /// </summary>
        /// <param name="obj">The dependency object</param>
        /// <returns>The start columns</returns>
        public static string GetStarColumns(DependencyObject obj)
        {
            return (string)obj.GetValue(StarColumnsProperty);
        }

        /// <summary>
        /// Sets the star columns
        /// </summary>
        /// <param name="obj">The dependency object</param>
        /// <param name="value">The start columns</param>
        public static void SetStarColumns(DependencyObject obj, string value)
        {
            obj.SetValue(StarColumnsProperty, value);
        }

        /// <summary>
        /// Handles the start column changes. Makes the specified column width equals to start
        /// </summary>
        /// <param name="obj">The dependency object</param>
        /// <param name="e">The dependency property change event</param>
        public static void StarColumnsChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid) || string.IsNullOrEmpty(e.NewValue.ToString()))
            {
                return;
            }

            SetStarColumns((Grid)obj);
        }

        /// <summary>
        /// Sets the start columns to the Grid
        /// </summary>
        /// <param name="grid">The grid</param>
        private static void SetStarColumns(Grid grid)
        {
            string[] starColumns =
                GetStarColumns(grid).Split(',');

            for (int i = 0; i < grid.ColumnDefinitions.Count; i++)
            {
                grid.ColumnDefinitions[i].Width =
                        new GridLength(1, GridUnitType.Star);
                //if (starColumns.Contains(i.ToString()))
                //{
                //    grid.ColumnDefinitions[i].Width =
                //        new GridLength(1, GridUnitType.Star);
                //}
            }
        }

        /// <summary>
        /// Sets the start rows to the grid
        /// </summary>
        /// <param name="grid">The grid</param>
        private static void SetStarRows(Grid grid)
        {
            string[] starRows =
                GetStarRows(grid).Split(',');

            for (var i = 0; i < grid.RowDefinitions.Count; i++)
            {
                if (starRows.Contains(i.ToString()))
                {
                    grid.RowDefinitions[i].Height =
                        new GridLength(1, GridUnitType.Star);
                }
            }
        }

        /// <summary>
        /// Shows the custom headers handler.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        public static void ShowCustomHeadersHandler(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is DataGrid) || string.IsNullOrEmpty(e.NewValue.ToString()))
            {
                return;
            }
            var dataGrid = obj as DataGrid;
            if (dataGrid != null)
            {
                var customHeaders = dataGrid.FindChild<Grid>("HeadersGrid");
                var val = (bool)e.NewValue;
                if (!val && customHeaders != null)
                {
                    customHeaders.Visibility = Visibility.Collapsed;
                }
            }
        }

        /// <summary>
        /// Refreshes the changed.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        public static void RefreshChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is DataGrid) || string.IsNullOrEmpty(e.NewValue.ToString()))
            {
                return;
            }

            var dataGrid = obj as DataGrid;
            if(dataGrid != null)
            {
                var val = (bool)e.NewValue;
                if (val)
                {
                    dataGrid.Loaded += (s, de) => UpdateBorders(dataGrid);
                    dataGrid.AddingNewItem += (s, de) => ScrollIntoView(dataGrid);                    
                }
                else
                {
                    dataGrid.Loaded -= (s, de) => UpdateBorders(dataGrid);
                    dataGrid.AddingNewItem -= (s, de) => ScrollIntoView(dataGrid);
                }
            }
        }

        /// <summary>
        /// Updates the borders.
        /// </summary>
        /// <param name="dataGrid">The data grid.</param>
        private static void UpdateBorders(DataGrid dataGrid)
        {
            var customHeaders = dataGrid.FindChild<Grid>("HeadersGrid");
            if (customHeaders != null && customHeaders.Children.Count > 0)
            {
                var childItems = customHeaders.FindVisualChildren<TextBlock>();
                if(childItems.All(x=> string.IsNullOrWhiteSpace(x.Text)))
                {
                    customHeaders.Visibility = Visibility.Collapsed;
                }

                for (int i = 0; i < customHeaders.Children.Count; i++)
                {
                    if (i > 0)
                    {
                        var currentItem = customHeaders.Children[i];
                        var currentBorder = currentItem.FindChild<Border>("DataBorder");
                        var previousItem = customHeaders.Children[i - 1];
                        var previousBorder = previousItem.FindChild<Border>("DataBorder");

                        if (currentBorder != null && previousBorder != null)
                        {
                            var currentText = currentBorder.FindChild<TextBlock>("DataBlock");
                            var previousText = previousBorder.FindChild<TextBlock>("DataBlock");
                            if (currentText != null && previousText != null && previousText.Text.Length <= 0 && currentText.Text.Length > 0)
                            {
                                previousBorder.BorderThickness = new Thickness(0, 0, 1, 0);
                                currentBorder.BorderThickness = new Thickness(0, 0, 1, 0);
                            }
                        }
                    }
                }
            }            
        }

        /// <summary>
        /// Scrolls the into view.
        /// </summary>
        /// <param name="dataGrid">The data grid.</param>
        private static void ScrollIntoView(DataGrid dataGrid)
        { 
            if(dataGrid != null && dataGrid.Items.Count > 0)
            {
                dataGrid.ScrollIntoView(dataGrid.Items[dataGrid.Items.Count - 1]);
            }
        }

    }
}
