using Prism.Regions;

namespace AirCloudWPF
{
    public interface IModalWindowService
    {
        /// <summary>
        /// Shows the specified view name.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="title">The title.</param>
        /// <param name="navigationParameters">The navigation parameters.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        void Show(string viewName, string title = "", NavigationParameters navigationParameters = null, double width = 0, double height = 0);

        /// <summary>
        /// Closes the specified view name.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        void Close(string viewName);

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <returns>The navigation parameters if any</returns>
        NavigationParameters GetParameters(string viewName);
    }
}
