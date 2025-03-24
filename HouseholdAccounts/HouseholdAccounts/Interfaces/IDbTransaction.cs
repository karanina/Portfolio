namespace HouseholdAccounts.Interfaces
{
    public interface IDbTransaction
    {
        string Year { get; set; } //<Year, varchar(4),>
        string Month { get; set; } //<Month, varchar(15),>
        string Day { get; set; } //<Day, varchar(2),>
        string Account { get; set; } // <Account, varchar(20),>
        string AccountOwner { get; set; } //<AccountOwner, varchar(20),>
        string Payee { get; set; } //<Payee, varchar(255),>
        string Notes { get; set; } //<Notes, varchar(255),>
        int Category {  get; set; }
        string BankUniqueID { get; set; } //<BankUniqueID, varchar(20),>
        DateTime TransactionLoaded { get; set; }
        int TransactionLoadedBy { get; set; }
        DateTime TransactionUpdated { get; set; }
        int TransactionUpdatedBy { get; set; }
    }
}
