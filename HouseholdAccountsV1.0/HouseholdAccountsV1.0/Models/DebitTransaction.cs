namespace HouseholdAccountsV1._0.Models
{
    // Model for bank statement Debit accounts
    public class DebitTransaction : SourceTransaction
    {
        //Date,Unique Id,Tran Type,Cheque Number,Payee,Memo,Amount
        private DateOnly? date;

        private string? chequeNumber;
        private string? payee;
        private string? memo;
    }
}
