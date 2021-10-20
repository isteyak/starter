using Prism.Commands;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace AirCloudWPF
{
    public class AirCloudBox : AirCloudModal
    {
        /// <summary>
        /// The show yes no property
        /// </summary>
        public static readonly DependencyProperty ShowYesNoProperty =
            DependencyProperty.Register("ShowYesNo", typeof(bool), typeof(AirCloudBox), new PropertyMetadata(false));

        /// <summary>
        /// The show cancel property
        /// </summary>
        public static readonly DependencyProperty ShowCancelProperty =
            DependencyProperty.Register("ShowCancel", typeof(bool), typeof(AirCloudBox), new PropertyMetadata(false));

        /// <summary>
        /// The show OK property
        /// </summary>
        public static readonly DependencyProperty ShowOkProperty =
            DependencyProperty.Register("ShowOk", typeof(bool), typeof(AirCloudBox), new PropertyMetadata(false));

        /// <summary>
        /// The show proceed property
        /// </summary>
        public static readonly DependencyProperty ShowProceedProperty =
            DependencyProperty.Register("ShowProceed", typeof(bool), typeof(AirCloudBox), new PropertyMetadata(false));

        /// <summary>
        /// The show later property
        /// </summary>
        public static readonly DependencyProperty ShowLaterProperty =
            DependencyProperty.Register("ShowLater", typeof(bool), typeof(AirCloudBox), new PropertyMetadata(false));

        /// <summary>
        /// The show delete property
        /// </summary>
        public static readonly DependencyProperty ShowDeleteProperty =
            DependencyProperty.Register("ShowDelete", typeof(bool), typeof(AirCloudBox), new PropertyMetadata(false));
        
        /// <summary>
        /// The selected command property
        /// </summary>
        public static readonly DependencyProperty SelectedCommandProperty =
            DependencyProperty.Register("SelectedCommand", typeof(DelegateCommand<string>), typeof(AirCloudBox), new PropertyMetadata(null));

        /// <summary>
        /// The message property
        /// </summary>
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(AirCloudBox), new PropertyMetadata(string.Empty));

        /// <summary>
        /// The show later property
        /// </summary>
        public static readonly DependencyProperty ShowSaveProperty =
            DependencyProperty.Register("ShowSave", typeof(bool), typeof(AirCloudBox), new PropertyMetadata(false));

        /// <summary>
        /// The show delete property
        /// </summary>
        public static readonly DependencyProperty ShowDontSaveProperty =
            DependencyProperty.Register("ShowDontSave", typeof(bool), typeof(AirCloudBox), new PropertyMetadata(false));

        /// <summary>
        /// The message box result property
        /// </summary>
        public static readonly DependencyProperty MessageBoxResultProperty =
            DependencyProperty.Register("MessageBoxResult", typeof(MessageBoxResult), typeof(AirCloudBox), new PropertyMetadata(MessageBoxResult.None));

        /// <summary>
        /// The message type property
        /// </summary>
        public static readonly DependencyProperty MessageTypeProperty =
            DependencyProperty.Register("MessageType", typeof(MessageType), typeof(AirCloudBox), new PropertyMetadata(MessageType.Information));

        /// <summary>
        /// The information property
        /// </summary>
        public static readonly DependencyProperty InformationProperty =
            DependencyProperty.Register("Information", typeof(string), typeof(AirCloudBox), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Initializes a new instance of the <see cref="AirCloudBox"/> class.
        /// </summary>
        public AirCloudBox() : base()
        {
            var dic = new ResourceDictionary() { Source = new Uri("pack://application:,,,/AirCloudWPF;component/Styles/Window.xaml") };
            this.Template = dic["AirCloudBox"] as ControlTemplate;
            this.MaxWidth = 508;
            this.MinHeight = 198;
            this.MinWidth = 508;
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AirCloudBox"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        /// <param name="buttons">The buttons.</param>
        public AirCloudBox(string title = "", string message = "", MessageType type = MessageType.Information, MessageBoxButton buttons = MessageBoxButton.OK) : this()
        {
            this.Title = title;
            this.Message = message;
            this.MessageType = type;
            this.SelectedCommand = new DelegateCommand<string>(this.HandleButtonClick);

            switch (buttons)
            {
                case MessageBoxButton.OKCancel:
                    this.ShowOk = true;
                    this.ShowCancel = true;
                    break;
                case MessageBoxButton.YesNo:
                    this.ShowYesNo = true;
                    break;
                case MessageBoxButton.YesNoCancel:
                    this.ShowYesNo = true;
                    this.ShowCancel = true;
                    break;
                case MessageBoxButton.OK:
                default:
                    this.ShowOk = true;
                    break;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AirCloudBox"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="extendedMessage">The extended message.</param>
        /// <param name="type">The type.</param>
        /// <param name="buttons">The buttons.</param>
        public AirCloudBox(string title = "", string message = "", string extendedMessage = "", MessageType type = MessageType.Information, MessageBoxButton buttons = MessageBoxButton.OK) 
            : this(title, message, type, buttons)
        {
            this.Information = extendedMessage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AirCloudBox"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        /// <param name="buttons">The buttons.</param>
        public AirCloudBox(string title = "", string message = "", MessageType type = MessageType.Information, AirCloudMessageBoxButtons buttons = AirCloudMessageBoxButtons.Proceed) : this()
        {
            this.Title = title;
            this.Message = message;
            this.MessageType = type;
            this.SelectedCommand = new DelegateCommand<string>(this.HandleButtonClick);

            switch (buttons)
            {
                case AirCloudMessageBoxButtons.Proceed:
                    this.ShowProceed = true;
                    this.ShowLater = true;
                    break;
                case AirCloudMessageBoxButtons.Delete:
                    this.ShowDelete = true;
                    this.ShowCancel = true;
                    break;
                case AirCloudMessageBoxButtons.Save:
                case AirCloudMessageBoxButtons.DontSave:
                    this.ShowSave = true;
                    this.ShowDontSave = true;
                    break;
                case AirCloudMessageBoxButtons.SaveCancel:
                case AirCloudMessageBoxButtons.DontSaveCancel:
                    this.ShowSave = true;
                    this.ShowDontSave = true;
                    this.ShowCancel = true;
                    break;
                default:
                    this.ShowProceed = true;
                    break;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AirCloudBox"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="extendedMessage">The extended message.</param>
        /// <param name="type">The type.</param>
        /// <param name="buttons">The buttons.</param>
        public AirCloudBox(string title = "", string message = "", string extendedMessage = "", MessageType type = MessageType.Information, AirCloudMessageBoxButtons buttons = AirCloudMessageBoxButtons.Proceed) 
            : this(title, message, type, buttons)
        {
            this.Information = extendedMessage;
            this.MaxHeight = SystemParameters.PrimaryScreenHeight - 120;
            this.MaxWidth = SystemParameters.PrimaryScreenWidth - 120;
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show proceed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show proceed]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowProceed
        {
            get => (bool)this.GetValue(ShowProceedProperty);
            set => this.SetValue(ShowProceedProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show later].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show later]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowLater
        {
            get => (bool)this.GetValue(ShowLaterProperty);
            set => this.SetValue(ShowLaterProperty, value);
        }


        /// <summary>
        /// Gets or sets a value indicating whether [show yes no].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show yes no]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowYesNo
        {
            get => (bool)this.GetValue(ShowYesNoProperty);
            set => this.SetValue(ShowYesNoProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show OK].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show OK]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowOk
        {
            get => (bool)this.GetValue(ShowOkProperty);
            set => this.SetValue(ShowOkProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show cancel].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show cancel]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowCancel
        {
            get => (bool)this.GetValue(ShowCancelProperty);
            set => this.SetValue(ShowCancelProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show delete].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show delete]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowDelete
        {
            get => (bool)this.GetValue(ShowDeleteProperty);
            set => this.SetValue(ShowDeleteProperty, value);
        }

        public bool ShowSave
        {
            get => (bool)this.GetValue(ShowSaveProperty);
            set => this.SetValue(ShowSaveProperty, value);
        }

        public bool ShowDontSave
        {
            get => (bool)this.GetValue(ShowDontSaveProperty);
            set => this.SetValue(ShowDontSaveProperty, value);
        }

        /// <summary>
        /// Gets or sets the selected command.
        /// </summary>
        /// <value>
        /// The selected command.
        /// </value>
        public DelegateCommand<string> SelectedCommand
        {
            get => (DelegateCommand<string>)this.GetValue(SelectedCommandProperty);
            set => this.SetValue(SelectedCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message
        {
            get => (string)this.GetValue(MessageProperty);
            set => this.SetValue(MessageProperty, value);
        }

        /// <summary>
        /// Gets or sets the information.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        public string Information
        {
            get => (string)this.GetValue(InformationProperty);
            set => this.SetValue(InformationProperty, value);
        }

        /// <summary>
        /// Gets or sets the message box result.
        /// </summary>
        /// <value>
        /// The message box result.
        /// </value>
        public MessageBoxResult MessageBoxResult
        {
            get => (MessageBoxResult)this.GetValue(MessageBoxResultProperty);
            set => this.SetValue(MessageBoxResultProperty, value);
        }

        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        /// <value>
        /// The type of the message.
        /// </value>
        public MessageType MessageType
        {
            get => (MessageType)this.GetValue(MessageTypeProperty);
            set => this.SetValue(MessageTypeProperty, value);
        }

        /// <summary>
        /// Shows the specified message.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        /// <param name="buttons">The buttons.</param>
        /// <returns>The message box result</returns>
        public static MessageBoxResult Show(string title = "", string message = "", MessageType type = MessageType.Information, MessageBoxButton buttons = MessageBoxButton.OK)
        {
            var airCloudBox = new AirCloudBox(title, message, type, buttons);
            airCloudBox.ShowDialog();
            return airCloudBox.MessageBoxResult;
        }

        /// <summary>
        /// Shows the specified title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        /// <param name="buttons">The buttons.</param>
        /// <returns></returns>
        public static MessageBoxResult ShowProceedMessage(string title = "", string message = "", MessageType type = MessageType.Information, AirCloudMessageBoxButtons buttons = AirCloudMessageBoxButtons.Proceed)
        {
            var airCloudBox = new AirCloudBox(title, message, type, buttons);
            airCloudBox.ShowDialog();
            return airCloudBox.MessageBoxResult;
        }

        public static MessageBoxResult ShowResult(string title = "", string message = "", string extendedMessage = "", MessageType type = MessageType.Information, MessageBoxButton buttons = MessageBoxButton.OK)
        {
            var airCloudBox = new AirCloudBox(title, message, extendedMessage, type, buttons);
            airCloudBox.ShowDialog();
            return airCloudBox.MessageBoxResult;
        }
        /// <summary>
        /// Shows the proceed message.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="extendedMessage">The extended message.</param>
        /// <param name="type">The type.</param>
        /// <param name="buttons">The buttons.</param>
        /// <returns></returns>
        public static MessageBoxResult ShowProceedMessage(string title = "", string message = "", string extendedMessage = "", MessageType type = MessageType.Information, AirCloudMessageBoxButtons buttons = AirCloudMessageBoxButtons.Proceed)
        {
            var airCloudBox = new AirCloudBox(title, message, extendedMessage, type, buttons);
            airCloudBox.ShowDialog();
            return airCloudBox.MessageBoxResult;
        }

        /// <summary>
        /// Shows the delete message.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="extendedMessage">The extended message.</param>
        /// <param name="type">The type.</param>
        /// <param name="buttons">The buttons.</param>
        /// <returns></returns>
        public static MessageBoxResult ShowDeleteMessage(string title = "", string message = "", string extendedMessage = "", MessageType type = MessageType.Warning, AirCloudMessageBoxButtons buttons = AirCloudMessageBoxButtons.Delete)
        {
            var airCloudBox = new AirCloudBox(title, message, extendedMessage, type, buttons);
            airCloudBox.ShowDialog();
            return airCloudBox.MessageBoxResult;
        }

        /// <summary>
        /// Shows the warning.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="buttons">The buttons.</param>
        /// <returns>The message box result</returns>
        public static MessageBoxResult ShowWarning(string title = "", string message = "", MessageBoxButton buttons = MessageBoxButton.OK)
            => AirCloudBox.Show(title, message, MessageType.Warning, buttons);

        /// <summary>
        /// Shows the error.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="buttons">The buttons.</param>
        /// <returns>The message box result</returns>
        public static MessageBoxResult ShowError(string title = "", string message = "", MessageBoxButton buttons = MessageBoxButton.OK)
            => AirCloudBox.Show(title, message, MessageType.Error, buttons);

        /// <summary>
        /// Shows the success.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="buttons">The buttons.</param>
        /// <returns></returns>
        public static MessageBoxResult ShowSuccess(string title = "", string message = "", MessageBoxButton buttons = MessageBoxButton.OK)
            => AirCloudBox.Show(title, message, MessageType.Success, buttons);

        public static MessageBoxResult ShowSuccess(string title = "", string message = "", string extendedMessage = "", MessageType messageType = MessageType.Information, MessageBoxButton button = MessageBoxButton.OK)
            => AirCloudBox.ShowResult(title, message, extendedMessage, messageType, button);

        /// <summary>
        /// Shows the proceed later.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="buttons">The buttons.</param>
        /// <returns></returns>
        public static MessageBoxResult ShowProceedLater(string title = "", string message = "", MessageType messageType = MessageType.Information, AirCloudMessageBoxButtons buttons = AirCloudMessageBoxButtons.Proceed)
            => AirCloudBox.ShowProceedMessage(title, message, messageType, buttons);

        /// <summary>
        /// Shows the proceed later.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="extendedMessage">The extended message.</param>
        /// <param name="buttons">The buttons.</param>
        /// <returns></returns>
        public static MessageBoxResult ShowProceedLater(string title = "", string message = "", string extendedMessage = "", MessageType messageType = MessageType.Information, AirCloudMessageBoxButtons buttons = AirCloudMessageBoxButtons.Proceed)
            => AirCloudBox.ShowProceedMessage(title, message, extendedMessage, messageType, buttons);

        /// <summary>
        /// Show save confirmation dialog
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="buttons">The buttons.</param>
        /// <returns></returns>
        public static MessageBoxResult ShowSaveAndCancel(string title = "", string message = "", MessageType messageType = MessageType.Information, AirCloudMessageBoxButtons buttons = AirCloudMessageBoxButtons.SaveCancel)
            => AirCloudBox.ShowProceedMessage(title, message, messageType, buttons);

        /// <summary>
        /// Show save confirmation dialog
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="extendedMessage">The extended message.</param>
        /// <param name="buttons">The buttons.</param>
        /// <returns></returns>
        public static MessageBoxResult ShowSaveAndCancel(string title = "", string message = "", string extendedMessage = "", MessageType messageType = MessageType.Information, AirCloudMessageBoxButtons buttons = AirCloudMessageBoxButtons.SaveCancel)
            => AirCloudBox.ShowProceedMessage(title, message, extendedMessage, messageType, buttons);

        /// <summary>
        /// Show save confirmation dialog
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="buttons">The buttons.</param>
        /// <returns></returns>
        public static MessageBoxResult ShowSaveDialog(string title = "", string message = "", MessageType messageType = MessageType.Information, AirCloudMessageBoxButtons buttons = AirCloudMessageBoxButtons.Save)
            => AirCloudBox.ShowProceedMessage(title, message, messageType, buttons);

        /// <summary>
        /// Show save confirmation dialog
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="extendedMessage">The extended message.</param>
        /// <param name="buttons">The buttons.</param>
        /// <returns></returns>
        public static MessageBoxResult ShowSaveDialog(string title = "", string message = "", string extendedMessage = "", MessageType messageType = MessageType.Information, AirCloudMessageBoxButtons buttons = AirCloudMessageBoxButtons.Save)
            => AirCloudBox.ShowProceedMessage(title, message, extendedMessage, messageType, buttons);

        /// <summary>
        /// Shows the delete later.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="extendedMessage">The extended message.</param>
        /// <param name="buttons">The buttons.</param>
        /// <returns></returns>
        public static MessageBoxResult ShowDeleteCancel(string title = "", string message = "", string extendedMessage = "", MessageType messageType = MessageType.Warning, AirCloudMessageBoxButtons buttons = AirCloudMessageBoxButtons.Delete)
            => AirCloudBox.ShowDeleteMessage(title, message, extendedMessage, messageType, buttons);

        /// <summary>
        /// Handles the button click.
        /// </summary>
        /// <param name="buttonType">Type of the button.</param>
        private void HandleButtonClick(string buttonType)
        {
            switch (buttonType.ToUpperInvariant())
            {
                case "OK":
                case "DELETE":
                    this.MessageBoxResult = MessageBoxResult.OK;
                    break;
                case "YES":
                case "PROCEED":
                case "SAVE":
                    this.MessageBoxResult = MessageBoxResult.Yes;
                    break;
                case "NO":
                case "LATER":
                case "DONTSAVE":
                    this.MessageBoxResult = MessageBoxResult.No;
                    break;
                case "CANCEL":
                    this.MessageBoxResult = MessageBoxResult.Cancel;
                    break;
                default:
                    this.MessageBoxResult = MessageBoxResult.None;
                    break;
            }

            this.Close();
        }
    }

    public enum AirCloudMessageBoxButtons
    {
        Proceed = 5,
        Later = 6,
        Delete = 7,
        Save = 8,
        DontSave = 9,
        SaveCancel = 10,
        DontSaveCancel = 11
    }
}
