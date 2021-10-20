using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AirCloudWPF
{
    /// <summary>
    /// Interaction logic for MultiSelectComboBox.xaml
    /// </summary>
    public partial class MultiSelectComboBox : UserControl
    {
        /// <summary>
        /// The text property
        /// </summary>
        public static readonly DependencyProperty TextProperty =
           DependencyProperty.Register("Text", typeof(string), typeof(MultiSelectComboBox), new UIPropertyMetadata(string.Empty));

        /// <summary>
        /// The default text property
        /// </summary>
        public static readonly DependencyProperty DefaultTextProperty =
            DependencyProperty.Register("DefaultText", typeof(string), typeof(MultiSelectComboBox), new UIPropertyMetadata(string.Empty));

        /// <summary>
        /// The items source property
        /// </summary>
        public static readonly DependencyProperty ItemsSourceProperty =
          DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<string>), typeof(MultiSelectComboBox), 
              new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(MultiSelectComboBox.OnItemsSourceChanged)));

        /// <summary>
        /// The selected items property
        /// </summary>
        public static readonly DependencyProperty SelectedItemsProperty =
         DependencyProperty.Register("SelectedItems", typeof(ObservableCollection<string>), typeof(MultiSelectComboBox), 
             new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(MultiSelectComboBox.OnSelectedItemsChanged)));

        /// <summary>
        /// The item checked property
        /// </summary>
        public static readonly DependencyProperty ItemCheckedProperty =
            DependencyProperty.Register("ItemChecked", typeof(ICommand), typeof(MultiSelectComboBox),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// The item UN-checked property
        /// </summary>
        public static readonly DependencyProperty ItemUnCheckedProperty =
            DependencyProperty.Register("ItemUnChecked", typeof(ICommand), typeof(MultiSelectComboBox),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(ICommand), typeof(MultiSelectComboBox), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// The items
        /// </summary>
        private ObservableCollection<ComboItem> items;

        public MultiSelectComboBox()
        {
            this.InitializeComponent();
            this.items = new ObservableCollection<ComboItem>();
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get => (string)this.GetValue(TextProperty);
            set => this.SetValue(TextProperty, value);
        }

        /// <summary>
        /// Gets or sets the default text.
        /// </summary>
        /// <value>
        /// The default text.
        /// </value>
        public string DefaultText
        {
            get => (string)this.GetValue(DefaultTextProperty);
            set => this.SetValue(DefaultTextProperty, value);
        }

        /// <summary>
        /// Gets or sets the items source.
        /// </summary>
        /// <value>
        /// The items source.
        /// </value>
        public ObservableCollection<string> ItemsSource
        {
            get => (ObservableCollection<string>)this.GetValue(ItemsSourceProperty);
            set => this.SetValue(ItemsSourceProperty, value);
        }

        /// <summary>
        /// Gets or sets the selected items.
        /// </summary>
        /// <value>
        /// The selected items.
        /// </value>
        public ObservableCollection<string> SelectedItems
        {
            get => (ObservableCollection<string>)this.GetValue(SelectedItemsProperty);
            set => this.SetValue(SelectedItemsProperty, value);
        }

        public ICommand ItemChecked
        {
            get => (ICommand)this.GetValue(ItemCheckedProperty);
            set => this.SetValue(ItemCheckedProperty, value);
        }

        public ICommand ItemUnChecked
        {
            get => (ICommand)this.GetValue(ItemUnCheckedProperty);
            set => this.SetValue(ItemUnCheckedProperty, value);
        }

        public object CommandParameter
        {
            get => (object)this.GetValue(CommandParameterProperty);
            set => this.SetValue(CommandParameterProperty, value);
        }

        /// <summary>
        /// Called when [items source changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var multiSelectComboBox = d as MultiSelectComboBox;
            RefreshComboBox(multiSelectComboBox, true);
            var action = new NotifyCollectionChangedEventHandler((o, s) =>
            {
                RefreshComboBox(multiSelectComboBox, true);
            });

            if (e.OldValue != null)
            {
                var collection = (INotifyCollectionChanged)e.OldValue;
                if (collection != null)
                {
                    collection.CollectionChanged -= action;
                }
            }

            if (e.NewValue != null)
            {
                var collection = (INotifyCollectionChanged)e.NewValue;
                if (collection != null)
                {
                    collection.CollectionChanged += action;
                }
            }
        }

        /// <summary>
        /// Called when [selected items changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var multiSelectComboBox = d as MultiSelectComboBox;
            RefreshComboBox(multiSelectComboBox);

            var action = new NotifyCollectionChangedEventHandler((o, s) =>
            {
                RefreshComboBox(multiSelectComboBox);
            });

            if(e.OldValue != null)
            {
                var collection = (INotifyCollectionChanged)e.OldValue;
                if (collection != null)
                {
                    collection.CollectionChanged -= action;
                }
            }

            if (e.NewValue != null)
            {
                var collection = (INotifyCollectionChanged)e.NewValue;
                if (collection != null)
                {
                    collection.CollectionChanged += action;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the CheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if(checkBox != null)
            {
                this.items.FirstOrDefault(x => x.Title.Equals(checkBox.Content)).IsSelected = checkBox.IsChecked.Value;
            }

            this.UpdateSelectedItems();
            this.SetText();           
        }

        /// <summary>
        /// Sets the text.
        /// </summary>
        private void SetText()
        {
            StringBuilder displayText = new StringBuilder();
            foreach (ComboItem comboItem in items)
            {
                if (comboItem.IsSelected)
                {
                    displayText.Append(comboItem.Title);
                    displayText.Append(',');
                }
            }

            this.Text = displayText.ToString().TrimEnd(new char[] { ',' });
        }

        /// <summary>
        /// Displays the in control.
        /// </summary>
        private void DisplayInControl()
        {
            this.items.Clear();
            foreach (var item in this.ItemsSource)
            {
                var comboItem = new ComboItem(item);
                this.items.Add(comboItem);
            }

            this.MultiSelectCombo.ItemsSource = this.items;
        }

        /// <summary>
        /// Selects the nodes.
        /// </summary>
        private void SelectNodes()
        {
            if (this.SelectedItems != null)
            {
                if (!this.SelectedItems.Any())
                {
                    this.items.ToList().ForEach(x => x.IsSelected = false);
                }

                foreach (var item in this.SelectedItems)
                {
                    var comboItem = this.items.FirstOrDefault(i => i.Title == item);
                    if (comboItem != null)
                    {
                        comboItem.IsSelected = true;
                    }
                }
            }
        }

        /// <summary>
        /// Updates the selected items.
        /// </summary>
        private void UpdateSelectedItems()
        {
            if(this.SelectedItems == null)
            {
                this.SelectedItems = new ObservableCollection<string>();
            }

            foreach(var item in this.items)
            {
                if (this.ItemsSource.Count > 0 && item.IsSelected && !this.SelectedItems.Contains(item.Title))
                {
                    this.SelectedItems.Add(item.Title);
                }
            }
        }

        /// <summary>
        /// Refreshes the Multi select combo-box
        /// </summary>
        /// <param name="multiSelectComboBox">The Multi select combo-box</param>
        /// <param name="refreshItemSource">The refresh item source flag</param>
        private static void RefreshComboBox(MultiSelectComboBox multiSelectComboBox, bool refreshItemSource = false)
        {
            if (multiSelectComboBox != null)
            {
                if (refreshItemSource)
                {
                    multiSelectComboBox.DisplayInControl();
                }

                multiSelectComboBox.SelectNodes();
                multiSelectComboBox.SetText();
            }
        }
    }
}
