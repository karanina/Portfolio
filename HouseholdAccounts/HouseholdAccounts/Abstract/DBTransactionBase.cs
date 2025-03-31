using HouseholdAccounts.Interfaces;
using System.Globalization;
using System.Text.Json.Serialization;
using HouseholdAccounts.Helpers;

namespace HouseholdAccounts.Abstract
{
    public abstract class DBTransactionBase : ITransaction, IDbTransaction
    {
        public int AccountID { get; set; }
        public int AccountOwnerID { get; set; }
        public string Payee { get; set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }
        public int CategoryID { get; set; }
        public string TranType { get; set; }
        public string BankUniqueID { get; set; }

        [JsonIgnore] // to not interfere with the derived classes
        public DateTime TransactionDate
        {
            get => _transactionDate; 
            set => _transactionDate = value;
        }

        /// <summary>
        /// Dates will be coming in from json in a string in the yyyy-MM-dd format. This enables conversion to a date time data type.
        /// </summary>
        private DateTime _transactionDate;
        public string TransactionDateString
        {
            get => DateHelper.GetDate(_transactionDate);
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _transactionDate = DateHelper.SetDate(value);
                }
            }
        }

        [JsonIgnore] // to not interfere with the derived classes
        public DateTime TransactionLoadedDate
        {
            get => _transactionLoadedDate;
            set => _transactionLoadedDate = value;
        }

        private DateTime _transactionLoadedDate;
        public string TransactionLoadedDateString
        {
            get => DateHelper.GetDate(_transactionLoadedDate);
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _transactionLoadedDate = DateHelper.SetDate(value);
                }
            }
        }
       public int TransactionLoadedByUserID { get; set; } // a user ID

        [JsonIgnore] // to not interfere with the derived classes
        public DateTime TransactionUpdatedDate
        {
            get => _transactionUpdatedDate;
            set => _transactionUpdatedDate = value;
        }

        private DateTime _transactionUpdatedDate;
        public string TransactionUpdatedDateString
        {
            get => DateHelper.GetDate(_transactionUpdatedDate);
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _transactionUpdatedDate = DateHelper.SetDate(value);
                }
            }
        }

        public int TransactionUpdatedByUserID { get; set; } // a user ID

        public DBTransactionBase()
        {
            if (Payee == null)
            {
                Payee = "";
            }
            if (Notes == null)
            {
                Notes = "";
            }
            if (TranType == null)
            {
                TranType = "";
            }
            if (BankUniqueID == null)
            {
                BankUniqueID = "";
            }
        }
    }
}
