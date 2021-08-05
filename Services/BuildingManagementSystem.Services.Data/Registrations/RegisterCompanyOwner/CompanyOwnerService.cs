namespace BuildingManagementSystem.Services.Data.Registrations.RegisterCompanyOwner
{
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models.BuildingData;

    public class CompanyOwnerService : ICompanyOwnerService
    {
        private readonly ApplicationDbContext dbContext;

        public CompanyOwnerService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddCompanyOwnerAsync(string companyName, string uic, string companyOwnerFirstName, string companyOwnerLastName, string email, string phone, string userId)
        {
            var companyOwner = new CompanyOwner()
            {
                CompanyName = companyName,
                UIC = uic,
                CompanyOwnerFirstName = companyOwnerFirstName,
                CompanyOwnerLastName = companyOwnerLastName,
                Email = email,
                Phone = phone,
                UserId = userId,
            };

            await this.dbContext.CompanyOwners.AddAsync(companyOwner);

            await this.dbContext.SaveChangesAsync();

            return companyOwner.Id;
        }
    }
}
