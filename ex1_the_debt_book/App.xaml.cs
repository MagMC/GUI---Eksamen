using ex1_the_debt_book.Views;
using Prism.Ioc;
using System.Windows;
using Prism.DryIoc;

namespace ex1_the_debt_book
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
            containerRegistry.Register<Services.IDebtorStore, Services.DbDebtorStore>();
        }
    }
}
