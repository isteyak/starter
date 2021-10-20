using System.ComponentModel;

namespace AirCloudWPF
{
    public class ComboItem : INotifyPropertyChanged
    {
        /// <summary>
        /// The title
        /// </summary>
        private string title;

        /// <summary>
        /// The is selected
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComboItem"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        public ComboItem(string title)
        {
            this.Title = title;
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get => this.title;
            set
            {
                this.title = value;
                this.NotifyPropertyChanged(nameof(this.Title));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is selected; otherwise, <c>false</c>.
        /// </value>
        public bool IsSelected
        {
            get => this.isSelected;
            set
            {
                this.isSelected = value;
                this.NotifyPropertyChanged(nameof(this.IsSelected));
            }
        }

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
