namespace BuildingManagementSystem.Services.Data.Registrations.InitialRegistrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models;
    using BuildingManagementSystem.Web.ViewModels.Registrations;
    using Microsoft.AspNetCore.Identity;

    public class InitialRegisterService : IInitialRegisterService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IServiceProvider serviceProvider;

        public InitialRegisterService(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            this.dbContext = dbContext;
            this.serviceProvider = serviceProvider;
        }

        public IEnumerable<RegisteredUsersDataModel> GetAllUsers()
        {
            var users = this.dbContext
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
                .ToList();

            return users;
        }

        public async Task<string> SetRoleAsync(string userId, string roleId)
        {

            var currUser = this.dbContext.Users.Where(x => x.Id == userId).FirstOrDefault();
            var currUserId = currUser.Id;

            currUser.IsRegisterConfirmed = true;

            // await this.dbContext.AddAsync(user);
            await this.dbContext.SaveChangesAsync();

            // dbContext.user

            return currUserId;
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
