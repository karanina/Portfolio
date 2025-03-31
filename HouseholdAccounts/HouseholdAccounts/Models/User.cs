using HouseholdAccounts.Helpers;
using System.Text.Json.Serialization;

namespace HouseholdAccounts.Models
{
    public partial class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        [JsonIgnore]
        public DateTime DateCreated
        {
            get => _dateCreated;
            set => _dateCreated = value;
        }

        /// <summary>
        /// Dates will be coming in from json in a string in the yyyy-MM-dd format. This enables conversion to a date time data type.
        /// </summary>
        private DateTime _dateCreated;

        [JsonPropertyName("DateCreated")]
        public string DateCreatedString
        {
            get => DateHelper.GetDate(_dateCreated);
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _dateCreated = DateHelper.SetDate(value);
                }
            }
        }
        [JsonIgnore]
        public DateTime DateUpdated
        {
            get => _dateUpdated;
            set => _dateUpdated = value;
        }

        /// <summary>
        /// Dates will be coming in from json in a string in the yyyy-MM-dd format. This enables conversion to a date time data type.
        /// </summary>
        private DateTime _dateUpdated;

        [JsonPropertyName("DateUpdated")]
        public string DateUpdatedString
        {
            get => DateHelper.GetDate(_dateUpdated);
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _dateUpdated = DateHelper.SetDate(value);
                }
            }
        }





        public User()
        {
            if (FirstName == null)
            {
                FirstName = "";
            }
            if (LastName == null)
            {
                LastName = "";
            }
            if (Email == null)
            {
                Email = "";
            }
        }
    }
}