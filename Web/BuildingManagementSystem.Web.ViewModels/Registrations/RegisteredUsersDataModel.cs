namespace BuildingManagementSystem.Web.ViewModels.Registrations
{
    using BuildingManagementSystem.Data.Models.Enums;

    public class RegisteredUsersDataModel
    {
        // public string UserName { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsRegisterConfirmed { get; set; }

        public IdentityRole Roles { get; set; }
    }
}
