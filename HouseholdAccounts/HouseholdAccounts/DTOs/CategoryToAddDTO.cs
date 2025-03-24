using HouseholdAccounts.Interfaces;

namespace HouseholdAccounts.DTOs
{
    public partial class CategoryToAddDTO
    {
        public string Name { get; set; }
        public string Item { get; set; }

        public CategoryToAddDTO()
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