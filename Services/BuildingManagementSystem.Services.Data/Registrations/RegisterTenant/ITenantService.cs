namespace BuildingManagementSystem.Services.Data.Registrations.RegisterTenant
{
    using System.Threading.Tasks;

    using BuildingManagementSystem.Web.ViewModels.Tenants;

    public interface ITenantService
    {
        Task<int> RegisterTenantAsync(RegisterTenantViewModel tenant, string userId);

        // Task<int> RegisterTenantAsync(string firstName, string middleName, string lastName, string email, string phone, string userId);
    }
}
