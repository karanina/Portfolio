using HouseholdAccounts.Interfaces;

namespace HouseholdAccounts.Models
{
    public class Category : ICategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Item { get; set; }

        public Category()
        {
            if (Name == null)
            {
                Name = "";
            }
            if (Item == null)
            {
                Item = "";
            }
        }
    }
}
