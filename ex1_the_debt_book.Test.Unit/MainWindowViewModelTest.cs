using System.Linq;
using ex1_the_debt_book.Models;
using ex1_the_debt_book.Services;
using ex1_the_debt_book.ViewModels;
using NUnit.Framework;

namespace ex1_the_debt_book.Test.Unit
{
    public class MainWindowViewModelTest
    {
        private IDebtorStore _debtorStore;
        private MainWindowViewModel _viewModel;

        [SetUp]
        public void Setup()
        {
            _debtorStore = new DbDebtorStore();
            _viewModel = new MainWindowViewModel(_debtorStore);
        }

        [Test]
        public void LoadDataFromStore()
        {
            _debtorStore.AddDebtor(new Debtor(-1, "Anders And")); // Add debtor to store
            Assert.AreEqual(0, _viewModel.Debtors.Count);
            _viewModel.LoadDebtors(); // Read store into view model
            Assert.AreEqual(1, _viewModel.Debtors.Count);
        }

        [Test]
        public void AddDebtorToStore()
        {
            Assert.AreEqual(0, _viewModel.Debtors.Count);
            int id = _viewModel.AddDebtor(new Debtor(-1, "Joakim"));
            Assert.AreEqual(1, _debtorStore.GetAll().Count);
            Assert.AreEqual(1, _viewModel.Debtors.Count);
            Debtor joakimDebtor = _viewModel.Debtors.First();
            Assert.AreEqual(id, joakimDebtor.Id);
            Assert.AreEqual("Joakim", joakimDebtor.Name);
            Assert.AreEqual(0, joakimDebtor.TotalDebt);
        }

        [Test]
        public void SetSelectedDebtor()
        {
            _viewModel.AddDebtor(new Debtor(-1, "Joakim"));
            Debtor joakimDebtor = _viewModel.Debtors.First();
            Assert.AreEqual(null, _viewModel.SelectedDebtor);
            _viewModel.SelectedDebtor = joakimDebtor;
            Assert.AreEqual(joakimDebtor, _viewModel.SelectedDebtor);
        }
    }
}