namespace BuildingManagementSystem.Services.Data.Registrations.InitialRegistrations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Web.ViewModels.Registrations;

    public interface IInitialRegisterService
    {
        Task<IEnumerable<RegisteredUsersDataModel>> GetAllUsersAsync();

        Task<string> IsRegisterConfirmAsync(string userId, string roleId);

        Task RemoveUserAsync(string userId);
    }
}
