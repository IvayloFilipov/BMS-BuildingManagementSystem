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

        public InitialRegisterService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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

        public async Task<string> IsRegisterConfirmAsync(string userId, string roleId)
        {
            var selectedUser = await this.dbContext
                .Users
                .Where(x => x.Id == userId)
                .FirstOrDefaultAsync();

            var currUserId = selectedUser.Id;

            selectedUser.IsRegisterConfirmed = true;

            await this.dbContext.SaveChangesAsync();

            return currUserId;
        }

        public async Task RemoveUserAsync(string userId)
        {
            var user = await this.dbContext
                .Users
                .Where(x => x.Id == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return;
            }

            user.IsDeleted = true;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
