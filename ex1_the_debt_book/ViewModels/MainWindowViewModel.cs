using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ex1_the_debt_book.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace ex1_the_debt_book.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly Services.IDebtorStore _debtorStore;

        public MainWindowViewModel(Services.IDebtorStore debtorStore)
        {
            _debtorStore = debtorStore;
            LoadDebtors();
        }


        public ObservableCollection<Debtor> Debtors { get; } = new ObservableCollection<Debtor>();


        private Debtor _selectedDebtor;

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

        public void LoadDebtors()
        {
            Debtors.Clear();
            List<Debtor> list = _debtorStore.GetAll();
            foreach (Debtor item in list)
                Debtors.Add(item);
        }

        private void CommandAddDebtorExecute()
        {
            // TODO: Open dialog
        }

        private void CommandAddDebtExecute()
        {
            // TODO: Open dialog
        }

        public int AddDebtor(string name)
        {
            int id = _debtorStore.AddDebtor(name);
            LoadDebtors();
            return id;
        }

        private DelegateCommand _commandAddDebtor;
        private DelegateCommand _commandAddDebt;

        public DelegateCommand CommandAddDebtor =>
            _commandAddDebtor ?? (_commandAddDebtor = new DelegateCommand(CommandAddDebtorExecute));

        public DelegateCommand CommandAddDebt =>
            _commandAddDebt ?? (_commandAddDebt = new DelegateCommand(CommandAddDebtExecute));
    }
}