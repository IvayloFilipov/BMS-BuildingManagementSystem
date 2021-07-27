namespace BuildingManagementSystem.Services.Data.Registrations.RegisterTenant
{
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models.BuildingData;

    public class TenantService : ITenantService
    {
        private readonly ApplicationDbContext dbContext;

        public TenantService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> RegisterTenantAsync(string firstName, string middleName, string lastName, string email, string phone, string userId)
        {
            var currTenant = new Tenant
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                UserId = userId,
            };

            await this.dbContext.AddAsync(currTenant);

            await this.dbContext.SaveChangesAsync();

            return currTenant.Id;
        }

        public void DeleteTenant(string userId)
        {
            var currTenant = this.dbContext
                .Tenants
                .Where(x => x.UserId == userId)
                .FirstOrDefault();

            if (currTenant == null)
            {
                return;
            }

            this.dbContext.Tenants.Remove(currTenant);

            this.dbContext.SaveChanges();
        }

        public void SetTenantToRole(string tenantId)
        {
            throw new System.NotImplementedException();
        }
    }
}
