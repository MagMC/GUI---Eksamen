using System.Collections.Generic;
using ex1_the_debt_book.Models;
using Prism.Mvvm;

namespace ex1_the_debt_book.ViewModels
{
    public class AddDebtViewModel : BindableBase
    {
        private readonly Services.IDebtorStore _debtorStore;
        private readonly int _debtorId;
        public Debtor Debtor;

        public AddDebtViewModel(Services.IDebtorStore debtorStore, int debtorId)
        {
            _debtorStore = debtorStore;
            _debtorId = debtorId;
            LoadDebtor();
        }

        private void LoadDebtor()
        {
            Debtor = _debtorStore.GetAll().Find(e => e.Id == _debtorId);
        }
    }
}