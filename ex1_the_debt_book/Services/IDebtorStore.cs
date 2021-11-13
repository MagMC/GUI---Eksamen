using System.Collections.Generic;
using ex1_the_debt_book.Models;

namespace ex1_the_debt_book.Services
{
    public interface IDebtorStore
    {
        List<Debtor> GetAll();
        void ClearAll();
        int AddDebtor(Debtor debtor);

        void AddDebtToDebtor(int debtorId, int counterpartId, int debtAmount);
        void LoadFile(string fileName);
        
        void SaveFile(string fileName);
    }
}