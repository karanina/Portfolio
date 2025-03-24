using HouseholdAccounts.Abstract;

using System.Text.Json.Serialization;

namespace HouseholdAccounts.Models
{
    public partial class DbTransaction : DBTransactionBase
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

        [JsonPropertyName("transactionUpdated")]
        public string TransactionUpdatedString
        {
            get => base.TransactionUpdatedString;
            set => base.TransactionUpdatedString = value;
        }
    
    }
}
