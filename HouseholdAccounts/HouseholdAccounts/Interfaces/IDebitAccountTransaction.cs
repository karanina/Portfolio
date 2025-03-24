namespace HouseholdAccounts.Interfaces
{
    public interface IDebitAccountTransaction : ITransaction
    {
        // Sample of CSS File
        // Date,        Unique Id,  Tran Type,  Cheque Number,      Payee,          Memo,                                       Amount
        //2025/02/13,   2025021301, D/D,        ,                   "PM TRANSFER",  "D/D TO 12-3216- 0217261-50 Anna Contrib",  -330.00
        string UniqueId { get; set; }
        string CheckNumber { get; set; }
        string Payee { get; set; }
        string Memo { get; set; }

        // explicit mapping as the Transaction Date has various header names.
        DateTime Date { get; set; }
        DateTime ITransaction.TransactionDate
        {
            get => Date;
            set => Date = value;
        }

    }
}
