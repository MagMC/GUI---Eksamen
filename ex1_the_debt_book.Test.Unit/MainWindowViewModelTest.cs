using ex1_the_debt_book.Models;
using ex1_the_debt_book.Services;
using ex1_the_debt_book.ViewModels;
using NUnit.Framework;

namespace ex1_the_debt_book.Test.Unit
{
    public class MainWindowViewModelTest
    {
        private IDebtorStore _debtorStore = new DbDebtorStore();
        private MainWindowViewModel _viewModel;

        public MainWindowViewModelTest()
        {
            _viewModel = new MainWindowViewModel(_debtorStore);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoadDataFromStore()
        {
            _debtorStore.AddDebtor("Anders And"); // Add debtor to store
            Assert.AreEqual(_viewModel.Debtors.Count, 0);
            _viewModel.CommandLoad.Execute(); // Read store into view model
            Assert.AreEqual(_viewModel.Debtors.Count, 1);
        }

        [Test]
        public void WriteDataToStore()
        {
            _viewModel.CommandLoad.Execute(); // Read store into view model
            Assert.AreEqual(_viewModel.Debtors.Count, 0);
            _viewModel.Debtors.Add(new Debtor(1, "Joakim"));
            Assert.AreEqual(_viewModel.Debtors.Count, 1);
            Assert.AreEqual(_debtorStore.GetAll().Count, 1);
        }
    }
}