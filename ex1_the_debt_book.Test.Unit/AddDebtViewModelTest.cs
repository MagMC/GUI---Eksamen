using ex1_the_debt_book.Services;
using ex1_the_debt_book.ViewModels;
using NUnit.Framework;

namespace ex1_the_debt_book.Test.Unit
{
    public class AddDebtViewModelTest
    {
        private IDebtorStore _debtorStore;
        private AddDebtViewModel _viewModel;
        private int _debtorId;

        [SetUp]
        public void Setup()
        {
            _debtorStore = new DbDebtorStore();
            _debtorId = _debtorStore.AddDebtor("Chip");
            _viewModel = new AddDebtViewModel(_debtorStore, _debtorId);
        }

        [Test]
        public void VerifyConstruction()
        {
            Assert.AreEqual(_debtorId, _viewModel.Debtor.Id);
            Assert.AreEqual("Chip", _viewModel.Debtor.Name);
        }
    }
}