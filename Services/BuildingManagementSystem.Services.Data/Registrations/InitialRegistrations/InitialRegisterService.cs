namespace BuildingManagementSystem.Services.Data.Registrations.InitialRegistrations
{
    using System.Collections.Generic;
    using System.Linq;

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
    }
}
