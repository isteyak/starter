using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Windows;
using Unity;

namespace AirCloudWPF
{
    public class Modal : IModalWindowService
    {
        /// <summary>
        /// The unity container
        /// </summary>
        private readonly IUnityContainer unityContainer;       

        /// <summary>
        /// The modal windows
        /// </summary>
        private IDictionary<string, Tuple<AirCloudModal, NavigationParameters>> modalWindows;

        /// <summary>
        /// Initializes a new instance of the <see cref="Modal"/> class.
        /// </summary>
        /// <param name="unityContainer">The unity container.</param>
        public Modal(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
            this.modalWindows = new Dictionary<string, Tuple<AirCloudModal, NavigationParameters>>();
        }

        /// <summary>
        /// Closes the specified view name.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        public void Close(string viewName)
        {
            if (this.modalWindows.ContainsKey(viewName))
            {
                this.modalWindows[viewName].Item1?.Close();
            }
        }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <returns>
        /// The navigation parameters if any
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public NavigationParameters GetParameters(string viewName)
        {
            NavigationParameters navigationParameters = null;
            if (this.modalWindows.ContainsKey(viewName))
            {
                navigationParameters = this.modalWindows[viewName].Item2;
            }

            return navigationParameters;
        }

        /// <summary>
        /// Shows the specified view name.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="title">The title.</param>
        /// <param name="navigationParameters">The navigation parameters.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void Show(string viewName, string title = "", NavigationParameters navigationParameters = null, double width = 0, double height = 0)
        {
            if (this.modalWindows.ContainsKey(viewName))
            {
                this.modalWindows[viewName].Item1?.ShowDialog();
            }
            else
            {
                var window = new AirCloudModal
                {
                    Title = title,
                    SizeToContent = width == 0 && height == 0 ? SizeToContent.WidthAndHeight : (width > 0 && height == 0 ? SizeToContent.Height : ( height > 0 && width == 0 ? SizeToContent.Width : SizeToContent.Manual)),              
                    Tag = viewName,
                    Width = width,
                    Height = height
                };

                window.Closed += this.WindowClosed;

                this.modalWindows.Add(viewName, Tuple.Create(window, navigationParameters));
                window.Content = this.unityContainer.Resolve<object>(viewName);
                window.ShowDialog();
            }
        }

        /// <summary>
        /// Windows the closed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void WindowClosed(object sender, EventArgs e)
        {
            var window = sender as AirCloudModal;            
            var viewName = window?.Tag?.ToString() ?? string.Empty;
            if (this.modalWindows.ContainsKey(viewName))
            {
                this.modalWindows.Remove(viewName);
            }
        }
    }
}
