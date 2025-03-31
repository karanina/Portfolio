namespace HouseholdAccounts.Interfaces
{
    public interface IDbTransaction
    {
        int AccountID { get; set; } 
        int AccountOwnerID { get; set; } 
        string Payee { get; set; } //<Payee, varchar(255),>
        string Notes { get; set; } //<Notes, varchar(255),>
        int CategoryID {  get; set; }
        string BankUniqueID { get; set; } //<BankUniqueID, varchar(20),>
        DateTime TransactionLoadedDate { get; set; }
        int TransactionLoadedByUserID { get; set; }
        DateTime TransactionUpdatedDate { get; set; }
        int TransactionUpdatedByUserID { get; set; }
    }
}
