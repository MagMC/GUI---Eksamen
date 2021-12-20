using Prism.Ioc;
using System.Windows;
using Eksamensdel1.Views;
using Prism.DryIoc;

namespace Eksamensdel1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
