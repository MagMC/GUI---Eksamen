using System.Collections.Generic;
using ex1_the_debt_book.Models;

namespace ex1_the_debt_book.Services
{
    public class DbDebtorStore : IDebtorStore
    {
        private List<Debtor> _debtors = new List<Debtor>();
        private int _debtorNextId;

        public DbDebtorStore()
        {
        }

        public List<Debtor> GetAll()
        {
            return _debtors;
        }

        public int AddDebtor(string name)
        {
            Debtor newDebtor = new Debtor(_debtorNextId, name);
            _debtors.Add(newDebtor);
            return _debtorNextId++;
        }

        public void AddDebtToDebtor(int debtorId, int counterpartId, int debtAmount)
        {
            Debtor debtorEntry = _debtors.Find(item => item.Id == debtorId);
            if (debtorEntry == null)
            {
                throw new System.ArgumentException("Debtor with id doesn't exist");
            }

            Debtor counterpartEntry = _debtors.Find(item => item.Id == counterpartId);
            if (counterpartEntry == null)
            {
                throw new System.ArgumentException("Counterpart with id doesn't exist");
            }

            debtorEntry.AddDebt(counterpartId, debtAmount);
            counterpartEntry.AddDebt(debtorId, -debtAmount);
        }
    }
}