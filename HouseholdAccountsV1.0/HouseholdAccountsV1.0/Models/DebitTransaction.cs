namespace HouseholdAccountsV1._0.Models
{
    // Model for bank statement Debit accounts
    public class DebitTransaction : SourceTransaction
    {
        //Date,Unique Id,Tran Type,Cheque Number,Payee,Memo,Amount
        public DateOnly? date { get; set; }

        public string? chequeNumber { get; set; }
        public string? payee { get; set; }
        public string? memo { get; set; }

    }
}
