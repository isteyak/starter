using System.Windows;

namespace AirCloudWPF
{
    public static class AirCloudModalExtensions
    {
        /// <summary>
        /// Shows the specified header.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <param name="message">The message.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="buttons">The buttons.</param>
        /// <returns>The message box result</returns>
        public static MessageBoxResult Show(this AirCloudModal airCloudModal, string header, string message, 
            MessageType messageType = MessageType.Information, AirCloudModalButtons buttons = AirCloudModalButtons.OK)
        {

            var messageBoxResult = MessageBoxResult.None;

             var res = airCloudModal.ShowDialog();

            switch (buttons)
            {
                case AirCloudModalButtons.OKCancel:
                    break;
                case AirCloudModalButtons.YesNo:
                    break;
                case AirCloudModalButtons.YesNoCancel:
                    break;
                default:
                    break;
            }

            return messageBoxResult;
        }
    }

    public enum MessageType
    {
        Information,
        Error,
        Warning,
        Success
    }

    public enum AirCloudModalButtons
    {
        OK,
        OKCancel,
        YesNo,
        YesNoCancel
    }
}
