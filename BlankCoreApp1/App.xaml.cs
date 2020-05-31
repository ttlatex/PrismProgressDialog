using Prism.Ioc;
using BlankCoreApp1.Views;
using System.Windows;
using Prism.Regions;
using System.Windows.Navigation;
using Prism.Modularity;
using Module1;

namespace BlankCoreApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<Module1Module>();
        }
    }
}
