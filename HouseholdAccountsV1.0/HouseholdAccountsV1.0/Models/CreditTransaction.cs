namespace HouseholdAccountsV1._0.Models
{
    // Model for bank statement credit accounts
    public class CreditTransaction : SourceTransaction
    {
        //Date Processed,Date of Transaction,Unique Id,Tran Type,Reference,Description,Amount
        private DateOnly? dateProcessed;
        private DateOnly? dateOfTransaction;

        private string? reference;
        private string? description;
    }
}
