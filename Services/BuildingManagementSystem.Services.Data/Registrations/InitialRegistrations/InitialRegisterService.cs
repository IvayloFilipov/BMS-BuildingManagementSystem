namespace BuildingManagementSystem.Services.Data.Registrations.InitialRegistrations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Web.ViewModels.Registrations;

    public class InitialRegisterService : IInitialRegisterService
    {
        private readonly ApplicationDbContext dbContext;

        public InitialRegisterService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<RegisteredUsersDataModel> GetAllUsers()
        {
            var users = this.dbContext
                .Users
                .Select(x => new RegisteredUsersDataModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    IsRegisterConfirmed = x.IsRegisterConfirmed,
                })
                .ToList();

            return users;
        }

        public async Task<string> SetRoleAsync(string userId, int roleId)
        {
            var user = this.dbContext.Users.Where(x => x.Id == userId).FirstOrDefault();

            user.IsRegisterConfirmed = true;

            // await this.dbContext.AddAsync(user);
            await this.dbContext.SaveChangesAsync();

            return user.Id;
        }

        public void DeleteUser(string userId)
        {
            var user = this.dbContext.Users.Where(x => x.Id == userId).FirstOrDefault();

            if (user == null)
            {
                return;
            }

            user.IsDeleted = true;

            this.dbContext.SaveChanges();
        }
    }
}
