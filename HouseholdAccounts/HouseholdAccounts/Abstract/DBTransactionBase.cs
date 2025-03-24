using HouseholdAccounts.Interfaces;
using System.Globalization;
using System.Text.Json.Serialization;
using HouseholdAccounts.Helpers;

namespace HouseholdAccounts.Abstract
{
    public abstract class DBTransactionBase : ITransaction, IDbTransaction
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string Account { get; set; }
        public string AccountOwner { get; set; }
        public string Payee { get; set; }
        public string Notes { get; set; }
        public decimal Amount { get; set; }
        public int Category { get; set; }
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
        public DateTime TransactionLoaded
        {
            get => _transactionLoaded;
            set => _transactionLoaded = value;
        }

        private DateTime _transactionLoaded;
        public string TransactionLoadedString
        {
            get => DateHelper.GetDate(_transactionLoaded);
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _transactionLoaded = DateHelper.SetDate(value);
                }
            }
        }
       public int TransactionLoadedBy { get; set; } // a user ID

        [JsonIgnore] // to not interfere with the derived classes
        public DateTime TransactionUpdated
        {
            get => _transactionUpdated;
            set => _transactionUpdated = value;
        }

        private DateTime _transactionUpdated;
        public string TransactionUpdatedString
        {
            get => DateHelper.GetDate(_transactionUpdated);
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _transactionUpdated = DateHelper.SetDate(value);
                }
            }
        }

        public int TransactionUpdatedBy { get; set; } // a user ID

        public DBTransactionBase()
        {
            if (Year == null)
            {
                Year = "";
            }
            if (Month == null)
            {
                Month = "";
            }
            if (Day == null)
            {
                Day = "";
            }
            if (Account == null)
            {
                Account = "";
            }
            if (AccountOwner == null)
            {
                AccountOwner = "";
            }
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
