namespace HouseholdAccountsV1._0.Models
{
    // Represents a Transaction in the DB
    public class Transaction
    {
        // properties
        // sets defaults as on values thatmay be null
        public int ID { get; set; } = 0;
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string Account { get; set; } = "";
        public string AccountOwner { get; set; }
        public string Payee { get; set; } = "";
        public string Notes { get; set; } = "";
        public decimal Amount { get; set; }
        public int Category { get; set; } = 0;
        public string TranType { get; set; } = "";
        public string BankUniqueID { get; set; } = "";
        public DateTime TransactionDate { get; set; }

        public Transaction()
        {
            // Default Constructor
        }
    }
}
