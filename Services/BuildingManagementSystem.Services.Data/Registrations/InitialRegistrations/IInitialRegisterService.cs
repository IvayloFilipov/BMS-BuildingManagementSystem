namespace BuildingManagementSystem.Services.Data.Registrations.InitialRegistrations
{
    using System.Collections.Generic;

    using BuildingManagementSystem.Data.Models;
    using BuildingManagementSystem.Web.ViewModels.Registrations;

    public interface IInitialRegisterService
    {
        IEnumerable<RegisteredUsersDataModel> GetAllUsers();
    }
}
