namespace BuildingManagementSystem.Services.Data.Registrations.InitialRegistrations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Web.ViewModels.Registrations;

    public interface IInitialRegisterService
    {
        Task<string> SetRoleAsync(string userId, int roleId);

        IEnumerable<RegisteredUsersDataModel> GetAllUsers();

        void DeleteUser(string userId);
    }
}
