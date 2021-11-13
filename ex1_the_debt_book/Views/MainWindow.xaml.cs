using System.Windows;
using System.Windows.Input;
using ex1_the_debt_book.ViewModels;

namespace ex1_the_debt_book.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DebtorList_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var vm = DataContext as MainWindowViewModel;
            vm.CommandOpenDebt.Execute();
        }
    }
}
