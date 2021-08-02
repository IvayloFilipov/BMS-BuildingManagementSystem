namespace BuildingManagementSystem.Web.ViewModels.Registrations
{
    using System.Collections.Generic;

    public class ShowAllUsersViewModel
    {
        public string UserId { get; set; }

        public string RoleId { get; set; }

        public IEnumerable<RegisteredUsersDataModel> RegisteredUsers { get; set; }
    }
}
