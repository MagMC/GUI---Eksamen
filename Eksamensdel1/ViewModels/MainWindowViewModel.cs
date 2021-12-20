using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using Eksamensdel1.Views;
using ImTools;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using static System.Windows.Media.ColorConverter;

namespace Eksamensdel1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        public DelegateCommand<string> CommandColor { get; }
        public MainWindowViewModel()
        {
            CommandColor = new DelegateCommand<string>(CommandColorExecute);
        }
        private void CommandColorExecute(string colorStr)
        {
            SolidColorBrush newBrush = SystemColors.WindowBrush; // Default color

            try
            {
                if (colorStr != null)
                {
                    if (colorStr != "Default")
                    {
                        var color = ConvertFromString(colorStr);
                        newBrush = new SolidColorBrush(color is Color c ? c : default);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unknown color name, default color is used", "Program error!");
            }

            Application.Current.Resources["BackgroundBrush"] = newBrush;
        }
    }
}