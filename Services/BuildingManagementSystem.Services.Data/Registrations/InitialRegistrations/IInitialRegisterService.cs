namespace BuildingManagementSystem.Services.Data.Registrations.InitialRegistrations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Web.ViewModels.Registrations;

    public interface IInitialRegisterService
    {
        Task<IEnumerable<RegisteredUsersDataModel>> GetAllUsersAsync();

        Task<string> SetRoleAsync(string userId, string roleId);

        void RemoveUser(string userId);
    }
}
