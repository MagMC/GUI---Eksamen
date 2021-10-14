using System.Windows;

namespace ex1_the_debt_book.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DebtorView : Window
    {
        public DebtorView()
        {
            InitializeComponent();
        }

        private void BtnAddPersonSave_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            
        }

        private void BtnAddPersonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
