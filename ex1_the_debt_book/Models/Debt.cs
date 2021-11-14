using System.Collections.ObjectModel;
using ImTools;

namespace ex1_the_debt_book.Models
{
    public class Debt
    {
        public int CounterpartId { get; }
        public int DebtAmount { get; set; }
        public ObservableCollection<Debtor> Debtors { set; private get; }

        public string CounterpartName
        {
            get { return Debtors?.FindFirst(d => d.Id == CounterpartId)?.Name; }
        }


        public Debt(int counterpartId, int debtAmount)
        {
            CounterpartId = counterpartId;
            DebtAmount = debtAmount;
        }
    }
}