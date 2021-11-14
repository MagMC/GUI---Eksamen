using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using ex1_the_debt_book.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace ex1_the_debt_book.ViewModels
{
    public class DebtViewModel : BindableBase
    {
        private readonly Services.IDebtorStore _debtorStore;
        private readonly int _debtorId;
        private Debt _selectedDebt;
        private Debtor _newCounterpart;
        private int _newDebtAmount = 0;
        private Debtor _selectedDebtor;

        public Debtor SelectedDebtor
        {
            get => _selectedDebtor;
            private set => SetProperty(ref _selectedDebtor, value);
        }

        public Debt SelectedDebt
        {
            get => _selectedDebt;
            set => SetProperty(ref _selectedDebt, value);
        }

        public Debtor NewCounterpart
        {
            get => _newCounterpart;
            set => SetProperty(ref _newCounterpart, value);
        }

        public int NewDebtAmount
        {
            get => _newDebtAmount;
            set => SetProperty(ref _newDebtAmount, value);
        }

        public ObservableCollection<Debtor> Debtors { get; } = new();

        public IEnumerable<Debtor> CounterpartDebtors
        {
            get { return Debtors.Where(d => d.Id != SelectedDebtor.Id); }
        }

        public DelegateCommand CommandAddTransaction { get; }

        public DebtViewModel(Services.IDebtorStore debtorStore, int debtorId)
        {
            CommandAddTransaction = new DelegateCommand(CommandAddTransactionExecute);
            _debtorStore = debtorStore;
            _debtorId = debtorId;
            LoadDebtors();
        }

        private void LoadDebtors()
        {
            SelectedDebtor = null;
            Debtors.Clear();
            List<Debtor> list = _debtorStore.GetAll();
            foreach (Debtor item in list)
            {
                Debtors.Add(item);
            }
            
            SelectedDebtor = list.Find(e => e.Id == _debtorId);
            foreach (var debt in SelectedDebtor.Debts)
            {
                debt.Debtors = Debtors;
            }
        }

        public void AddDebt(int counterpartId, int debtAmount)
        {
            _debtorStore.AddDebtToDebtor(_debtorId, counterpartId, debtAmount);
            LoadDebtors();
        }

        private void CommandAddTransactionExecute()
        {
            if (NewCounterpart != null)
            {
                AddDebt(NewCounterpart.Id, NewDebtAmount);
                NewCounterpart = null;
                NewDebtAmount = 0;
            }
            else
            {
                MessageBox.Show("You need a counterpart!");
            }

        }
    }
}