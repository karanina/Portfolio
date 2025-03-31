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

        [JsonPropertyName("transactionLoadedDate")]
        public string TransactionLoadedDateString
        {
            get => base.TransactionLoadedDateString;
            set => base.TransactionLoadedDateString = value;
        }

        [JsonPropertyName("transactionUpdatedDate")]
        public string TransactionUpdatedDateString
        {
            get => base.TransactionUpdatedDateString;
            set => base.TransactionUpdatedDateString = value;
        }
    
    }
}
