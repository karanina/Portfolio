using HouseholdAccounts.Interfaces;

namespace HouseholdAccounts.DTOs
{
    public partial class CategoryToAddDTO
    {
        public string GroupName { get; set; }
        public string CategoryName { get; set; }

        public CategoryToAddDTO()
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