namespace BuildingManagementSystem.Web.ViewModels.Registrations
{
    using System.Collections.Generic;

    public class ShowAllUsersViewModel
    {
        public IEnumerable<RegisteredUsersDataModel> RegisteredUsers { get; set; }
    }
}
