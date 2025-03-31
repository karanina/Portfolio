using HouseholdAccounts.Interfaces;

namespace HouseholdAccounts.Models
{
    public class Category : ICategory
    {
        public int ID { get; set; }
        public string GroupName { get; set; }
        public string CategoryName { get; set; }

        public Category()
        {
            if (GroupName == null)
            {
                GroupName = "";
            }
            if (CategoryName == null)
            {
                CategoryName = "";
            }
        }
    }
}
