namespace BuildingManagementSystem.Services.Data.Registrations.InitialRegistrations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Web.ViewModels.Registrations;

    public interface IInitialRegisterService
    {
        IEnumerable<RegisteredUsersDataModel> GetAllUsers();

        Task<string> SetRoleAsync(string userId, string roleId);

        void DeleteUser(string userId);
    }
}
