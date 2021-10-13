using System.Collections.Generic;
using System.Collections.ObjectModel;
using ex1_the_debt_book.Models;
using Prism.Mvvm;

namespace ex1_the_debt_book.ViewModels
{
    public class AddDebtViewModel : BindableBase
    {
        private readonly Services.IDebtorStore _debtorStore;
        private readonly int _debtorId;
        public Debtor SelectedDebtor { get; private set; }
        public ObservableCollection<Debtor> Debtors { get; } = new ObservableCollection<Debtor>();

        public AddDebtViewModel(Services.IDebtorStore debtorStore, int debtorId)
        {
            _debtorStore = debtorStore;
            _debtorId = debtorId;
            LoadDebtors();
        }

        private void LoadDebtors()
        {
            Debtors.Clear();
            List<Debtor> list = _debtorStore.GetAll();
            foreach (Debtor item in list)
                Debtors.Add(item);
            SelectedDebtor = list.Find(e => e.Id == _debtorId);
        }

        public void AddDebt(int counterpartId, int debtAmount)
        {
            _debtorStore.AddDebtToDebtor(_debtorId, counterpartId, debtAmount);
            LoadDebtors();
        }
    }
}