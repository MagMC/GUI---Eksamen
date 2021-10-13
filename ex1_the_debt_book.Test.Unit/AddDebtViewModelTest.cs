using ex1_the_debt_book.Services;
using ex1_the_debt_book.ViewModels;
using NUnit.Framework;

namespace ex1_the_debt_book.Test.Unit
{
    public class AddDebtViewModelTest
    {
        private IDebtorStore _debtorStore;
        private AddDebtViewModel _viewModel;

        [SetUp]
        public void Setup()
        {
            _debtorStore = new DbDebtorStore();
            int id = _debtorStore.AddDebtor("Chip");
            _viewModel = new AddDebtViewModel(_debtorStore, id);
        }

        [Test]
        public void LoadDataFromStore()
        {
        }
    }
}