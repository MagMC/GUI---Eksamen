using System.Windows;

namespace ex1_the_debt_book.Views
{
    public partial class DepterView : Window
    {
        public DepterView()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as AgentViewModel;
            if (vm.IsValid)
                DialogResult = true;
            else
                MessageBox.Show("Enter values for Id, codename and specialities", "Missing data");
        }
    }
}