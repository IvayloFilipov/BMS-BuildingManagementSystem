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

        public async Task<int> AddTenantAsync(string firstName, string middleName, string lastName, string email, string phone, string userId)
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

            await this.dbContext.Tenants.AddAsync(currTenant);

            await this.dbContext.SaveChangesAsync();

            return currTenant.Id;
        }

        public void RemoveTenant(string userId, bool isDeleted)
        {
            var currTenant = this.dbContext
                .Tenants
                .Where(x => x.UserId == userId && x.IsDeleted == false)
                .FirstOrDefault();

            if (currTenant == null)
            {
                return;
            }

            // this.dbContext.Tenants.Remove(currTenant);
            currTenant.IsDeleted = true;

            this.dbContext.SaveChanges();
        }

        public void SetTenantToRole(string tenantId)
        {
            throw new System.NotImplementedException();
        }
    }
}
