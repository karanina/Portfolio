using HouseholdAccounts.Abstract;
using HouseholdAccounts.Interfaces;
using System.Text.Json.Serialization;

namespace HouseholdAccounts.DTOs
{
    public partial class DbTransactionToEditDTO : DBTransactionBase
    {
        public int ID { get; set; }

        [JsonPropertyName("transactionDate")]
        public string TransactionDateString
        {
            get => base.TransactionDateString;
            set => base.TransactionDateString = value;
        }

        [JsonPropertyName("transactionLoaded")]
        public string TransactionLoadedString
        {
            get => base.TransactionLoadedString;
            set => base.TransactionLoadedString = value;
        }
    }
}