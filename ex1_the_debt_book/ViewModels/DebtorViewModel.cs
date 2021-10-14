using ex1_the_debt_book.Models;
using Prism.Mvvm;

namespace ex1_the_debt_book.ViewModels
{
    public class DebtorViewModel : BindableBase
    {
        public Debtor Debtor { get; }

        public DebtorViewModel(Debtor debtor)
        {
            Debtor = debtor;
        }
    }
}