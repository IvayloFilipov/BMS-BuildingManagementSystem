namespace BuildingManagementSystem.Services.Data.Registrations.RegisterTenant
{
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models.BuildingData;
    using BuildingManagementSystem.Web.ViewModels.Tenants;

    public class TenantService : ITenantService
    {
        private readonly ApplicationDbContext dbContext;

        public TenantService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // public async Task<int> RegisterTenantAsync(string firstName, string middleName, string lastName,  string email, string phone, int userId)
        // {
        //     var tenant = new Tenant
        //     {
        //         FirstName = firstName,
        //         MiddleName = middleName,
        //         LastName = lastName,
        //         Email = email,
        //         Phone = phone,
        //         UserId = userId.ToString(),
        //     };
        //     await this.dbContext.AddAsync(tenant);
        //     await this.dbContext.SaveChangesAsync();
        //     return tenant.Id;
        // }

        public async Task<int> RegisterTenantAsync(RegisterTenantViewModel tenant, string userId)
        {
            var currTenant = new Tenant
            {
               FirstName = tenant.FirstName,
               MiddleName = tenant.MiddleName,
               LastName = tenant.LastName,
               Email = tenant.Email,
               Phone = tenant.Phone,
               UserId = userId,
            };

            await this.dbContext.AddAsync(currTenant);

            await this.dbContext.SaveChangesAsync();

            return currTenant.Id;
        }
    }
}
