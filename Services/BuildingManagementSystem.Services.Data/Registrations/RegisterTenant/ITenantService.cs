namespace BuildingManagementSystem.Services.Data.Registrations.RegisterTenant
{
    using System.Threading.Tasks;

    public interface ITenantService
    {
        Task<int> RegisterTenantAsync(string firstName, string middleName, string lastName, string email, string phone, string userId);

        void DeleteTenant(string userId);

        void SetTenantToRole(string tenantId);
    }
}
