using AirCloudWPF;
using Prism.Ioc;
using System.Windows;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return this.Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<object, Controls>("Controls");
            containerRegistry.RegisterSingleton<IModalWindowService, Modal>();           
        }
    }
}
