namespace HouseholdAccountsV1._0.Models
{
    // Parent class for bank statement attributes
    public class SourceTransaction
    {
        public string? uniqueId;
        public string? tranType;

        public double? amount;
        public string? account;
    }
}
