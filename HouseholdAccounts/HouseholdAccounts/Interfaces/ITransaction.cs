using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HouseholdAccounts.Interfaces
{
    public interface ITransaction
    {
        decimal Amount { get; set; }
        string TranType { get; set; }
        DateTime TransactionDate { get; set; }

    }
}
