using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HouseholdAccounts.Interfaces
{
    public interface ICreditAccountTransaction : ITransaction
    {
        // Sample of CSS File
        //Date Processed,   Date of Transaction,    Unique Id,      Tran Type,  Reference,  Description,        Amount
        //2025/02/12,       2025/02/11,             2025021201,     DEBIT,      1657,       "MERCURY TAURANGA", 202.98
        string UniqueId { get; set; }
        string Reference { get; set; }
        string Description { get; set; }

        DateTime DateProcessed { get; set; }

        // explicit mapping as the Transaction Date has various header names.
        DateTime DateOfTransaction { get; set; }
        DateTime ITransaction.TransactionDate
        {
            get => DateOfTransaction;
            set => DateOfTransaction = value;
        }
    }
}
