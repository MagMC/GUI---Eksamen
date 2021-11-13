using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using ex1_the_debt_book.Models;
using ex1_the_debt_book.Services;
using ex1_the_debt_book.Views;
using ImTools;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using static System.Windows.Media.ColorConverter;

namespace ex1_the_debt_book.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IDebtorStore _debtorStore;


        public ObservableCollection<Debtor> Debtors { get; } = new();

        private Debtor _selectedDebtor;
        private string _lastFileName;

        public Debtor SelectedDebtor
        {
            get => _selectedDebtor;
            set
            {
                if (SetProperty(ref _selectedDebtor, value))
                {
                    Debug.WriteLine(_selectedDebtor?.Name ?? "no debtor selected");
                }
            }
        }

        public DelegateCommand CommandAddDebtor { get; }
        public DelegateCommand CommandOpenDebt { get; }
        public DelegateCommand CommandNewFile { get; }
        public DelegateCommand CommandOpenFile { get; }
        public DelegateCommand CommandSaveFile { get; }
        public DelegateCommand CommandSaveFileAs { get; }
        public DelegateCommand<string> CommandColor { get; }


        public MainWindowViewModel(IDebtorStore debtorStore)
        {
            _debtorStore = debtorStore;
            LoadDebtors();

            CommandAddDebtor = new DelegateCommand(CommandAddDebtorExecute);
            CommandOpenDebt = new DelegateCommand(CommandOpenDebtExecute);
            CommandNewFile = new DelegateCommand(CommandNewFileExecute);
            CommandOpenFile = new DelegateCommand(CommandOpenFileExecute);
            CommandSaveFile = new DelegateCommand(CommandSaveFileExecute);
            CommandSaveFileAs = new DelegateCommand(CommandSaveFileAsExecute);
            CommandColor = new DelegateCommand<string>(CommandColorExecute);
        }

        public void LoadDebtors()
        {
            Debtors.Clear();
            List<Debtor> list = _debtorStore.GetAll();
            foreach (Debtor item in list)
                Debtors.Add(item);
        }

        public int AddDebtor(Debtor debtor)
        {
            int id = _debtorStore.AddDebtor(debtor);
            LoadDebtors();
            return id;
        }

        private void CommandAddDebtorExecute()
        {
            Debtor newDebtor = new Debtor();
            var vm = new DebtorViewModel(newDebtor);

            var dlg = new DebtorView
            {
                DataContext = vm
            };
            if (dlg.ShowDialog() == true)
            {
                int id = AddDebtor(newDebtor);
                SelectedDebtor = Debtors.FindFirst(e => e.Id == id);
            }
        }

        private void CommandOpenDebtExecute()
        {
            // TODO: Open dialog
            var vm = new DebtViewModel(_debtorStore, _selectedDebtor.Id);
            var dlg = new DebtView
            {
                DataContext = vm
            };
            if (dlg.ShowDialog() == true)
            {
            }
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

        private void CommandNewFileExecute()
        {
            // Simply clear everything
            _debtorStore.ClearAll();
            LoadDebtors();
        }

        private void CommandOpenFileExecute()
        {
            OpenFileDialog dlg = new();
            dlg.Filter = "Debt Book file|*.json";
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    _debtorStore.LoadFile(dlg.FileName);
                    LoadDebtors();
                    _lastFileName = dlg.FileName;
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to parse file", "Program error!");
                }
            }
        }


        private void CommandSaveFileExecute()
        {
            if (_lastFileName == null)
            {
                MessageBox.Show("Save file not set", "Program error!");
                return;
            }

            SaveFile(_lastFileName);
        }


        private void CommandSaveFileAsExecute()
        {
            SaveFileDialog dlg = new();
            dlg.Filter = "Debt Book file|*.json";
            if (dlg.ShowDialog() == true)
            {
                SaveFile(dlg.FileName);
            }
        }

        private void SaveFile(string fileName)
        {
            try
            {
                _debtorStore.SaveFile(fileName);
                _lastFileName = fileName;
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to save file", "Program error!");
            }
        }
    }
}