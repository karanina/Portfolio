namespace HouseholdAccounts.DTOs
{
    public partial class UserToAddDTO
    {
        public string Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool Active { get; set; }

        public UserToAddDTO()
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