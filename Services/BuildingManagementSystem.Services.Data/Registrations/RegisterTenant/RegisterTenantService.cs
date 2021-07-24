namespace BuildingManagementSystem.Services.Data.Registrations.RegisterTenant
{
    using BuildingManagementSystem.Data;

    public class RegisterTenantService : IRegisterTenantService
    {
        private readonly ApplicationDbContext dbContext;

        public RegisterTenantService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
