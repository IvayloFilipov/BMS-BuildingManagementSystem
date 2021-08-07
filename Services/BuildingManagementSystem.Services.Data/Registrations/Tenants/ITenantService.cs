namespace BuildingManagementSystem.Services.Data.Registrations.Tenants
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Web.ViewModels.Properties;
    using BuildingManagementSystem.Web.ViewModels.Tenants.ManagerModules;

    public interface ITenantService
    {
        Task<int> AddTenantAsync(string firstName, string middleName, string lastName, string email, string phone, string userId);

        public IEnumerable<AllTenantsDataModel> GetAll();

        void ConfirmTenantRegitration(int tenantId);

        void RemoveTenant(int tenantId);
    }
}
