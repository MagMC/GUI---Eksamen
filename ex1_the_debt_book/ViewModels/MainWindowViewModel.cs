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
        private Services.IDebtorStore _debtorStore = null;

        public MainWindowViewModel(Services.IDebtorStore debtorStore)
        {
            _debtorStore = debtorStore;
        }


        public ObservableCollection<Debtor> Debtors { get; private set; } = new ObservableCollection<Debtor>();


        private Debtor _selectedDebtor = null;

        public Debtor SelectedDebtor
        {
            get => _selectedDebtor;
            set
            {
                if (SetProperty<Debtor>(ref _selectedDebtor, value))
                {
                    Debug.WriteLine(_selectedDebtor?.Name ?? "no customer selected");
                }
            }
        }

        private void CommandLoadExecute()
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

        private void AddDebtor()
        {
            
        }
        
        private DelegateCommand _commandLoad = null;
        private DelegateCommand _commandAddDebtor = null;

        public DelegateCommand CommandLoad =>
            _commandLoad ?? (_commandLoad = new DelegateCommand(CommandLoadExecute));
        
        public DelegateCommand CommandAddDebtor =>
            _commandAddDebtor ?? (_commandAddDebtor = new DelegateCommand(CommandAddDebtorExecute));
    }
}