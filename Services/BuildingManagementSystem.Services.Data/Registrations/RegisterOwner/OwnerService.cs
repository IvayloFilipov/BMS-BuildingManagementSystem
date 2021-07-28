namespace BuildingManagementSystem.Services.Data.Registrations.RegisterOwner
{
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models.BuildingData;

    public class OwnerService : IOwnerService
    {
        private readonly ApplicationDbContext dbContext;

        public OwnerService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddOwnerAsync(string firstName, string middleName, string lastName, string email, string phone)
        {
            var owner = new Owner()
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Email = email,
                Phone = phone,
            };

            await this.dbContext.Owners.AddAsync(owner);

            await this.dbContext.SaveChangesAsync();

            return owner.Id;
        }
    }
}
