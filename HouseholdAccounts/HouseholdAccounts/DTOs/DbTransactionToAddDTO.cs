using HouseholdAccounts.Abstract;
using System.Globalization;
using System.Text.Json.Serialization;

namespace HouseholdAccounts.DTOs
{
    public partial class DbTransactionToAddDTO : DBTransactionBase
    {
        [JsonPropertyName("transactionDate")]
        public new string TransactionDateString
        {
            get => base.TransactionDateString;
            set => base.TransactionDateString = value;
        }
    }
}