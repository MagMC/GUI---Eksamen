using System.Windows;
using System.Windows.Input;
using Eksamensdel1.ViewModels;

namespace Eksamensdel1.Views
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

        private void Credits_OnClick(object sender, RoutedEventArgs e)
        {
            var cm = new CreditsWindow();
            cm.ShowDialog();
        }
    }
}
