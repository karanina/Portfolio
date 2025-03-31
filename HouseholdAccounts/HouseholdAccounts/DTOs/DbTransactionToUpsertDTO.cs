using HouseholdAccounts.Abstract;
using HouseholdAccounts.Interfaces;
using HouseholdAccounts.Models;
using Microsoft.Identity.Client;
using System.Text.Json.Serialization;
using static Azure.Core.HttpHeader;
using System.Transactions;

namespace HouseholdAccounts.DTOs
{
    public partial class DbTransactionToUpsertDTO : DBTransactionBase, ICategory
    {

        public int ID { get; set; } // this is the TransactionID
        public int CategoryID { get; set; }

        // from ICategory
        public string GroupName { get; set; }
        public string CategoryName { get; set; }

        [JsonPropertyName("transactionDate")]
        public string TransactionDateString
        {
            get => base.TransactionDateString;
            set => base.TransactionDateString = value;
        }

        [JsonPropertyName("transactionLoaded")]
        public string TransactionLoadedDateString
        {
            get => base.TransactionLoadedDateString;
            set => base.TransactionLoadedDateString = value;
        }

        public DbTransactionToUpsertDTO()
        {
            if (CategoryName == null)
            {
                CategoryName = "";
            }
            if (GroupName == null)
            {
                GroupName = "";
            }
        }
    }
}