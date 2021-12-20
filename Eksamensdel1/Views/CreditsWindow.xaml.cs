using System.Windows;

namespace Eksamensdel1.Views
{
    public partial class CreditsWindow : Window
    {
        public CreditsWindow()
        {
            InitializeComponent();
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}