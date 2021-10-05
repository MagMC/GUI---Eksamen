using System.Collections.Generic;
using ex1_the_debt_book.Models;

namespace ex1_the_debt_book.Services
{
    public interface IDebtorStore
    {
        List<Debtor> GetAll();
        int AddDebtor(string name);

        void AddDebtToDebtor(int debtorId, int counterpartId, int debtAmount);
    }
}