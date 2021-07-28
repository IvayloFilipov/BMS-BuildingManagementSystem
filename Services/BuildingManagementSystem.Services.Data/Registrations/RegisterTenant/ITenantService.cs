namespace BuildingManagementSystem.Services.Data.Registrations.RegisterTenant
{
    using System.Threading.Tasks;

    public interface ITenantService
    {
        Task<int> AddTenantAsync(string firstName, string middleName, string lastName, string email, string phone, string userId);

        void RemoveTenant(string userId, bool isDeleted);

        void SetTenantToRole(string tenantId);
    }
}
