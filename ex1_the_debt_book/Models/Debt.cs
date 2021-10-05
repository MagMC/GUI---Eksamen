namespace ex1_the_debt_book.Models
{
    public class Debt
    {
        public readonly int CounterpartId;
        public int DebtAmount;

        public Debt(int counterpartId, int debtAmount)
        {
            CounterpartId = counterpartId;
            DebtAmount = debtAmount;
        }
    }
}