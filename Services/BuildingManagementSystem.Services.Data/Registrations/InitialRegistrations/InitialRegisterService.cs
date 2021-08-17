namespace BuildingManagementSystem.Services.Data.Registrations.InitialRegistrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Web.ViewModels.Registrations;
    using Microsoft.EntityFrameworkCore;

    public class InitialRegisterService : IInitialRegisterService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IServiceProvider serviceProvider;

        public InitialRegisterService(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            this.dbContext = dbContext;
            this.serviceProvider = serviceProvider;
        }

        public async Task<IEnumerable<RegisteredUsersDataModel>> GetAllUsersAsync()
        {
            var users = await this.dbContext
                .Users
                .Select(x => new RegisteredUsersDataModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    IsRegisterConfirmed = x.IsRegisterConfirmed,
                })
                .ToListAsync();

            return users;
        }

        public async Task<string> SetRoleAsync(string userId, string roleId)
        {
            var currUser = await this.dbContext
                .Users
                .Where(x => x.Id == userId)
                .FirstOrDefaultAsync();

            var currUserId = currUser.Id;

            currUser.IsRegisterConfirmed = true;

            await this.dbContext.SaveChangesAsync();

            return currUserId;
        }

        public void RemoveUser(string userId)
        {
            var user = this.dbContext
                .Users
                .Where(x => x.Id == userId)
                .FirstOrDefault();

            if (user == null)
            {
                return;
            }

            user.IsDeleted = true;

            this.dbContext.SaveChanges();
        }
    }
}
