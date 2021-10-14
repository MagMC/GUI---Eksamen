using System.Collections.Generic;
using System.Linq;

namespace ex1_the_debt_book.Models
{
    public class Debtor
    {
        public readonly int Id;

        public string Name { get; set; }
        public int InitialDebt { get; set; }

        public readonly List<Debt> Debts = new();

        public int TotalDebt
        {
            get { return Debts.Sum(item => item.DebtAmount) + InitialDebt; }
        }

        public Debtor(int id = -1, string name = "")
        {
            Id = id;
            Name = name;
        }

        public void AddDebt(int counterpartId, int debtAmount)
        {
            Debt debtEntry = Debts.Find(item => item.CounterpartId == counterpartId);
            if (debtEntry == null)
            {
                Debts.Add(new Debt(counterpartId, debtAmount));
            }
            else
            {
                debtEntry.DebtAmount += debtAmount;
                if (debtEntry.DebtAmount == 0)
                {
                    Debts.Remove(debtEntry);
                }
            }
        }
    }
}