using System.Linq;
using ex1_the_debt_book.Models;
using ex1_the_debt_book.Services;
using ex1_the_debt_book.ViewModels;
using ImTools;
using NUnit.Framework;

namespace ex1_the_debt_book.Test.Unit
{
    public class AddDebtViewModelTest
    {
        private IDebtorStore _debtorStore;
        private AddDebtViewModel _viewModel;
        private int _debtorId;
        private int _creditorId;

        [SetUp]
        public void Setup()
        {
            _debtorStore = new DbDebtorStore();
            _debtorId = _debtorStore.AddDebtor(new Debtor(-1, "Chip"));
            _creditorId = _debtorStore.AddDebtor(new Debtor(-1, "Joakim"));
            _viewModel = new AddDebtViewModel(_debtorStore, _debtorId);
        }

        [Test]
        public void VerifyConstruction()
        {
            Assert.AreEqual(_debtorId, _viewModel.SelectedDebtor.Id);
            Assert.AreEqual("Chip", _viewModel.SelectedDebtor.Name);
            Assert.AreEqual(2, _viewModel.Debtors.Count);
        }

        [Test]
        public void AddDebt()
        {
            _viewModel.AddDebt(_creditorId, 100);

            // Check if entry in debtor is valid
            Assert.AreEqual(100, _viewModel.SelectedDebtor.TotalDebt);
            Assert.AreEqual(1, _viewModel.SelectedDebtor.Debts.Count);
            Assert.AreEqual(_creditorId, _viewModel.SelectedDebtor.Debts.First().CounterpartId);
            Assert.AreEqual(100, _viewModel.SelectedDebtor.Debts.First().DebtAmount);

            // Check if entry in creditor is valid
            Debtor creditor = _viewModel.Debtors.FindFirst(e => e.Id == _creditorId);
            Assert.AreEqual(_creditorId, creditor.Id);
            Assert.AreEqual(-100, creditor.TotalDebt);
            Assert.AreEqual(_debtorId, creditor.Debts.First().CounterpartId);
            Assert.AreEqual(-100, creditor.Debts.First().DebtAmount);
        }

        [Test]
        public void PayOffDebt()
        {
            _viewModel.AddDebt(_creditorId, 100);
            Assert.AreEqual(100, _viewModel.SelectedDebtor.Debts.First().DebtAmount);
            _viewModel.AddDebt(_creditorId, 200);
            Assert.AreEqual(300, _viewModel.SelectedDebtor.Debts.First().DebtAmount);
            _viewModel.AddDebt(_creditorId, -50);
            Assert.AreEqual(250, _viewModel.SelectedDebtor.Debts.First().DebtAmount);
            _viewModel.AddDebt(_creditorId, -250);
            Assert.AreEqual(0, _viewModel.SelectedDebtor.Debts.Count);

            Debtor creditor = _viewModel.Debtors.FindFirst(e => e.Id == _creditorId);
            Assert.AreEqual(_creditorId, creditor.Id);
            Assert.AreEqual(0, creditor.Debts.Count);
        }

        [Test]
        public void AddDebtWithNonExistingCreditor()
        {
            Assert.Throws<System.ArgumentException>(() => _viewModel.AddDebt(_creditorId + 1, 100));
        }

        [Test]
        public void AddDebtWithNonExistingDebtor()
        {
            Assert.Throws<System.ArgumentException>(() =>
                _debtorStore.AddDebtToDebtor(_creditorId + 1, _creditorId, 100));
        }
    }
}